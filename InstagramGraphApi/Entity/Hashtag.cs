/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using Newtonsoft.Json;

namespace InstagramGraphApi.Entity
{
    public class HashtagMedias
    {
        [JsonProperty("data")]
        public DataHashtagMedia Data { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public class DataHashtagMedia
    {
        [JsonProperty("hashtag")]
        public Hashtag Hashtag { get; set; }
    }
    public class Hashtag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("media_count")]
        public int MediaCount { get; set; }

        [JsonProperty("search_result_subtitle")]
        public string SearchResultSubtitle { get; set; }

        [JsonProperty("allow_following")]
        public bool AllowFollowing { get; set; }

        [JsonProperty("is_following")]
        public bool IsFollowing { get; set; }

        [JsonProperty("is_top_media_only")]
        public bool IsTopMediaOnly { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("edge_hashtag_to_media")]
        public EdgeHashtagToMedia EdgeHashtagToMedia { get; set; }

        [JsonProperty("edge_hashtag_to_top_posts")]
        public EdgeHashtagToTopPosts EdgeHashtagToTopPosts { get; set; }
    }
}
