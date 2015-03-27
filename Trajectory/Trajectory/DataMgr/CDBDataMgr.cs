using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Trajectory.Entity;

namespace Trajectory.DataMgr
{
    class CDBDataMgr
    {
        #region 事件
        /// <summary>
        /// 数据表清空事件，发生在切换数据库上面
        /// </summary>
        public event EventHandler RTDCleared;
        #endregion


        #region 数据成员
        private string data_dir;
        private List<CEntityUser> m_listUser;    //所有用户内存副本
        private List<CEntityTrajectory> m_listTrajectory; //所有轨迹的内存副本
        private Dictionary<string, CEntityTrajectory> m_mapTrajectory;    //轨迹ID和轨迹映射
        #endregion


        #region 单件模式
        private static CDBDataMgr m_sInstance;   //实例指针
        private CDBDataMgr()
        {

        }
        public static CDBDataMgr Instance
        {
            get { return GetInstance(); }
        }
        public static CDBDataMgr GetInstance()
        {
            if (m_sInstance == null)
            {
                m_sInstance = new CDBDataMgr();
            }
            return m_sInstance;
        }
        #endregion ///<单件模式

        public bool Init()
        {
            m_listUser = ReadAllUserData();
            if ( (m_listUser==null) || (m_listUser.Count==0))
            {
                return false;
            }
            else
            {
                return true;
            }         
        }

        public List<CEntityUser> GetAllUser()
        {
            return m_listUser;
        }


        public void SetDataDir(string dir)
        {
            data_dir = dir;
        }
        private List<CEntityUser> ReadAllUserData()
        {
            if (!Directory.Exists(data_dir))
            {
                return null ;
            }
            List<CEntityUser> results = new List<CEntityUser>();
            try
            {
                //枚举全部目录
            	List<string> dirs = new List<string>(Directory.EnumerateDirectories(data_dir));
                foreach (var dir in dirs)
                {
                    CEntityUser user = new CEntityUser();
                    string dir_name = dir.Substring(dir.LastIndexOf("\\") + 1);
                    user.ID = dir_name;
                    user.Name = dir_name;
                    List<CEntityTrajectory> tmp_list_traj= new List<CEntityTrajectory>();
                    string traj_dir = dir+@"\Trajectory\";
                    if (!Directory.Exists(traj_dir))
                    {
                        continue;
                    }
                    var pltFiles = Directory.EnumerateFiles(traj_dir, "*.plt"); //获取全部轨迹文件
                    foreach (string current_file in pltFiles)
                    {
                        CEntityTrajectory trajectory = new CEntityTrajectory();
                        string plt_name = current_file.Substring(traj_dir.LastIndexOf("\\")+1);
                        trajectory.Name = plt_name;
                        trajectory.TrajectoryID = plt_name;
                        trajectory.fullPathName = current_file;
                        tmp_list_traj.Add(trajectory);
                    }
                    user.m_listTrajectory = tmp_list_traj;
                    results.Add(user);
                }

            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }

            return results;
        }

        /// <summary>
        /// 返回指定UID和TID的轨迹
        /// </summary>
        /// <param name="uid">用户编号</param>
        /// <param name="tid">轨迹编号</param>
        /// <returns></returns>
        public CEntityTrajectory GetTrajectory(string uid, string tid)
        {
            foreach (var user in m_listUser)
            {
                if (user.ID==uid)
                {
                    foreach (var traj in user.m_listTrajectory)
                    {
                        if (traj.TrajectoryID==tid)
                        {
                            return traj;
                        }
                    }
                }
            }
            return null;
        }
    }
}
