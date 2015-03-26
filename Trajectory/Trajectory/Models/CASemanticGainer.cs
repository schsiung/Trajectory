using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trajectory.Entity;
using Trajectory.Utils;

namespace Trajectory.Models
{
    public class CASemanticGainer
    {
        public void ObtainSemanticMain(CEntityTrajectory traj)
        {
            //如果轨迹不在内存中，则从磁盘上读入数据
            if (!traj.bInMemory)
            {
                traj.ReadDataFromDisk();
            }
            CBaiduMapProxy.Instance.Trajectory = traj;
            CBaiduMapProxy.Instance.GetSemanticMain();

        }
    }
}
