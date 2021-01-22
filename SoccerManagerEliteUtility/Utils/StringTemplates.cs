using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMElite
{
    public class StringTemplates
    {
        public static string Tactics = "  {0,-20} | {1,-1}";


        public static string AllManagersReport = "  {0,-20} | Manages club ID {1, 4} ({2})";

        public static string AgentsPlayersReport = "  {0, 6} {1, 24} - plays for - {2, 4} {3, 20} ";

        public static string OrdersReportPlayerRow = "  {0, -26} {1, 4} {2, -12} Plays for {3}";
        public static string OrdersReportClubRow = "  {0, -26} {1, 4} {2, -12}";

        // user share orders
        public static string UserShareOrderRow = "  {0, -16} {1, 4} {2, 8} SMC for {3, 6} shares of {4, -7} {5, -20} totaling {6, 15} SMC";

        // all clubs orderbooks
        public static string ClubsOrderbooksRow = "  {0, -3} {1, 12} {2, 12} {3, -20}"; // {4, 12}";

        // Player name 0
        // - club 1
        // - country 2
        // - dob 3
        // - height 4
        // - weight 5
        // - foot 6
        // - position 7
        // - fitness 8
        // - morale 9
        // - wages 10
        // - value 11
        // - calculated weekly dividends 12
        // - calculated agent commissions 13
        public static string PlayerEconomicsRow = "{0, -30} {1, -24} {2, -8} {3, -20} {4, 6} cm {5, 7} kg {6, -6} {7, -9} {8, 7} {9, -8} {10, 9} {11, 15} {12, 12} {13, 12} {14, 12} {15, 17} "; //";

        public static string ClubEconomicsRow = "{0, -30} {1, -8} {2, 18} {3, 15} {4, 15} {5, 15} {6, 18} {7, 12} {8, 14} {9, 17}";

        // Player orderbook rows
        //0   order_id
        //1   is_ask
        //2   share_id
        //3   name
        //4   num
        //5   price
        //6   player_id
        //7   club_id
        //8   wages
        //9   fitness
        //10  morale
        //11  injured
        //12  injury_id
        //13  form
        //14  rating
        //15  banned
        //16  cup_tied
        //17  yellow_cards
        //18  red_cards
        //19  dob
        //20  foot
        //21  value
        //22  height
        //23  weight
        //24  country_id
        //25  agent_name

        public static string PlayerOrderbookHeader = "    {0} {1, 31} ";
        public static string PlayerOrderbookHeaderDummy = "".PadLeft(40);

        public static string PlayerOrderbookRow = "{0,9} SMC {1,6} {2,6} {3,13} {4,9} {5,8} {6}";

        public static string AllTransferHistoryHeader = "PLAYER                       FROM                             TO                               AMOUNT        DATE";
        public static string AllTransferHistoryRow    = "{0,28} {1,32} {2,32} {3,12} {4, 20}";


    }
}
