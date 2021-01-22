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
    public class get_all_managers
    {


        // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
        //
        //    using get_all_managers;
        //
        //    var getAllManagers = GetAllManagers.FromJson(jsonString);

        public static string ManagersListReport(GetAllManagers managers, world world)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ALL MANAGERS");
            sb.AppendLine("============");

            foreach (var manager in managers.Result.Data)
            {
                sb.AppendLine(string.Format(StringTemplates.AllManagersReport, manager.ManagerName, manager.ClubId , Utilities.GetClubNameFromId(manager.ClubId, world)));
            }

            return sb.ToString();
        }


    public partial class GetAllManagers
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
        [JsonProperty("club_id")]
        public long ClubId { get; set; }

        [JsonProperty("manager_name")]
        public string ManagerName { get; set; }
    }

    public partial class GetAllManagers
    {
        public static GetAllManagers FromJson(string json) => JsonConvert.DeserializeObject<GetAllManagers>(json, get_all_managers.Converter.Settings);
    }

    //public static class Serialize
    //{
    //    public static string ToJson(this GetAllManagers self) => JsonConvert.SerializeObject(self, get_all_managers.Converter.Settings);
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
