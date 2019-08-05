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
    public class ActivityFeed
    {
        [JsonProperty("timestamp")]
        public double Timestamp { get; set; }

        [JsonProperty("edge_web_activity_feed")]
        public EdgeWebActivityFeed EdgeWebActivityFeed { get; set; }
    }
}
