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
    public class UserMedias
    {
        [JsonProperty("data")]
        public DataUserMedia Data { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public class DataUserMedia
    {
        [JsonProperty("user")]
        public User User { get; set; }
    }
    public class User
    {
        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("blocked_by_viewer")]
        public bool BlockedByViewer { get; set; }

        [JsonProperty("country_block")]
        public bool CountryBlock { get; set; }

        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; }

        [JsonProperty("external_url_linkshimmed")]
        public string ExternalUrlLinkshimmed { get; set; }

        [JsonProperty("followed_by_viewer")]
        public bool FollowedByViewer { get; set; }

        [JsonProperty("follows_viewer")]
        public bool FollowsViewer { get; set; }

        [JsonProperty("full_name")]
        public string Fullname { get; set; }

        [JsonProperty("has_channel")]
        public bool HasChannel { get; set; }

        [JsonProperty("has_blocked_viewer")]
        public bool HasBlockedViewer { get; set; }

        [JsonProperty("highlight_reel_count")]
        public int HighlightReelCount { get; set; }

        [JsonProperty("has_requested_viewer")]
        public bool HasRequestedViewer { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("is_business_account")]
        public bool IsBusinessAccount { get; set; }

        [JsonProperty("is_joined_recently")]
        public bool IsJoinedRecently { get; set; }

        [JsonProperty("business_category_name")]
        public string BusinessCategoryName { get; set; }

        [JsonProperty("is_private")]
        public bool IsPrivate { get; set; }

        [JsonProperty("is_verified")]
        public bool IsVerified { get; set; }

        [JsonProperty("profile_pic_url")]
        public string ProfilePicUrl { get; set; }

        [JsonProperty("profile_pic_url_hd")]
        public string ProfilePicUrlHd { get; set; }

        [JsonProperty("requested_by_viewer")]
        public bool RequestedByViewer { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("connected_fb_page")]
        public bool? ConnectedFbPage { get; set; }

        [JsonProperty("edge_followed_by")]
        public EdgeFollowedBy EdgeFollowedBy { get; set; }

        [JsonProperty("edge_follow")]
        public EdgeFollow EdgeFollow { get; set; }

        [JsonProperty("edge_owner_to_timeline_media")]
        public EdgeOwnerToTimelineMedia EdgeOwnerToTimelineMedia { get; set; }

        [JsonProperty("edge_saved_media")]
        public EdgeSavedMedia EdgeSavedMedia { get; set; }

        [JsonProperty("edge_mutual_followed_by")]
        public EdgeMutualFollowedBy EdgeMutualFollowedBy { get; set; }

        [JsonProperty("edge_user_to_photos_of_you")]
        public EdgeUserToPhotosOfYou EdgeUserToPhotosOfYou { get; set; }

        [JsonProperty("edge_activity_count")]
        public EdgeActivityCount EdgeActivityCount { get; set; }

        [JsonProperty("edge_following_hashtag")]
        public EdgeFollowingHashtag EdgeFollowingHashtag { get; set; }

        [JsonProperty("edge_web_feed_timeline")]
        public EdgeWebFeedTimeline EdgeWebFeedTimeline { get; set; }

        [JsonProperty("edge_web_discover_media")]
        public EdgeWebDiscoverMedia EdgeWebDiscoverMedia { get; set; }

        [JsonProperty("feed_reels_tray")]
        public FeedReelsTray FeedReelsTray { get; set; }

        [JsonProperty("activity_feed")]
        public ActivityFeed ActivityFeed { get; set; }

        #region [ Search properties ]
        [JsonProperty("pk")]
        public string Pk { get; set; }

        [JsonProperty("has_anonymous_profile_picture")]
        public bool HasAnonymousProfilePicture { get; set; }

        [JsonProperty("follower_count")]
        public int FollowerCount { get; set; }

        [JsonProperty("byline")]
        public string Byline { get; set; }

        [JsonProperty("social_context")]
        public string SocialContext { get; set; }

        [JsonProperty("search_social_context")]
        public string SearchSocialContext { get; set; }

        [JsonProperty("mutual_followers_count")]
        public int MutualFollowersCount { get; set; }

        [JsonProperty("latest_reel_media")]
        public long LatestReelMedia { get; set; }

        [JsonProperty("following")]
        public bool Following { get; set; }

        [JsonProperty("outgoing_request")]
        public bool OutgoingRequest { get; set; }

        [JsonProperty("seen")]
        public int? Seen { get; set; }

        [JsonProperty("unseen_count")]
        public int? UnseenCount { get; set; }
        #endregion
    }

    public class UserInfoData
    {
        [JsonProperty("form_data")]
        public UserInfo UserInfo { get; set; }
    }
    public class UserInfo
    {
        [JsonProperty("first_name")]
        public string Firstname { get; set; }

        [JsonProperty("last_name")]
        public string Lastname { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("is_email_confirmed")]
        public bool IsEmailConfirmed { get; set; }

        [JsonProperty("is_phone_confirmed")]
        public bool IsPhoneConfirmed { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonProperty("gender")]
        public int Gender { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("biography")]
        public string Biography { get; set; }

        [JsonProperty("external_url")]
        public string ExternalUrl { get; set; }

        [JsonProperty("chaining_enabled")]
        public bool ChainingEnabled { get; set; }

        [JsonProperty("presence_disabled")]
        public bool PresenceDisabled { get; set; }

        [JsonProperty("business_account")]
        public bool BusinessAccount { get; set; }

        [JsonProperty("usertag_review_enabled")]
        public bool UsertagReviewEnabled { get; set; }
    }
}
