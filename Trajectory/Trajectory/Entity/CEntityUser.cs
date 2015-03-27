using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectory.Entity
{
    public class CEntityUser
    {
        #region PROPERTY
        /// <summary>
        /// 用户ID
        /// </summary>
        public string ID { get; set; }

        /// <summary>
        ///  用户名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  备注
        /// </summary>
        public string Comment { get; set; }

        public List<CEntityTrajectory> m_listTrajectory;
        #endregion
        public CEntityUser ()
        {
            m_listTrajectory = new List<CEntityTrajectory>();
        }
    }
}
