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
    public class UserData
    {
        [JsonProperty("config")]
        public Config Config { get; set; }

        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("language_code")]
        public string LanguageCode { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("entry_data")]
        public EntryData EntryData { get; set; }

        [JsonProperty("rhx_gis")]
        public string RhxGis { get; set; }

        [JsonProperty("nonce")]
        public string Nonce { get; set; }
    }
    public class Viewer
    {
        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; }

        [JsonProperty("full_name")]
        public string Fullname { get; set; }

        [JsonProperty("has_phone_number")]
        public bool HasPhoneNumber { get; set; }

        [JsonProperty("has_profile_pic")]
        public bool HasProfilePic { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_joined_recently")]
        public bool IsJoinedRecently { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("profile_pic_url_hd")]
        public string ProfilePicUrlHd { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("badge_count")]
        public string BadgeCount { get; set; }
    }
    public class Config
    {
        [JsonProperty("csrf_token")]
        public string CsrfToken { get; set; }

        [JsonProperty("viewer")]
        public Viewer Viewer { get; set; }

        [JsonProperty("viewerId")]
        public string ViewerId { get; set; }
    }
    public class EntryData
    {
        [JsonProperty("ProfilePage")]
        public List<ProfilePage> ProfilePage { get; set; }

        [JsonProperty("TagPage")]
        public List<TagPage> TagPage { get; set; }
    }
    public class ProfilePage
    {
        [JsonProperty("logging_page_id")]
        public string LoggingPageId { get; set; }

        [JsonProperty("graphql")]
        public Graphql Graphql { get; set; }
    }
    public class Graphql
    {
        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("hashtag")]
        public Hashtag Hashtag { get; set; }
    }
}
