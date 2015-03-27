using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectory.Entity
{
    public enum EMoveType
    {
        Walk,
        Car,
        Bus,
        Subway,
        Unknown
    }

    public class CEntityMove
    {
        /// <summary>
        /// 移动方式
        /// </summary>
        public EMoveType Type { get; set; }

        /// <summary>
        /// 移动路径
        /// </summary>
        public String ReleventRoad { get; set; }

        /// <summary>
        /// 开始采样点
        /// </summary>
        public CEntitySample BeginSample { get; set; }

        /// <summary>
        /// 最后一个采样点
        /// </summary>
        public CEntitySample EndSample { get; set; }

        /// <summary>
        /// 移动时长
        /// </summary>
        public TimeSpan Span { get; set; }

    }
}
