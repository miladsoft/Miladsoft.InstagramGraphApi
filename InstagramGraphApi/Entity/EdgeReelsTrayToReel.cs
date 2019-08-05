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
    public class EdgeReelsTrayToReel
    {
        [JsonProperty("edges")]
        public List<EdgeReelsTrayToReelEdges> Edges { get; set; }
    }

    public class EdgeReelsTrayToReelEdges
    {
        [JsonProperty("node")]
        public EdgeReelsTrayToReelNode node { get; set; }
    }

    public class EdgeReelsTrayToReelNode
    {
        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("can_reply")]
        public bool CanReply { get; set; }

        [JsonProperty("can_reshare")]
        public bool CanReshare { get; set; }

        [JsonProperty("expiring_at")]
        public int ExpiringAt { get; set; }

        [JsonProperty("latest_reel_media")]
        public int? LatestReelMedia { get; set; }

        [JsonProperty("muted")]
        public bool Muted { get; set; }

        [JsonProperty("items")]
        private List<EdgeReelsTrayToReelItem> _Items = new List<EdgeReelsTrayToReelItem>();
        public List<EdgeReelsTrayToReelItem> Items
        {
            get { return _Items; }
            set
            {
                if ((value == null))
                {
                    new List<EdgeReelsTrayToReelItem>();
                }
            }
        }

        [JsonProperty("prefetch_count")]
        public int PrefetchCount { get; set; }

        [JsonProperty("ranked_position")]
        public int RankedPosition { get; set; }

        [JsonProperty("seen")]
        public int? Seen { get; set; }

        [JsonProperty("seen_ranked_position")]
        public int SeenRankedPosition { get; set; }

        [JsonProperty("user")]
        public EdgeReelsTrayToReelUser User { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }
    }

    public class EdgeReelsTrayToReelUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("followed_by_viewer")]
        public bool? FollowedByViewer { get; set; }

        [JsonProperty("requested_by_viewer")]
        public bool? RequestedByViewer { get; set; }
    }

    public class EdgeReelsTrayToReelItem
    {
        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("story_view_count")]
        public int? StoryViewCount { get; set; }

        [JsonProperty("display_url")]
        public string DisplayUrl { get; set; }

        [JsonProperty("media_preview")]
        public string MediaPreview { get; set; }

        [JsonProperty("gating_info")]
        public string GatingInfo { get; set; }

        [JsonProperty("taken_at_timestamp")]
        public int TakenAtTimestamp { get; set; }

        [JsonProperty("expiring_at_timestamp")]
        public int ExpiringAtTimestamp { get; set; }

        [JsonProperty("story_cta_url")]
        public string StoryCtaUrl { get; set; }

        [JsonProperty("is_video")]
        public bool IsVideo { get; set; }

        [JsonProperty("should_log_client_event")]
        public bool ShouldLogClientEvent { get; set; }

        [JsonProperty("tracking_token")]
        public string TrackingToken { get; set; }

        [JsonProperty("video_duration")]
        public double? VideoDuration { get; set; }

        [JsonProperty("dimensions")]
        public Dimensions Dimensions { get; set; }

        [JsonProperty("owner")]
        public Owner Owner { get; set; }

        [JsonProperty("display_resources")]
        public List<DisplayResource> DisplayResources { get; set; }

        [JsonProperty("tappable_objects")]
        public List<TappableObjects> TappableObjects { get; set; }

        [JsonProperty("video_resources")]
        public List<VideoResources> VideoResources { get; set; }
    }

    public class TappableObjects
    {
        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("rotation")]
        public double Rotation { get; set; }

        [JsonProperty("custom_title")]
        public string CustomTitle { get; set; }

        [JsonProperty("attribution")]
        public string Attribution { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("full_name")]
        public string Fullname { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }
    }

    public class VideoResources
    {
        [JsonProperty("src")]
        public string Src { get; set; }

        [JsonProperty("config_width")]
        public int ConfigWidth { get; set; }

        [JsonProperty("config_height")]
        public int ConfigHeight { get; set; }

        [JsonProperty("mime_type")]
        public string MimeType { get; set; }

        [JsonProperty("profile")]
        public string Profile { get; set; }
    }
}
