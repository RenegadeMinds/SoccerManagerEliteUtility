using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using J = Newtonsoft.Json.JsonPropertyAttribute;
using R = Newtonsoft.Json.Required;
using N = Newtonsoft.Json.NullValueHandling;

namespace SMElite
{
    public class get_news_feed
    {
        public partial class GetNewsFeed
        {
            [J("id")] public string Id { get; set; }
            [J("jsonrpc")] public string Jsonrpc { get; set; }
            [J("result")] public Result Result { get; set; }
        }

        public partial class Result
        {
            [J("blockhash")] public string Blockhash { get; set; }
            [J("chain")] public string Chain { get; set; }
            [J("data")] public List<Dictionary<string, long?>> Data { get; set; }
            [J("gameid")] public string Gameid { get; set; }
            [J("height")] public long Height { get; set; }
            [J("state")] public string State { get; set; }
        }

        public partial class GetNewsFeed
        {
            public static GetNewsFeed FromJson(string json) => JsonConvert.DeserializeObject<GetNewsFeed>(json, get_news_feed.Converter.Settings);
        }

        //public static class Serialize
        //{
        //    public static string ToJson(this GetNewsFeed self) => JsonConvert.SerializeObject(self, get_news_feed.Converter.Settings);
        //}

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }
    }
}
