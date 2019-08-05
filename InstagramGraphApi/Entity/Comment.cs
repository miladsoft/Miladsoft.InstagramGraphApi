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
    public class CommentData
    {
        [JsonProperty("data")]
        public DataComment Data { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public class DataComment
    {
        [JsonProperty("comment")]
        public Comment Comment { get; set; }
    }
    public class Comment
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("edge_liked_by")]
        public EdgeLikedBy EdgeLikedBy { get; set; }

        [JsonProperty("edge_threaded_comments")]
        public EdgeThreadedComments EdgeThreadedComments { get; set; }

        [JsonProperty("viewer_has_liked")]
        public bool VieweHasLiked { get; set; }
    }
}
