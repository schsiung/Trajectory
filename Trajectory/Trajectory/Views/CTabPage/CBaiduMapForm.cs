using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Permissions;

using Trajectory.Entity;
using Trajectory.Utils;
namespace Trajectory.Views
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]  
    public partial class CBaiduMapForm : Form, ITabPage
    {
        public delegate void StatusInfoEventHandler(object sender, CStatusInfoEventArgs e);//委托签名
        public event StatusInfoEventHandler SetStatusInfo; //out
        #region 数据成员
        private CExTabControl m_tabControl;
        #endregion ///<数据成员
        #region  ITABPAGE
        // 页面关闭事件
        public event EventHandler TabClosed;

        private string m_strTitle;
        public string Title
        {
            get
            {
                return m_strTitle;
            }
            set
            {
                m_strTitle = value;  //设置标题的值
            }
        }
        public ETabType TabType
        {
            get;
            set;
        }
        private Boolean m_bClosable;
        public Boolean BTabRectClosable
        {
            get
            {
                return m_bClosable;
            }
            set
            {
                m_bClosable = value;
            }
        }
        private int m_iTabIndex;
        public int TabPageIndex
        {
            get { return m_iTabIndex; }
            set { m_iTabIndex = value; }
        }
        public void CloseTab()
        {
            if (TabClosed != null)
            {
                this.TabClosed(this, new EventArgs());
            }
        }
        #endregion ITABPAGE
        public CBaiduMapForm()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Load += MapBrouser_Load;
            //InitUI();
        }



        private void MapBrouser_Load(object sender, EventArgs e)
        {
//             string str_url = Application.StartupPath + "\\IndexMap.html";
//             Uri url = new Uri(str_url);
//             webBrowser.Url = url;
//             webBrowser.ObjectForScripting = this;
            this.Controls.Remove(webBrowser);
            webBrowser = CBaiduMapProxy.Instance.Brouser;
            webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(webBrowser);
        }


        public void SetlngAndlatStrip(object lng, object lat)
        {
            if (SetStatusInfo !=null)
            {
                CStatusInfoEventArgs e = new CStatusInfoEventArgs();
                e.info = "当前坐标：" + lng.ToString() + "," + lat.ToString();
                e.lng = lng;
                e.lat = lat;
                SetStatusInfo(this, e);
            }
        }

        /// <summary>
        ///  初始化自定义界面
        /// </summary>
        private void InitUI()
        {
            this.SuspendLayout();
            m_tabControl = new CExTabControl();
            this.Controls.Add(m_tabControl);

            m_tabControl.Dock = DockStyle.Fill;
            m_tabControl.Alignment = TabAlignment.Bottom;
            //m_tabControl.ItemSelectedColor = Color.FromArgb(255, 0, 0);
            m_tabControl.ItemUnSelectedColor = Color.Transparent;
            //m_tabControl.WhitePlaceFillColor = Color.Red;
            m_tabControl.TabContentSpacePixel = 3;
            m_tabControl.TabRightSpacePixel = -1; //消除完全对比线
            m_tabControl.Margin = new System.Windows.Forms.Padding(0);

            this.ResumeLayout(false);
        }



    }
}
