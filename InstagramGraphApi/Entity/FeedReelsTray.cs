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
    public class FeedReelsTray
    {
        [JsonProperty("edge_reels_tray_to_reel")]
        public EdgeReelsTrayToReel EdgeReelsTrayToReel { get; set; }
    }
}
