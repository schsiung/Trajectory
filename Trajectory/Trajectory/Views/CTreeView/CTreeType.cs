using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectory.Views
{
        /// <summary>
        /// 树形控件节点类型
        /// </summary>
        public enum CTreeType
        {
            RootNode, //一级用户节点
            UserNode,    //单个用户节点
            TrajectoryNode //单个轨迹节点
        }
}
