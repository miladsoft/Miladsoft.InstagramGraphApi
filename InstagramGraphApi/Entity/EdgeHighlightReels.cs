/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
using Newtonsoft.Json;
using System.Collections.Generic;

namespace InstagramGraphApi.Entity
{
    public class EdgeHighlightReels
    {
        [JsonProperty("edges")]
        public List<EdgeHighlightReelsEdges> Edges { get; set; }
    }

    public class EdgeHighlightReelsEdges
    {
        [JsonProperty("node")]
        public EdgeHighlightReelsNode Node { get; set; }
    }

    public class EdgeHighlightReelsNode
    {
        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("cover_media")]
        public CoverMedia CoverMedia { get; set; }

        [JsonProperty("cover_media_cropped_thumbnail")]
        public CoverMediaCroppedThumbnail CoverMediaCroppedThumbnail { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }     
    }

    public class CoverMedia
    {
        [JsonProperty("thumbnail_src")]
        public string ThumbnailSrc { get; set; }
    }

    public class CoverMediaCroppedThumbnail
    {
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
