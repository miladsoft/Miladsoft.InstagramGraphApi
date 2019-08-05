/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
using InstagramGraphApi.Classes.Interfaces;
using InstagramGraphApi.Entity;

namespace InstagramGraphApi.API.Services.Interfaces
{
    public interface IUserService
    {        
        IResult<EdgeOwnerToTimelineMediaNode> GetShortcodeMedia(string shortcode);
        IResult<UserInfo> GetUserInfo();
        IResult<User> GetUser(string username);
        IResult<User> GetUserDetails(string username);
        IResult<User> GetWebDiscoverMedia(int limitPerPage = 24, int endCursor = 0);
        IResult<EdgeActivityCount> GetUserActivitySummary();
        IResult<ActivityFeed> GetUserActivityFeed();
        IResult<EdgeOwnerToTimelineMedia> GetUserMedias(string userid, string endCursor, int limitPerPage = 12);        
        IResult<EdgeOwnerToTimelineMedia> GetAllUserMedias(string username, int limitPerPage = 12);
        IResult<EdgeWebFeedTimeline> GetUserTimelineMedias(string endCursor = null);
        IResult<EdgeSavedMedia> GetSavedUserMedias(int limitPerPage = 12);
        IResult<EdgeUserToPhotosOfYou> GetTaggedUserMedias(string userId, int limitPerPage = 12);
        IResult<EdgeFollowedBy> GetUserFollowers(string userId, int limitPerPage = 12);
        IResult<EdgeFollow> GetUserFollowing(string userId, int limitPerPage = 12);
        IResult<EdgeFollowingHashtag> GetUserHashtagFollowing(string userId);
        IResult<FeedReelsTray> GetRecentsFollowingUsersStories();
        IResult<DataStoryMedia> GetRecentsStoriesByUserId(string userId);
        IResult<DataStoryMedia> GetFeaturedStoriesByUserId(string userId);
        IResult<DataStoryMedia> GetFeaturedStoriesByHighlightReelIds(string[] highlight_reel_ids);
        IResult<DataStoryMedia> GetStoryByUserIds(string[] userIds);
        IResult<DataStoryMedia> GetSuggestedUsers(string userId);
        IResult<ShortcodeMediaLikes> GetMediaLikes(string shortcode, string endCursor = null, int limitPerPage = 24);
    }
}
