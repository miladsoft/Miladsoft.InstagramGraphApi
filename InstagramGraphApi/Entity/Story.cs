/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstagramGraphApi.Entity
{
    public class StoryMedias
    {
        [JsonProperty("data")]
        public DataStoryMedia Data { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class DataStoryMedia
    {
        [JsonProperty("user")]
        public StoryUserReel User { get; set; }

        [JsonProperty("reels_media")]
        public List<EdgeReelsTrayToReelNode> ReelsMedia { get; set; }
    }

    public class StoryUserReel
    {
        [JsonProperty("reel")]
        public EdgeReelsTrayToReelNode Reel { get; set; }

        [JsonProperty("edge_highlight_reels")]
        public EdgeHighlightReels EdgeHighlightReels { get; set; }

        [JsonProperty("edge_chaining")]
        public EdgeChaining EdgeChaining { get; set; }
    }
}
