using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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


        public void ExportSemanticMain(CEntityTrajectory traj, string uid)
        {
            if (!traj.bInMemory)
            {
                MessageBox.Show("请先查询轨迹的语义信息");
                return;
            }
            string filename = uid+"_"+traj.Name.Substring(0, traj.Name.Length-4) + ".info";
            string path = Application.StartupPath + "\\" + filename;
            FileStream fs = new FileStream(path, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            for (int i = 0; i < traj.m_listSamples.Count; i++)
            {
                double lng = traj.m_listSamples[i].Longtitude;
                double lat = traj.m_listSamples[i].Latitude;
                string addr = traj.m_listSamples[i].GeocoderResult !=null ? traj.m_listSamples[i].GeocoderResult.Address:"NULL";
                string poi = "NULL";
                if (traj.m_listSamples[i].GeocoderResult !=null  
                    &&traj.m_listSamples[i].GeocoderResult.SurroundingPOIS !=null
                    && traj.m_listSamples[i].GeocoderResult.SurroundingPOIS.Count>0)
                {
                    poi = traj.m_listSamples[i].GeocoderResult.SurroundingPOIS[0].Title;
                }
                string dt_str = traj.m_listSamples[i].RecvTime.ToString();
                string msg = String.Format("序号：{0}；时间：{1}； 经纬度：（{2}，{3}）；地址：{4}；POI：{5}", i, dt_str, lng, lat, addr, poi);
                sw.WriteLine(msg);
            }
            sw.Flush();
            sw.Close();
            fs.Close();
        }

    }
}
