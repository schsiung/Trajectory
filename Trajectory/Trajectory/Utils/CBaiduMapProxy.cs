using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;
using Newtonsoft.Json;

using Trajectory.Entity;
namespace Trajectory.Utils
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]  
    public class CBaiduMapProxy
    {
        public delegate void StatusInfoEventHandler(object sender, CStatusInfoEventArgs e);//委托签名
        public event StatusInfoEventHandler SetStatusInfo; //out


        #region 单件模式
        private static CBaiduMapProxy m_sInstance;   //实例指针
        private CBaiduMapProxy()
        {
            Brouser = new WebBrowser();
            
            string str_url = Application.StartupPath + "\\BaiduMapInterface.html";
            Uri url = new Uri(str_url);
            Brouser.Url = url;
            Brouser.ObjectForScripting = this;
        }
        public static CBaiduMapProxy Instance
        {
            get { return GetInstance(); }
        }
        public static CBaiduMapProxy GetInstance()
        {
            if (m_sInstance == null)
            {
                m_sInstance = new CBaiduMapProxy();
            }
            return m_sInstance;
        }
        #endregion ///<单件模式

        public WebBrowser Brouser { get; set; }
        public CEntityTrajectory Trajectory { get; set; }

        public void GetSemanticMain()
        {
            Brouser.Document.InvokeScript("GetSemanticInfoMain");
        }

        public void DrawTrajectoryMain()
        {
            Brouser.Document.InvokeScript("DrawTrajectoryMain");
        }
        /// <summary>
        /// 返回当前轨迹中的采样点数
        /// </summary>
        /// <returns></returns>
        public int getPointNumber()
        {
            return Trajectory.m_listSamples.Count;
        }

        public double GetLng(int index)
        {
            return Trajectory.m_listSamples[index].Longtitude;
        }
        public double GetLat(int index)
        {
            return Trajectory.m_listSamples[index].Latitude;
        }

        public void SetlngAndlatStrip(object lng, object lat)
        {
            if (SetStatusInfo != null)
            {
                CStatusInfoEventArgs e = new CStatusInfoEventArgs();
                e.info = "当前坐标：" + lng.ToString() + "," + lat.ToString();
                e.lng = lng;
                e.lat = lat;
                SetStatusInfo(this, e);
            }
        }

        /// <summary>
        /// 设置查询信息
        /// </summary>
        /// <param name="json_obj">json序列化后的GeocoderResult 对象</param>
        /// 实例：{"point":{"lng":116.387983,"lat":39.927942},"address":"北京市西城区府右街3号","addressComponents":{"streetNumber":"3号","street":"府右街","district":"西城区","city":"北京市","province":"北京市"},"surroundingPois":[{"title":"北京市自忠小学分校","uid":"39d43f82796acc86a8059d28","point":{"lng":116.388028,"lat":39.928296},"city":"北京市","xi":"教育培训","type":0,"address":"北京市西城区府右街1号","postcode":null,"phoneNumber":null,"dt":["教育培训"]}],"business":"西四,金融街,阜成门"}
        /// <param name="index">GPS采样点在轨迹中的位置</param>
        /// 由于异步调用，index与采样点次序不一致，故采用查询的办法进行匹配
        public void SetLocalInfo(object JsonData, int index)
        {
            string jsonText = JsonData as string;
            Debug.WriteLine(jsonText);

            //CEntityGeocoderResult mGeocoderResult = new CEntityGeocoderResult();
            CEntityGeocoderResult mGeocoderResult = (CEntityGeocoderResult)JsonConvert.DeserializeObject(jsonText, typeof(CEntityGeocoderResult));

            //Trajectory.m_listSamples[index].GeocoderResult = mGeocoderResult;
            for (int i = 0; i < Trajectory.m_listSamples.Count; i++)
            {
                if ( (Trajectory.m_listSamples[i].Latitude==mGeocoderResult.Point.Lat)
                    && (Trajectory.m_listSamples[i].Longtitude == mGeocoderResult.Point.Lng))
                {
                    Trajectory.m_listSamples[i].GeocoderResult = mGeocoderResult;
                    break;
                }
            }
        }



//         public List<object> DeSerialize<T>(string jsonStr)
//         {
//             List<object> list = new List<object>();
//             JsonTextParser jtp = new JsonTextParser();
//             JsonArrayCollection jac = jtp.Parse(jsonStr) as JsonArrayCollection;
//             T o = Activator.CreateInstance<T>();
//             foreach (JsonObjectCollection joc in jac)
//             {
// 
//                 using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(joc.ToString())))
//                 {
//                     DataContractJsonSerializer serializer = new DataContractJsonSerializer(o.GetType());
//                     list.Add((T)serializer.ReadObject(ms));
//                 }
//             }
//             return list;
//         }

    }
}
