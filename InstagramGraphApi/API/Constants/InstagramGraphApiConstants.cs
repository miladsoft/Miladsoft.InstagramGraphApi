/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstagramGraphApi.API.Constants
{
    internal static class InstagramGraphApiConstants
    {
        public const string INSTAGRAM_URL = "https://www.instagram.com";
        
        public const string LOGIN_GET_REQUEST_ACCEPT = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
        public const string LOGIN_POST_REQUEST_ACCEPT = "*/*";
        public const string USER_AGENT = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.86 Safari/537.36";


        public const string LOGIN_URL = INSTAGRAM_URL + "/accounts/login/?source=auth_switcher";
        public const string LOGIN_RESPONSE_URL = INSTAGRAM_URL + "/accounts/login/ajax/";

        public const string USER_INFO_URL = INSTAGRAM_URL + "/accounts/edit/?__a=1";

        public const string USER_DATA_URL = INSTAGRAM_URL + "/{0}";

        public const string SHORTCODE_URL = INSTAGRAM_URL + "/p/{0}/?__a=1";

        public const string REQUEST_DOWNLOAD_DATA_URL = INSTAGRAM_URL + "/download/request_download_data_ajax/";

        public const string EXPLORE_TAG_DATA_INIT = INSTAGRAM_URL + "/explore/tags/{0}";
        public const string EXPLORE_TAG_DATA = "https://www.instagram.com/graphql/query/?query_hash=f92f56d47dc7a55b606908374b43a314&variables=%7B%22tag_name%22%3A%22{0}%22%2C%22show_ranked%22%3Afalse%2C%22first%22%3A{1}%2C%22after%22%3A%22{2}%22%7D";
        public const string EXPLORE_TAG_SHORTCODE_DATA = "https://www.instagram.com/graphql/query/?query_hash=477b65a610463740ccdb83135b2014db&variables=%7B%22shortcode%22%3A%22{0}%22%2C%22child_comment_count%22%3A10%2C%22fetch_comment_count%22%3A40%2C%22parent_comment_count%22%3A24%2C%22has_threaded_comments%22%3Atrue%7D";

        public const string SEARCH_URL = "https://www.instagram.com/web/search/topsearch/?context=blended&query={0}&rank_token=0.4047735978789335&include_reel=true";

        public const string USER_ACTIVITY_SUMMARY = "https://www.instagram.com/graphql/query/?query_hash=0f318e8cfff9cc9ef09f88479ff571fb&variables=%7B%22id%22%3A%22{0}%22%7D";
        public const string USER_ACTIVITY_FEED = INSTAGRAM_URL + "/accounts/activity/?__a=1&include_reel=true";

        public const string SUGGESTED_USERS = "https://www.instagram.com/graphql/query/?query_hash=7c16654f22c819fb63d1183034a5162f&variables=%7B%22user_id%22%3A%22{0}%22%2C%22include_chaining%22%3Atrue%2C%22include_reel%22%3Atrue%2C%22include_suggested_users%22%3Atrue%2C%22include_logged_out_extras%22%3Afalse%2C%22include_highlight_reels%22%3Atrue%7D";

        public const string USER_TIMELINE_URL = "https://www.instagram.com/graphql/query/?query_hash=f2405b236d85e8296cf30347c9f08c2a&variables=%7B%22id%22%3A%22{0}%22%2C%22first%22%3A{1}%2C%22after%22%3A%22{2}%22%7D";

        public const string USER_SAVED_MEDIAS_URL = "https://www.instagram.com/graphql/query/?query_hash=8c86fed24fa03a8a2eea2a70a80c7b6b&variables=%7B%22id%22%3A%22{0}%22%2C%22first%22%3A{1}%2C%22after%22%3A%22{2}%22%7D";

        public const string USER_TIMELINE_MEDIAS_INIT = "https://www.instagram.com/graphql/query/?query_hash=e59e186af2a0f74e2477de230f68d30c&variables=%7B%22has_threaded_comments%22%3Atrue%7D";
        public const string USER_TIMELINE_MEDIAS = "https://www.instagram.com/graphql/query/?query_hash=e59e186af2a0f74e2477de230f68d30c&variables=%7B%22cached_feed_item_ids%22%3A%5B%5D%2C%22fetch_media_item_count%22%3A12%2C%22fetch_media_item_cursor%22%3A%22{0}%22%2C%22fetch_comment_count%22%3A4%2C%22fetch_like%22%3A3%2C%22has_stories%22%3Afalse%2C%22has_threaded_comments%22%3Atrue%7D";

        public const string USER_TO_PHOTOS_OF_YOU_INIT = "https://www.instagram.com/graphql/query/?query_hash=ff260833edf142911047af6024eb634a&variables=%7B%22id%22%3A%22{0}%22%2C%22first%22%3A{1}%7D";
        public const string USER_TO_PHOTOS_OF_YOU = "https://www.instagram.com/graphql/query/?query_hash=ff260833edf142911047af6024eb634a&variables=%7B%22id%22%3A%22{0}%22%2C%22first%22%3A{1}%2C%22after%22%3A%22{2}%22%7D";

        public const string USER_FOLLOWERS_INIT = "https://www.instagram.com/graphql/query/?query_hash=56066f031e6239f35a904ac20c9f37d9&variables=%7B%22id%22%3A%22{0}%22%2C%22include_reel%22%3Atrue%2C%22fetch_mutual%22%3Atrue%2C%22first%22%3A{1}%7D";
        public const string USER_FOLLOWERS = "https://www.instagram.com/graphql/query/?query_hash=56066f031e6239f35a904ac20c9f37d9&variables=%7B%22id%22%3A%22{0}%22%2C%22include_reel%22%3Atrue%2C%22fetch_mutual%22%3Afalse%2C%22first%22%3A{1}%2C%22after%22%3A%22{2}%22%7D";

        public const string USER_FOLLOWING_INIT = "https://www.instagram.com/graphql/query/?query_hash=c56ee0ae1f89cdbd1c89e2bc6b8f3d18&variables=%7B%22id%22%3A%22{0}%22%2C%22include_reel%22%3Atrue%2C%22fetch_mutual%22%3Afalse%2C%22first%22%3A{1}%7D";
        public const string USER_FOLLOWING = "https://www.instagram.com/graphql/query/?query_hash=c56ee0ae1f89cdbd1c89e2bc6b8f3d18&variables=%7B%22id%22%3A%22{0}%22%2C%22include_reel%22%3Atrue%2C%22fetch_mutual%22%3Afalse%2C%22first%22%3A{1}%2C%22after%22%3A%22{2}%22%7D";

        public const string USER_FOLLOWING_HASHTAG = "https://www.instagram.com/graphql/query/?query_hash=e6306cc3dbe69d6a82ef8b5f8654c50b&variables=%7B%22id%22%3A%22{0}%22%7D";

        public const string RECENTS_FOLLOWING_USERS_STORIES = "https://www.instagram.com/graphql/query/?query_hash=bb52bbcf154da2ce65493b19bda2b85c&variables=%7B%22only_stories%22%3Atrue%2C%22stories_prefetch%22%3Atrue%7D";

        public const string RECENTS_STORIES_BY_USER_ID = "https://www.instagram.com/graphql/query/?query_hash=45246d3fe16ccc6577e0bd297a5db1ab&variables=%7B%22reel_ids%22%3A%5B%22{0}%22%5D%2C%22tag_names%22%3A%5B%5D%2C%22location_ids%22%3A%5B%5D%2C%22highlight_reel_ids%22%3A%5B%5D%2C%22precomposed_overlay%22%3Afalse%7D";

        public const string DESTAQUES_STORIES_BY_USER_ID = "https://www.instagram.com/graphql/query/?query_hash=7c16654f22c819fb63d1183034a5162f&variables=%7B%22user_id%22%3A%22{0}%22%2C%22include_chaining%22%3Atrue%2C%22include_reel%22%3Atrue%2C%22include_suggested_users%22%3Afalse%2C%22include_logged_out_extras%22%3Afalse%2C%22include_highlight_reels%22%3Atrue%7D";
        public const string DESTAQUES_DATA_STORIES_BY_USER_ID = "https://www.instagram.com/graphql/query/?query_hash=d884801a7354d2b9325532892372f8ae&variables=%7B%22reel_ids%22%3A%5B%5D%2C%22tag_names%22%3A%5B%5D%2C%22location_ids%22%3A%5B%5D%2C%22highlight_reel_ids%22%3A%5B%22{0}%22%5D%2C%22precomposed_overlay%22%3Afalse%2C%22show_story_viewer_list%22%3Atrue%2C%22story_viewer_fetch_count%22%3A50%2C%22story_viewer_cursor%22%3A%22%22%7D";

        public const string STORIES_BY_USER_IDS = "https://www.instagram.com/graphql/query/?query_hash=db3e2df1d491e043b1a767a68b8378b0&variables=%7B%22reel_ids%22%3A%5B%22{0}%22%5D%2C%22tag_names%22%3A%5B%5D%2C%22location_ids%22%3A%5B%5D%2C%22highlight_reel_ids%22%3A%5B%5D%2C%22precomposed_overlay%22%3Afalse%2C%22show_story_viewer_list%22%3Atrue%2C%22story_viewer_fetch_count%22%3A50%2C%22story_viewer_cursor%22%3A%22%22%7D";

        public const string DISCOVER_MEDIAS_URL = "https://www.instagram.com/graphql/query/?query_hash=ecd67af449fb6edab7c69a205413bfa7&variables=%7B%22first%22%3A{0}%2C%22after%22%3A%22{1}%22%7D";

        public const string LIKE_URL = "https://www.instagram.com/web/likes/{0}/like/";

        public const string UNLIKE_URL = "https://www.instagram.com/web/likes/{0}/unlike/";

        public const string FOLLOW_URL = "https://www.instagram.com/web/friendships/{0}/follow/";

        public const string UNFOLLOW_URL = "https://www.instagram.com/web/friendships/{0}/unfollow/";

        public const string COMMENT_URL = "https://www.instagram.com/web/comments/{0}/add/";

        public const string DELETE_COMMENT_URL = "https://www.instagram.com/web/comments/{0}/delete/{1}/";

        public const string LIKE_COMMENT_URL = "https://www.instagram.com/web/comments/like/{0}/";

        public const string UNLIKE_COMMENT_URL = "https://www.instagram.com/web/comments/unlike/{0}/";

        public const string SAVE_MEDIA_URL = "https://www.instagram.com/web/save/{0}/save/";

        public const string UNSAVE_MEDIA_URL = "https://www.instagram.com/web/save/{0}/unsave/";

        public const string MEDIA_LIKES_INIT = "https://www.instagram.com/graphql/query/?query_hash=e0f59e4a1c8d78d0161873bc2ee7ec44&variables=%7B%22shortcode%22%3A%22{0}%22%2C%22include_reel%22%3Atrue%2C%22first%22%3A{1}%7D";
        public const string MEDIA_LIKES_URL =  "https://www.instagram.com/graphql/query/?query_hash=e0f59e4a1c8d78d0161873bc2ee7ec44&variables=%7B%22shortcode%22%3A%22{0}%22%2C%22include_reel%22%3Atrue%2C%22first%22%3A{1}%2C%22after%22%3A%22{2}%22%7D";

        public const string MEDIA_INFO_URL = "https://www.instagram.com/graphql/query/?query_hash=477b65a610463740ccdb83135b2014db&variables=%7B%22shortcode%22%3A%22{0}%22%2C%22child_comment_count%22%3A10%2C%22fetch_comment_count%22%3A40%2C%22parent_comment_count%22%3A40%2C%22has_threaded_comments%22%3Atrue%7D";

        public const string MEDIA_COMMENTS_URL = "https://www.instagram.com/graphql/query/?query_hash=97b41c52301f77ce508f55e66d17620e&variables=%7B%22shortcode%22%3A%22{0}%22%2C%22first%22%3A{1}%2C%22after%22%3A%22%7B%5C%22cached_comments_cursor%5C%22%3A+%5C%22{2}%5C%22%2C+%5C%22bifilter_token%5C%22%3A+%5C%22{3}%5C%22%7D%22%7D";

        public const string LIKES_FROM_COMMENT_INIT = "https://www.instagram.com/graphql/query/?query_hash=5f0b1f6281e72053cbc07909c8d154ae&variables=%7B%22comment_id%22%3A%22{0}%22%2C%22first%22%3A{1}%7D";
        public const string LIKES_FROM_COMMENT_URL =  "https://www.instagram.com/graphql/query/?query_hash=5f0b1f6281e72053cbc07909c8d154ae&variables=%7B%22comment_id%22%3A%22{0}%22%2C%22first%22%3A{1}%2C%22after%22%3A%22{2}%22%7D";

        public const string COMMENT_REPLIES_INIT = "https://www.instagram.com/graphql/query/?query_hash=51fdd02b67508306ad4484ff574a0b62&variables=%7B%22comment_id%22%3A%22{0}%22%2C%22first%22%3A{1}%7D";
        public const string COMMENT_REPLIES_URL =  "https://www.instagram.com/graphql/query/?query_hash=51fdd02b67508306ad4484ff574a0b62&variables=%7B%22comment_id%22%3A%22{0}%22%2C%22first%22%3A{1}%2C%22after%22%3A%22{2}%22%7D";

    }
}