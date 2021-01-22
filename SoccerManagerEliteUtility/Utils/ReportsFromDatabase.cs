using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoccerManagerEliteUtility.Utils
{
    public class ReportsFromDatabase
    {

        public static string GetAllAgents(SMElite.get_all_users.GetAllUsers users)
        {
            foreach (var user in users.Result.Data)
            {

            }

            return string.Empty;
        }


        public List<string> AllUsers()
        {
            // Bug here for if there are multiple worlds - but there aren't so ok for now

            // Properties.Settings.Default.smcSqlite
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Properties.Settings.Default.smcSqlite;


            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select * 
                    from players
                    where agent_name is not null 
	                    and agent_name != ""
                        ";




            }









                return null;
        }






    }





}
