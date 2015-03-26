using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trajectory.Entity;
using Trajectory.Views;
using Trajectory.DataMgr;
using Trajectory.Models;
namespace Trajectory.Controls
{
    public class CMainFormAndCTreeBridage
    {
        public static MainWindow m_refMainForm;                  //主窗体
        private static ContextMenuStrip cmsClickRoute;
        public static void Instance_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

         public static void NodeMouseClickRouter(object sender, TreeNodeMouseClickEventArgs e)
         {
             if (!  (e.Button == MouseButtons.Right   &&  (e.Node as CTreeNode).Type ==CTreeType.TrajectoryNode ) )
                 return;
             CTree.Instance.SelectedNode = (e.Node as CTreeNode);
             InitCMS((e.Node as CTreeNode).Type);
             cmsClickRoute.Show(CTree.Instance,e.X, e.Y);
         }


         /// <summary>
         /// 当用户选中三级节点时，初始化鼠标右键菜单
         /// </summary>
         /// <param name="nodetype"></param>
         private static  void InitCMS(CTreeType nodetype)
         {
             cmsClickRoute = new ContextMenuStrip();
             if (nodetype == CTreeType.TrajectoryNode)
             {
                 ToolStripMenuItem MI_FindStop = new ToolStripMenuItem("识别停留点");
                 MI_FindStop.Click += MI_FindStop_Click;
                 cmsClickRoute.Items.Add(MI_FindStop);

                 ToolStripMenuItem MI_ObtainSemantic = new ToolStripMenuItem("查询语义信息");
                 MI_ObtainSemantic.Click += MI_ObtainSemantic_Click;
                 cmsClickRoute.Items.Add(MI_ObtainSemantic);

                 ToolStripMenuItem MI_DrawMap = new ToolStripMenuItem("在地图中显示");
                 MI_DrawMap.Click += MI_DrawMap_Click;
                 cmsClickRoute.Items.Add(MI_DrawMap);
                 ToolStripMenuItem MI_AddComparison = new ToolStripMenuItem("加入轨迹对比");
                 MI_AddComparison.Click += MI_AddComparison_Click;
                 cmsClickRoute.Items.Add(MI_AddComparison);
             }
             else 
             {
             }
         }

         private static void MI_FindStop_Click(object sender, EventArgs e)
         {
             CTreeNode target_node = (CTreeNode) CTree.Instance.SelectedNode;
             CTreeNode userNode = (CTreeNode)CTree.Instance.SelectedNode.Parent;
             CEntityTrajectory traj = CDBDataMgr.Instance.GetTrajectory(userNode.ID, target_node.ID);
             CAStopFinder mStopFinder = new CAStopFinder();
             mStopFinder.FindStopMain(traj);
         }
         private static void MI_ObtainSemantic_Click(object sender, EventArgs e)
         {
             CTreeNode target_node = (CTreeNode)CTree.Instance.SelectedNode;
             CTreeNode userNode = (CTreeNode)CTree.Instance.SelectedNode.Parent;
             CEntityTrajectory traj = CDBDataMgr.Instance.GetTrajectory(userNode.ID, target_node.ID);
             CASemanticGainer mSemanticGainer = new CASemanticGainer();
             mSemanticGainer.ObtainSemanticMain(traj);
         }

         private static void MI_DrawMap_Click(object sender, EventArgs e)
         {
             CTreeNode target_node = (CTreeNode)CTree.Instance.SelectedNode;
             CTreeNode userNode = (CTreeNode)CTree.Instance.SelectedNode.Parent;
             CEntityTrajectory traj = CDBDataMgr.Instance.GetTrajectory(userNode.ID, target_node.ID);
             CATrajectoryDrawer mTrajectoryDrawer = new CATrajectoryDrawer();
             mTrajectoryDrawer.DrawTrajectoryMain(traj);
         }
         private static void MI_AddComparison_Click(object sender, EventArgs e)
         {
             
         }

    }
}
