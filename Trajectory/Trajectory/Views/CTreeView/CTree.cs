using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trajectory.Utils;
using Trajectory.Entity;
using Trajectory.DataMgr;
namespace Trajectory.Views
{
    public class CTree : TreeView
    {
        #region 单例模式
        private static CTree instance;
        public static CTree Instance
        {
            get
            {
                return instance;
            }
        }
        #endregion

        #region 构造函数
        static CTree()
        {
            if (instance == null)
            {
                instance = new CTree();
            }
        }
        private CTree()
            : base()
        {
            //  修改TreeView样式
            this.ShowLines = true;
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("宋体", 12);
            this.Dock = DockStyle.Fill;
            //  加载图片资源列表
            this.ImageList = CImageList.GetImageList();
        }
        #endregion

        public void LoadTree()
        {
            if (instance.Nodes.Count > 0)
                instance.Nodes.Clear();
            InitTrajectory();
            int firstLevelNodeCount = GetNodeCount(false);
            for (int i = 0; i < firstLevelNodeCount; i++)
            {
                instance.Nodes[i].Expand();
            }
        }

        #region 树形控件添加结点
        /// <summary>
        /// 初始化系统设置结点
        /// </summary>
        private void InitSystem()
        {
            var sysNode = BuildTreeNode(CTreeType.RootNode);  //添加用户一级节点
            sysNode.Nodes.Add(BuildTreeNode(CTreeType.UserNode));//  添加单个用户二级节点
            sysNode.Nodes.Add(BuildTreeNode(CTreeType.TrajectoryNode));//  添加单条轨迹三级节点

            instance.Nodes.Add(sysNode);
        }
        /// <summary>
        /// 初始化分中心、站点信息
        /// </summary>
        private void InitTrajectory()
        {
            //  初始化一级节点，根节点
            var nodeRoot = BuildTreeNode(CTreeType.RootNode);
            var m_listUser = CDBDataMgr.GetInstance().GetAllUser();
            if (m_listUser==null)
            {
                return;
            }
            foreach (var user in m_listUser)
            {
                var nodeUser = BuildTreeNode(CTreeType.UserNode, user);
                
                var m_listTrajectory = user.m_listTrajectory;
                if (m_listTrajectory==null)
                {
                    continue;
                }
                foreach (var trajectory in m_listTrajectory)
                {
                    //  初始化三级节点，轨迹结点
                    var nodeTrajectory = BuildTreeNode(CTreeType.TrajectoryNode, trajectory);
                    nodeUser.Nodes.Add(nodeTrajectory);
                }
                nodeRoot.Nodes.Add(nodeUser);
            }
            instance.Nodes.Add(nodeRoot);
 
        }
        #endregion

        private CTreeNode BuildTreeNode(CTreeType treeType, object obj = null)
        {
            return BuildTreeNodeMap[treeType](obj);
        }

        /// <summary>
        /// 结点类型和生成结点方法的Map
        ///     根据节点类型，快速查找构建结点的方法
        /// </summary>
        private Dictionary<CTreeType, BuildTreeNodeDelegate> BuildTreeNodeMap = new Dictionary<CTreeType, BuildTreeNodeDelegate>()
        {
            { CTreeType.RootNode, new BuildTreeNodeDelegate( CBuildTreeNodeHelper.BuildRootNode)  },
            { CTreeType.UserNode, new BuildTreeNodeDelegate( CBuildTreeNodeHelper.BuildUserNode)  },
            { CTreeType.TrajectoryNode, new BuildTreeNodeDelegate( CBuildTreeNodeHelper.BuildTrajectoryNode)  },
        };

        private delegate CTreeNode BuildTreeNodeDelegate(object obj);

        /// <summary>
        /// 树形控件结点定义
        /// </summary>
        internal class CBuildTreeNodeHelper
        {
            /// <summary>
            /// 系统设置结点
            /// </summary>
            public static CTreeNode BuildRootNode(object obj)
            {
                var node = new CTreeNode("根节点", CTreeType.RootNode);
                node.SetImageIndex(0);
                return node;
            }
            /// <summary>
            /// 用户结点
            /// </summary>
            public static CTreeNode BuildUserNode(object obj)
            {
                var user = obj as CEntityUser;
                var node = new CTreeNode("用户"+user.Name, CTreeType.UserNode,user.Name);
                node.SetImageIndex(1);
                return node;
            }
            /// <summary>
            /// 轨迹结点
            /// </summary>
            /// <param name="subcenter"></param>
            /// <returns></returns>
            public static CTreeNode BuildTrajectoryNode(object obj)
            {
                var trajectory = obj as CEntityTrajectory;
                var node = new CTreeNode(trajectory.Name, CTreeType.TrajectoryNode, trajectory.Name);
                node.SetImageIndex(2);
                return node;
            }
        }
    }
}
