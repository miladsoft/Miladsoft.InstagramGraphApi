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
    public class DashInfo
    {
        [JsonProperty("is_dash_eligible")]
        public bool IsDashEligible { get; set; }

        [JsonProperty("video_dash_manifest")]
        public object VideoDashManifest { get; set; }

        [JsonProperty("number_of_qualities")]
        public int NumberOfQualities { get; set; }
    }
}
