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
    public class Reel  
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("expiring_at")]
        public int ExpiringAt { get; set; }

        [JsonProperty("latest_reel_media")]
        public int? LatestReelMedia { get; set; }

        [JsonProperty("seen")]
        public int? Seen { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }
    }
}
