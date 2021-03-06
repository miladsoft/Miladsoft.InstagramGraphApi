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
    public class EdgeWebDiscoverMedia
    {
        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("edges")]
        public List<EdgeWebDiscoverMediaEdges> Edges { get; set; }
    }

    public class EdgeWebDiscoverMediaEdges
    {
        [JsonProperty("node")]
        public EdgeWebDiscoverMediaNode Node { get; set; }
    }

    public class EdgeWebDiscoverMediaNode
    {
        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("comments_disabled")]
        public bool CommentsDisabled { get; set; }

        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("edge_liked_by")]
        public EdgeLikedBy EdgeLikedBy { get; set; }

        [JsonProperty("edge_media_preview_like")]
        public EdgeMediaPreviewLike EdgeMediaPreviewLike { get; set; }

        [JsonProperty("edge_media_to_caption")]
        public EdgeMediaToCaption EdgeMediaToCaption { get; set; }

        [JsonProperty("edge_media_to_comment")]
        public EdgeMediaToComment EdgeMediaToComment { get; set; }

        [JsonProperty("is_video")]
        public bool IsVideo { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }

        [JsonProperty("taken_at_timestamp")]
        public int TakenAtTimestamp { get; set; }

        [JsonProperty("thumbnail_src")]
        public string ThumbnailSrc { get; set; }

        [JsonProperty("thumbnail_resources")]
        public List<ThumbnailResource> ThumbnailResources { get; set; }

        [JsonProperty("accessibility_caption")]
        public string AccessibilityCaption { get; set; }

        [JsonProperty("edge_sidecar_to_children")]
        public EdgeSidecarToChildren EdgeSidecarToChildren { get; set; }
    }
}
