/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InstagramGraphApi.Entity
{
    public class EdgeWebActivityFeed
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("edges")]
        public List<EdgeWebActivityFeedEdges> Edges { get; set; }
    }

    public class EdgeWebActivityFeedEdges
    {
        [JsonProperty("node")]
        public EdgeWebActivityFeedNode Node { get; set; }
    }

    public class EdgeWebActivityFeedNode
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("timestamp")]
        public double Timestamp { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("user")]
        public WebActivityFeedUser WebActivityFeedUser { get; set; }

        [JsonProperty("media")]
        public WebActivityFeedMedia WebActivityFeedMedia { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public class WebActivityFeedMedia
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("thumbnail_src")]
        public string ThumbnailSrc { get; set; }

        [JsonProperty("thumbnail_resources")]
        public List<ThumbnailResource> ThumbnailResources { get; set; }

        [JsonProperty("shortcode")]
        public string Shortcode { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }
    }

    public class WebActivityFeedUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("full_name")]
        public string Fullname { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("reel")]
        public Reel Reel { get; set; }

        [JsonProperty("requested_by_viewer")]
        public bool RequestedByViewer { get; set; }

        [JsonProperty("followed_by_viewer")]
        public bool FollowedByViewer { get; set; }
    }
}
