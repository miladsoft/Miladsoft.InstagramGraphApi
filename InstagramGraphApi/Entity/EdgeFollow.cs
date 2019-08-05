/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
using System.Collections.Generic;
using Newtonsoft.Json;

namespace InstagramGraphApi.Entity
{
    public class EdgeFollow
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("page_info")]
        public PageInfo PageInfo { get; set; }

        [JsonProperty("edges")]
        public List<EdgeFollowEdges> Edges { get; set; }
    }

    public class EdgeFollowEdges
    {
        [JsonProperty("node")]
        public EdgeFollowNode Node { get; set; }
    }

    public class EdgeFollowNode
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("full_name")]
        public string Fullname { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("followed_by_viewer")]
        public bool FollowedByViewer { get; set; }

        [JsonProperty("requested_by_viewer")]
        public bool RequestedByViewer { get; set; }

        [JsonProperty("reel")]
        public Reel Reel { get; set; }
    }
}
