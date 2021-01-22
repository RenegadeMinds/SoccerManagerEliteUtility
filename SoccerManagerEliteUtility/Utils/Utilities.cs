using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SMElite
{
    public partial class Utilities
    {

        public static string GetClubNameFromId(long id, world world)
        {
            string result = string.Empty;
            int i = Int32.Parse(id.ToString());
            try
            {
                return world.clubs[i].name;
            }
            catch
            {
                return "Unknown club id: " + i.ToString();
            }
        }

        public static string GetPlayerNameFromId(long id, world world)
        {
            int i = Int32.Parse(id.ToString());
            try
            {
                return world.players[i].firstname + " " + world.players[i].lastname;
            }
            catch
            {
                return "Unknown player id: " + i.ToString();
            }
        }

        // This should be in the settings
        public static string smcSqlite = @"\Xaya-Electron\scmdata\smc\main\storage.sqlite";

        public static Dictionary<int, int> GetClubsForPlayers()
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select player_id, club_id from players"; 

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0), reader.GetInt32(1));
                    }
                }
            }

            return result;
        }

        public static string GetClubForPlayer(long playerId, world world)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;
            int clubId = 0;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select club_id from players where player_id = " + playerId.ToString();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clubId = reader.GetInt32(0);
                    }
                }
            }
            if (clubId > 0)
                return world.clubs[clubId].name;
            else
                return "Unknown club";
        }

        public static List<int> GetAllPlayerIds()
        {
            List<int> result = new List<int>();

            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select player_id from players";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetInt32(0));
                    }
                }
            }

            return result;
        }



        public static string GetNiceAmount(long amount)
        {
            string result = string.Empty;

            // Format it with ₷
            result = "₷" + amount.ToString("N0");

            return result;
        }


        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }


        public static string GetNiceDateTime(DateTime dateTime)
        {
            string result = string.Empty;

            result = dateTime.ToString("yyyy-MM-dd HH:mm:ss");

            return result;
        }


        public static string FootString(int foot)
        {
            string result = "Both";

            switch (foot)
            {
                case 0:
                    result = "Right";
                    break;

                case 1:
                    result = "Left";
                    break;

                case 2:
                    result = "Both";
                    break;

                default:
                    result = "??";
                    break;
            }

            return result;
        }

        public static string MoraleString(int morale)
        {
            if (morale == 1)
                return "Happy";
            else if (morale == 0)
                return "Unhappy";
            else
                return "Neutral";
        }

        public static string PositionString(int position)
        {
            string result = "Uknown position";
            switch (position)
            {
                case 0:
                    result = "";
                    break;

                case 1:
                    result = "GK";
                    break;

                case 2:
                    result = "LB";
                    break;

                case 4:
                    result = "CB";
                    break;

                case 8:
                    result = "RB";
                    break;

                case 16:
                    result = "LDM";
                    break;

                case 32:
                    result = "CDM";
                    break;

                case 64:
                    result = "RDM";
                    break;

                case 128:
                    result = "LM";
                    break;

                case 256:
                    result = "CM";
                    break;

                case 512:
                    result = "RM";
                    break;

                case 1024:
                    result = "LAM";
                    break;

                case 2048:
                    result = "CAM";
                    break;

                case 4096:
                    result = "RAM";
                    break;

                case 8192:
                    result = "LF";
                    break;

                case 16384:
                    result = "CF";
                    break;

                case 32768:
                    result = "RF";
                    break;

                default:
                    result = "??";
                    break;

            }


            return result;
        }




    }
}
