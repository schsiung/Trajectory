using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using Trajectory.Entity;

namespace Trajectory.Models
{
    /// <summary>
    /// 用于发现和识别轨迹中的停留点
    /// </summary>
    public class CAStopFinder
    {
        public List<CEntityStop> m_listStops;

        public void FindStopMain(CEntityTrajectory traj)
        {
            //如果轨迹不在内存中，则从磁盘上读入数据
            if (! traj.bInMemory)
            {
                traj.ReadDataFromDisk();
            }
            m_listStops = new List<CEntityStop>();
            int beginIndex=0;
            CEntityStop mStop = FindNextSingleStop(traj,beginIndex);
            
            while (mStop!=null )
            {
                m_listStops.Add(mStop);
                beginIndex = beginIndex +mStop.Count+CStopHelper.KValue;
                mStop = FindNextSingleStop(traj, beginIndex);
            }
            Debug.WriteLine("\n\n\n**********Sample Count in total: {0} *************", traj.m_listSamples.Count);
            Debug.WriteLine("**********Stop Count in total: {0} *************\n\n\n", m_listStops.Count);
        }

        /// <summary>
        /// 返回指定位置开始的第一个停留
        /// </summary>
        /// <param name="traj"></param>
        /// <param name="beginIndex"></param>
        /// <returns></returns>
        public CEntityStop FindNextSingleStop(CEntityTrajectory traj, int beginIndex=0)
        {
            while (beginIndex<traj.m_listSamples.Count)
            {
	            CEntityStop mStop = new CEntityStop();
	
	            mStop.BeginSample = traj.m_listSamples[beginIndex];
	            int lastIndex = FindLastSampleInStop(traj, beginIndex);
	            mStop.EndSample = traj.m_listSamples[lastIndex];
	            mStop.Span = traj.m_listSamples[lastIndex].RecvTime - traj.m_listSamples[beginIndex].RecvTime;
	
	            //计算停留的中心和相关POI
	            int count = lastIndex - beginIndex + 1;
	            double sum_lat = 0, sum_lng = 0;
	            for (int i = beginIndex; i <= lastIndex; ++i)
	            {
	                sum_lat += traj.m_listSamples[lastIndex].Latitude;
	                sum_lng += traj.m_listSamples[lastIndex].Longtitude;
	            }
	            mStop.StopCenterLat = sum_lat / count;
	            mStop.StopCenterLng = sum_lng / count;
                
                mStop.ReleventPOI = QueryPOIByLocation(mStop.StopCenterLat, mStop.StopCenterLng);
	
	            //判断停留所属类型
	            if (beginIndex==0)
	            {
	                mStop.Type = EStopType.StartPoint;
	            }
	            else if (lastIndex==traj.m_listSamples.Count-1)
	            {
	                mStop.Type = EStopType.EndPoint;
	            }
	            else
	            {
	                mStop.Type = EStopType.Stay;
	            }
	            //除开始和结束外，所有停留都必须超过时间阈值
	            if (mStop.Type == EStopType.StartPoint || mStop.Type == EStopType.EndPoint
	                || mStop.Span.TotalSeconds > CStopHelper.stay_duration_threshold)
	            {
                    Debug.WriteLine("Sample Points Count in stop: {0}. ", count);
                    mStop.Count = count;
	                return mStop;
	            }

                //更新beginIndex
                beginIndex = lastIndex + 1;
            }
            return null;   
        }


        /// <summary>
        /// 找到目标轨迹指定位置开始的Stop中的最后一个采样点的位置
        /// </summary>
        /// <param name="traj">目标轨迹</param>
        /// <param name="pos">起始位置</param>
        /// <returns></returns>
        public  int FindLastSampleInStop(CEntityTrajectory traj, int pos)
        {
            int i=pos;
            while(i < traj.m_listSamples.Count)
            {
                double dist = traj.CalcMeanDistWithNextKPoints(i, CStopHelper.KValue);
                
                //如果相邻点间的移动距离大于阈值，或是采样发生间断，就把当前点作为停留的最后一个采样返回
                if (dist>  CStopHelper.dist_threshold)
                {//
                    break;
                }
                if ( i+1 == traj.m_listSamples.Count )
                {
                    break;
                }
                TimeSpan span = traj.m_listSamples[i + 1].RecvTime - traj.m_listSamples[i].RecvTime;
                if (span.TotalSeconds>=CStopHelper.Intrpt_threshold)
                {
                    break;
                }

                ++i;
            }

            //校正最后一个
            if (i==traj.m_listSamples.Count)
            {
                --i;
            }
            return i;
        }


        /// <summary>
        /// 根据经纬度查询相关POI信息
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <returns></returns>
        public string QueryPOIByLocation(double lat, double lng)
        {
            return "UNKNOWN";
        }


        public CEntityStop FindSingleMove(CEntityTrajectory traj, int beginIndex=0)
        {
            return null;
        }

        public  int FindLastSampleInMove(CEntityTrajectory traj, int pos)
        {
            return traj.m_listSamples.Count;
        }
    }
}
