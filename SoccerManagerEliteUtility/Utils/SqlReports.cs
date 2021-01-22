using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMElite
{
    public class SqlReports
    {

        public static string ClubOrderbookReport(long clubId, world world)
        {

            Dictionary<int, int> result = new Dictionary<int, int>();
            StringBuilder sb = new StringBuilder();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utilities.smcSqlite;
            
            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select * from share_orders where share_type = ""club"" order by share_id, share_type, price desc, num, name  ";

                int lastClubId = 0;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // result.Add(reader.GetInt32(0), reader.GetInt32(1));
                        if (lastClubId != reader.GetInt32(3))
                        {
                            // add header
                            sb.AppendLine("CLUB " + Utilities.GetClubNameFromId(reader.GetInt32(3), world));
                            sb.AppendLine("  TYPE       PRICE       SHARES NAME");
                        }
                            string type = string.Empty;
                            if (reader.GetInt32(1) == 1)
                                type = "ask";
                            else if (reader.GetInt32(1) == 0)
                                type = "bid";

                            string price = reader.GetInt32(6).ToString("N0");
                            string num = reader.GetInt32(5).ToString("N0");
                            string name = reader.GetString(4);

                            sb.AppendLine(
                                string.Format(
                                    StringTemplates.ClubsOrderbooksRow,
                                        type,
                                        price,
                                        num,
                                        name
                                        ));
                        
                        lastClubId = reader.GetInt32(3);
                    }
                }
            }

            return sb.ToString();
        }

        // Need to do player orderbook report still


        public static List<AdgvColumn> PlayerOrderbookAdgvCols()
        {
            List<AdgvColumn> cols = new List<AdgvColumn>();

            AdgvColumn col = new AdgvColumn("order_id", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("is_ask", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("share_id", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("name", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("num", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("price", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("player_id", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("player_name", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("club_id", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("club_name", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("position", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("wages", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("value", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("value_wages", typeof(decimal));
            cols.Add(col);
            col = new AdgvColumn("fitness", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("morale", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("injured", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("injury_id", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("form", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("rating", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("banned", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("cup_tied", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("yellow_cards", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("red_cards", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("dob", typeof(DateTime));
            cols.Add(col);
            col = new AdgvColumn("foot", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("height", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("weight", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("country_id", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("agent_name", typeof(string));
            cols.Add(col);

            return cols;
        }

        public static List<AdgvColumn> ClubOrderbookAdgvCols()
        {
            List<AdgvColumn> cols = new List<AdgvColumn>();

            AdgvColumn col = new AdgvColumn("order_id", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("is_ask", typeof(string));
            cols.Add(col);
            //col = new AdgvColumn("share_type", typeof(string));
            //cols.Add(col);
            col = new AdgvColumn("share_id", typeof(int));
            cols.Add(col);
            // Add in club name.
            col = new AdgvColumn("club_name", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("name", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("num", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("price", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("total", typeof(int));
            cols.Add(col);
            //col = new AdgvColumn("club_id", typeof(int));
            //cols.Add(col);
            //col = new AdgvColumn("club_name", typeof(string));
            //cols.Add(col);
            col = new AdgvColumn("balance", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("form", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("fans_start", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("fans_current", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("stadium_size_start", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("stadium_size_current", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("stadium_id", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("manager_name", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("chairman_name", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("home_colour", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("away_colour", typeof(string));
            cols.Add(col);
            col = new AdgvColumn("value", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("default_formation", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("rating", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("country_id", typeof(string));
            cols.Add(col);
            //col = new AdgvColumn("committed_tactics", typeof(Byte[]));
            //cols.Add(col);
            col = new AdgvColumn("game_world_id", typeof(int));
            cols.Add(col);
            col = new AdgvColumn("proposed_manager", typeof(string));
            cols.Add(col);

            return cols;
        }


        public static List<AdgvRow> GetClubOrderbookAdgvRows(List<AdgvColumn> cols, world world)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utilities.smcSqlite;
            List<AdgvRow> rows = new List<AdgvRow>();

            //Stop if club doesn't exist
            // List<int> existing_clubs = Utilities.Get

            #region get rows


            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select so.order_id, 
	so.is_ask, 
	so.share_type, 
	so.share_id, 
	so.name, 
	so.num, 
	so.price, 
	(so.price * so.num) as total, 
	c.club_id, 
	c.balance, 
	c.form, 
	c.fans_start, 
	c.fans_current, 
	c.stadium_size_start, 
	c.stadium_size_current, 
	c.stadium_id, 
	c.manager_name, 
	c.chairman_name, 
	c.home_colour, 
	c.away_colour, 
	c.value, 
	c.default_formation, 
	c.rating, 
	c.country_id, 
	-- c.committed_tactics, 
	c.game_world_id, 
	c.proposed_manager
from share_orders as so,
    clubs as c

where share_type = ""club""
    and c.club_id = so.share_id
    -- and c.club_id = 45

order by so.price desc, c.value desc, c.club_id asc
--c.committed_tactics, 
";

                //0   order_id
                //1   is_ask
                //2   share_type
                //3   share_id
                //4   name
                //5   num
                //6   price
                //7   total
                //8   club_id
                //9   balance
                //10  form
                //11  fans_start
                //12  fans_current
                //13  stadium_size_start
                //14  stadium_size_current
                //15  stadium_id
                //16  manager_name
                //17  chairman_name
                //18  home_colour
                //19  away_colour
                //20  value
                //21  default_formation
                //22  rating
                //23  country_id
                //24  committed_tactics -- commented out...
                //24  game_world_id
                //25  proposed_manager


                int order_id = 0;
                string is_ask = "???";
                string share_type = string.Empty;
                int share_id = 0;
                string name = string.Empty;
                int num = 0;
                int price = 0;
                int total = 0;
                int club_id = 0;
                int balance = 0;
                string form = string.Empty;
                int fans_start = 0;
                int fans_current = 0;
                int stadium_size_start = 0;
                int stadium_size_current = 0;
                int stadium_id = 0;
                string manager_name = string.Empty;
                string chairman_name = string.Empty;
                string home_colour = string.Empty;
                string away_colour = string.Empty;
                int value = 0;
                int default_formation = 0;
                int rating = 0;
                string country_id = string.Empty;
                //Byte[] committed_tactics;
                int game_world_id = 0;
                string proposed_manager = string.Empty;


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        order_id = reader.GetInt32(0);
                        is_ask = reader.GetInt32(1) == 1 ? "ask" : "bid";
                        share_id = reader.GetInt32(3);
                        name = reader.GetString(4);
                        num = reader.GetInt32(5);
                        price = reader.GetInt32(6);
                        total = reader.GetInt32(7);
                        club_id = reader.GetInt32(8);

                        // Stop if club doesn't exist
                        //if (!existing_clubs.Contains(player_id)) // Still need to create method for this
                        //    continue;
                        
                        balance = reader.GetInt32(9);                        
                        form = reader.GetString(10);
                        fans_start = reader.GetInt32(11);
                        fans_current = reader.GetInt32(12);
                        stadium_size_start = reader.GetInt32(13);
                        stadium_size_current = reader.GetInt32(14);
                        stadium_id = reader.GetInt32(15);
                        manager_name = reader.IsDBNull(16) ? string.Empty : reader.GetString(16);
                        chairman_name = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);
                        home_colour = reader.GetString(18);
                        away_colour = reader.GetString(19);
                        value = reader.GetInt32(20);
                        default_formation = reader.IsDBNull(21) ? -1 : reader.GetInt32(21);
                        rating = reader.GetInt32(22);
                        country_id = reader.GetString(23);
                        // committed_tactics = reader.GetBytes .GetString(24);
                        game_world_id = reader.GetInt32(24);
                        proposed_manager = reader.IsDBNull(25) ? string.Empty : reader.GetString(25);

                        string club_name = Utilities.GetClubNameFromId(club_id, world);

                        List<object> list = new List<object>();
                        list.Add(order_id);
                        list.Add(is_ask);
                        //list.Add(share_type);
                        list.Add(share_id);
                        list.Add(club_name);
                        list.Add(name);
                        list.Add(num);
                        list.Add(price);
                        list.Add(total);
                        //list.Add(club_id);
                        //list.Add(club_name);
                        list.Add(balance);
                        list.Add(form);
                        list.Add(fans_start);
                        list.Add(fans_current);
                        list.Add(stadium_size_start);
                        list.Add(stadium_size_current);
                        list.Add(stadium_id);
                        list.Add(manager_name);
                        list.Add(chairman_name);
                        list.Add(home_colour);
                        list.Add(away_colour);
                        list.Add(value);
                        list.Add(default_formation);
                        list.Add(rating);
                        list.Add(country_id);
                        // list.Add(committed_tactics);
                        list.Add(game_world_id);
                        list.Add(proposed_manager);

                        AdgvRow row = new AdgvRow(cols, list);
                        rows.Add(row);
                        //shortcircuit++;
                        //if (shortcircuit >= 100)
                        //    break;
                    }
                }
            }

            #endregion



            return rows;
        }

        public static List<AdgvRow> GetPlayerOrderbookAdgvRows(List<AdgvColumn> cols, world world)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utilities.smcSqlite;
            List<AdgvRow> rows = new List<AdgvRow>();
            int shortcircuit = 0;


            // stop if the player doesn't exist
            List<int> existing_players = Utilities.GetAllPlayerIds();

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select  
	s.order_id, s.is_ask, s.share_id, s.name, s.num, s.price, 
	p.player_id, p.club_id, p.wages, p.fitness, p.morale, 
	p.injured, p.injury_id, p.form, p.rating, p.banned, 
	p.cup_tied, p.yellow_cards, p.red_cards, 
	p.dob, p.foot, p.value, p.height, 
	p.weight, p.country_id, p.agent_name, p.position

from 
	share_orders as s, 
	players as p
where share_type = ""player"" and s.share_id = p.player_id 
order by
    s.is_ask desc,
    p.rating desc,
    s.share_id,
	s.price desc,
    s.num, 
	s.name, 
	s.share_type";

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
                //26  position

                int order_id = 0;
                string is_ask = string.Empty;
                int share_id = 0;
                string name = string.Empty;
                int num = 0;
                int price = 0;
                int player_id = 0;
                int club_id = 0;
                int wages = 0;  //************
                int fitness = 0;
                string morale = string.Empty;
                int injured = 0;
                int injury_id = 0;
                string form = string.Empty;
                int rating = 0;
                int banned = 0;
                int cup_tied = 0;
                int yellow_cards = 0;
                int red_cards = 0;
                DateTime dob = DateTime.Now;
                string foot = string.Empty;
                int value = 0;//************
                int height = 0;
                int weight = 0;
                string country_id = string.Empty;
                string agent_name = string.Empty;
                string position = string.Empty;
                decimal value_wages = 0;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        order_id = reader.GetInt32(0);
                        is_ask = reader.GetInt32(1) == 1 ? "ask" : "bid";
                        share_id = reader.GetInt32(2);
                        name = reader.GetString(3);
                        num = reader.GetInt32(4);
                        price = reader.GetInt32(5);
                        player_id = reader.GetInt32(6);

                        // Stop if player doesn't exist
                        if (!existing_players.Contains(player_id))
                            continue;

                        club_id = reader.GetInt32(7);
                        wages = reader.GetInt32(8);
                        fitness = reader.GetInt32(9);
                        morale = Utilities.MoraleString(reader.GetInt32(10));
                        injured = reader.GetInt32(11);
                        injury_id = reader.GetInt32(12);
                        form = reader.GetString(13);
                        rating = reader.GetInt32(14);
                        banned = reader.GetInt32(15);
                        cup_tied = reader.GetInt32(16);
                        yellow_cards = reader.GetInt32(17);
                        red_cards = reader.GetInt32(18);
                        dob = Utilities.UnixTimeStampToDateTime(reader.GetInt32(19));
                        foot = Utilities.FootString(reader.GetInt32(20));
                        value = reader.GetInt32(21) * 1000;
                        height = reader.GetInt32(22);
                        weight = reader.GetInt32(23);
                        country_id = reader.GetString(24);
                        agent_name = reader.IsDBNull(25) ? string.Empty : reader.GetString(25);
                        position = Utilities.PositionString(reader.GetInt32(26));

                        value_wages = decimal.Round((decimal)value / (decimal)wages, 2);

                        string player_name = Utilities.GetPlayerNameFromId(player_id, world);

                        string club_name = Utilities.GetClubNameFromId(club_id, world);

                        List<object> list = new List<object>();
                        list.Add(order_id);
                        list.Add(is_ask);
                        list.Add(share_id);
                        list.Add(name);
                        list.Add(num);
                        list.Add(price);
                        list.Add(player_id);
                        list.Add(player_name);
                        list.Add(club_id);
                        list.Add(club_name);
                        list.Add(position);
                        list.Add(wages);


                            










                        list.Add(value);
                        // add in ((float)(value * 1000) / (float)wages).ToString("0.0")
                        list.Add(value_wages);
                        list.Add(fitness);
                        list.Add(morale);
                        list.Add(injured);
                        list.Add(injury_id);
                        list.Add(form);
                        list.Add(rating);
                        list.Add(banned);
                        list.Add(cup_tied);
                        list.Add(yellow_cards);
                        list.Add(red_cards);
                        list.Add(dob);
                        list.Add(foot);
                        list.Add(height);
                        list.Add(weight);
                        list.Add(country_id);
                        list.Add(agent_name);

                        AdgvRow row = new AdgvRow(cols, list);
                        rows.Add(row);
                        //shortcircuit++;
                        //if (shortcircuit >= 100)
                        //    break;
                    }
                }
            }

            return rows;
        }

        public static string PlayerOrderbookReport(long clubId, world world)
        {
            StringBuilder report = new StringBuilder();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utilities.smcSqlite;
            int name_length = 0;
            bool is_bid_header_done = false;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select  
	s.order_id, s.is_ask, s.share_id, s.name, s.num, s.price, 
	p.player_id, p.club_id, p.wages, p.fitness, p.morale, 
	p.injured, p.injury_id, p.form, p.rating, p.banned, 
	p.cup_tied, p.yellow_cards, p.red_cards, 
	p.dob, p.foot, p.value, p.height, 
	p.weight, p.country_id, p.agent_name

from 
	share_orders as s, 
	players as p
where share_type = ""player"" and s.share_id = p.player_id 
order by
    s.is_ask desc,
    p.rating desc,
    s.share_id,
	s.price desc,
    s.num, 
	s.name, 
	s.share_type";

                int lastPlayerId = 0;

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
                
                int order_id = 0;
                string is_ask = string.Empty;
                int share_id = 0;
                string name = string.Empty;
                int num = 0;
                int price = 0;
                int player_id = 0;
                int club_id = 0;
                int wages = 0;  //************
                int fitness = 0;
                int morale = 0;
                int injured = 0;
                int injury_id = 0;
                string form = string.Empty;
                int rating = 0;
                int banned = 0;
                int cup_tied = 0;
                int yellow_cards = 0;
                int red_cards = 0;
                int dob = 0;
                int foot = -1;
                int value = 0;//************
                int height = 0;
                int weight = 0;
                string country_id = string.Empty;
                string agent_name = string.Empty;

                report.AppendLine("  A/B                              NAME         PRICE    QTY RATING         VALUE     WAGES      V/W SELLER/BIDDER");
                report.AppendLine("  ASKS");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        order_id = reader.GetInt32(0);
                        is_ask = reader.GetInt32(1) == 1 ? "ask" : "bid";
                        share_id = reader.GetInt32(2);
                        name = reader.GetString(3);
                        num = reader.GetInt32(4);
                        price = reader.GetInt32(5);
                        player_id = reader.GetInt32(6);
                        club_id = reader.GetInt32(7);
                        wages = reader.GetInt32(8);
                        fitness = reader.GetInt32(9);
                        morale = reader.GetInt32(10);
                        injured = reader.GetInt32(11);
                        injury_id = reader.GetInt32(12);
                        form = reader.GetString(13);
                        rating = reader.GetInt32(14);
                        banned = reader.GetInt32(15);
                        cup_tied = reader.GetInt32(16);
                        yellow_cards = reader.GetInt32(17);
                        red_cards = reader.GetInt32(18);
                        dob = reader.GetInt32(19);
                        foot = reader.GetInt32(20);
                        value = reader.GetInt32(21);
                        height = reader.GetInt32(22);
                        weight = reader.GetInt32(23);
                        country_id = reader.GetString(24);
                        agent_name = reader.IsDBNull(25) ? string.Empty : reader.GetString(25);

                        string player_name = Utilities.GetPlayerNameFromId(player_id, world);

                        if (player_name.Length > name_length)
                            name_length = player_name.Length;

                        // bid header
                        if (!is_bid_header_done && is_ask == "bid")
                        {
                            is_bid_header_done = true;
                            // add bid header
                            report.AppendLine("  BIDS");
                        }

                        if (lastPlayerId != player_id)
                        {
                            // add header for each player
                            report.Append(string.Format(StringTemplates.PlayerOrderbookHeader, is_ask, /* player name */ player_name + " (" + player_id + ")"));
                        }
                        else
                        {
                            // append appropriate padding
                            report.Append(StringTemplates.PlayerOrderbookHeaderDummy);
                        }
                        //string type = string.Empty;
                        //if (reader.GetInt32(1) == 1)
                        //    type = "ask";
                        //else if (reader.GetInt32(1) == 0)
                        //    type = "bid";

                        //price = reader.GetInt32(6).ToString("N0");
                        //num = reader.GetInt32(5).ToString("N0");
                        //name = reader.GetString(4);

                        report.Append(
                            string.Format(
                                StringTemplates.PlayerOrderbookRow,
                                    price.ToString("N0"),
                                    num.ToString("N0"),
                                    rating,
                                    (value * 1000).ToString("N0"),
                                    wages.ToString("N0"),
                                    ((float)(value * 1000) / (float)wages).ToString("0.0"),
                                    name
                                    ) + Environment.NewLine);

                        lastPlayerId = player_id;
                    }
                }
            }

            return report.ToString(); // name_length.ToString() + Environment.NewLine + 
        }

        // find financial advice for buying players/clubs
        // sme code POPULATEtACTICS.CS =- line 1433 or so for positions


        public static string PlayerEconomicsReport(world world)
        {
            StringBuilder sb = new StringBuilder();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utilities.smcSqlite;

            sb.AppendLine(
                string.Format(
                    StringTemplates.PlayerEconomicsRow,
                    "NAME",
                    "CLUB",
                    "COUNTRY",
                    "DOB",
                    "HEIGHT",
                    "WEIGHT",
                    "FOOT",
                    "POSITION",
                    "FITNESS",
                    "MORALE",
                    "WAGES",
                    "VALUE",
                    "DIVIDENDS",
                    "COMMISSIONS",
                    "PRICE",
                    "HOUSE MONEY WEEKS"
                ));

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select  
	p.player_id, p.fitness, p.morale, p.wages, p.position, p.dob, p.foot, p.value, p.height, p.weight, p.country_id, p.club_id, 
	min(s.price) as price, (price / ((p.wages * 0.02 * 2) / 10000)) as housemoney
from players as p, 
     share_orders as s
where p.player_id = s.share_id and 
	  s.share_type = ""player"" and

      s.is_ask = 1
group by p.player_id
order by housemoney asc, 
         p.wages desc,
         p.club_id asc,
         value ";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string pname = Utilities.GetPlayerNameFromId(reader.GetInt32(0), world);
                        string cname = Utilities.GetClubNameFromId(reader.GetInt32(11), world);
                        string country = reader.GetString(10);
                        string dob = Utilities.UnixTimeStampToDateTime(reader.GetInt32(5)).ToLongDateString();
                        int height = reader.GetInt32(8);
                        int weight = reader.GetInt32(9);
                        int foot = reader.GetInt32(6);
                        int value = reader.GetInt32(7) * 1000;
                        int wages = reader.GetInt32(3);
                        int fitness = reader.GetInt32(1);
                        int position = reader.GetInt32(4);
                        int morale = reader.GetInt32(2);
                        int price = reader.GetInt32(12);
                        double housemoney = reader.GetDouble(13);


                        double weeklyShareDividends = wages * 0.02 * 2;    // paid 2x per week
                        double weeklyAgentCommissions = wages * 0.001 * 2; // paid 2x per week

                        // weeks to earn back investment - House Money Weeks
                        double weeksToEarnBackInvestment = weeklyShareDividends / (price * 100);
                        double onesharedividend = weeklyShareDividends / 10000;
                        double priceBy1share = price / onesharedividend;


                        sb.AppendLine(
                            string.Format(
                                StringTemplates.PlayerEconomicsRow,
                                pname,
                                cname,
                                country,
                                dob,
                                height.ToString(),
                                weight.ToString(),
                                Utilities.FootString(foot),
                                Utilities.PositionString(position),
                                fitness.ToString(),
                                Utilities.MoraleString(morale),
                                wages.ToString("N0"),
                                value.ToString("N0"),
                                weeklyShareDividends.ToString("N0"),
                                weeklyAgentCommissions.ToString("N0"),
                                price.ToString("N0"),
                                housemoney.ToString("#.00")
                            ));
                    }
                }
            }

            return sb.ToString();
        }




        public static string ClubEconomicsReport(world world)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            StringBuilder sb = new StringBuilder();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utilities.smcSqlite;

            sb.AppendLine("CLUB SHARE INFO REPORT");
            sb.AppendLine("  This report is to help you decide on what clubs you wish to purchase shares in.");
            sb.AppendLine("  50% of clubs in this report are playing 'away', so they don't have much revenue.");
            sb.AppendLine("  Those are marked with '**' in the total revenue column.");
            sb.AppendLine("  What you should pay attention to is the'HOUSE MONEY WEEKS' column.");
            sb.AppendLine("  That tells you how many weeks it takes to earn back your initial investment in weeks. ");
            sb.AppendLine("  That number is a rough estimate based on the current market. It could change radically and quickly. ");
            sb.AppendLine("");

            sb.AppendLine(
                string.Format(
                    StringTemplates.ClubEconomicsRow,
                    "CLUB",
                    "COUNTRY",
                    "BALANCE",
                    "PRICE",
                    "TV REVENUE",
                    "MANAGER SALARY",
                    "TOTAL REVENUE",
                    "DIVIDENDS",
                    "DIV PER SHARE",
                    "HOUSE MONEY WEEKS"
                ));


            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @" select 
c.club_id, c.balance, c.value, c.manager_name, country_id, 
min(s.price) as price,  
b.tv_revenue as tv, 
(b.tv_revenue * 0.002) as manager_money,
(b.gate_receipts + b.tv_revenue + b.sponsor + merchandise) as revenue, 
(b.gate_receipts + b.tv_revenue + b.sponsor + merchandise) * 0.01 as dividend, 
(b.gate_receipts + b.tv_revenue + b.sponsor + merchandise) * 0.01 / 10000 as dividend_per_share,  
( min(s.price) / ( (b.gate_receipts + b.tv_revenue + b.sponsor + merchandise) * 0.01) * 10000  ) as housemoney

from 
clubs as c,
share_orders as s,
balance_sheets as b

where c.club_id = s.share_id and
      s.share_type = ""club"" and
      c.club_id = b.club_id and 
      s.is_ask = 1 
      -- and c.club_id = 45

group by c.club_id
order by housemoney asc , 
         manager_money desc,
         c.club_id
 ";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string club = Utilities.GetClubNameFromId(reader.GetInt32(0), world);
                        string country = reader.GetString(4);
                        int balance = reader.GetInt32(1);
                        int price = reader.GetInt32(5);
                        int tv_revenue = reader.GetInt32(6);
                        double manager_salary = reader.GetDouble(7);
                        int total_revenue = reader.GetInt32(8);
                        double dividends = reader.GetDouble(9);
                        double div_per_share = reader.GetDouble(10);
                        double housemoney = reader.IsDBNull(11) ? 0 : reader.GetDouble(11);

                        string revenue_flag = tv_revenue == total_revenue ? "** " : "";

                        sb.AppendLine(
                            string.Format(
                                StringTemplates.ClubEconomicsRow,
                                club,
                                country,
                                balance.ToString("N0"),
                                price.ToString("N0"),
                                tv_revenue.ToString("N0"),
                                manager_salary.ToString("#,##0.00"),
                                revenue_flag + total_revenue.ToString("N0"),
                                dividends.ToString("#,##0.00"),
                                div_per_share.ToString("0.00"),
                                housemoney.ToString("0.00")
                            ));
                    }
                }
            }

            return sb.ToString();
        }













        // TEMPLATE
        public static string ReportTemplate(long clubId, world world)
        {

            Dictionary<int, int> result = new Dictionary<int, int>();
            StringBuilder sb = new StringBuilder();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utilities.smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select  
                    player_id, fitness, morale, wages, position, dob, foot, value, height, weight, country_id, club_id
                  from players as p
                    order by wages desc, club_id asc , value   ";


                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //reader.GetInt32(0);
                    }
                }
            }

            return sb.ToString();
        }

        // Get all player IDs
        public static List<int> GetAllPlayerIds()
        {

            Dictionary<int, int> result = new Dictionary<int, int>();
            List<int> player_ids = new List<int>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utilities.smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select  
                    player_id
                  from players as p
                    order by player_id ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        player_ids.Add(reader.GetInt32(0));
                    }
                }
            }

            return player_ids;
        }

        // Get all club IDs
        public static List<int> GetAllClubIds()
        {

            Dictionary<int, int> result = new Dictionary<int, int>();
            List<int> club_ids = new List<int>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utilities.smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select  
                    club_id
                  from clubs as c
                    order by club_id ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        club_ids.Add(reader.GetInt32(0));
                    }
                }
            }

            return club_ids;
        }


        // Get all stadium IDs
        public static List<int> GetAllStadiumIds()
        {

            Dictionary<int, int> result = new Dictionary<int, int>();
            List<int> stadium_ids = new List<int>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + Utilities.smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"select  
                    stadium_id
                  from clubs as c
                    order by stadium_id ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        stadium_ids.Add(reader.GetInt32(0));
                    }
                }
            }

            return stadium_ids;
        }




    }
}
