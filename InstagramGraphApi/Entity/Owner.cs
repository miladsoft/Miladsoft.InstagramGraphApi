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
    public class Owner
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("__typename")]
        public string Typename { get; set; }

        [JsonProperty("followed_by_viewer")]
        public bool? FollowedByViewer { get; set; }

        [JsonProperty("requested_by_viewer")]
        public bool? RequestedByViewer { get; set; }
    }
}
