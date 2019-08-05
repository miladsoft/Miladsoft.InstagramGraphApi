/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using Newtonsoft.Json;

namespace InstagramGraphApi.Entity
{
    public class TagData
    {
        [JsonProperty("config")]
        public Config Config { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("language_code")]
        public string LanguageCode { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("entry_data")]
        public EntryData EntryData { get; set; }

        [JsonProperty("rhx_gis")]
        public string RhxGis { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }
    }

    public class TagPage
    {
        [JsonProperty("graphql")]
        public Graphql Graphql { get; set; }
    }
}
