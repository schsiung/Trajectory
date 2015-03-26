using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Trajectory.DataMgr;
using Trajectory.Forms;
using Trajectory.Views;
using Trajectory.Controls;
using Trajectory.Entity;
using Trajectory.Utils;
namespace Trajectory
{

    public partial class MainWindow : Form
    {


        #region 数据成员
        private System.Timers.Timer m_sysTimer;
        private MainForm m_formInfo;
        private CBaiduMapForm m_formBaiduMap;
        private CRoadMapForm m_formRoadMap;
        private CExTabControl m_tabControl;
        #endregion

        public MainWindow()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            try
            {
                CDBDataMgr.Instance.SetDataDir(@"E:\GeolifeTrajectories\Data");
                if (!CDBDataMgr.Instance.Init())
                {
                    MessageBox.Show("数据库初始化错误，程序将推出！");
                    throw new  Exception("数据库初始化阶段错误");
                }
            }
            catch (Exception ex)
            {           
                throw ex;
            }
            InitCustomerControls();
            CreateMsgBinding();

            m_sysTimer = new System.Timers.Timer();
            m_sysTimer.Elapsed += (s, e) =>
            {
                this.lblSysTimer.Text = "系统时间:  " + DateTime.Now.ToString();
            };
            m_sysTimer.Start();
        }

        private void InitCustomerControls()
        {
            this.SuspendLayout();
            CTree.Instance.LoadTree();

            CTree.Instance.NodeMouseClick += CMainFormAndCTreeBridage.NodeMouseClickRouter;
//             CTree.Instance.NodeMouseDoubleClick += CMainFormAndCTreeViewBridage.Instance_NodeMouseDoubleClick;
//             CMainFormAndCTreeViewBridage.m_tabControlUp = this.m_tabControlUp;
//             CMainFormAndCTreeViewBridage.m_refMainForm = this;
            m_formBaiduMap = new CBaiduMapForm() { Title = "百度地图", BTabRectClosable = true, MdiParent = this };
            m_formBaiduMap.Dock = DockStyle.Fill;
            
            m_formRoadMap = new CRoadMapForm() { Title = "路网地图", BTabRectClosable = true, MdiParent = this };
            m_formRoadMap.Dock = DockStyle.Fill;




            //m_formInfo = new MainForm();
            //m_formInfo.Parent = splitContainer.Panel2;

            //m_formInfo.Show();
            m_formBaiduMap.Show();
            m_formRoadMap.Show();

            m_tabControl = new CExTabControl();
            m_tabControl.SuspendLayout();
            m_tabControl.AddPage(m_formBaiduMap);
            m_tabControl.AddPage(m_formRoadMap);
            m_tabControl.Show();


            splitContainer.Panel1.Controls.Add(CTree.Instance);
            splitContainer.Panel2.Controls.Add(m_tabControl);
            m_tabControl.ResumeLayout(false);

            this.ResumeLayout(false);
        }
        private void CreateMsgBinding()
        {
            // 设置FormHelper的对象指针
            FormHelper.MainFormRef = this;

            this.FormClosing += new FormClosingEventHandler(this.EHClosing);
            this.MI_FileOpen.Click+= new EventHandler(FormHelper.ShowForm);
            this.MI_SysExit.Click += new EventHandler(FormHelper.SysExit);


            this.MI_About.Click += new EventHandler(FormHelper.ShowForm);

            //m_formBaiduMap.SetStatusInfo += new CBaiduMapForm.StatusInfoEventHandler(SetStatusInfoStrip);
            CBaiduMapProxy.Instance.SetStatusInfo += new CBaiduMapProxy.StatusInfoEventHandler(SetStatusInfoStrip);
        }

        private void EHClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确定退出系统", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.No == result)
            {
                e.Cancel = true;
                return;
            }
            System.Environment.Exit(System.Environment.ExitCode);
            this.Dispose();
            this.Close();
        }

        public void SetStatusInfoStrip(object sender, CStatusInfoEventArgs e)
        {
            this.lblInfo.Text = e.info;
        }
    }
}
