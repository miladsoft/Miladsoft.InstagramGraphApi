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
    public class EdgeActivityCount
    {
        [JsonProperty("edges")]
        public List<EdgeActivityCountEdges> Edges { get; set; }
    }

    public class EdgeActivityCountEdges
    {
        [JsonProperty("node")]
        public EdgeActivityCountEdgesNode Node { get; set; }
    }

    public class EdgeActivityCountEdgesNode
    {
        [JsonProperty("comment_likes")]
        public int CommentLikes { get; set; }

        [JsonProperty("comments")]
        public int Comments { get; set; }

        [JsonProperty("likes")]
        public int Likes { get; set; }

        [JsonProperty("relationships")]
        public int Relationships { get; set; }

        [JsonProperty("usertags")]
        public int Usertags { get; set; }
    }
}
