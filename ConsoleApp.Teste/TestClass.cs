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
using InstagramGraphApi.API;
using InstagramGraphApi.Classes;
using InstagramGraphApi.Entity;

namespace ConsoleApp.Teste
{
    public class TestClass
    {
        private static IInstagramGraphApi _InstagramGraphApi;

        public TestClass(IInstagramGraphApi IInstagramGraphApi)
        {
            _InstagramGraphApi = IInstagramGraphApi;
        }

        public bool ExecuteLoginTest()
        {
            var loginResult = _InstagramGraphApi.Login();

            if (!loginResult.Authenticated)
            {
                Console.WriteLine("Unauthenticated");
                return false;
            }

            Console.WriteLine("Authenticated User");

            return true;
        }

        public User GetUserTest(string username)
        {
            return _InstagramGraphApi.GetUser(username).Data;
        }

        public User GetUserDetailsTest(string username)
        {
            return _InstagramGraphApi.GetUserDetails(username).Data;
        }

        public EdgeWebFeedTimeline GetUserTimelineMediasTest(string endCursor = null)
        {
            return _InstagramGraphApi.GetUserTimelineMedias(endCursor).Data;
        }

        public EdgeSavedMedia GetSavedUserMediasTest()
        {
            return _InstagramGraphApi.GetSavedUserMedias().Data;
        }

        public EdgeUserToPhotosOfYou GetTaggedUserMediasTest(string userId)
        {
            return _InstagramGraphApi.GetTaggedUserMedias(userId).Data;
        }

        public EdgeActivityCount GetUserActivitySummaryTest()
        {
            return _InstagramGraphApi.GetUserActivitySummary().Data;
        }

        public ActivityFeed GetUserActivityFeedTest()
        {
            return _InstagramGraphApi.GetUserActivityFeed().Data;
        }

        public FeedReelsTray GetRecentsFollowingUsersStoriesTest()
        {
            return _InstagramGraphApi.GetRecentsFollowingUsersStories().Data;
        }

        public DataStoryMedia GetStoryByUserIdsTest(string[] userIds)
        {
            return _InstagramGraphApi.GetStoryByUserIds(userIds).Data;
        }

        public DataStoryMedia GetRecentsStoriesByUserIdTest(string userId)
        {
            return _InstagramGraphApi.GetRecentsStoriesByUserId(userId).Data;
        }

        public DataStoryMedia GetFeaturedStoriesByUserIdTest(string userId)
        {
            return _InstagramGraphApi.GetFeaturedStoriesByUserId(userId).Data;
        }

        public DataStoryMedia GetFeaturedStoriesByHighlightReelIdsTest(string[] highlight_reel_ids)
        {
            return _InstagramGraphApi.GetFeaturedStoriesByHighlightReelIds(highlight_reel_ids).Data;
        }

        public DataStoryMedia GetSuggestedUsersTest(string userId)
        {
            return _InstagramGraphApi.GetSuggestedUsers(userId).Data;
        }

        public Search SearchTest(string query)
        {
            return _InstagramGraphApi.Search(query).Data;
        }

        public User GetWebDiscoverMediaTest(int limitPerPage = 24, int endCursor = 0)
        {
            return _InstagramGraphApi.GetWebDiscoverMedia(limitPerPage, endCursor).Data;
        }

        public string LikeTest(string mediaId)
        {
            return _InstagramGraphApi.Like(mediaId).Data;
        }

        public string UnlikeTest(string mediaId)
        {
            return _InstagramGraphApi.Unlike(mediaId).Data;
        }

        public string FollowTest(string userId)
        {
            return _InstagramGraphApi.Follow(userId).Data;
        }

        public string UnfollowTest(string userId)
        {
            return _InstagramGraphApi.Unfollow(userId).Data;
        }

        public CommentResponse CommentTest(string mediaId, string text)
        {
            return _InstagramGraphApi.Comment(mediaId, text).Data;
        }

        public string DeleteCommentTest(string mediaId, string commentId)
        {
            return _InstagramGraphApi.DeleteComment(mediaId, commentId).Data;
        }
        public string LikeCommentTest(string commentId)
        {
            return _InstagramGraphApi.LikeComment(commentId).Data;
        }
        public string UnlikeCommentTest(string commentId)
        {
            return _InstagramGraphApi.UnlikeComment(commentId).Data;
        }

        public string SaveMediaTest(string mediaId)
        {
            return _InstagramGraphApi.SaveMedia(mediaId).Data;
        }

        public string UnSaveMediaTest(string mediaId)
        {
            return _InstagramGraphApi.UnsaveMedia(mediaId).Data;
        }

        public string RequestDownloadDataInformationTest(string email)
        {
            return _InstagramGraphApi.RequestDownloadDataInformation(email).Data;
        }

        public Hashtag GetHashtagMediaInitTest(string hashtag)
        {
            return _InstagramGraphApi.GetHashtag(hashtag).Data;
        }

        public EdgeHashtagToMedia GetHashtagMediasTest(string hashtag, string endCursor, int limitPerPage = 12)
        {
            return _InstagramGraphApi.GetHashtagMedias(hashtag, endCursor, limitPerPage).Data;
        }

        public UserInfo GetUserInfoTest()
        {
            return _InstagramGraphApi.GetUserInfo().Data;
        }

        public ShortcodeMediaLikes GetMediaLikesTest(string shortcode, string endCursor = null, int limitPerPage = 24)
        {
            return _InstagramGraphApi.GetMediaLikes(shortcode, endCursor, limitPerPage).Data;
        }

        public ShortcodeMedia GetMediaInfoDataTest(string shortcode)
        {
            return _InstagramGraphApi.GetMediaInfoData(shortcode).Data;
        }

        public EdgeMediaToParentComment GetMediaCommentsTest(string shortcode, string endCursor, int limitPerPage = 12)
        {
            return _InstagramGraphApi.GetMediaComments(shortcode, endCursor, limitPerPage).Data;
        }

        public Comment GetLikesFromCommentTest(string comment_id, string endCursor = null, int limitPerPage = 48)
        {
            return _InstagramGraphApi.GetLikesFromComment(comment_id, endCursor, limitPerPage).Data;
        }

        public Comment GetCommentRepliesTest(string comment_id, string endCursor = null, int limitPerPage = 48)
        {
            return _InstagramGraphApi.GetCommentReplies(comment_id, endCursor, limitPerPage).Data;
        }
        public EdgeFollowedBy GetUserFollowers(string userId, int limitPerPage = 48)
        {
            return _InstagramGraphApi.GetUserFollowers(userId, limitPerPage).Data;
        }
        public EdgeFollow GetUserFollowing(string userId, int limitPerPage = 48)
        {
            return _InstagramGraphApi.GetUserFollowing(userId, limitPerPage).Data;
        }
    }
}
