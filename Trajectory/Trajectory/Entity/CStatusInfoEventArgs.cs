using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectory.Entity
{
    public class CStatusInfoEventArgs:EventArgs
    {
        public string info;
        public object lat;
        public object lng;
        public CStatusInfoEventArgs(string info = null, object lat = null, object lng = null)
        {
            this.info = info;
            this.lat = lat;
            this.lng = lng;
        }
    }
}
