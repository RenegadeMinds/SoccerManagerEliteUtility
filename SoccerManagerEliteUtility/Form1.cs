using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft;
using Newtonsoft.Json;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;
using SMElite;
using static SMElite.get_best_managers;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using FastColoredTextBoxNS;

namespace SoccerManagerEliteUtility
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pbxClub.MouseWheel += PbxClub_MouseWheel;
            pbxPlayer.MouseWheel += PbxPlayer_MouseWheel;

            // ADGV
            //initialize dataset
            _dataTable = new DataTable();
            _dataSet = new DataSet();

            //initialize bindingsource
            bsBinder.DataSource = _dataSet;

            //initialize datagridview
            adgvReport.SetDoubleBuffered();
            adgvReport.DataSource = bsBinder;
        }

        private void PbxPlayer_MouseWheel(object sender, MouseEventArgs e)
        {
            int playerIndex = 0;
            int playerItemCount = 0;
            playerIndex = cbxPlayers.SelectedIndex;
            playerItemCount = cbxPlayers.Items.Count;

            if (e.Delta > 0)
            {
                if (playerIndex > 0)
                {
                    // Go to the next
                    cbxPlayers.SelectedIndex--;
                }
            }
            if (e.Delta < 0)
            {
                if (playerIndex < (playerItemCount - 1))
                {
                    // Go to the next
                    cbxPlayers.SelectedIndex++;
                }
            }

            RemoveTransparentImage();
            AddTransparentImage(pbxPlayer);
        }

        private void PbxClub_MouseWheel(object sender, MouseEventArgs e)
        {
            int clubIndex = 0;
            int clubItemCount = 0;
            clubIndex = cbxClubs.SelectedIndex;
            clubItemCount = cbxClubs.Items.Count;

            if (e.Delta > 0)
            {
                if (clubIndex > 0)
                {
                    // Go to the next
                    cbxClubs.SelectedIndex--;
                }
            }
            if (e.Delta < 0)
            {
                if (clubIndex < (clubItemCount - 1))
                {
                    // Go to the next
                    cbxClubs.SelectedIndex++;
                }
            }

            RemoveTransparentImage();
            AddTransparentImage(pbxClub); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            net = mainnet;
            cbxRpcs = rpcs.PopulateCombobox(cbxRpcs);
            cbxRpcs.SelectedIndex = 0;
            cbxDataPack.SelectedIndex = 0;

            PopulateWorldFromXml();
            PopulateControls();

            fctbJson.Language = FastColoredTextBoxNS.Language.JSON;
            fctbJson.WordWrap = true;
            fctbJson.WordWrapAutoIndent = true;
        }

        private void PopulateControls()
        {
            // Clear the controls first
            cbxClubs.Items.Clear();
            cbxPlayers.Items.Clear();
            cbxFixtures.Items.Clear();
            cbxLeagues.Items.Clear();
            cbxGameWorlds.Items.Clear();
            cbxSeasons.Items.Clear();
            cbxTurns.Items.Clear();
            cbxUsernames.Items.Clear();

            Console.WriteLine("Cleared all controls.");

            //// Populate the combobox
            List<string> tmpClubs = new List<string>();
            List<int> usedClubs = new List<int>();
            usedClubs = GetClubIds();
            foreach (var c in world.clubs)
            {
                if (usedClubs.Contains(c.Key))
                    tmpClubs.Add(c.Value.name + " " + c.Key);
            }
            tmpClubs.Sort();

            cbxClubs.Items.AddRange(tmpClubs.ToArray());
            cbxClubs.SelectedIndex = 0;

            StringBuilder sbs = new StringBuilder();

            foreach (string s in tmpClubs.ToArray())
            {
                sbs.AppendLine(s);
            }

            fctbReportMaster.Text = sbs.ToString() ;

            StringBuilder sb = new StringBuilder();
            List<int> usedPlayers = GetPlayerIds();

            foreach (var p in world.players)
            {
                if (usedPlayers.Contains(p.Key))
                    sb.AppendLine(p.Value.lastname + ", " + p.Value.firstname + " " + p.Key);
            }

            String pl = sb.ToString();

            List<string> list = pl.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            list.Sort();

            cbxPlayers.Items.AddRange(list.ToArray());
            cbxPlayers.SelectedIndex = 0;

            PopulateGameWorlds();
            PopulateUsers();
            Application.DoEvents();
            PopulateFixtures();
            PopulateSeasons();
            FillUsersClubs();
            PopulateLeagues();
            PopulateTurns();

        }

        int testnet = 18396; // testnet = 18396
        int mainnet = 8610; // Mainnet = 8610
        int net;

        string smcSqlite = @"\Xaya-Electron\scmdata\smc\main\storage.sqlite";

        rpcs rpcs = new rpcs();

        string packfile = "DefaultPack-fake-names.xml"; // "superworldsdata-unescaped.xml";
        string wikifile = "DefaultPack-fake-names.xml"; // "SoccerWiki_2020-07-29_1596062538.xml";
        string fakefile = "DefaultPack-fake-names.xml";
        world world = new world();

        string seasonId = "2";

        /// <summary>
        /// This runs the RPC-based report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGo_Click(object sender, EventArgs e)
        {
            RunRpc();
        }

        private void PopulateGameWorlds()
        {
            List<int> game_worlds = new List<int>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select game_world_id from game_worlds ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        game_worlds.Add(reader.GetInt32(0));
                    }
                }
            }

            // Add to gameworlds combobox
            foreach(int i in game_worlds)
            {
                cbxGameWorlds.Items.Add(i.ToString());
            }

            if (cbxGameWorlds.Items.Count > 0)
            {
                cbxGameWorlds.SelectedIndex = 0;
            }
        }

        private void PopulateSeasons()
        {
            List<int> seasons = new List<int>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select season_id from seasons ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        seasons.Add(reader.GetInt32(0));
                    }
                }
            }

            // Add to gameworlds combobox
            foreach (int i in seasons)
            {
                cbxSeasons.Items.Add(i.ToString());
            }

            if (cbxSeasons.Items.Count > 0)
            {
                cbxSeasons.SelectedIndex = 0;
            }

            // The actual season is 549520, so select that
            if (seasons.Count == 2)
                cbxSeasons.SelectedIndex = 1;
        }


        private List<int> GetClubIds()
        {
            List<int> result = new List<int>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select club_id from clubs 
                    -- where game_world_id = 1";

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

        private List<int> GetPlayerIds()
        {
            List<int> result = new List<int>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select player_id from players 
                    -- where game_world_id = 1";

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


        private void PopulateUsers()
        {

            List<string> usernames = new List<string>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select name from users ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usernames.Add(reader.GetString(0));
                    }
                }
            }

            usernames.Sort();
            // Add to combobox
            cbxUsernames.Items.AddRange(usernames.ToArray());
            //foreach (string name in usernames)
            //{
            //    cbxUsernames.Items.Add(name);
            //}

            if (cbxUsernames.Items.Count > 0)
            {
                cbxUsernames.SelectedIndex = 0;
            }
        }


        private void PopulateFixtures()
        {

            List<string> fixtures = new List<string>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select * from fixtures 
                    where season_id = " + seasonId;//  549520 ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string home = GetClubNameFromId(reader.GetInt32(1));
                        string away = GetClubNameFromId(reader.GetInt32(2));
                        fixtures.Add(home + " (" + reader.GetInt32(1) + ") vs. " + away + " (" + reader.GetInt32(2) + ") " + reader.GetString(0));
                    }
                }
            }

            fixtures.Sort();
            // Add to combobox
            cbxFixtures.Items.AddRange(fixtures.ToArray());
            //foreach (string name in fixtures)
            //{
            //    cbxFixtures.Items.Add(name);
            //}

            if (cbxFixtures.Items.Count > 0)
            {
                cbxFixtures.SelectedIndex = 0;
            }
        }

        private void PopulateLeagues()
        {
            List<string> leagues = new List<string>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select * from leagues 
                    where season_id = " + seasonId;// 549520 ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        leagues.Add(reader.GetString(1) + " - " + reader.GetInt32(0).ToString());
                    }
                }
            }

            leagues.Sort();
            // Add to combobox
            cbxLeagues.Items.AddRange(leagues.ToArray());

            if (cbxLeagues.Items.Count > 0)
            {
                cbxLeagues.SelectedIndex = 0;
            }
        }

        private void PopulateTurns()
        {
            List<string> turns = new List<string>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select * from turns 
                    where season_id = " + seasonId;// 549520 ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string date = UnixTimeStampToDateTime(reader.GetDouble(1)).ToLongDateString();

                        turns.Add(date + " - #" + reader.GetInt32(3) + " - " + reader.GetInt32(0).ToString());
                    }
                }
            }

            turns.Sort();
            // Add to combobox
            cbxTurns.Items.AddRange(turns.ToArray());

            if (cbxTurns.Items.Count > 0)
            {
                cbxTurns.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// This runs the JSON-RPC-based reports. The RPC method is selected in a dropdown menu.
        /// </summary>
        private void RunRpc()
        {
            // This is the JSON-RPC method that we'll run now.
            string method = cbxRpcs.Text;
            // m holds the method string.
            string m = rpcs.methods[method];

            // Need to check for parameters then use the right ones
            List<string> parameters = rpcs.parameters[method];

            #region Inject parameters into the method string.
            // The method string needs to have its parameters injected into it.
            if (parameters == null)
            {
                m = string.Format(m, "");
            }
            else if (parameters == rpcs.tactics)
            {
                //m = string.Format(m, "");
            }
            else if (parameters == rpcs.gw_id)
            {
                m = string.Format(m, cbxGameWorlds.Text);
            }
            else if (parameters == rpcs.club_id_game_world_id)
            {
                m = string.Format(m, SelectedClub, cbxGameWorlds.Text);
            }
            else if (parameters == rpcs.player_ids)
            {
                // m = string.Format(m, SelectedPlayer);
                MessageBox.Show("Method not supported yet.");
                return;
            }
            else if (parameters == rpcs.comp_id)
            {
                MessageBox.Show("Method not supported yet.");
                return;
            }
            else if (parameters == rpcs.fixture_id)
            {
                m = string.Format(m, SelectedFixture);
            }
            else if (parameters == rpcs.league_id)
            {
                m = string.Format(m, SelectedLeague);
            }
            else if (parameters == rpcs.club_id_season_id)
            {
                m = string.Format(m, SelectedClub, cbxSeasons.Text);
            }
            else if (parameters == rpcs.club_id)
            {
                m = string.Format(m, SelectedClub);
            }
            else if (parameters == rpcs.stadium_id)
            {
                MessageBox.Show("Method not supported yet.");
                return;
            }
            else if (parameters == rpcs.manager_name)
            {
                m = string.Format(m, cbxUsernames.Text);
            }
            else if (parameters == rpcs.agent_name)
            {
                m = string.Format(m, cbxUsernames.Text);
            }
            else if (parameters == rpcs.game_world_id)
            {
                m = string.Format(m, cbxGameWorlds.Text);
            }
            else if (parameters == rpcs.turn_id)
            {
                m = string.Format(m, SelectedTurn);
            }
            else if (parameters == rpcs.club_id_fixture_id)
            {
                m = string.Format(m, SelectedClub, SelectedFixture);
            }
            else if (parameters == rpcs.old_tactic_action_id)
            {
                MessageBox.Show("Method not supported yet.");
                return;
            }
            else if (parameters == rpcs.season_id)
            {
                m = string.Format(m, cbxSeasons.Text);
            }
            else if (parameters == rpcs.cup_id)
            {
                MessageBox.Show("Method not supported yet.");
                return;
            }
            else if (parameters == rpcs.player_id_season_id)
            {
                m = string.Format(m, SelectedPlayer, cbxSeasons.Text);
            }
            else if (parameters == rpcs.name_since)
            {
                m = string.Format(m, cbxUsernames.Text, "1");
                //MessageBox.Show("Method not supported yet.");
                //return;
            }
            else if (parameters == rpcs.player_id)
            {
                m = string.Format(m, SelectedPlayer);
            }
            else if (parameters == rpcs.league_id_num)
            {
                m = string.Format(m, SelectedLeague, nudNum.Value.ToString());
            }
            else if (parameters == rpcs.num)
            {
                m = string.Format(m, nudNum.Value.ToString());
            }
            else if (parameters == rpcs.name)
            {
                m = string.Format(m, cbxUsernames.Text);
            }
            else if (parameters == rpcs.share)
            {
                // This can be either player or club shares - just do club for now - fix UI/UX issue late
                m = string.Format(m, SelectedClub);
                //MessageBox.Show("Method not supported yet.");
                //return;
            }
            else
            {
                m = string.Format(m, "");
            }
            #endregion

            // Make the JSON-RPC call to the SME daemon.
            string result = GetJsonRpcResponse(m);

            // Format the JSON result nicely for display.
            result = format_json(result);

            // IMPORTANT METHOD HERE - Should really be reworked/refactored, but good enough for now.
            // This creates our SME objects and creates the reports.
            JsonToObject(method, result);

            // Put the JSON into the JSON fast text box. 
            fctbJson.Text = result;            
        }


        private string GetClubNameFromId(int id)
        {
            if (id == 0)
                return "Invalid";
            if (!world.clubs.ContainsKey(id))
                return "Club unnamed";            

            return world.clubs[id].name;
        }

        private string GetPlayerNameFromId(int id)
        {
            return world.players[id].lastname + ", " + world.players[id].firstname;
        }


        private int GetCurrentClubId()
        {
            // Create a pattern for a word that starts with ...  
            string pattern = @"[0-9]+$";
            // Create a Regex  
            Regex rg = new Regex(pattern);
            MatchCollection matchCollection = rg.Matches(cbxClubs.Text);

            string cId = matchCollection[0].Value;

            return Int32.Parse(cId);
        }

        private int GetCurrentPlayerId()
        {
            // Create a pattern for a word that starts with ...  
            string pattern = @"[0-9]+$";
            // Create a Regex  
            Regex rg = new Regex(pattern);
            MatchCollection matchCollection = rg.Matches(cbxPlayers.Text);

            string pId = matchCollection[0].Value;

            return Int32.Parse(pId);
        }

        private void JsonToObject(string method, string json)
        {
            switch (method)
            {
                case "":

                    break;

                case "get_news_feed":
                    fctbReportMaster.Text = "Not implemented.";
                    break;

                case "getcurrentstate":
                    fctbReportMaster.Text = "Not implemented.";
                    break;

                case "getnullstate":
                    fctbReportMaster.Text = "Not implemented.";
                    break;

                case "getpendingstate":
                    fctbReportMaster.Text = "Not implemented.";
                    break;

                case "get_all_stadium_data_ids":

                    break;

                case "get_all_transfer_history":
                    var GetAllTransferHistory = get_all_transfer_history.GetAllTransferHistory.FromJson(json);

                    string report = get_all_transfer_history.GetAllTransferHistoryReport(GetAllTransferHistory, world);

                    fctbReportMaster.Text = report;

                    break;

                case "get_best_managers":
                    GetBestManagers getBestManagers = get_best_managers.GetBestManagers.FromJson(json);

                    fctbReportMaster.Text = string.Join("\r\n", getBestManagers.InOrder().ToArray());
                    break;

                case "get_best_share_asks":
                    return; // Removed
                    var getBestShareAsks = get_best_share_asks.GetBestShareAsks.FromJson(json);
                    //List<string> sorted = getBestShareAsks.bestShareAsks(world);
                    //sorted.Sort();
                    //txtResult.Text = string.Join("\r\n", sorted.ToArray());
                    fctbReportMaster.Text = string.Join("\r\n", getBestShareAsks.bestShareAsks(world).ToArray());

                    break;

                case "get_best_share_orders":
                    return; // This method has been removed 
                    var bestShareOrders = get_best_share_orders.GetBestShareOrders.FromJson(json);

                    fctbReportMaster.Text = get_best_share_orders.GetShareOrdersReport(bestShareOrders, world);

                    break;

                case "get_share_orderbook":
                    

                    break;

                case "get_all_managers":
                    // 
                    var allManagers = get_all_managers.GetAllManagers.FromJson(json);

                    string s = get_all_managers.ManagersListReport(allManagers, world);

                    fctbReportMaster.Text = s;
                    break;

                case "get_all_users":

                    break;

                case "get_agents_players":
                    var agentsPlayers = get_agents_players.GetAgentsPlayers.FromJson(json);

                    string t = get_agents_players.AgentsPlayersReport(agentsPlayers, world);
                    fctbReportMaster.Text = t;
                    var users = get_all_users.GetAllUsers.FromJson(json);

                    foreach (var user in users.Result.Data)
                    {
                        // var allAgents = user.Name
                        get_agents_players.GetAgentsPlayers gap = new get_agents_players.GetAgentsPlayers();
                        
                    }


                    break;

                case "get_user_account":

                    break;

                case "get_club_ids":

                    break;

                case "get_player_ids":

                    break;

                case "get_players":

                    break;

                case "get_all_turns":

                    break;

                case "get_fixture":

                    break;

                case "get_league_table":

                    break;

                case "get_stadiums_club":

                    break;

                case "get_all_clubs":

                    break;

                case "get_match_goals":

                    break;

                case "get_match_events":

                    break;

                case "get_match_yellow_cards":

                    break;

                case "get_match_red_cards":

                    break;

                case "get_match_subs":

                    break;

                case "get_fixture_player_data":

                    break;

                case "get_club_tactics":
                    // DO THIS NEXT 
                    get_club_tactics.GetClubTactics getClubTactics = get_club_tactics.GetClubTactics.FromJson(json);
                    string full_tactics = Utils.get_club_tactics.Get_club_tactics(getClubTactics, world);
                    fctbReportMaster.Text = full_tactics;
                    // txtResult.Text = full_tactics;

                    break;

                case "get_clubs_league":

                    break;

                case "get_league":

                    break;

                case "get_cups":

                    break;

                case "get_cup":

                    break;

                case "get_seasons":

                    break;

                case "get_season":

                    break;

                case "get_clubs_next_fixture":

                    break;

                case "get_clubs_last_fixture":
                    // 875897


                    break;

                case "get_league_player_data":

                    break;

                case "get_cup_player_data":

                    break;

                case "get_top_transfer_auctions":

                    break;

                case "get_clubs_transfer_auctions":

                    break;

                case "get_clubs_transfer_bids":

                    break;

                case "get_transfer_auction_details":

                    break;

                case "get_club_transfer_history":

                    break;

                case "get_player_transfer_history":

                    break;

                case "get_player_injury_history":

                    break;

                case "get_game_world_history":

                    break;

                case "get_comp_history_by_club":

                    break;

                case "get_comp_history_by_manager":

                    break;

                case "get_manager_history_by_club":

                    break;

                case "get_manager_history_by_manager":

                    break;

                case "get_user_balance_sheet":

                    break;

                case "get_user_share_balances":

                    break;

                case "get_user_share_transactions":

                    break;

                case "get_user_share_orders":

                    var userShareOrders = get_user_share_orders.GetUserShareOrders.FromJson(json);

                    fctbReportMaster.Text = get_user_share_orders.GetUserShareOrdersReport(userShareOrders, world, cbxUsernames.Text);


                    break;

                case "get_turn_fixtures":

                    break;

                case "get_club":

                    break;

                case "get_managers_club":

                    break;

                case "get_club_balance_sheet":

                    break;

                case "get_leagues":

                    break;

                default:

                    break;
            }





        }


        private static string format_json(string json)
        {
            dynamic parsedJson = JsonConvert.DeserializeObject(json);
            return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
        }

        private void PopulateWorldFromXml()
        {
            XmlDocument pack = new XmlDocument();
            XmlDocument wiki = new XmlDocument();

            // Use the fake one? 
            string fileToUse = wikifile;
            bool useFake = cbxDataPack.SelectedIndex == 0 ? true : false;
            if (useFake)
                fileToUse = fakefile;
            else
                fileToUse = wikifile;

            pack.Load(packfile);
            wiki.Load(fileToUse);

            XmlNode xplayers = wiki.DocumentElement.SelectSingleNode("/PackData/PlayerData");
            XmlNode xclubs = wiki.DocumentElement.SelectSingleNode("/PackData/ClubData");

            XmlNode xleagues = wiki.DocumentElement.SelectSingleNode("/PackData/LeagueData");
            XmlNode xstadia = wiki.DocumentElement.SelectSingleNode("/PackData/StadiumData");
            XmlNode xcups = wiki.DocumentElement.SelectSingleNode("/PackData/CupData");
            XmlNode xmanagers = wiki.DocumentElement.SelectSingleNode("/PackData/ManagerData");

            Dictionary<int, club> clubs = new Dictionary<int, club>();
            Dictionary<int, player> players = new Dictionary<int, player>();
            Dictionary<int, league> leagues = new Dictionary<int, league>();
            Dictionary<int, stadium> stadia = new Dictionary<int, stadium>();
            Dictionary<int, cup> cups = new Dictionary<int, cup>();
            Dictionary<int, manager> managers = new Dictionary<int, manager>();

            // Dictionaries
            Dictionary<string, club> dClubs = new Dictionary<string, club>();

            StringBuilder sb = new StringBuilder();

            // CLUBS
            // Get the base URL
            //string baseImageUrl = xclubs.Attributes["baseImageUrl"]?.InnerText;

            foreach (XmlNode node in xclubs)
            {
                club c = new club();
                c.id = node.Attributes["id"]?.InnerText;
                c.name = node.Attributes["n"]?.InnerText;
                if (node.Attributes["i"]?.InnerText != string.Empty)
                {
                    c.image = node.Attributes["i"]?.InnerText; // baseImageUrl + 
                }
                else
                {
                    c.image = string.Empty;
                }

                clubs.Add(int.Parse(c.id), c);
            }

            // PLAYERS
            // Get the base URL
            //baseImageUrl = xplayers.Attributes["baseImageUrl"]?.InnerText;

            foreach (XmlNode node in xplayers)
            {
                player p = new player();
                p.id = node.Attributes["id"]?.InnerText;
                p.firstname = node.Attributes["f"]?.InnerText;
                p.lastname = node.Attributes["s"]?.InnerText;
                if (node.Attributes["i"]?.InnerText != string.Empty)
                {
                    p.image = node.Attributes["i"]?.InnerText; //baseImageUrl + 
                }
                else
                {
                    p.image = string.Empty;
                }

                players.Add(int.Parse(p.id), p);
            }

            // LEAGUES
            foreach (XmlNode node in xleagues)
            {
                league l = new league();
                l.id = node.Attributes["id"]?.InnerText;
                l.name = node.Attributes["n"]?.InnerText;
                if (node.Attributes["i"]?.InnerText != string.Empty)
                {
                    l.image = node.Attributes["i"]?.InnerText;
                }
                else
                {
                    l.image = string.Empty;
                }

                leagues.Add(int.Parse(l.id), l);
            }

            // STADIA
            foreach (XmlNode node in xstadia)
            {
                stadium s = new stadium();
                s.id = node.Attributes["id"]?.InnerText;
                s.name = node.Attributes["n"]?.InnerText;
                if (node.Attributes["i"]?.InnerText != string.Empty)
                {
                    s.image = node.Attributes["i"]?.InnerText;
                }
                else
                {
                    s.image = string.Empty;
                }

                stadia.Add(int.Parse(s.id), s);
            } 

            // Maybe fix data pack for this later.
            if ( false ) // !useFake)
            {

                // CUPS
                foreach (XmlNode node in xcups)
                {
                    cup c = new cup();
                    c.id = node.Attributes["id"]?.InnerText;
                    c.name = node.Attributes["n"]?.InnerText;
                    if (node.Attributes["i"]?.InnerText != string.Empty)
                    {
                        c.image = node.Attributes["i"]?.InnerText;
                    }
                    else
                    {
                        c.image = string.Empty;
                    }

                    cups.Add(int.Parse(c.id), c);
                }

                // MANAGERS
                foreach (XmlNode node in xmanagers)
                {
                    manager m = new manager();
                    m.id = node.Attributes["id"]?.InnerText;
                    m.firstname = node.Attributes["f"]?.InnerText;
                    m.lastname = node.Attributes["s"]?.InnerText;
                    if (node.Attributes["i"]?.InnerText != string.Empty)
                    {
                        m.image = node.Attributes["i"]?.InnerText;
                    }
                    else
                    {
                        m.image = string.Empty;
                    }

                    managers.Add(int.Parse(m.id), m);
                }
            }

            world = new world();
            world.clubs = clubs;
            world.players = players;
            world.cups = cups;
            world.stadia = stadia;
            world.leagues = leagues;
            world.managers = managers;
            world.name = "Super World Pack + Wiki Data";

        }



        private string GetJsonRpcResponse(string json)
        {
            string result = string.Empty;
            try
            {
                using (var webClient = new WebClient())
                {
                    var response = webClient.UploadString("http://localhost:" + net.ToString(), "POST", json);
                    result = response.ToString();
                }
            }
            catch
            {
                return @"{""error"" : ""Encountered an error while posting JSON.""}";
            }

            return result;
        }

        private string GetJsonFromObject(object obj)
        {
            string json = "{}";
            json = JsonConvert.SerializeObject(obj);
            return json;
        }

        private dynamic GetObjectFromJson(string json, Type type)
        {
            dynamic result;

            result = JsonConvert.DeserializeObject<Type>(json);
            result = Convert.ChangeType(result, type);

            return result;
        }


        /// <summary>
        /// The season report is for testing purposes to analyse many seasons run on presumably regtest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeasonReport_Click(object sender, EventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select c.club_id, c.balance, c.game_world_id, 
                      s.game_world_id, s.season_id, s.name, 
                      b.balance_sheet_id, b.date, b.season_ticket_receipts + b.gate_receipts + tv_revenue + b.sponsor + b.merchandise + b.transfers_in + b.prize_money + b.other_income as INCOME, 
                      b.player_wages + b.ground_maintenance + b.transfers_out + b.other_outgoings as EXPENDITURES

                    from clubs as c, 
                      seasons as s, 
                      balance_sheets as b

                    where c.game_world_id = s.game_world_id
                      and c.club_id = b.club_id

                    order by c.club_id, b.date
                        ";

                StringBuilder sb = new StringBuilder();
                // These 2 are for performance to short around the foreach searching for the club name.
                long lastClubId = 0;
                string lastClubName = string.Empty;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Get team name
                        string clubName = string.Empty;
                        if (lastClubId.ToString() != reader.GetString(0))
                        {
                            foreach (KeyValuePair<int, club> club in world.clubs)
                            {
                                if (reader.GetString(0) == club.Value.id)
                                {
                                    clubName = club.Value.name;
                                    lastClubId = int.Parse(club.Value.id);
                                    lastClubName = club.Value.name;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            clubName = lastClubName;
                        }

                        // OLD 0.2.4 version
                        //var result = clubName 
                        //     + "\t " + reader.GetString(0) // club_id
                        //     //+ "\t " + reader.GetString(1) // club_data_id
                        //     + "\t " + reader.GetString(2) // balance
                        //     //+ "\t " + reader.GetString(3) // game_world_id
                        //     + "\t " + reader.GetString(4) // game_world_id
                        //     + "\t " + reader.GetString(5) // season_id
                        //     //+ "\t " + reader.GetString(6) // season name
                        //     //+ "\t " + reader.GetString(7) // balance sheet id
                        //     + "\t " + UnixTimeStampToDateTime( double.Parse(reader.GetString(8))).ToLongDateString() // date
                        //     + "\t " + reader.GetString(9) // income
                        //     + "\t " + reader.GetString(10); // expenditures

                        // New phase 3 beta
                        var result = clubName
                             + "\t " + reader.GetString(0) // club_id
                             + "\t " + reader.GetString(1) // balance
                             //+ "\t " + reader.GetString(2) // game_world_id
                             + "\t " + reader.GetString(3) // game_world_id
                             + "\t " + reader.GetString(4) // season_id
                             //+ "\t " + reader.GetString(5) // season name
                             //+ "\t " + reader.GetString(6) // balance sheet id
                             + "\t " + UnixTimeStampToDateTime(double.Parse(reader.GetString(7))).ToLongDateString() // date
                             + "\t " + reader.GetString(8) // income
                             + "\t " + reader.GetString(9); // expenditures

                        sb.AppendLine(result);
                    }
                }
                fctbReportMaster.Text = sb.ToString();
            }
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

        private void btnClubPower_Click(object sender, EventArgs e)
        {
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;


            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select p.club_id, p.player_id, p.rating
                    from players as p
                    order by p.club_id, p.rating desc
                        ";

                StringBuilder sb = new StringBuilder();

                int clubId = 0;
                int lastClubId = 0;

                int clubPower = 0;
                int count = 0;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string result = string.Empty;
                        int club = reader.GetInt32(0);
                        int player = reader.GetInt32(1);
                        int rating = reader.GetInt32(2);

                        // if the last club ID is the same
                        if (lastClubId == club)
                        {

                        }

                        sb.AppendLine(result);
                    }
                }
                fctbReportMaster.Text = sb.ToString();
            }

        }

        private void btnClubIdName_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var c in world.clubs)
            {
                sb.AppendLine(c.Value.name + " " + c.Key);
            }

            fctbReportMaster.Text = sb.ToString();
        }

        private void btnPlayerIdName_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var p in world.players)
            {
                sb.AppendLine(p.Value.lastname + ", " + p.Value.firstname + " " + p.Key);
            }

            fctbReportMaster.Text = sb.ToString();
            String pl = sb.ToString();

            List<string> list = pl.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries ).ToList<string>();
            list.Sort();
            try
            {
                using (Stream stream = File.Open("players.bin", FileMode.Create))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    bin.Serialize(stream, list);
                }
            }
            catch (IOException)
            {
            }

        }

        int SelectedClub = 0;
        int SelectedPlayer = 0;
        int SelectedFixture = 0;
        int SelectedLeague = 0;
        int SelectedTurn = 0;

        /// <summary>
        /// Changing the selected index changes which input parameters are highlighted.
        /// It does not run any other functionality. A button must be clicked to run the report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRpcs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string method = cbxRpcs.Text;

            // Need to check for parameters then use the right ones
            List<string> parameters = rpcs.parameters[method];

            #region Highlight the parameters that are needed

            RemoveHighlights();
            if (parameters == null)
            {
                RemoveHighlights();
            }
            else if (parameters == rpcs.tactics)
            {

            }
            else if (parameters == rpcs.gw_id)
            {
                RemoveHighlights();
                HighlightControl(cbxGameWorlds);
            }
            else if (parameters == rpcs.club_id_game_world_id)
            {
                RemoveHighlights();
                HighlightControl(cbxClubs);
                HighlightControl(cbxGameWorlds);
            }
            else if (parameters == rpcs.player_ids)
            {

            }
            else if (parameters == rpcs.comp_id)
            {

            }
            else if (parameters == rpcs.fixture_id)
            {
                RemoveHighlights();
                HighlightControl(cbxFixtures);
            }
            else if (parameters == rpcs.league_id)
            {
                RemoveHighlights();
                HighlightControl(cbxLeagues);
            }
            else if (parameters == rpcs.club_id_season_id)
            {
                RemoveHighlights();
                HighlightControl(cbxClubs);
                HighlightControl(cbxSeasons);
            }
            else if (parameters == rpcs.club_id)
            {
                RemoveHighlights();
                HighlightControl(cbxClubs);
            }
            else if (parameters == rpcs.stadium_id)
            {

            }
            else if (parameters == rpcs.manager_name)
            {
                RemoveHighlights();
                HighlightControl(cbxUsernames);
            }
            else if (parameters == rpcs.agent_name)
            {
                RemoveHighlights();
                HighlightControl(cbxUsernames);
            }
            else if (parameters == rpcs.game_world_id)
            {
                RemoveHighlights();
                HighlightControl(cbxGameWorlds);
            }
            else if (parameters == rpcs.turn_id)
            {
                RemoveHighlights();
                HighlightControl(cbxTurns);
            }
            else if (parameters == rpcs.club_id_fixture_id)
            {
                RemoveHighlights();
                HighlightControl(cbxClubs);
                HighlightControl(cbxFixtures);
            }
            else if (parameters == rpcs.old_tactic_action_id)
            {

            }
            else if (parameters == rpcs.season_id)
            {
                RemoveHighlights();
                HighlightControl(cbxSeasons);
            }
            else if (parameters == rpcs.cup_id)
            {

            }
            else if (parameters == rpcs.player_id_season_id)
            {
                RemoveHighlights();
                HighlightControl(cbxPlayers);
                HighlightControl(cbxSeasons);
            }
            else if (parameters == rpcs.name_since)
            {

            }
            else if (parameters == rpcs.player_id)
            {
                RemoveHighlights();
                HighlightControl(cbxPlayers);
            }
            else if (parameters == rpcs.league_id_num)
            {
                RemoveHighlights();
                HighlightControl(cbxLeagues);
                HighlightControl(nudNum);
            }
            else if (parameters == rpcs.num)
            {
                RemoveHighlights();
                HighlightControl(nudNum);
            }
            else if (parameters == rpcs.name)
            {
                RemoveHighlights();
                HighlightControl(cbxUsernames);
            }
            else if (parameters == rpcs.share)
            {

            }
            else
            {
                RemoveHighlights();
            }

            #endregion 
        }

        private void HighlightControl(Control control)
        {
            Point location = control.Location;
            location.X--;
            location.Y--;

            Size size = control.Size;
            size.Height += 2;
            size.Width += 2;

            Panel panel = new Panel();
            panel.Size = size;
            panel.Location = location;
            panel.BackColor = Color.LimeGreen;

            this.Controls.Add(panel);
            panel.SendToBack();
        }

        private void RemoveHighlights()
        {
            // just go through all controls. If it's a green panel, remove it. 
            foreach (Control control in this.Controls)
            {
                if (control.GetType().Equals(typeof(Panel)) && control.BackColor == Color.LimeGreen)
                {
                    this.Controls.Remove(control);
                }
            }
        }


        private void cbxClubs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Create a pattern  
            string pattern = @"[0-9]+$";
            // Create a Regex  
            Regex rg = new Regex(pattern);
            MatchCollection matchCollection = rg.Matches(cbxClubs.Text);

            string cId = matchCollection[0].Value;
            SelectedClub = int.Parse(cId);

            // Load the club image if it exists
            if (world.clubs[SelectedClub].image != string.Empty && world.clubs[SelectedClub].image != "n")
                pbxClub.Load(world.clubs[SelectedClub].image);
            else
                pbxClub.Image = pbxClub.ErrorImage;
        }

        private void cbxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Create a pattern  
            string pattern = @"[0-9]+$";
            // Create a Regex  
            Regex rg = new Regex(pattern);
            MatchCollection matchCollection = rg.Matches(cbxPlayers.Text);

            string pId = matchCollection[0].Value;

            SelectedPlayer = Int32.Parse(pId);

            // Load the player image if it exists
            if (world.players[SelectedPlayer].image != string.Empty && world.players[SelectedPlayer].image != "n")
                pbxPlayer.Load(world.players[SelectedPlayer].image);
            else
                pbxPlayer.Image = pbxPlayer.ErrorImage;
        }

        private void cbxFixtures_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Create a pattern  
            string pattern = @"[0-9]+$";
            // Create a Regex  
            Regex rg = new Regex(pattern);
            MatchCollection matchCollection = rg.Matches(cbxFixtures.Text);

            string fId = matchCollection[0].Value;

            SelectedFixture = Int32.Parse(fId);
        }

        Dictionary<string, string> UsersClubs = new Dictionary<string, string>();

        private void FillUsersClubs()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            string folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + smcSqlite;

            using (var connection = new SqliteConnection("Data Source=" + folder))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    select club_id, manager_name from clubs ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        //seasons.Add(reader.GetInt32(0));
                        
                        string manager_name = string.Empty;
                        if (reader.IsDBNull(1))
                        {
                            manager_name = "none (" + reader.GetInt32(0) + ")";
                        }
                        else
                        {
                            manager_name = reader.GetString(1);
                        }
                        result.Add(manager_name, GetClubNameFromId(reader.GetInt32(0)));
                    }
                }
            }
            UsersClubs = result;
        }

        private void cbxUsernames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblUsersClub.Text = UsersClubs[cbxUsernames.Text];
            }
            catch
            {
                lblUsersClub.Text = "no club";
            }
        }

        private void cbxLeagues_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Create a pattern  
            string pattern = @"[0-9]+$";
            // Create a Regex  
            Regex rg = new Regex(pattern);
            MatchCollection matchCollection = rg.Matches(cbxLeagues.Text);

            string lId = matchCollection[0].Value;

            SelectedLeague = Int32.Parse(lId);
        }

        private void cbxTurns_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Create a pattern  
            string pattern = @"[0-9]+$";
            // Create a Regex  
            Regex rg = new Regex(pattern);
            MatchCollection matchCollection = rg.Matches(cbxTurns.Text);

            string tId = matchCollection[0].Value;

            SelectedTurn = Int32.Parse(tId);
        }

        private void pbxClub_MouseEnter(object sender, EventArgs e)
        {
            AddTransparentImage(pbxClub);
            return;

            // Create a larger image
            // Image dimensions
            int height = pbxClub.Image.Height;
            int width = pbxClub.Image.Width;

            // we should center it in the form
            TransparentDrawing drawing = new TransparentDrawing();
            drawing.Height = height;
            drawing.Width = width;
            drawing.Location = new Point((this.Width / 2) - (width / 2), (this.Height / 2) - (height / 2));
            //drawing.BackColor = Color.Transparent;
            drawing.BackgroundImage = pbxClub.Image;
            drawing.Name = "zoomed";
            
            this.Controls.Add(drawing);
            drawing.BringToFront();
            drawing.Show();
        }

        private void pbxClub_MouseLeave(object sender, EventArgs e)
        {
            RemoveTransparentImage();
        }

        private void pbxPlayer_MouseEnter(object sender, EventArgs e)
        {
            AddTransparentImage(pbxPlayer);
            return;

            // Create a larger image
            // Image dimensions
            int height = pbxPlayer.Image.Height;
            int width = pbxPlayer.Image.Width;

            // we should center it in the form
            TransparentDrawing drawing = new TransparentDrawing();
            drawing.Height = height;
            drawing.Width = width;
            drawing.Location = new Point((this.Width / 2) - (width / 2), (this.Height / 2) - (height / 2));
            //drawing.BackColor = Color.Transparent;
            drawing.BackgroundImage = pbxPlayer.Image;
            drawing.Name = "zoomed";

            this.Controls.Add(drawing);
            drawing.BringToFront();
            drawing.Show();
        }

        private void pbxPlayer_MouseLeave(object sender, EventArgs e)
        {
            RemoveTransparentImage();
        }


        private void AddTransparentImage(PictureBox pbx)
        {
            // Create a larger image
            // Image dimensions
            int height = pbx.Image.Height;
            int width = pbx.Image.Width;

            // we should center it in the form
            TransparentDrawing drawing = new TransparentDrawing();
            drawing.Height = height;
            drawing.Width = width;

            // We need to keep the image below the thumbnail otherwise things get wonky.
            int x = 0;
            int y = 0;
            // This is the max + 20 pixels padding
            int maxTop = pbx.Location.Y + pbx.Size.Height + 20;
            x = (this.Width / 2) - (width / 2);
            y = (this.Height / 2) - (height / 2);
            if (y < maxTop)
                y = maxTop;

            drawing.Location = new Point(x, y);
            drawing.BackgroundImage = pbx.Image;
            drawing.Name = "zoomed";

            this.Controls.Add(drawing);
            drawing.BringToFront();
            this.Invalidate();
            this.Refresh();
            drawing.Show();
        }

        private void RemoveTransparentImage()
        {
            foreach (Control control in this.Controls)
            {
                if (control.Name == "zoomed")
                    this.Controls.Remove(control);

                break;
            }
        }


        private void pbxClub_MouseClick(object sender, MouseEventArgs e)
        {
            int clubIndex = 0;
            int clubItemCount = 0;
            clubIndex = cbxClubs.SelectedIndex;
            clubItemCount = cbxClubs.Items.Count;

            if (e.Button == MouseButtons.Left)
            {
                if (clubIndex < (clubItemCount -1))
                {
                    // Go to the next
                    cbxClubs.SelectedIndex++;
                    // Change the picture
                    // remove the old one
                    RemoveTransparentImage();
                    // add the new one
                    AddTransparentImage(pbxClub);
                }                
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (clubIndex > 0)
                {
                    // Go to the next
                    cbxClubs.SelectedIndex--;
                    // Change the picture
                    // remove the old one
                    RemoveTransparentImage();
                    // add the new one
                    AddTransparentImage(pbxClub);
                }
            }
        }

        private void pbxPlayer_MouseClick(object sender, MouseEventArgs e)
        {
            int playerIndex = 0;
            int playerItemCount = 0;
            playerIndex = cbxPlayers.SelectedIndex;
            playerItemCount = cbxPlayers.Items.Count;

            if (e.Button == MouseButtons.Left)
            {
                if (playerIndex < (playerItemCount - 1))
                {
                    // Go to the next
                    cbxPlayers.SelectedIndex++;
                    // Change the picture
                    // remove the old one
                    RemoveTransparentImage();
                    // add the new one
                    AddTransparentImage(pbxPlayer);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (playerIndex > 0)
                {
                    // Go to the next
                    cbxPlayers.SelectedIndex--;
                    // Change the picture
                    // remove the old one
                    RemoveTransparentImage();
                    // add the new one
                    AddTransparentImage(pbxPlayer);
                }
            }
        }

        private void cbxDataPack_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateWorldFromXml();
            PopulateControls();
        }

        private void fctbJson_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            //delete all markers
            fctbJson.Range.ClearFoldingMarkers();

            var currentIndent = 0;
            var lastNonEmptyLine = 0;

            for (int i = 0; i < fctbJson.LinesCount; i++)
            {
                var line = fctbJson[i];
                var spacesCount = line.StartSpacesCount;
                if (spacesCount == line.Count) //empty line
                    continue;

                if (currentIndent < spacesCount)
                    //append start folding marker
                    fctbJson[lastNonEmptyLine].FoldingStartMarker = "m" + currentIndent;
                else
                if (currentIndent > spacesCount)
                    //append end folding marker
                    fctbJson[lastNonEmptyLine].FoldingEndMarker = "m" + spacesCount;

                currentIndent = spacesCount;
                lastNonEmptyLine = i;
            }
        }

        private void fctbJson_AutoIndentNeeded(object sender, FastColoredTextBoxNS.AutoIndentEventArgs e)
        {
            //we assign this handler to disable AutoIndent by folding
        }

        private void fctbReport_TextChangedDelayed(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            //delete all markers
            fctbReportMaster.Range.ClearFoldingMarkers();

            var currentIndent = 0;
            var lastNonEmptyLine = 0;

            for (int i = 0; i < fctbReportMaster.LinesCount; i++)
            {
                var line = fctbReportMaster[i];
                var spacesCount = line.StartSpacesCount;
                if (spacesCount == line.Count) //empty line
                    continue;

                if (currentIndent < spacesCount)
                    //append start folding marker
                    fctbReportMaster[lastNonEmptyLine].FoldingStartMarker = "m" + currentIndent;
                else
                if (currentIndent > spacesCount)
                    //append end folding marker
                    fctbReportMaster[lastNonEmptyLine].FoldingEndMarker = "m" + spacesCount;

                currentIndent = spacesCount;
                lastNonEmptyLine = i;
            }



        }

        private void fctbReport_AutoIndentNeeded(object sender, FastColoredTextBoxNS.AutoIndentEventArgs e)
        {

        }

        private void fctbJson_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            
        }

        //Create style for highlighting
        TextStyle heading = new TextStyle(Brushes.Brown, null, FontStyle.Bold);

        private void fctbReport_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            //clear previous highlighting
            //e.ChangedRange.ClearStyle(heading);
            //highlight tags
            //e.ChangedRange.SetStyle(heading, "^[A-Z][A-Z].+$");
            //fctbReportMaster.OnSyntaxHighlight(new TextChangedEventArgs(fctbReportMaster.Range));
        }

        private void btnSqlReport_Click(object sender, EventArgs e)
        {
            int clubId = GetCurrentClubId();

            switch (cbxSqlReports.SelectedIndex)
            {
                case 0:
                    string s = SqlReports.ClubOrderbookReport(clubId, world);
                    fctbReportMaster.Text = s;

                    // Reset the grid stuff.
                    ResetAdgv();

                    // Get grid columns.
                    List<AdgvColumn> club_cols = SqlReports.ClubOrderbookAdgvCols();

                    // Add the columns to the grid
                    bool add_club_column_headers = Utilities.SetGridData(club_cols,
                        "ClubOrderbook",
                        ref _dataTable,
                        ref _dataSet,
                        ref bsBinder,
                        ref adgvSearch,
                        ref adgvReport);

                    // Get the club rows
                    List<AdgvRow> club_rows = SqlReports.GetClubOrderbookAdgvRows(club_cols, world);

                    Utilities.AddGridData(club_rows, ref _dataTable);

                    // format columns? could be done in AddGridData - fuggit.
                    foreach (DataGridViewColumn column in adgvReport.Columns)
                    {
                        if (column.ValueType == typeof(DateTime))
                        {
                            column.DefaultCellStyle.Format = "yyyy-MM-dd";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else if (column.ValueType == typeof(int))
                        {
                            column.DefaultCellStyle.Format = "N0";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else if (column.ValueType == typeof(decimal))
                        {
                            column.DefaultCellStyle.Format = "#,##0.00";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }

                    break;

                case 1:

                    string s1 = SqlReports.PlayerOrderbookReport(clubId, world);
                    fctbReportMaster.Text = s1;

                    // Do ADGV version
                    // reset the ADGV
                    ResetAdgv();

                    // Set the grid columns
                    List<AdgvColumn> cols = SqlReports.PlayerOrderbookAdgvCols();

                    bool add_headers = Utilities.SetGridData(cols,
                        "PlayerOrderbook",
                        ref _dataTable,
                        ref _dataSet,
                        ref bsBinder,
                        ref adgvSearch,
                        ref adgvReport);

                    List<AdgvRow> rows = SqlReports.GetPlayerOrderbookAdgvRows(cols, world);

                    Utilities.AddGridData(rows, ref _dataTable);

                    // format columns? could be done in AddGridData - fuggit.
                    foreach (DataGridViewColumn column in adgvReport.Columns)
                    {
                        if (column.ValueType == typeof(DateTime))
                        {
                            column.DefaultCellStyle.Format = "yyyy-MM-dd";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else if (column.ValueType == typeof(int))
                        {
                            column.DefaultCellStyle.Format = "N0";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else if (column.ValueType == typeof(decimal))
                        {
                            column.DefaultCellStyle.Format = "#,##0.00";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                    }

                    break;

                case 2:
                    string s2 = SqlReports.ClubEconomicsReport(world);
                    fctbReportMaster.Text = s2;
                    break;

                case 3:
                    string s3 = SqlReports.PlayerEconomicsReport(world);
                    fctbReportMaster.Text = s3;
                    break;

                default:

                    break;
            }
        }


        #region ADGV


        private void test12()
        {

        }



        private void ResetAdgv()
        {
            _dataTable = new DataTable();
            _dataSet = new DataSet();
            _filtersaved = new SortedDictionary<int, string>();
            _sortsaved = new SortedDictionary<int, string>();

            //initialize bindingsource
            bsBinder.DataSource = _dataSet;

            //initialize datagridview
            adgvReport.SetDoubleBuffered();
            adgvReport.DataSource = bsBinder;
        }

        public DataTable _dataTable = null;
        public DataSet _dataSet = null;

        public SortedDictionary<int, string> _filtersaved = new SortedDictionary<int, string>();
        public SortedDictionary<int, string> _sortsaved = new SortedDictionary<int, string>();

        //private object[][] _inrows = new object[][] { };

        private void adgvSearch_Search(object sender, Zuby.ADGV.AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {
            if (adgvReport.Columns.Count == 0 || adgvReport.Rows.Count == 0)
                return; // get out if nothing in there

            bool restartsearch = true;
            int startColumn = 0;
            int startRow = 0;
            if (!e.FromBegin)
            {
                bool endcol = adgvReport.CurrentCell.ColumnIndex + 1 >= adgvReport.ColumnCount;
                bool endrow = adgvReport.CurrentCell.RowIndex + 1 >= adgvReport.RowCount;

                if (endcol && endrow)
                {
                    startColumn = adgvReport.CurrentCell.ColumnIndex;
                    startRow = adgvReport.CurrentCell.RowIndex;
                }
                else
                {
                    startColumn = endcol ? 0 : adgvReport.CurrentCell.ColumnIndex + 1;
                    startRow = adgvReport.CurrentCell.RowIndex + (endcol ? 1 : 0);
                }
            }
            DataGridViewCell c = adgvReport.FindCell(
                e.ValueToSearch,
                e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                startRow,
                startColumn,
                e.WholeWord,
                e.CaseSensitive);
            if (c == null && restartsearch)
                c = adgvReport.FindCell(
                    e.ValueToSearch,
                    e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                    0,
                    0,
                    e.WholeWord,
                    e.CaseSensitive);
            if (c != null)
                adgvReport.CurrentCell = c;
        }





        #endregion

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            SaveAdgvCsv();
        }

        // adgv 
        private void SaveAdgvCsv()
        {
            var sb = new StringBuilder();

            var headers = adgvReport.Columns.Cast<DataGridViewColumn>();
            sb.AppendLine(string.Join(",", headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

            foreach (DataGridViewRow row in adgvReport.Rows)
            {
                var cells = row.Cells.Cast<DataGridViewCell>();
                sb.AppendLine(string.Join(",", cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
            }

            // fctbJson.Text = sb.ToString();

            sfdExportCSV.Title = "Export CSV Data";
            sfdExportCSV.OverwritePrompt = true;
            sfdExportCSV.DefaultExt = "csv";
            sfdExportCSV.Filter = "CSV files (*.csv)|*.csv";
            //saveFileDialog1.RestoreDirectory = true;
            sfdExportCSV.FileName = "SMElite data - " + DateTime.Now.ToString("yyyy'-'MM'-'dd' - 'HH'-'mm'-'ss") + ".csv";

            if (sfdExportCSV.ShowDialog() == DialogResult.OK)
            {
                string filepath = sfdExportCSV.FileName;

                // save it
                using (StreamWriter writer = new StreamWriter(filepath, false, Encoding.UTF8))
                {                    
                    writer.WriteLine(sb.ToString());
                }
            }
        }

        private void miSaveReport_Click(object sender, EventArgs e)
        {

        }

        private void miSaveJson_Click(object sender, EventArgs e)
        {

        }

        private void miHelp2_Click(object sender, EventArgs e)
        {

        }

        private void miAbout_Click(object sender, EventArgs e)
        {

        }
    } // Form1


} // namespace SoccerManagerUtility
