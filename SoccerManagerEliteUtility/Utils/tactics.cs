using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManagerEliteUtility.Utils
{
    public class tactics
    {
        //public int counterattack { get; set; } 
        //public int menbehindball { get; set; }
        //public int tightmarking { get; set; }
        //public int playoffside { get; set; }
        //public int useplaymaker { get; set; }
        //public int usetargetman { get; set; }

        public static string[] tacklingstyle = { "Timid", "Soft", "Normal", "Hard", "Aggressive" };
        public static string[] mentality = { "Very Defensive", "Defensive", "Normal", "Attacking", "Very Attacking" };
        public static string[] passingstyle = { "Short", "Mixed", "Direct", "Long Ball" };
        public static string[] attackingstyle = { "Mixed", "Down Both Flanks", "Down Left Flank", "Fown Right Flank", "Through the Middle" };
        public static string[] tempo = { "Slow", "Normal", "Fast" };
        public static string[] pressing = { "Own Area", "Own Half", "All Over" };


        public static string GetSituation(int id)
        {
            switch (id)
            {
                case 0:
                    return "Any Score";
                case 1:
                    return "Winning";
                case 2:
                    return "Losing";
                case 3:
                    return "Drawing";
                case 4:
                    return "Losing or Drawing";
                case 5:
                    return "Winning or Drawing";
                default:
                    return "";
            }
        }

        public static string GetGoalMargin(int id)
        {
            switch (id)
            {
                case 0:
                case 1:
                    return "Any Score";
                case 2:
                    return "By 1 goal";
                case 3:
                    return "By 2 goals";
                case 4:
                    return "By 3 or more goals";
                default:
                    return "";
            }
        }

    }
}
