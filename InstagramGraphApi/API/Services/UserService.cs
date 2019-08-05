/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using InstagramGraphApi.API.Constants;
using InstagramGraphApi.API.Services.Interfaces;
using InstagramGraphApi.Classes;
using InstagramGraphApi.Classes.Enums;
using InstagramGraphApi.Classes.Interfaces;
using InstagramGraphApi.Helpers;
using InstagramGraphApi.Entity;
using Newtonsoft.Json;
using System.Web;

namespace InstagramGraphApi.API.Services
{
    public class UserService : IUserService
    {
        private readonly UserSessionData _user;

        public UserService(UserSessionData user)
        {
            _user = user;
        }

        public IResult<EdgeOwnerToTimelineMediaNode> GetShortcodeMedia(string shortcode)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.SHORTCODE_URL, shortcode);
                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeOwnerToTimelineMediaNode>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<ShortcodeMediaData>(json);
                var media = objRetorno.Graphql.ShortcodeMedia;

                return Result.Success(media);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeOwnerToTimelineMediaNode>(ex.Message);
            }
        }
        public IResult<UserInfo> GetUserInfo()
        {
            try
            {
                var uri = InstagramGraphApiConstants.USER_INFO_URL;

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<UserInfo>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserInfoData>(json);
                var userInfo = objRetorno.UserInfo;

                return Result.Success(userInfo);
            }
            catch (Exception ex)
            {
                return Result.Fail<UserInfo>(ex.Message);
            }
        }
        public IResult<User> GetUser(string username)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.USER_DATA_URL, username);
                
                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var html = response.ReadAsString();
                var json = ApplicationHelper.ExtractJsonFromHtml(html);

                if(response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<User>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserData>(json);
                _user.UserRhxGis = objRetorno.RhxGis;                

                var user = objRetorno.EntryData.ProfilePage[0].Graphql.User;

                return Result.Success(user);
            }
            catch (Exception ex)
            {
                return Result.Fail<User>(ex.Message);
            }            
        }
        public IResult<User> GetUserDetails(string username)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.USER_DATA_URL, username);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var html = response.ReadAsString();
                var json = ApplicationHelper.ExtractJsonFromHtml(html);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<User>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserData>(json);
                _user.UserRhxGis = objRetorno.RhxGis;

                User user = objRetorno.EntryData.ProfilePage[0].Graphql.User;
                user.EdgeOwnerToTimelineMedia = null;
                user.EdgeSavedMedia = null;                

                return Result.Success(user);
            }
            catch (Exception ex)
            {
                return Result.Fail<User>(ex.Message);
            }
        }
        public IResult<User> GetWebDiscoverMedia(int limitPerPage = 24, int endCursor = 0)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.DISCOVER_MEDIAS_URL, limitPerPage, endCursor);

                var variables = string.Format("{0}:{{\"first\":{1},\"after\":\"{2}\"}}", _user.UserRhxGis, limitPerPage, endCursor);
                var signature = ApplicationHelper.CreateMD5(variables);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<User>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var medias = objRetorno.Data.User;

                return Result.Success(medias);
            }
            catch (Exception ex)
            {
                return Result.Fail<User>(ex.Message);
            }
        }
        public IResult<EdgeActivityCount> GetUserActivitySummary()
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.USER_ACTIVITY_SUMMARY, _user.UserId);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);                
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeActivityCount>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var activity = objRetorno.Data.User.EdgeActivityCount;

                return Result.Success(activity);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeActivityCount>(ex.Message);
            }
        }
        public IResult<ActivityFeed> GetUserActivityFeed()
        {
            try
            {
                var uri = InstagramGraphApiConstants.USER_ACTIVITY_FEED;

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<ActivityFeed>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<ProfilePage>(json);
                var activity = objRetorno.Graphql.User.ActivityFeed;

                return Result.Success(activity);
            }
            catch (Exception ex)
            {
                return Result.Fail<ActivityFeed>(ex.Message);
            }
        }
        public IResult<EdgeOwnerToTimelineMedia> GetUserMedias(string userid, string endCursor, int limitPerPage = 12)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.USER_TIMELINE_URL, userid, limitPerPage, endCursor);

                var variables = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2},\"after\":\"{3}\"}}", _user.UserRhxGis, userid, limitPerPage, endCursor);
                var signature = ApplicationHelper.CreateMD5(variables);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeOwnerToTimelineMedia>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var medias = objRetorno.Data.User.EdgeOwnerToTimelineMedia;

                return Result.Success(medias);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeOwnerToTimelineMedia>(ex.Message);
            }
        }        
        public IResult<EdgeOwnerToTimelineMedia> GetAllUserMedias(string username, int limitPerPage = 12)
        {
            EdgeOwnerToTimelineMedia EdgeOwnerToTimelineMedia = new EdgeOwnerToTimelineMedia();
            EdgeOwnerToTimelineMedia.Edges = new List<EdgeOwnerToTimelineMediaEdges>();
            
            var _userAllTimelineMedias = GetAllUserMediasInit(username, limitPerPage);

            var ImageMedias = _userAllTimelineMedias.Data.Edges.Where(c => c.Node.Typename == MediaType.Image).ToList();
            var SidecarMedias = _userAllTimelineMedias.Data.Edges.Where(c => c.Node.Typename == MediaType.Sidecar).ToList();
            var VideosMedias = _userAllTimelineMedias.Data.Edges.Where(c => c.Node.Typename == MediaType.Video).ToList();

            foreach(var image in ImageMedias)
            {
                EdgeOwnerToTimelineMedia.Edges.Add(new EdgeOwnerToTimelineMediaEdges() { Node = image.Node });
            }

            foreach(var sidecar in SidecarMedias)
            {
                var shortcode = sidecar.Node.Shortcode;

                var sidecarShortcodeData = GetShortcodeMedia(shortcode);

                EdgeOwnerToTimelineMedia.Edges.Add(new EdgeOwnerToTimelineMediaEdges() { Node = sidecarShortcodeData.Data });
            }

            foreach (var video in VideosMedias)
            {
                var shortcode = video.Node.Shortcode;

                var videoShortcodeData = GetShortcodeMedia(shortcode);

                EdgeOwnerToTimelineMedia.Edges.Add(new EdgeOwnerToTimelineMediaEdges() { Node = videoShortcodeData.Data });
            }

            return Result.Success(EdgeOwnerToTimelineMedia);
        }
        public IResult<EdgeWebFeedTimeline> GetUserTimelineMedias(string endCursor = null)
        {
            try
            {
                var uri = "";
                var variables = "";
                var signature = "";
                HttpWebRequest request = null;

                if (String.IsNullOrEmpty(endCursor))
                {
                    uri = InstagramGraphApiConstants.USER_TIMELINE_MEDIAS_INIT;
                    request = HttpHelper.GetDefaultRequest(uri);
                    request.Headers["Cookie"] = _user.UserCookie;                    
                }
                else
                {
                    uri = string.Format(InstagramGraphApiConstants.USER_TIMELINE_MEDIAS, endCursor);
                    variables = string.Format("{0}:{{\"cached_feed_item_ids\":[],\"fetch_media_item_count\":12,\"fetch_media_item_cursor\":\"{0}\",\"fetch_comment_count\":4,\"fetch_like\":3,\"has_stories\":false,\"has_threaded_comments\":true}}", _user.UserRhxGis, endCursor);
                    signature = ApplicationHelper.CreateMD5(variables);

                    request = HttpHelper.GetDefaultRequest(uri);
                    request.Headers["Cookie"] = _user.UserCookie;
                    request.Headers["X-Instagram-GIS"] = signature;
                }
                                                
                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeWebFeedTimeline>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var medias = objRetorno.Data.User.EdgeWebFeedTimeline;

                return Result.Success(medias);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeWebFeedTimeline>(ex.Message);
            }
        }
        public IResult<EdgeSavedMedia> GetSavedUserMedias(int limitPerPage = 12)
        {
            EdgeSavedMedia EdgeSavedMedia = new EdgeSavedMedia();
            EdgeSavedMedia.Edges = new List<EdgeSavedMediaEdges>();

            var _userAllSavedMedias = GetSavedUserMediasInit(_user.Username, limitPerPage);

            var ImageMedias = _userAllSavedMedias.Data.Edges.Where(c => c.Node.Typename == MediaType.Image).ToList();
            var SidecarMedias = _userAllSavedMedias.Data.Edges.Where(c => c.Node.Typename == MediaType.Sidecar).ToList();
            var VideosMedias = _userAllSavedMedias.Data.Edges.Where(c => c.Node.Typename == MediaType.Video).ToList();

            foreach (var image in ImageMedias)
            {
                EdgeSavedMedia.Edges.Add(new EdgeSavedMediaEdges() { Node = image.Node });
            }

            foreach (var sidecar in SidecarMedias)
            {
                var shortcode = sidecar.Node.Shortcode;

                var sidecarShortcodeData = GetShortcodeSavedMedia(shortcode);

                EdgeSavedMedia.Edges.Add(new EdgeSavedMediaEdges() { Node = sidecarShortcodeData.Data });
            }

            foreach (var video in VideosMedias)
            {
                var shortcode = video.Node.Shortcode;

                var videoShortcodeData = GetShortcodeSavedMedia(shortcode);

                EdgeSavedMedia.Edges.Add(new EdgeSavedMediaEdges() { Node = videoShortcodeData.Data });
            }

            return Result.Success(EdgeSavedMedia);
        }
        public IResult<EdgeUserToPhotosOfYou> GetTaggedUserMedias(string userId, int limitPerPage = 12)
        {
            EdgeUserToPhotosOfYou EdgeUserToPhotosOfYou = new EdgeUserToPhotosOfYou();
            EdgeUserToPhotosOfYou.Edges = new List<EdgeUserToPhotosOfYouEdges>();

            var _userAllTaggedMedias = GetTaggedMediasInit(userId, limitPerPage);

            var ImageMedias = _userAllTaggedMedias.Data.Edges.Where(c => c.Node.Typename == MediaType.Image).ToList();
            var SidecarMedias = _userAllTaggedMedias.Data.Edges.Where(c => c.Node.Typename == MediaType.Sidecar).ToList();
            var VideosMedias = _userAllTaggedMedias.Data.Edges.Where(c => c.Node.Typename == MediaType.Video).ToList();

            foreach (var image in ImageMedias)
            {
                EdgeUserToPhotosOfYou.Edges.Add(new EdgeUserToPhotosOfYouEdges() { Node = image.Node });
            }

            foreach (var sidecar in SidecarMedias)
            {
                var shortcode = sidecar.Node.Shortcode;

                var sidecarShortcodeData = GetShortcodeTaggedMedia(shortcode);

                EdgeUserToPhotosOfYou.Edges.Add(new EdgeUserToPhotosOfYouEdges() { Node = sidecarShortcodeData.Data });
            }

            foreach (var video in VideosMedias)
            {
                var shortcode = video.Node.Shortcode;

                var videoShortcodeData = GetShortcodeTaggedMedia(shortcode);

                EdgeUserToPhotosOfYou.Edges.Add(new EdgeUserToPhotosOfYouEdges() { Node = videoShortcodeData.Data });
            }

            return Result.Success(EdgeUserToPhotosOfYou);
        }
        public IResult<EdgeFollowedBy> GetUserFollowers(string userId, int limitPerPage = 12)
        {
            try
            {
                var uriInit = string.Format(InstagramGraphApiConstants.USER_FOLLOWERS_INIT, userId, limitPerPage);
                var variablesInit = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2} }}", _user.UserRhxGis, userId, limitPerPage);
                var signatureInit = ApplicationHelper.CreateMD5(variablesInit);

                var request = HttpHelper.GetDefaultRequest(uriInit);
                request.Headers["X-Instagram-GIS"] = signatureInit;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeFollowedBy>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var followers = objRetorno.Data.User.EdgeFollowedBy;
                string endCursorFollowers = objRetorno.Data.User.EdgeFollowedBy.PageInfo.EndCursor;

                if (followers.PageInfo.HasNextPage)
                {
                    bool has_next_page = true;

                    do
                    {
                        var uri = string.Format(InstagramGraphApiConstants.USER_FOLLOWERS, userId, limitPerPage, endCursorFollowers);

                        var variablesMedias = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2},\"after\":\"{3}\"}}", _user.UserRhxGis, userId, limitPerPage, endCursorFollowers);
                        var signatureMedias = ApplicationHelper.CreateMD5(variablesMedias);

                        var requestMedias = HttpHelper.GetDefaultRequest(uri);
                        requestMedias.Headers["X-Instagram-GIS"] = signatureMedias;
                        requestMedias.Headers["Cookie"] = _user.UserCookie;

                        var responseFollowers = HttpHelper.GetDefaultResponse(requestMedias);
                        var jsonFollowers = responseFollowers.ReadAsString();

                        if (responseFollowers.StatusCode != HttpStatusCode.OK)
                        {
                            return Result.UnExpectedResponse<EdgeFollowedBy>(responseFollowers, jsonFollowers);
                        }

                        var objRetornoFollowers = JsonConvert.DeserializeObject<UserMedias>(jsonFollowers);

                        objRetornoFollowers.Data.User.EdgeFollowedBy.Edges.ForEach(c => followers.Edges.Add(c));

                        has_next_page = objRetornoFollowers.Data.User.EdgeFollowedBy.PageInfo.HasNextPage;

                        endCursorFollowers = objRetornoFollowers.Data.User.EdgeFollowedBy.PageInfo.EndCursor;

                    } while (has_next_page);
                }

                return Result.Success(followers);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeFollowedBy>(ex.Message);
            }
        }
        public IResult<EdgeFollow> GetUserFollowing(string userId, int limitPerPage = 12)
        {
            try
            {
                var uriInit = string.Format(InstagramGraphApiConstants.USER_FOLLOWING_INIT, userId, limitPerPage);
                var variablesInit = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2} }}", _user.UserRhxGis, userId, limitPerPage);
                var signatureInit = ApplicationHelper.CreateMD5(variablesInit);

                var request = HttpHelper.GetDefaultRequest(uriInit);
                request.Headers["X-Instagram-GIS"] = signatureInit;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeFollow>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var following = objRetorno.Data.User.EdgeFollow;
                string endCursorFollowing = objRetorno.Data.User.EdgeFollow.PageInfo.EndCursor;

                if (following.PageInfo.HasNextPage)
                {
                    bool has_next_page = true;

                    do
                    {
                        var uri = string.Format(InstagramGraphApiConstants.USER_FOLLOWING, userId, limitPerPage, endCursorFollowing);

                        var variablesMedias = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2},\"after\":\"{3}\"}}", _user.UserRhxGis, userId, limitPerPage, endCursorFollowing);
                        var signatureMedias = ApplicationHelper.CreateMD5(variablesMedias);

                        var requestMedias = HttpHelper.GetDefaultRequest(uri);
                        requestMedias.Headers["X-Instagram-GIS"] = signatureMedias;
                        requestMedias.Headers["Cookie"] = _user.UserCookie;

                        var responseFollowers = HttpHelper.GetDefaultResponse(requestMedias);
                        var jsonFollowers = responseFollowers.ReadAsString();

                        if (responseFollowers.StatusCode != HttpStatusCode.OK)
                        {
                            return Result.UnExpectedResponse<EdgeFollow>(responseFollowers, jsonFollowers);
                        }

                        var objRetornoFollowing = JsonConvert.DeserializeObject<UserMedias>(jsonFollowers);

                        objRetornoFollowing.Data.User.EdgeFollow.Edges.ForEach(c => following.Edges.Add(c));

                        has_next_page = objRetornoFollowing.Data.User.EdgeFollow.PageInfo.HasNextPage;

                        endCursorFollowing = objRetornoFollowing.Data.User.EdgeFollow.PageInfo.EndCursor;

                    } while (has_next_page);
                }

                return Result.Success(following);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeFollow>(ex.Message);
            }
        }
        public IResult<EdgeFollowingHashtag> GetUserHashtagFollowing(string userId)
        {
            try
            {
                var uriInit = string.Format(InstagramGraphApiConstants.USER_FOLLOWING_HASHTAG, userId);
                var variablesInit = string.Format("{0}:{{\"id\":\"{1}\"}}", _user.UserRhxGis, userId);
                var signatureInit = ApplicationHelper.CreateMD5(variablesInit);

                var request = HttpHelper.GetDefaultRequest(uriInit);
                request.Headers["X-Instagram-GIS"] = signatureInit;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeFollowingHashtag>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var hashtags = objRetorno.Data.User.EdgeFollowingHashtag;
                return Result.Success(hashtags);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeFollowingHashtag>(ex.Message);
            }
        }
        public IResult<FeedReelsTray> GetRecentsFollowingUsersStories()
        {
            try
            {
                var uri = InstagramGraphApiConstants.RECENTS_FOLLOWING_USERS_STORIES;

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<FeedReelsTray>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var recents_users_stories = objRetorno.Data.User.FeedReelsTray;

                return Result.Success(recents_users_stories);
            }
            catch (Exception ex)
            {
                return Result.Fail<FeedReelsTray>(ex.Message);
            }
        }
        public IResult<DataStoryMedia> GetRecentsStoriesByUserId(string userId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.RECENTS_STORIES_BY_USER_ID, userId);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<DataStoryMedia>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<StoryMedias>(json);
                var recents_user_stories = objRetorno.Data;

                return Result.Success(recents_user_stories);
            }
            catch (Exception ex)
            {
                return Result.Fail<DataStoryMedia>(ex.Message);
            }
        }
        public IResult<DataStoryMedia> GetFeaturedStoriesByUserId(string userId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.DESTAQUES_STORIES_BY_USER_ID, userId);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<DataStoryMedia>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<StoryMedias>(json);
                var recents_user_stories = objRetorno.Data;

                return Result.Success(recents_user_stories);
            }
            catch (Exception ex)
            {
                return Result.Fail<DataStoryMedia>(ex.Message);
            }
        }
        public IResult<DataStoryMedia> GetFeaturedStoriesByHighlightReelIds(string[] highlight_reel_ids)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.DESTAQUES_DATA_STORIES_BY_USER_ID, GetFormattedHighlightReelIds(highlight_reel_ids));

                var variables = string.Format("{0}:{{ \"reel_ids\":[],\"tag_names\":[],\"location_ids\":[],\"highlight_reel_ids\":[{0}],\"precomposed_overlay\":false,\"show_story_viewer_list\":true,\"story_viewer_fetch_count\":50,\"story_viewer_cursor\":\"\"}}", highlight_reel_ids);
                var signature = ApplicationHelper.CreateMD5(variables);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<DataStoryMedia>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<StoryMedias>(json);
                var recents_user_stories = objRetorno.Data;

                return Result.Success(recents_user_stories);
            }
            catch (Exception ex)
            {
                return Result.Fail<DataStoryMedia>(ex.Message);
            }
        }              
        public IResult<DataStoryMedia> GetStoryByUserIds(string[] userIds)
        {
            return null;
        }
        public IResult<DataStoryMedia> GetSuggestedUsers(string userId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.SUGGESTED_USERS, userId);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<DataStoryMedia>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<StoryMedias>(json);
                var recents_user_stories = objRetorno.Data;

                return Result.Success(recents_user_stories);
            }
            catch (Exception ex)
            {
                return Result.Fail<DataStoryMedia>(ex.Message);
            }
        }
        public IResult<ShortcodeMediaLikes> GetMediaLikes(string shortcode, string endCursor = null, int limitPerPage = 24)
        {
            try
            {
                string uri = string.Empty;
                string variables = string.Empty;

                if (endCursor == null)
                {
                    uri = string.Format(InstagramGraphApiConstants.MEDIA_LIKES_INIT, shortcode, limitPerPage);
                    variables = string.Format("{0}:{{\"shortcode\":\"{1}\",\"include_reel\":true,\"first\":{2} }}", _user.UserRhxGis, shortcode, limitPerPage);
                }
                else
                {
                    uri = string.Format(InstagramGraphApiConstants.MEDIA_LIKES_URL, shortcode, limitPerPage, endCursor);
                    variables = string.Format("{0}:{{\"shortcode\":\"{1}\",\"include_reel\":true,\"first\":{2},\"after\":\"{3}\"}}", _user.UserRhxGis, shortcode, limitPerPage, endCursor);
                }

                var signature = ApplicationHelper.CreateMD5(variables);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<ShortcodeMediaLikes>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<ShortcodeMediaLikesData>(json);

                return Result.Success(objRetorno.Data);
            }
            catch (Exception ex)
            {
                return Result.Fail<ShortcodeMediaLikes>(ex.Message);
            }
        }


        #region [ Private Methods ]                
        private static string GetFormattedHighlightReelIds(string[] highlight_reel_ids)
        {
            //return string.Join("%22%2C%22", highlight_reel_ids);
            return HttpUtility.UrlEncode(string.Join("\",\"", highlight_reel_ids)).ToUpper();
        }

        private IResult<EdgeOwnerToTimelineMedia> GetAllUserMediasInit(string username, int limitPerPage)
        {
            try
            {
                EdgeOwnerToTimelineMedia _EdgeOwnerToTimelineMedia = new EdgeOwnerToTimelineMedia();
                _EdgeOwnerToTimelineMedia.Edges = new List<EdgeOwnerToTimelineMediaEdges>();

                var user = GetUser(username).Data;
                _EdgeOwnerToTimelineMedia.Edges = user.EdgeOwnerToTimelineMedia.Edges;

                var userId = user.Id;
                var endCursor = user.EdgeOwnerToTimelineMedia.PageInfo.EndCursor;

                var uri = string.Format(InstagramGraphApiConstants.USER_TIMELINE_URL, userId, limitPerPage, endCursor);

                var variables = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2},\"after\":\"{3}\"}}", _user.UserRhxGis, userId, limitPerPage, endCursor);
                var signature = ApplicationHelper.CreateMD5(variables);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeOwnerToTimelineMedia>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var medias = objRetorno.Data.User.EdgeOwnerToTimelineMedia;
                string endCursorMedias = objRetorno.Data.User.EdgeOwnerToTimelineMedia.PageInfo.EndCursor;

                if (medias.PageInfo.HasNextPage)
                {
                    bool has_next_page = true;

                    do
                    {
                        var uriMedias = string.Format(InstagramGraphApiConstants.USER_TIMELINE_URL, userId, limitPerPage, endCursorMedias);

                        var variablesMedias = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2},\"after\":\"{3}\"}}", _user.UserRhxGis, userId, limitPerPage, endCursorMedias);
                        var signatureMedias = ApplicationHelper.CreateMD5(variablesMedias);

                        var requestMedias = HttpHelper.GetDefaultRequest(uriMedias);
                        requestMedias.Headers["X-Instagram-GIS"] = signatureMedias;
                        requestMedias.Headers["Cookie"] = _user.UserCookie;

                        var responseMedias = HttpHelper.GetDefaultResponse(requestMedias);
                        var jsonMedias = responseMedias.ReadAsString();

                        if (responseMedias.StatusCode != HttpStatusCode.OK)
                        {
                            return Result.UnExpectedResponse<EdgeOwnerToTimelineMedia>(responseMedias, jsonMedias);
                        }

                        var objRetornoMedias = JsonConvert.DeserializeObject<UserMedias>(jsonMedias);

                        objRetornoMedias.Data.User.EdgeOwnerToTimelineMedia.Edges.ForEach(c => medias.Edges.Add(c));

                        has_next_page = objRetornoMedias.Data.User.EdgeOwnerToTimelineMedia.PageInfo.HasNextPage;

                        endCursorMedias = objRetornoMedias.Data.User.EdgeOwnerToTimelineMedia.PageInfo.EndCursor;

                    } while (has_next_page);
                }

                medias.Edges.ForEach(c => _EdgeOwnerToTimelineMedia.Edges.Add(c));

                return Result.Success(_EdgeOwnerToTimelineMedia);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeOwnerToTimelineMedia>(ex.Message);
            }
        }

        private IResult<EdgeSavedMedia> GetSavedUserMediasInit(string username, int limitPerPage)
        {
            try
            {
                EdgeSavedMedia _EdgeSavedMedia = new EdgeSavedMedia();
                _EdgeSavedMedia.Edges = new List<EdgeSavedMediaEdges>();

                var user = GetUser(username).Data;
                _EdgeSavedMedia.Edges = user.EdgeSavedMedia.Edges;

                var userId = user.Id;
                var endCursor = user.EdgeSavedMedia.PageInfo.EndCursor;

                var uri = string.Format(InstagramGraphApiConstants.USER_SAVED_MEDIAS_URL, userId, limitPerPage, endCursor);

                var variables = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2},\"after\":\"{3}\"}}", _user.UserRhxGis, userId, limitPerPage, endCursor);
                var signature = ApplicationHelper.CreateMD5(variables);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeSavedMedia>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var medias = objRetorno.Data.User.EdgeSavedMedia;
                string endCursorMedias = objRetorno.Data.User.EdgeSavedMedia.PageInfo.EndCursor;

                if (medias.PageInfo.HasNextPage)
                {
                    bool has_next_page = true;

                    do
                    {
                        var uriMedias = string.Format(InstagramGraphApiConstants.USER_SAVED_MEDIAS_URL, userId, limitPerPage, endCursorMedias);

                        var variablesMedias = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2},\"after\":\"{3}\"}}", _user.UserRhxGis, userId, limitPerPage, endCursorMedias);
                        var signatureMedias = ApplicationHelper.CreateMD5(variablesMedias);

                        var requestMedias = HttpHelper.GetDefaultRequest(uriMedias);
                        requestMedias.Headers["X-Instagram-GIS"] = signatureMedias;
                        requestMedias.Headers["Cookie"] = _user.UserCookie;

                        var responseMedias = HttpHelper.GetDefaultResponse(requestMedias);
                        var jsonMedias = responseMedias.ReadAsString();

                        if (responseMedias.StatusCode != HttpStatusCode.OK)
                        {
                            return Result.UnExpectedResponse<EdgeSavedMedia>(responseMedias, jsonMedias);
                        }

                        var objRetornoMedias = JsonConvert.DeserializeObject<UserMedias>(jsonMedias);

                        objRetornoMedias.Data.User.EdgeSavedMedia.Edges.ForEach(c => medias.Edges.Add(c));

                        has_next_page = objRetornoMedias.Data.User.EdgeSavedMedia.PageInfo.HasNextPage;

                        endCursorMedias = objRetornoMedias.Data.User.EdgeSavedMedia.PageInfo.EndCursor;

                    } while (has_next_page);
                }

                medias.Edges.ForEach(c => _EdgeSavedMedia.Edges.Add(c));

                return Result.Success(_EdgeSavedMedia);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeSavedMedia>(ex.Message);
            }
        }
        private IResult<EdgeSavedMediaNode> GetShortcodeSavedMedia(string shortcode)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.SHORTCODE_URL, shortcode);
                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeSavedMediaNode>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<ShortcodeSavedMediaData>(json);
                var media = objRetorno.Graphql.ShortcodeSavedMedia;

                return Result.Success(media);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeSavedMediaNode>(ex.Message);
            }
        }


        private IResult<EdgeUserToPhotosOfYou> GetTaggedMediasInit(string userId, int limitPerPage)
        {
            try
            {
                var uriInit = string.Format(InstagramGraphApiConstants.USER_TO_PHOTOS_OF_YOU_INIT, userId, limitPerPage);
                var variablesInit = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2} }}", _user.UserRhxGis, userId, limitPerPage);
                var signatureInit = ApplicationHelper.CreateMD5(variablesInit);

                var request = HttpHelper.GetDefaultRequest(uriInit);
                request.Headers["X-Instagram-GIS"] = signatureInit;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeUserToPhotosOfYou>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<UserMedias>(json);
                var medias = objRetorno.Data.User.EdgeUserToPhotosOfYou;
                string endCursorMedias = objRetorno.Data.User.EdgeUserToPhotosOfYou.PageInfo.EndCursor;

                if (medias.PageInfo.HasNextPage)
                {
                    bool has_next_page = true;

                    do
                    {
                        var uriMedias = string.Format(InstagramGraphApiConstants.USER_TO_PHOTOS_OF_YOU, userId, limitPerPage, endCursorMedias);

                        var variablesMedias = string.Format("{0}:{{\"id\":\"{1}\",\"first\":{2},\"after\":\"{3}\"}}", _user.UserRhxGis, userId, limitPerPage, endCursorMedias);
                        var signatureMedias = ApplicationHelper.CreateMD5(variablesMedias);

                        var requestMedias = HttpHelper.GetDefaultRequest(uriMedias);
                        requestMedias.Headers["X-Instagram-GIS"] = signatureMedias;
                        requestMedias.Headers["Cookie"] = _user.UserCookie;

                        var responseMedias = HttpHelper.GetDefaultResponse(requestMedias);
                        var jsonMedias = responseMedias.ReadAsString();

                        if (responseMedias.StatusCode != HttpStatusCode.OK)
                        {
                            return Result.UnExpectedResponse<EdgeUserToPhotosOfYou>(responseMedias, jsonMedias);
                        }

                        var objRetornoMedias = JsonConvert.DeserializeObject<UserMedias>(jsonMedias);

                        objRetornoMedias.Data.User.EdgeUserToPhotosOfYou.Edges.ForEach(c => medias.Edges.Add(c));

                        has_next_page = objRetornoMedias.Data.User.EdgeUserToPhotosOfYou.PageInfo.HasNextPage;

                        endCursorMedias = objRetornoMedias.Data.User.EdgeUserToPhotosOfYou.PageInfo.EndCursor;

                    } while (has_next_page);
                }

                return Result.Success(medias);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeUserToPhotosOfYou>(ex.Message);
            }
        }
        private IResult<EdgeUserToPhotosOfYouNode> GetShortcodeTaggedMedia(string shortcode)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.SHORTCODE_URL, shortcode);
                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeUserToPhotosOfYouNode>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<ShortcodeTaggedMediaData>(json);
                var media = objRetorno.Graphql.ShortcodeTaggedMedia;

                return Result.Success(media);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeUserToPhotosOfYouNode>(ex.Message);
            }
        }

        
        #endregion
    }
}
