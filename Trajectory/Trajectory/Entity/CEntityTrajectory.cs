using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

using Trajectory.Utils;

namespace Trajectory.Entity
{
    public class CEntityTrajectory
    {
        #region PROPERTY
        /// <summary>
        /// 轨迹ID
        /// </summary>
        public string TrajectoryID { get; set; }

        /// <summary>
        ///  轨迹名字
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///  备注
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// 采样点
        /// </summary>
        public List<CEntitySample> m_listSamples;

        /// <summary>
        /// 轨迹文件存放路径
        /// </summary>
        public string fullPathName;

        /// <summary>
        /// 是否已读入到内存
        /// </summary>
        public bool bInMemory;


        #endregion


        public CEntityTrajectory()
        {
            m_listSamples = null;
            bInMemory = false;
        }


        public void ReadDataFromDisk()
        {
            if (bInMemory)
            { //已经在内存中
                return;
            }
            m_listSamples = new List<CEntitySample>();
            try
            {
                #region 读文件
                FileStream fs = new FileStream(this.fullPathName, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                String curLine =string.Empty;
                for (int i = 0; i <= 6 && curLine != null; i++)
                {
                    curLine = sr.ReadLine();
                }               
                while( !String.IsNullOrEmpty(curLine)  )
                {
                    CEntitySample loc = GenerateLocationSample(curLine);
                    if (loc ==null)
                    {
                        break;
                    }

                    m_listSamples.Add(loc);
                    curLine = sr.ReadLine();
                }
                #endregion
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            if (m_listSamples!=null && m_listSamples.Count>0)
            {
                bInMemory = true;
            }
        }


        /// <summary>
        /// 根据文件行获得采样点
        /// </summary>
        /// <param name="str">文件行字符串</param>
        /// <returns></returns>
        private CEntitySample GenerateLocationSample(string str)
        {
            try
            {
	            String[] segsf = str.Split(CSpecialChars.COMMA_CHAR);
	            double latf = Double.Parse(segsf[0]);
	            double lngf = Double.Parse(segsf[1]);
	            double field3 = Double.Parse(segsf[2]);
	            double atdf = Double.Parse(segsf[3]);
	            double daysFrom=Double.Parse(segsf[4]);
	            string date = segsf[5];
	            string time = segsf[6];
	            return new CEntitySample(latf,lngf,field3,atdf,daysFrom,date,time);
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 轨迹间的比较，待完成
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            int result = 0;
            try
            {
                CEntityTrajectory trajectory = obj as CEntityTrajectory;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            return result;
        }



        public double CalcMeanDistWithNextKPoints(int pos, int k)
        {
            if ( (pos+k) >= m_listSamples.Count)
            {
                k = m_listSamples.Count - pos-1;
                if (k == 0)
                {//当前点已经是最后一个采样点
                    return CStopHelper.DISTZERO;
                }
                return CalcMeanDistWithNextKPoints(pos,k);
            }
            double sum_dist = 0;
            double count = 0;
            for (int i = 1; i <= k; i++ )
            {
                if (CheckTimeThreshold(m_listSamples[pos],m_listSamples[pos+i]))
                {
                    ++count;
                    sum_dist += CalcSampleDist(m_listSamples[pos], m_listSamples[pos + i]);
                }
                else
                {
                    break;
                }
            }
            if (count==0)
            {
                return  CStopHelper.DISTINFINITY;
            }
            else
            {
                return sum_dist / count;
            }
        }

        public bool CheckTimeThreshold(CEntitySample pSample, CEntitySample nSample)
        {
            TimeSpan span = nSample.RecvTime - pSample.RecvTime;
            return span.TotalSeconds < CStopHelper.Intrpt_threshold;
        }

        public double CalcSampleDist(CEntitySample pSample, CEntitySample nSample)
        {
            return CSpatialUtil.GetDistance(pSample.Latitude, pSample.Longtitude, nSample.Latitude, nSample.Longtitude);
        }
    }
}
