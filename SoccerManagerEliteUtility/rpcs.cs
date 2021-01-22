using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoccerManagerEliteUtility
{
    public class rpcs
    {

        #region old strings
        // Methods with no parameters
        public string get_news_feed = @"{{""jsonrpc"": ""2.0"", ""id"":""get_news_feed"", ""method"": ""get_news_feed"", ""params"": {{}}}}";
        public string getcurrentstate = @"{{""jsonrpc"": ""2.0"", ""id"":""getcurrentstate"", ""method"": ""getcurrentstate"", ""params"": {{}}}}";
        public string getnullstate = @"{{""jsonrpc"": ""2.0"", ""id"":""getnullstate"", ""method"": ""getnullstate"", ""params"": {{}}}}";
        public string getpendingstate = @"{{""jsonrpc"": ""2.0"", ""id"":""getpendingstate"", ""method"": ""getpendingstate"", ""params"": {{}}}}";
        public string get_all_stadium_data_ids = @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_stadium_data_ids"", ""method"": ""get_all_stadium_data_ids"", ""params"": {{}}}}";
        public string get_all_transfer_history = @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_transfer_history"", ""method"": ""get_all_transfer_history"", ""params"": {{}}}}";
        public string get_best_managers = @"{{""jsonrpc"": ""2.0"", ""id"":""get_best_managers"", ""method"": ""get_best_managers"", ""params"": {{}}}}";
        //public string get_best_share_asks = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_best_share_asks"", ""params"": {{}}}}";
        public string get_all_managers = @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_managers"", ""method"": ""get_all_managers"", ""params"": {{}}}}";
        public string get_all_users = @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_users"", ""method"": ""get_all_users"", ""params"": {{}}}}";

        // Methods with 1 parameter
        public string get_user_account = @"{{""jsonrpc"": ""2.0"", ""id"":""get_user_account"", ""method"": ""get_user_account"", ""params"": {{""name"": ""{0}""}}}}";
        public string get_club_ids = @"{{""jsonrpc"": ""2.0"", ""id"":""get_club_ids"", ""method"": ""get_club_ids"", ""params"": {{""gw_id"": {0} }}}}";
        public string get_player_ids = @"{{""jsonrpc"": ""2.0"", ""id"":""get_player_ids"", ""method"": ""get_player_ids"", ""params"": {{""gw_id"": {0} }}}}";
        // player_ids takes a comma separated list of numerical IDs
        public string get_players = @"{{""jsonrpc"": ""2.0"", ""id"":""get_players"", ""method"": ""get_players"", ""params"": {{""player_ids"": [ {0} ] }}}}";
        public string get_all_turns = @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_turns"", ""method"": ""get_all_turns"", ""params"": {{""comp_id"": {0} }}}}";
        public string get_fixture = @"{{""jsonrpc"": ""2.0"", ""id"":""get_fixture"", ""method"": ""get_fixture"", ""params"": {{""fixture_id"": {0} }}}}";
        public string get_league_table = @"{{""jsonrpc"": ""2.0"", ""id"":""get_league_table"", ""method"": ""get_league_table"", ""params"": {{""league_id"": {0} }}}}";
        public string get_stadiums_club = @"{{""jsonrpc"": ""2.0"", ""id"":""get_stadiums_club"", ""method"": ""get_stadiums_club"", ""params"": {{""stadium_id"": {0} }}}}";
        public string get_agents_players = @"{{""jsonrpc"": ""2.0"", ""id"":""get_agents_players"", ""method"": ""get_agents_players"", ""params"": {{""agent_name"": ""{0}""}}}}";
        public string get_all_clubs = @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_clubs"", ""method"": ""get_all_clubs"", ""params"": {{""game_world_id"": {0} }}}}";
        public string get_match_goals = @"{{""jsonrpc"": ""2.0"", ""id"":""get_match_goals"", ""method"": ""get_match_goals"", ""params"": {{""fixture_id"": {0} }}}}";
        public string get_match_events = @"{{""jsonrpc"": ""2.0"", ""id"":""get_match_events"", ""method"": ""get_match_events"", ""params"": {{""fixture_id"": {0} }}}}";
        public string get_match_yellow_cards = @"{{""jsonrpc"": ""2.0"", ""id"":""get_match_yellow_cards"", ""method"": ""get_match_yellow_cards"", ""params"": {{""fixture_id"": {0} }}}}";
        public string get_match_red_cards = @"{{""jsonrpc"": ""2.0"", ""id"":""get_match_red_cards"", ""method"": ""get_match_red_cards"", ""params"": {{""fixture_id"": {0} }}}}";
        public string get_match_subs = @"{{""jsonrpc"": ""2.0"", ""id"":""get_match_subs"", ""method"": ""get_match_subs"", ""params"": {{""fixture_id"": {0} }}}}";
        public string get_fixture_player_data = @"{{""jsonrpc"": ""2.0"", ""id"":""get_fixture_player_data"", ""method"": ""get_fixture_player_data"", ""params"": {{""fixture_id"": {0} }}}}";
        public string get_club_tactics = @"{{""jsonrpc"": ""2.0"", ""id"":""get_club_tactics"", ""method"": ""get_club_tactics"", ""params"": {{""club_id"": {0} }}}}";
        public string get_clubs_league = @"{{""jsonrpc"": ""2.0"", ""id"":""get_clubs_league"", ""method"": ""get_clubs_league"", ""params"": {{""club_id"": {0} }}}}";
        public string get_league = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_league"", ""params"": {{""league_id"": {0} }}}}";
        public string get_cups = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_cups"", ""params"": {{""season_id"": {0} }}}}";
        public string get_cup = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_cup"", ""params"": {{""cup_id"": {0} }}}}";
        public string get_seasons = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_seasons"", ""params"": {{""game_world_id"": {0} }}}}";
        public string get_season = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_season"", ""params"": {{""season_id"": {0} }}}}";
        public string get_clubs_next_fixture = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_clubs_next_fixture"", ""params"": {{""club_id"": {0} }}}}";
        public string get_clubs_last_fixture = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_clubs_last_fixture"", ""params"": {{""club_id"": {0} }}}}";
        public string get_league_player_data = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_league_player_data"", ""params"": {{""player_id"": {0} }}}}";
        public string get_cup_player_data = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_cup_player_data"", ""params"": {{""player_id"": {0} }}}}";
        public string get_top_transfer_auctions = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_top_transfer_auctions"", ""params"": {{""num"": {0} }}}}";
        public string get_clubs_transfer_auctions = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_clubs_transfer_auctions"", ""params"": {{""club_id"": {0} }}}}";
        public string get_clubs_transfer_bids = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_clubs_transfer_bids"", ""params"": {{""club_id"": {0} }}}}";
        public string get_transfer_auction_details = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_transfer_auction_details"", ""params"": {{""player_id"": {0} }}}}";
        public string get_club_transfer_history = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_club_transfer_history"", ""params"": {{""club_id"": {0} }}}}";
        public string get_player_transfer_history = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_player_transfer_history"", ""params"": {{""player_id"": {0} }}}}";
        public string get_player_injury_history = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_player_injury_history"", ""params"": {{""player_id"": {0} }}}}";
        public string get_game_world_history = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_game_world_history"", ""params"": {{""season_id"": {0} }}}}";
        public string get_comp_history_by_club = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_comp_history_by_club"", ""params"": {{""club_id"": {0} }}}}";
        public string get_comp_history_by_manager = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_comp_history_by_manager"", ""params"": {{""name"": ""{0}"" }}}}";
        public string get_manager_history_by_club = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_manager_history_by_club"", ""params"": {{""club_id"": {0} }}}}";
        public string get_manager_history_by_manager = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_manager_history_by_manager"", ""params"": {{""name"": ""{0}"" }}}}";
        public string get_user_balance_sheet = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_user_balance_sheet"", ""params"": {{""name"": ""{0}"" }}}}";
        public string get_user_share_balances = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_user_share_balances"", ""params"": {{""name"": ""{0}"" }}}}";
        public string get_user_share_transactions = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_user_share_transactions"", ""params"": {{""name"": ""{0}"" }}}}";
        public string get_user_share_orders = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_user_share_orders"", ""params"": {{""name"": ""{0}"" }}}}";
        public string get_turn_fixtures = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_turn_fixtures"", ""params"": {{""turn_id"":{0}}}}}"; 
        public string get_club = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_club"", ""params"": {{""club_id"":{0}}}}}";
        public string get_managers_club = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_managers_club"", ""params"": {{""manager_name"":""{0}""}}}}";
        public string get_club_balance_sheet = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_club_balance_sheet"", ""params"": {{""club_id"":{0}, ""season_id"":{1}}}}}";
        public string get_leagues = @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_leagues"", ""params"": {{""season_id"":{0}}}}}";
        #endregion

        public static Dictionary<string, string> methods = new Dictionary<string, string>();

        public rpcs()
        {
            // Add methods
            methods.Add("get_news_feed", @"{{""jsonrpc"": ""2.0"", ""id"":""get_news_feed"", ""method"": ""get_news_feed"", ""params"": {{}}}}");
            methods.Add("getcurrentstate", @"{{""jsonrpc"": ""2.0"", ""id"":""getcurrentstate"", ""method"": ""getcurrentstate"", ""params"": {{}}}}");
            methods.Add("getnullstate", @"{{""jsonrpc"": ""2.0"", ""id"":""getnullstate"", ""method"": ""getnullstate"", ""params"": {{}}}}");
            methods.Add("getpendingstate", @"{{""jsonrpc"": ""2.0"", ""id"":""getpendingstate"", ""method"": ""getpendingstate"", ""params"": {{}}}}");
            methods.Add("get_all_stadium_data_ids", @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_stadium_data_ids"", ""method"": ""get_all_stadium_data_ids"", ""params"": {{}}}}");
            methods.Add("get_all_transfer_history", @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_transfer_history"", ""method"": ""get_all_transfer_history"", ""params"": {{}}}}");
            methods.Add("get_best_managers", @"{{""jsonrpc"": ""2.0"", ""id"":""get_best_managers"", ""method"": ""get_best_managers"", ""params"": {{}}}}");
            //methods.Add("get_best_share_asks", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_best_share_asks"", ""params"": {{}}}}");
            // get_best_share_orders has been removed.
            //methods.Add("get_best_share_orders", @"{{""jsonrpc"": ""2.0"", ""id"":""get_best_share_orders"", ""method"": ""get_best_share_orders"", ""params"": {{}}}}");

            methods.Add("get_share_orderbook", @"{{""jsonrpc"": ""2.0"", ""id"":""get_share_orderbook"", ""method"": ""get_share_orderbook"", ""params"": {{""share"":{0}}}}}");
            methods.Add("get_all_managers", @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_managers"", ""method"": ""get_all_managers"", ""params"": {{}}}}");
            methods.Add("get_all_users", @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_users"", ""method"": ""get_all_users"", ""params"": {{}}}}");


            methods.Add("get_user_account", @"{{""jsonrpc"": ""2.0"", ""id"":""get_user_account"", ""method"": ""get_user_account"", ""params"": {{""name"": ""{0}""}}}}");
            methods.Add("get_club_ids", @"{{""jsonrpc"": ""2.0"", ""id"":""get_club_ids"", ""method"": ""get_club_ids"", ""params"": {{""gw_id"": {0} }}}}");
            methods.Add("get_player_ids", @"{{""jsonrpc"": ""2.0"", ""id"":""get_player_ids"", ""method"": ""get_player_ids"", ""params"": {{""gw_id"": {0} }}}}");
            methods.Add("get_players", @"{{""jsonrpc"": ""2.0"", ""id"":""get_players"", ""method"": ""get_players"", ""params"": {{""player_ids"": [ {0} ] }}}}");
            methods.Add("get_all_turns", @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_turns"", ""method"": ""get_all_turns"", ""params"": {{""comp_id"": {0} }}}}");
            methods.Add("get_fixture", @"{{""jsonrpc"": ""2.0"", ""id"":""get_fixture"", ""method"": ""get_fixture"", ""params"": {{""fixture_id"": {0} }}}}");
            methods.Add("get_league_table", @"{{""jsonrpc"": ""2.0"", ""id"":""get_league_table"", ""method"": ""get_league_table"", ""params"": {{""league_id"": {0} }}}}");
            methods.Add("get_stadiums_club", @"{{""jsonrpc"": ""2.0"", ""id"":""get_stadiums_club"", ""method"": ""get_stadiums_club"", ""params"": {{""stadium_id"": {0} }}}}");
            methods.Add("get_agents_players", @"{{""jsonrpc"": ""2.0"", ""id"":""get_agents_players"", ""method"": ""get_agents_players"", ""params"": {{""agent_name"": ""{0}""}}}}");
            methods.Add("get_all_clubs", @"{{""jsonrpc"": ""2.0"", ""id"":""get_all_clubs"", ""method"": ""get_all_clubs"", ""params"": {{""game_world_id"": {0} }}}}");
            methods.Add("get_match_goals", @"{{""jsonrpc"": ""2.0"", ""id"":""get_match_goals"", ""method"": ""get_match_goals"", ""params"": {{""fixture_id"": {0} }}}}");
            methods.Add("get_match_events", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_match_events"", ""params"": {{""fixture_id"": {0} }}}}");
            methods.Add("get_match_yellow_cards", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_match_yellow_cards"", ""params"": {{""fixture_id"": {0} }}}}");
            methods.Add("get_match_red_cards", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_match_red_cards"", ""params"": {{""fixture_id"": {0} }}}}");
            methods.Add("get_match_subs", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_match_subs"", ""params"": {{""fixture_id"": {0} }}}}");
            methods.Add("get_fixture_player_data", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_fixture_player_data"", ""params"": {{""fixture_id"": {0} }}}}");
            methods.Add("get_club_tactics", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_club_tactics"", ""params"": {{""club_id"": {0} }}}}");
            methods.Add("get_clubs_league", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_clubs_league"", ""params"": {{""club_id"": {0} }}}}");
            methods.Add("get_league", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_league"", ""params"": {{""league_id"": {0} }}}}");
            methods.Add("get_cups", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_cups"", ""params"": {{""season_id"": {0} }}}}");
            methods.Add("get_cup", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_cup"", ""params"": {{""cup_id"": {0} }}}}");
            methods.Add("get_seasons", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_seasons"", ""params"": {{""game_world_id"": {0} }}}}");
            methods.Add("get_season", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_season"", ""params"": {{""season_id"": {0} }}}}");
            methods.Add("get_clubs_next_fixture", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_clubs_next_fixture"", ""params"": {{""club_id"": {0} }}}}");
            methods.Add("get_clubs_last_fixture", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_clubs_last_fixture"", ""params"": {{""club_id"": {0} }}}}");
            methods.Add("get_league_player_data", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_league_player_data"", ""params"": {{""player_id"": {0} }}}}");
            methods.Add("get_cup_player_data", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_cup_player_data"", ""params"": {{""player_id"": {0} }}}}");
            methods.Add("get_top_transfer_auctions", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_top_transfer_auctions"", ""params"": {{""num"": {0} }}}}");
            methods.Add("get_clubs_transfer_auctions", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_clubs_transfer_auctions"", ""params"": {{""club_id"": {0} }}}}");
            methods.Add("get_clubs_transfer_bids", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_clubs_transfer_bids"", ""params"": {{""club_id"": {0} }}}}");
            methods.Add("get_transfer_auction_details", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_transfer_auction_details"", ""params"": {{""player_id"": {0} }}}}");
            methods.Add("get_club_transfer_history", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_club_transfer_history"", ""params"": {{""club_id"": {0} }}}}");
            methods.Add("get_player_transfer_history", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_player_transfer_history"", ""params"": {{""player_id"": {0} }}}}");
            methods.Add("get_player_injury_history", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_player_injury_history"", ""params"": {{""player_id"": {0} }}}}");
            methods.Add("get_game_world_history", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_game_world_history"", ""params"": {{""season_id"": {0} }}}}");
            methods.Add("get_comp_history_by_club", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_comp_history_by_club"", ""params"": {{""club_id"": {0} }}}}");
            methods.Add("get_comp_history_by_manager", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_comp_history_by_manager"", ""params"": {{""name"": ""{0}"" }}}}");
            methods.Add("get_manager_history_by_club", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_manager_history_by_club"", ""params"": {{""club_id"": {0} }}}}");
            methods.Add("get_manager_history_by_manager", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_manager_history_by_manager"", ""params"": {{""name"": ""{0}"" }}}}");
            methods.Add("get_user_balance_sheet", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_user_balance_sheet"", ""params"": {{""name"": ""{0}"" }}}}");
            methods.Add("get_user_share_balances", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_user_share_balances"", ""params"": {{""name"": ""{0}"" }}}}");
            methods.Add("get_user_share_transactions", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_user_share_transactions"", ""params"": {{""name"": ""{0}"" }}}}");
            methods.Add("get_user_share_orders", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_user_share_orders"", ""params"": {{""name"": ""{0}"" }}}}");
            methods.Add("get_turn_fixtures", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_turn_fixtures"", ""params"": {{""turn_id"":{0}}}}}");
            methods.Add("get_club", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_club"", ""params"": {{""club_id"":{0}}}}}");
            methods.Add("get_managers_club", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_managers_club"", ""params"": {{""manager_name"":""{0}""}}}}");
            //methods.Add("get_club_balance_sheet", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_club_balance_sheet"", ""params"": {{""club_id"":{0}, ""season_id"":{1}}}}}");
            methods.Add("get_leagues", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_leagues"", ""params"": {{""season_id"":{0}}}}}");

            // Methods with 2 parameters
            methods.Add("get_squad", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_squad"", ""params"": {{""club_id"":{0}, ""game_world_id"":{1}}}}}");


            methods.Add("get_club_schedule", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_club_schedule"", ""params"": {{""club_id"":{0}, ""season_id"":{1}}}}}");


            methods.Add("get_club_balance_sheet", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_club_balance_sheet"", ""params"": {{""club_id"":{0}, ""season_id"":{1}}}}}");


            methods.Add("get_old_tactic_actions", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_old_tactic_actions"", ""params"": {{""club_id"":{0}, ""fixture_id"":{1}}}}}");


            methods.Add("get_club_messages", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_club_messages"", ""params"": {{""club_id"":{0}, ""season_id"":{1}}}}}");


            methods.Add("get_player_messages", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_player_messages"", ""params"": {{""player_id"":{0}, ""season_id"":{1}}}}}");


            methods.Add("get_notifications", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_notifications"", ""params"": {{""name"":""{0}"", ""since"":{1}}}}}");


            methods.Add("get_league_top_scorers", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_league_top_scorers"", ""params"": {{""league_id"":{0}, ""num"":{1}}}}}");


            methods.Add("get_league_top_assists", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_league_top_assists"", ""params"": {{""league_id"":{0}, ""num"":{1}}}}}");


            methods.Add("get_league_top_performance", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_league_top_performance"", ""params"": {{""league_id"":{0}, ""num"":{1}}}}}");


            methods.Add("get_league_top_mom", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_league_top_mom"", ""params"": {{""league_id"":{0}, ""num"":{1}}}}}");


            methods.Add("get_league_top_yellow", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_league_top_yellow"", ""params"": {{""league_id"":{0}, ""num"":{1}}}}}");


            methods.Add("get_league_top_red", @"{{""jsonrpc"": ""2.0"", ""id"":""curltest"", ""method"": ""get_league_top_red"", ""params"": {{""league_id"":{0}, ""num"":{1}}}}}");


            PopulateParameters();
        }



        public Dictionary<string, List<string>> parameters = new Dictionary<string, List<string>>();
        public List<string> tactics = new List<string>();
        public List<string> gw_id = new List<string>();
        public List<string> club_id_game_world_id = new List<string>();
        public List<string> player_ids = new List<string>();
        public List<string> comp_id = new List<string>();
        public List<string> fixture_id = new List<string>();
        public List<string> league_id = new List<string>();
        public List<string> club_id_season_id = new List<string>();
        public List<string> club_id = new List<string>();
        public List<string> stadium_id = new List<string>();
        public List<string> manager_name = new List<string>();
        public List<string> agent_name = new List<string>();
        public List<string> game_world_id = new List<string>();
        public List<string> turn_id = new List<string>();
        public List<string> club_id_fixture_id = new List<string>();
        public List<string> old_tactic_action_id = new List<string>();
        public List<string> season_id = new List<string>();
        public List<string> cup_id = new List<string>();
        public List<string> player_id_season_id = new List<string>();
        public List<string> name_since = new List<string>();
        public List<string> player_id = new List<string>();
        public List<string> league_id_num = new List<string>();
        public List<string> num = new List<string>();
        public List<string> name = new List<string>();
        public List<string> share = new List<string>();


        public void PopulateParameters()
        {
            // Create string lists for the various combinations of parameters
            tactics.Add("tactics");

            gw_id.Add("gw_id");

            club_id_game_world_id.Add("club_id");
            club_id_game_world_id.Add("game_world_id");

            player_ids.Add("player_ids");

            comp_id.Add("comp_id");

            fixture_id.Add("fixture_id");

            league_id.Add("league_id");

            club_id_season_id.Add("club_id");
            club_id_season_id.Add("season_id");

            club_id.Add("club_id");

            stadium_id.Add("stadium_id");

            manager_name.Add("manager_name");

            agent_name.Add("agent_name");

            game_world_id.Add("game_world_id");

            turn_id.Add("turn_id");

            club_id_fixture_id.Add("club_id");
            club_id_fixture_id.Add("fixture_id");

            old_tactic_action_id.Add("old_tactic_action_id");

            season_id.Add("season_id");

            cup_id.Add("cup_id");

            player_id_season_id.Add("player_id");
            player_id_season_id.Add("season_id");

            name_since.Add("name");
            name_since.Add("since");

            player_id.Add("player_id");

            league_id_num.Add("league_id");
            league_id.Add("num");

            num.Add("num");

            name.Add("name");

            share.Add("share");

            // Add the parameter lists to the "parameters" variable.
            parameters.Add("stop", null);
            parameters.Add("getcurrentstate", null);
            parameters.Add("getnullstate", null);
            parameters.Add("getpendingstate", null);
            parameters.Add("waitforchange", null);
            parameters.Add("waitforpendingchange", null);
            parameters.Add("preparetactics", tactics);
            parameters.Add("get_club_ids", gw_id);
            parameters.Add("get_player_ids", gw_id);
            parameters.Add("get_squad", club_id_game_world_id);
            parameters.Add("get_players", player_ids);
            parameters.Add("get_all_turns", comp_id);
            parameters.Add("get_fixture", fixture_id);
            parameters.Add("get_league_table", league_id);
            parameters.Add("get_club_schedule", club_id_season_id);
            parameters.Add("get_club", club_id);
            parameters.Add("get_stadiums_club", stadium_id);
            parameters.Add("get_managers_club", manager_name);
            parameters.Add("get_agents_players", agent_name);
            parameters.Add("get_all_clubs", game_world_id);
            parameters.Add("get_club_balance_sheet", club_id_season_id);
            parameters.Add("get_turn_fixtures", turn_id);
            parameters.Add("get_match_goals", fixture_id);
            parameters.Add("get_match_events", fixture_id);
            parameters.Add("get_match_yellow_cards", fixture_id);
            parameters.Add("get_match_red_cards", fixture_id);
            parameters.Add("get_match_subs", fixture_id);
            parameters.Add("get_fixture_player_data", fixture_id);
            parameters.Add("get_old_tactic_actions", club_id_fixture_id);
            parameters.Add("get_old_tactic_action_lineups", old_tactic_action_id);
            parameters.Add("get_club_tactics", club_id);
            parameters.Add("get_clubs_league", club_id);
            parameters.Add("get_leagues", season_id);
            parameters.Add("get_league", league_id);
            parameters.Add("get_cups", season_id);
            parameters.Add("get_cup", cup_id);
            parameters.Add("get_seasons", game_world_id);
            parameters.Add("get_season", season_id);
            parameters.Add("get_clubs_next_fixture", club_id);
            parameters.Add("get_clubs_last_fixture", club_id);
            parameters.Add("get_club_messages", club_id_season_id);
            parameters.Add("get_player_messages", player_id_season_id);
            parameters.Add("get_news_feed", null);
            parameters.Add("get_notifications", name_since);
            parameters.Add("get_league_player_data", player_id);
            parameters.Add("get_cup_player_data", player_id);
            parameters.Add("get_league_top_scorers", league_id_num);
            parameters.Add("get_league_top_assists", league_id_num);
            parameters.Add("get_league_top_performance", league_id_num);
            parameters.Add("get_league_top_mom", league_id_num);
            parameters.Add("get_league_top_yellow", league_id_num);
            parameters.Add("get_league_top_red", league_id_num);
            parameters.Add("get_all_stadium_data_ids", null);
            parameters.Add("get_top_transfer_auctions", num);
            parameters.Add("get_clubs_transfer_auctions", club_id);
            parameters.Add("get_clubs_transfer_bids", club_id);
            parameters.Add("get_transfer_auction_details", player_id);
            parameters.Add("get_all_transfer_history", null);
            parameters.Add("get_club_transfer_history", club_id);
            parameters.Add("get_player_transfer_history", player_id);
            parameters.Add("get_player_injury_history", player_id);
            parameters.Add("get_game_world_history", season_id);
            parameters.Add("get_best_managers", null);
            parameters.Add("get_comp_history_by_club", club_id);
            parameters.Add("get_comp_history_by_manager", name);
            parameters.Add("get_manager_history_by_club", club_id);
            parameters.Add("get_manager_history_by_manager", name);
            parameters.Add("get_user_account", name);
            parameters.Add("get_user_balance_sheet", name);
            parameters.Add("get_user_share_balances", name);
            parameters.Add("get_user_share_transactions", name);
            parameters.Add("get_share_owners", share);
            parameters.Add("get_user_share_orders", name);
            parameters.Add("get_share_orderbook", share);
            //parameters.Add("get_best_share_orders", null);
            parameters.Add("get_share_trade_history", share);
            parameters.Add("get_share_proposals", share);
            parameters.Add("get_all_users", null);
            parameters.Add("get_all_managers", null);

        }


        public static ComboBox PopulateCombobox(ComboBox box)
        {
            // Let's sort the methods alphabetically first
            List<string> alphabetical = rpcs.methods.Keys.ToList();
            alphabetical.Sort();

            // Old method isn't alphabetical
            //foreach(var v in rpcs.methods)
            //{
            //    box.Items.Add(v.Key);
            //}

            // New alphabetical method
            box.Items.AddRange(alphabetical.ToArray());

            return box;

            box.Items.Add("get_news_feed");
            box.Items.Add("getcurrentstate");
            box.Items.Add("getnullstate");
            box.Items.Add("getpendingstate");
            box.Items.Add("get_all_stadium_data_ids");
            box.Items.Add("get_all_transfer_history");
            box.Items.Add("get_best_managers");
            //box.Items.Add("get_best_share_asks");
            //box.Items.Add("get_best_share_orders");
            box.Items.Add("get_share_orderbook");
            box.Items.Add("get_all_managers");
            box.Items.Add("get_all_users");
            box.Items.Add("get_user_account");
            box.Items.Add("get_club_ids");
            box.Items.Add("get_player_ids");
            box.Items.Add("get_players");
            box.Items.Add("get_all_turns");
            box.Items.Add("get_fixture");
            box.Items.Add("get_league_table");
            box.Items.Add("get_stadiums_club");
            box.Items.Add("get_agents_players");
            box.Items.Add("get_all_clubs");
            box.Items.Add("get_match_goals");
            box.Items.Add("get_match_events");
            box.Items.Add("get_match_yellow_cards");
            box.Items.Add("get_match_red_cards");
            box.Items.Add("get_match_subs");
            box.Items.Add("get_fixture_player_data");
            box.Items.Add("get_club_tactics");
            box.Items.Add("get_clubs_league");
            box.Items.Add("get_league");
            box.Items.Add("get_cups");
            box.Items.Add("get_cup");
            box.Items.Add("get_seasons");
            box.Items.Add("get_season");
            box.Items.Add("get_clubs_next_fixture");
            box.Items.Add("get_clubs_last_fixture");
            box.Items.Add("get_league_player_data");
            box.Items.Add("get_cup_player_data");
            box.Items.Add("get_top_transfer_auctions");
            box.Items.Add("get_clubs_transfer_auctions");
            box.Items.Add("get_clubs_transfer_bids");
            box.Items.Add("get_transfer_auction_details");
            box.Items.Add("get_club_transfer_history");
            box.Items.Add("get_player_transfer_history");
            box.Items.Add("get_player_injury_history");
            box.Items.Add("get_game_world_history");
            box.Items.Add("get_comp_history_by_club");
            box.Items.Add("get_comp_history_by_manager");
            box.Items.Add("get_manager_history_by_club");
            box.Items.Add("get_manager_history_by_manager");
            box.Items.Add("get_user_balance_sheet");
            box.Items.Add("get_user_share_balances");
            box.Items.Add("get_user_share_transactions");
            box.Items.Add("get_user_share_orders");
            box.Items.Add("get_turn_fixtures");
            box.Items.Add("get_club");
            box.Items.Add("get_managers_club");
            box.Items.Add("get_club_balance_sheet");
            box.Items.Add("get_leagues");

            return box;
        }




    }
}
