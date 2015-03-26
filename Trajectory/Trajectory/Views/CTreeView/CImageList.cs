using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Trajectory.Views
{
    public class CImageList
    {
        public static ImageList GetImageList()
        {
            var il = new ImageList();

            //string dir = "../Image/树/";

            il.Images.Add(new Bitmap(Trajectory.Properties.Resources.用户设置));  //  0
            il.Images.Add(new Bitmap(Trajectory.Properties.Resources.用户));  //  1
            il.Images.Add(new Bitmap(Trajectory.Properties.Resources.轨迹));  //  2

            return il;
        }
    }
}
