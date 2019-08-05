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
    public class EdgeMediaPreviewLike
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("edges")]
        public List<EdgeMediaPreviewLikeEdges> Edges { get; set; }
    }

    public class EdgeMediaPreviewLikeEdges
    {
        [JsonProperty("node")]
        public EdgeMediaPreviewLikeNode Node { get; set; }
    }

    public class EdgeMediaPreviewLikeNode
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_verified")]
        public bool? IsVerified { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }
    }

    
}
