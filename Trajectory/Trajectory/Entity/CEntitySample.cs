using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectory.Entity
{
    /// <summary>
    /// 轨迹里面的一条采样点记录
    /// 39.906631,116.385564,0,492,40097.5864583333,2009-10-11,14:04:30
    /// </summary>
    public class CEntitySample
    {
        public double Latitude { get; set; }  //纬度
        public double Longtitude { get; set; } //经度
        public double FieldThree { get; set; } //未使用
        public double Altitude { get; set; }   //高度 -777 if invalid
        public double DaysFrom { get; set; }  //经过天数 12/30/1899
        public string Date { get; set; }  // Date as a string.
        public string Time { get; set; }  //Time as a string.
        public DateTime RecvTime { get; set; } //采集时间


        public bool BIsValid { get; set; } //数据是否可用

        //public string Address { get; set; }
        public CEntityGeocoderResult GeocoderResult { get; set; }




        public CEntitySample(double lat = 0, double lng = 0, double field3 = 0, double atd = 0, double daysFrom = 0, string date=null, string time=null)
        {
            Latitude = lat;
            Longtitude = lng;
            FieldThree = field3;
            Altitude = atd;
            DaysFrom = daysFrom;
            Date = date;
            Time = time;
            if ( (!String.IsNullOrEmpty(Date) ) && (! String.IsNullOrEmpty(Time))   )
            {
                //如果日期和时间都不为空，则初始化采集时间
                String dt_strf = Date + " " + Time;
                RecvTime = DateTime.Parse(dt_strf);
                BIsValid = true;
            }
            else
            {
                RecvTime = DateTime.MinValue;
                BIsValid = false;
            }
        }


    }
}
