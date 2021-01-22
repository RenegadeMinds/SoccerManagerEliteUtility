using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SMElite
{
    public class get_best_share_orders
    {

        // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
        //
        //    using QuickType;
        //
        //    var getBestShareOrders = GetBestShareOrders.FromJson(jsonString);

        public static string GetShareOrdersReport(get_best_share_orders.GetBestShareOrders shareOrders, world world)
        {
            StringBuilder sbClubs = new StringBuilder();
            StringBuilder sbPlayers = new StringBuilder();

            // var sortedDict = from entry in Players orderby entry.Value.Minted descending, entry.Value.Inventory.Count descending select entry;

            List<Datum> clubAskOrders = new List<Datum>();
            List<Datum> clubBidOrders = new List<Datum>(); 
            List<Datum> playerAskOrders = new List<Datum>();
            List<Datum> playerBidOrders = new List<Datum>();

            foreach (var order in shareOrders.Result.Data)
            {
                if (order.Share.Club.HasValue)
                {
                    string clubName = Utilities.GetClubNameFromId(order.Share.Club.Value, world);
                    if (order.BestAsk.HasValue)
                        clubAskOrders.Add(order);
                    if (order.BestBid.HasValue)
                        clubBidOrders.Add(order);
                }
                else
                {
                    string playerName = Utilities.GetPlayerNameFromId(order.Share.Player.Value, world);
                    //playerOrders.Add(order);
                    if (order.BestAsk.HasValue)
                        playerAskOrders.Add(order);
                    if(order.BestBid.HasValue)
                        playerBidOrders.Add(order);
                }
            }

            // Bug fix - GSP is returning players that don't exist in orders - need to remove them
            // 2020-10-22 - This bug may be fixed - remove this after verifying
            List<int> existingPlayers = new List<int>();  // A list to contain all players that exist - their player_ids
            existingPlayers = Utilities.GetAllPlayerIds(); // Just returns select player_id from players
            List<Datum> playersToRemove = new List<Datum>(); // Create a list of players to remove, i.e. the ones that don't exist

            foreach (var player in playerBidOrders)
            {
                if (!existingPlayers.Contains(Convert.ToInt32(player.Share.Player)))
                {
                    // If the player_id isn't in the list of existing players, add it to the remove list
                    playersToRemove.Add(player);
                }
            }

            // It only affects bids, but might as well do asks as well
            foreach (var player in playerAskOrders)
            {
                if (!existingPlayers.Contains(Convert.ToInt32(player.Share.Player)))
                {
                    //playerAskOrders.Remove(player);
                    playersToRemove.Add(player);
                }
            }

            // Go over our list of players to remove, and remove them from the bid and ask lists
            foreach (var player in playersToRemove)
            {
                playerBidOrders.Remove(player);
                playerAskOrders.Remove(player);
            }
            // Done - lists are now cleaned of players that don't exist

            var sortedClubAsks = from entry in clubAskOrders orderby entry.BestAsk.Value descending select entry;
            var sortedClubBids = from entry in clubBidOrders orderby entry.BestBid.Value descending select entry;
            var sortedPlayerAsks = from entry in playerAskOrders orderby entry.BestAsk.Value descending select entry;
            var sortedPlayerBids = from entry in playerBidOrders orderby entry.BestBid.Value descending select entry;

            sbClubs.AppendLine("CLUB ASKS");

            foreach (var club in sortedClubAsks)
            {
                sbClubs.AppendLine(string.Format(StringTemplates.OrdersReportClubRow, Utilities.GetClubNameFromId(club.Share.Club.Value, world).ToString(), "ask", club.BestAsk.Value.ToString("N0")));
            }

            sbClubs.AppendLine("CLUB BIDS");
            foreach (var club in sortedClubBids)
            {
                sbClubs.AppendLine(string.Format(StringTemplates.OrdersReportClubRow, 
                    Utilities.GetClubNameFromId(club.Share.Club.Value, world).ToString(), 
                    "bid", 
                    club.BestBid.Value.ToString("N0")));
            }

            Dictionary<int, int> playerClubIds = Utilities.GetClubsForPlayers();

            sbPlayers.AppendLine("PLAYER ASKS");
            foreach (var player in sortedPlayerAsks)
            {
                try
                {
                    sbPlayers.AppendLine(string.Format(StringTemplates.OrdersReportPlayerRow,
                        Utilities.GetPlayerNameFromId(player.Share.Player.Value, world),
                        "ask",
                        player.BestAsk.Value.ToString("N0"),
                        Utilities.GetClubNameFromId( playerClubIds[Convert.ToInt32(player.Share.Player.Value)], world)
                        //Utilities.GetClubForPlayer(player.Share.Player.Value, world)
                        ));
                }
                catch { }
            }

            sbPlayers.AppendLine("PLAYER BIDS");
            foreach (var player in sortedPlayerBids)
            {
                try
                {
                    //int? cId = playerClubIds[Convert.ToInt32(player.Share.Player.Value)];

                    sbPlayers.AppendLine(string.Format(StringTemplates.OrdersReportPlayerRow,
                        Utilities.GetPlayerNameFromId(player.Share.Player.Value, world),
                        "bid",
                        player.BestBid.Value.ToString("N0"),

                        Utilities.GetClubNameFromId(playerClubIds[Convert.ToInt32(player.Share.Player.Value)], world)
                        //Utilities.GetClubForPlayer(player.Share.Player.Value, world
                        ));
                }
                catch { }
            }


            return sbClubs.ToString() + Environment.NewLine + Environment.NewLine + sbPlayers.ToString();
        }

        public partial class GetBestShareOrders
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("jsonrpc")]
            public string Jsonrpc { get; set; }

            [JsonProperty("result")]
            public Result Result { get; set; }
        }

        public partial class Result
        {
            [JsonProperty("blockhash")]
            public string Blockhash { get; set; }

            [JsonProperty("chain")]
            public string Chain { get; set; }

            [JsonProperty("data")]
            public Datum[] Data { get; set; }

            [JsonProperty("gameid")]
            public string Gameid { get; set; }

            [JsonProperty("height")]
            public long Height { get; set; }

            [JsonProperty("state")]
            public string State { get; set; }
        }

        public partial class Datum
        {
            [JsonProperty("best_ask")]
            public long? BestAsk { get; set; }

            [JsonProperty("best_bid")]
            public long? BestBid { get; set; }

            [JsonProperty("share")]
            public Share Share { get; set; }
        }

        public partial class Share
        {
            [JsonProperty("club", NullValueHandling = NullValueHandling.Ignore)]
            public long? Club { get; set; }

            [JsonProperty("player", NullValueHandling = NullValueHandling.Ignore)]
            public long? Player { get; set; }
        }

        public partial class GetBestShareOrders
        {
            public static GetBestShareOrders FromJson(string json) => JsonConvert.DeserializeObject<GetBestShareOrders>(json, get_best_share_orders.Converter.Settings);
        }

        //public static class Serialize
        //{
        //    public static string ToJson(this GetBestShareOrders self) => JsonConvert.SerializeObject(self, get_best_share_orders.Converter.Settings);
        //}

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }



    }





}
