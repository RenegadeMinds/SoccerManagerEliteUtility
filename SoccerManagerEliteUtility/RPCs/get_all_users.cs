using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMElite;

namespace SMElite
{
    public class get_all_users
    {


        public static string UsersReport(GetAllUsers users, world world)
        {
            string result = string.Empty;

            StringBuilder sb = new StringBuilder();

            // Users is pretty boring unless we add some other information. Manager or agent would be good. 

            foreach (var user in users.Result.Data)
            {
                // user.Name 
            }

            return result;
        }



        // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var getAllUsers = GetAllUsers.FromJson(jsonString);




    public partial class GetAllUsers
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
        [JsonProperty("balance")]
        public long Balance { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class GetAllUsers
    {
        public static GetAllUsers FromJson(string json) => JsonConvert.DeserializeObject<GetAllUsers>(json, get_all_users.Converter.Settings);
    }

    //public static class Serialize
    //{
    //    public static string ToJson(this GetAllUsers self) => JsonConvert.SerializeObject(self, get_all_users.Converter.Settings);
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
