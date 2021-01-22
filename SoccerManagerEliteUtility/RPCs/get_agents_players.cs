using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMElite
{

    public class get_agents_players
    {
                                   
        // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var getAgentsPlayers = GetAgentsPlayers.FromJson(jsonString);

        public static string AgentsPlayersReport(GetAgentsPlayers agentsPlayers, world world)
        {
            StringBuilder sb = new StringBuilder();

            // sb.AppendLine(agentsPlayers.Result.Data)
            bool didHeader = false;

            foreach(var player in agentsPlayers.Result.Data)
            {
                if (!didHeader)
                {
                    sb.AppendLine(player.AgentName);
                    sb.AppendLine(new String('=', player.AgentName.Length));
                    didHeader = true;
                }

                string playerName = Utilities.GetPlayerNameFromId(player.PlayerId, world);
                string clubName = Utilities.GetClubNameFromId(player.ClubId, world);

                sb.AppendLine(string.Format(StringTemplates.AgentsPlayersReport,
                    player.PlayerId.ToString(),
                    playerName,
                    player.ClubId.ToString(),
                    clubName));
            }

            return sb.ToString();
        }



    public partial class GetAgentsPlayers
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
        [JsonProperty("agent_name")]
        public string AgentName { get; set; }

        [JsonProperty("banned")]
        public long Banned { get; set; }

        [JsonProperty("club_id")]
        public long ClubId { get; set; }

        [JsonProperty("country_id")]
        public string CountryId { get; set; }

        [JsonProperty("cup_tied")]
        public bool CupTied { get; set; }

        [JsonProperty("dob")]
        public long Dob { get; set; }

        [JsonProperty("fitness")]
        public long Fitness { get; set; }

        [JsonProperty("foot")]
        public long Foot { get; set; }

        [JsonProperty("form")]
        //[JsonConverter(typeof(ParseIntegerConverter))]
        public string Form { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("injured")]
        public long Injured { get; set; }

        [JsonProperty("injury_id")]
        public long InjuryId { get; set; }

        [JsonProperty("morale")]
        public long Morale { get; set; }

        [JsonProperty("player_id")]
        public long PlayerId { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("rating")]
        public long Rating { get; set; }

        [JsonProperty("red_cards")]
        public long RedCards { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }

        [JsonProperty("wages")]
        public long Wages { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }

        [JsonProperty("yellow_cards")]
        public long YellowCards { get; set; }
    }

    public partial class GetAgentsPlayers
    {
        public static GetAgentsPlayers FromJson(string json) => JsonConvert.DeserializeObject<GetAgentsPlayers>(json, get_agents_players.Converter.Settings);
    }

    //public static class Serialize
    //{
    //    public static string ToJson(this GetAgentsPlayers self) => JsonConvert.SerializeObject(self, get_agents_players.Converter.Settings);
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

    internal class ParseIntegerConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseIntegerConverter Singleton = new ParseIntegerConverter();
    }


        

    }
}
