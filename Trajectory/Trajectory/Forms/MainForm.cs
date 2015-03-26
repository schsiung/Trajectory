using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trajectory.Forms
{
    /// <summary>
    /// 容器窗体，用于呈现数据
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopLevel = false;
//             Label testInfo = new Label();
//             testInfo.Text = "内容展示测试";
//             testInfo.BackColor = Color.Red;
//             testInfo.Location = this.Location;
//             testInfo.Visible = true;
//             this.BackColor = Color.Red;
//             this.Controls.Add(testInfo);
            this.Visible = true;

        }
    }
}
