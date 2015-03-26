using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectory.Entity
{
    public class CEntityPoint
    {
        public double Lng { get; set; }
        public double Lat { get; set; }
    }

    public class CEntityAddressComponent
    {
        public string StreetNumber { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
    }

    public enum EPOIType 
    {
        BMAP_POI_TYPE_NORMAL=0, //一般位置点
        BMAP_POI_TYPE_BUSSTOP=1, //公交车站位置点
        BMAP_POI_TYPE_SUBSTOP=2, //地铁车站位置点
    }

    public class CEntityLocalResultPOI
    {
        public string Title { get; set; }
        public CEntityPoint Point { get; set; }
        public string URL { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string PostCode { get; set; }
        public EPOIType Type { get; set; }
        public bool IsAccurate { get; set; }
        public string Province { get; set; }
        public List<String> Tags { get; set; }
        public string DetailURL { get; set; }

        //实际补充字段
        public string UID { get; set; }
        public string XI { get; set; }  //实例："旅游景点"
        public List<string> DT { get; set; } //实例：["旅游景点"]； 估计就是Tags字段
    }

    public class CEntityGeocoderResult
    {
        public CEntityPoint Point { get; set; }
        public string Address { get; set; }
        public CEntityAddressComponent AddressComponents { get; set; }
        public List<CEntityLocalResultPOI> SurroundingPOIS { get; set; }
        public string Business { get; set; }
    }
}
