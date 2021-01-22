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
    public class get_user_share_orders
    {

        // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
        //
        //    using QuickType;
        //
        //    var getUserShareOrders = GetUserShareOrders.FromJson(jsonString);
        public static string GetUserShareOrdersReport(GetUserShareOrders userShareOrders, world world, string name)
        {
            if (userShareOrders.Result.Data.Length == 0)
                return string.Empty;

            StringBuilder sb = new StringBuilder();

            var sortedOrders = from entry in userShareOrders.Result.Data orderby entry.Type ascending, entry.Price descending select entry;

            sb.AppendLine(name + " ASKS & BIDS");

            foreach (var order in sortedOrders)
            {
                // "  {0, 16} {1, 4} {2,-8} SMC for {3, 6} shares of {4, 16} totaling {5, -15}";
                string type = order.Type.ToString();
                string price = order.Price.ToString("N0");
                string total = (order.Price * order.Num).ToString("N0");

                // club or player?
                string asset = "Unknown club or player";
                string PorC = "???";
                if (order.Share.Club.HasValue)
                {
                    asset = Utilities.GetClubNameFromId(order.Share.Club.Value, world);
                    PorC = "CLUB";
                }
                else if (order.Share.Player.HasValue)
                {
                    asset = Utilities.GetPlayerNameFromId(order.Share.Player.Value, world);
                    PorC = "PLAYER";
                }

                sb.AppendLine(string.Format(StringTemplates.UserShareOrderRow,
                    name,
                    type,
                    price,
                    order.Num.ToString("N0"),
                    PorC,
                    asset,
                    total));
            }
            sb.AppendLine("  ===============");

            return sb.ToString();
        }



        public partial class GetUserShareOrders
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
            [JsonProperty("num")]
            public long Num { get; set; }

            [JsonProperty("order_id")]
            public long OrderId { get; set; }

            [JsonProperty("price")]
            public long Price { get; set; }

            [JsonProperty("share")]
            public Share Share { get; set; }

            [JsonProperty("type")]
            public TypeEnum Type { get; set; }
        }

        public partial class Share
        {
            [JsonProperty("player", NullValueHandling = NullValueHandling.Ignore)]
            public long? Player { get; set; }

            [JsonProperty("club", NullValueHandling = NullValueHandling.Ignore)]
            public long? Club { get; set; }
        }

        public enum TypeEnum { Ask, Bid };

        public partial class GetUserShareOrders
        {
            public static GetUserShareOrders FromJson(string json) => JsonConvert.DeserializeObject<GetUserShareOrders>(json, get_user_share_orders.Converter.Settings);
        }

        //public static class Serialize
        //{
        //    public static string ToJson(this GetUserShareOrders self) => JsonConvert.SerializeObject(self, get_user_share_orders.Converter.Settings);
        //}

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class TypeEnumConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "ask":
                        return TypeEnum.Ask;
                    case "bid":
                        return TypeEnum.Bid;
                }
                throw new Exception("Cannot unmarshal type TypeEnum");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (TypeEnum)untypedValue;
                switch (value)
                {
                    case TypeEnum.Ask:
                        serializer.Serialize(writer, "ask");
                        return;
                    case TypeEnum.Bid:
                        serializer.Serialize(writer, "bid");
                        return;
                }
                throw new Exception("Cannot marshal type TypeEnum");
            }

            public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
        }










    }
}
