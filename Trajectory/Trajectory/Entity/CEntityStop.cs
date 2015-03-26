using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectory.Entity
{
    /// <summary>
    /// 停留类型枚举
    /// </summary>
    public enum EStopType
    {
        StartPoint, //起始点
        Stay,   //途中停留
        EndPoint //终点
    }

    public class CEntityStop
    {
        /// <summary>
        /// 停留类型
        /// </summary>
        public EStopType Type { get; set; } 

        /// <summary>
        /// 停留的POI
        /// </summary>
        public String ReleventPOI { get; set; }

        /// <summary>
        /// 开始采样点
        /// </summary>
        public CEntitySample BeginSample { get; set; }

        /// <summary>
        /// 最后一个采样点
        /// </summary>
        public CEntitySample EndSample { get; set; }

        /// <summary>
        /// 停留时长
        /// </summary>
        public TimeSpan Span { get; set; }

        /// <summary>
        /// 停留点数
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 点集的欧式中心
        /// </summary>
        public double StopCenterLat { get; set; }
        public double StopCenterLng { get; set; }
    }
}
