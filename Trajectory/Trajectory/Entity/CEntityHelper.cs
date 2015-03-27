using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trajectory.Entity
{
    public class CSpecialChars
    {
        public const char DOLLAR_CHAR = '$';
        public const char ENTER_CHAR = '\r';
        public const char BALNK_CHAR = ' ';
        public const char HASH_MARK_CHAR = '#';
        public const char COMMA_CHAR = ',';
        public const char SEMICOLIN_CHAR = ';';
    }

    public class CStopHelper
    {
        public static double DISTINFINITY=10000000; //单位米
        public static double DISTZERO = 0; //单位米

        public static double Intrpt_threshold = 180; //单位秒，采样中断间隔不超过
        public static double stay_duration_threshold = 15*60;  //超过5分钟才认为存在停留
        public static int KValue = 10;  //默认的K值        
        public static int span = 10;
        public static double dist_threshold = KValue*span;
    }


}
