using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
namespace Trajectory.Forms
{
    public class FormHelper
    {
        public static MainWindow MainFormRef;
        /// <summary>
        /// 当前的弹出窗体
        /// </summary>
        public static Form CurrentForm = null;
        /// <summary>
        /// 退出系统
        /// </summary>
        public static void SysExit(object sender, EventArgs e)
        {

            MainFormRef.Close();
        }
        /// <summary>
        /// 弹出系统菜单窗体
        /// </summary>
        public static void ShowForm(object sender, EventArgs e)
        {
            var item = sender as ToolStripItem;
            if (item != null && item.Tag != null)
            {
                try
                {
                    var form = GetForm(item.Tag.ToString());

                    if (form != null)
                    {

                        form.Show();
                    }
                }
                catch (System.OverflowException ex)
                {
                    //MessageBox.Show("操作非法,请参考帮助手册");
                    Debug.WriteLine(ex.ToString());
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show("操作非法,请参考帮助手册");
                    Debug.WriteLine(ex.ToString());
                }
            }
        }

        private static Form GetForm(String tag)
        {
            Form form = null;
            switch (tag)
            {

                case "数据协议配置":                     
                    break;


                case "关于":
                    form = new CAboutBox();
                    break;

                default:
                    form = null;
                    break;
            }
            if (form != null)
            {
                //  设置窗体相关属性
                form.StartPosition = FormStartPosition.CenterScreen;
            }

            return form;
        }

    }
}
