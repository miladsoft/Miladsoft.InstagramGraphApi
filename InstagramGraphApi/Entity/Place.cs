/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
using Newtonsoft.Json;

namespace InstagramGraphApi.Entity
{
    public class Place
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("subtitle")]
        public string Subtitle { get; set; }      

        [JsonProperty("header_media")]
        public HeaderMedia HeaderMedia { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }
    }
}
