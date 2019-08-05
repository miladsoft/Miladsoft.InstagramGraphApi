/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using InstagramGraphApi.API.Constants;
using InstagramGraphApi.API.Services;
using InstagramGraphApi.API.Services.Interfaces;
using InstagramGraphApi.Classes;
using InstagramGraphApi.Classes.Interfaces;
using InstagramGraphApi.Helpers;
using InstagramGraphApi.Entity;
using Newtonsoft.Json;

namespace InstagramGraphApi.API
{
    internal class InstagramGraphApi : IInstagramGraphApi
    {
        private UserSessionData _user;
        private IUserService _userService;
        private ISearchService _searchService;
        private IActionsService _actionService;
        public IHashtagService _hashtagService;
        public IMediaService _mediaService;

        public bool IsUserAuthenticated { get; private set; }
        public string Cookie { get; private set; }

        public InstagramGraphApi(UserSessionData user)
        {
            _user = user;
        }

        public AuthenticatedLogin Login()
        {
            ValidateUser();

            try
            {
                var uri = InstagramGraphApiConstants.LOGIN_URL;
                CookieContainer container = new CookieContainer();
                HttpWebRequest requestToken = (HttpWebRequest)WebRequest.Create(uri);
                requestToken.Method = "GET";
                requestToken.Accept = InstagramGraphApiConstants.LOGIN_GET_REQUEST_ACCEPT;
                requestToken.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                requestToken.CookieContainer = container;

                string csrftoken = string.Empty;
                using (HttpWebResponse responseToken = (HttpWebResponse)requestToken.GetResponse())
                {
                    foreach (Cookie cookie in responseToken.Cookies)
                    {
                        if (cookie.Name.Equals("csrftoken"))
                        {
                            csrftoken = cookie.Value;
                            _user.CsrfToken = csrftoken;
                        }
                    }
                }

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString.Add("username", _user.Username);
                queryString.Add("password", _user.Password);
                queryString.Add("queryParams", "{\"source\":\"auth_switcher\"}");
                queryString.Add("optIntoOneTap", "false");

                var formData = queryString.ToString();
                var data = Encoding.ASCII.GetBytes(formData);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(InstagramGraphApiConstants.LOGIN_RESPONSE_URL);
                request.Headers["x-csrftoken"] = csrftoken;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = InstagramGraphApiConstants.LOGIN_POST_REQUEST_ACCEPT;

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                AuthenticatedLogin AuthenticatedResponse = new AuthenticatedLogin();
                AuthenticatedResponse = JsonConvert.DeserializeObject<AuthenticatedLogin>(responseString);

                IsUserAuthenticated = AuthenticatedResponse.Authenticated;

                if (AuthenticatedResponse.Authenticated)
                {
                    string part1 = response.Headers.ToString().Split(new string[] { "Set-Cookie: " }, StringSplitOptions.RemoveEmptyEntries)[1];
                    string part2 = part1.Split(new string[] { "Connection: " }, StringSplitOptions.RemoveEmptyEntries)[0];
                    string SetCookie = part2;

                    var response_csrftoken = response.Headers.ToString().SplitString("csrftoken=")[1].Split(';')[0];
                    var response_mid = response.Headers.ToString().SplitString("mid=")[1].Split(';')[0];
                    var response_shbid = response.Headers.ToString().SplitString("shbid=")[1].Split(';')[0];
                    var response_shbts = response.Headers.ToString().SplitString("shbts=")[1].Split(';')[0];
                    var response_rur = response.Headers.ToString().SplitString("rur=")[1].Split(';')[0];
                    var response_sessionid = response.Headers.ToString().SplitString("sessionid=")[1].Split(';')[0];
                    var response_ds_user_id = response.Headers.ToString().SplitString("ds_user_id=")[1].Split(';')[0];

                    Dictionary<string, object> cookiesDic = new Dictionary<string, object>();
                    cookiesDic.Add("mid", response_mid);
                    cookiesDic.Add("shbid", response_shbid);
                    cookiesDic.Add("shbts", response_shbts);
                    cookiesDic.Add("rur", response_rur);
                    cookiesDic.Add("csrftoken", response_csrftoken);
                    cookiesDic.Add("sessionid", response_sessionid);
                    cookiesDic.Add("ds_user_id", response_ds_user_id);

                    string cookieStr = string.Empty;
                    foreach (var cookie in cookiesDic)
                    {
                        cookieStr += $"{cookie.Key}={cookie.Value}; ";
                    }

                    AuthenticatedResponse.Cookie = cookieStr.Trim();
                    Cookie = cookieStr.Trim();
                    _user.UserCookie = cookieStr.Trim();
                    _user.UserId = response_ds_user_id;
                    _user.CsrfToken = response_csrftoken;
                }
                
                return AuthenticatedResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                InvalidateServices();
            }
        }

        public IResult<Search> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentException("Query must be specified");
            }
            return _searchService.Search(query);
        }
        public IResult<EdgeOwnerToTimelineMediaNode> GetShortcodeMedia(string shortcode)
        {
            if (string.IsNullOrEmpty(shortcode))
            {
                throw new ArgumentException("Shortcode must be specified");
            }
            return _userService.GetShortcodeMedia(shortcode);
        }
        public IResult<UserInfo> GetUserInfo()
        {
            return _userService.GetUserInfo();
        }
        public IResult<User> GetUser(string username)
        {
            ValidateUser();
            return _userService.GetUser(username);
        }
        public IResult<User> GetUserDetails(string username)
        {
            ValidateUser();
            return _userService.GetUserDetails(username);
        }
        public IResult<User> GetWebDiscoverMedia(int limitPerPage = 24, int endCursor = 0)
        {
            return _userService.GetWebDiscoverMedia(limitPerPage, endCursor);
        }
        public IResult<EdgeActivityCount> GetUserActivitySummary()
        {
            return _userService.GetUserActivitySummary();
        }
        public IResult<ActivityFeed> GetUserActivityFeed()
        {
            return _userService.GetUserActivityFeed();
        }
        public IResult<EdgeOwnerToTimelineMedia> GetUserMedias(string userid, string endCursor, int limitPerPage = 12)
        {
            ValidadeParamsUserMedia(userid, endCursor);
            return _userService.GetUserMedias(userid, endCursor, limitPerPage);            
        }        
        public IResult<EdgeOwnerToTimelineMedia> GetAllUserMedias(string username, int limitPerPage = 12)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentException("Username must be specified");
            }
            return _userService.GetAllUserMedias(username, limitPerPage);
        }
        public IResult<EdgeWebFeedTimeline> GetUserTimelineMedias(string endCursor = null)
        {
            return _userService.GetUserTimelineMedias(endCursor);
        }
        public IResult<EdgeSavedMedia> GetSavedUserMedias(int limitPerPage = 12)
        {            
            return _userService.GetSavedUserMedias(limitPerPage);
        }
        public IResult<EdgeUserToPhotosOfYou> GetTaggedUserMedias(string userId, int limitPerPage = 12)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("UserId must be specified");
            }
            return _userService.GetTaggedUserMedias(userId, limitPerPage);
        }
        public IResult<EdgeFollowedBy> GetUserFollowers(string userId, int limitPerPage = 12)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("UserId must be specified");
            }
            return _userService.GetUserFollowers(userId, limitPerPage);
        }
        public IResult<EdgeFollow> GetUserFollowing(string userId, int limitPerPage = 12)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("UserId must be specified");
            }
            return _userService.GetUserFollowing(userId, limitPerPage);
        }
        public IResult<EdgeFollowingHashtag> GetUserHashtagFollowing(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("UserId must be specified");
            }
            return _userService.GetUserHashtagFollowing(userId);
        }
        public IResult<FeedReelsTray> GetRecentsFollowingUsersStories()
        {
            return _userService.GetRecentsFollowingUsersStories();
        }
        public IResult<DataStoryMedia> GetRecentsStoriesByUserId(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentException("UserId must be specified");
            }
            return _userService.GetRecentsStoriesByUserId(userId);
        }
        public IResult<DataStoryMedia> GetFeaturedStoriesByUserId(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentException("UserId must be specified");
            }
            return _userService.GetFeaturedStoriesByUserId(userId);
        }
        public IResult<DataStoryMedia> GetFeaturedStoriesByHighlightReelIds(string[] highlight_reel_ids)
        {
            if (highlight_reel_ids == null || highlight_reel_ids.ToList().Count == 0)
            {
                throw new ArgumentException("Highlight_reel_ids must be specified");
            }
            return _userService.GetFeaturedStoriesByHighlightReelIds(highlight_reel_ids);
        }
        public IResult<DataStoryMedia> GetStoryByUserIds(string[] userIds)
        {
            if (userIds == null || userIds.ToList().Count == 0)
            {
                throw new ArgumentException("List of userId must be specified");
            }
            if (userIds.ToList().Count > 15)
            {
                throw new ArgumentException("List of userId cannot be greater than 15 itens");
            }
            return _userService.GetStoryByUserIds(userIds);
        }
        public IResult<DataStoryMedia> GetSuggestedUsers(string userId)
        {
            if (userId == null)
            {
                throw new ArgumentException("UserId must be specified");
            }
            return _userService.GetSuggestedUsers(userId);
        }
        public IResult<string> Like(string mediaId)
        {
            if (String.IsNullOrEmpty(mediaId))
            {
                throw new ArgumentException("MediaId must be specified");
            }
            return _actionService.Like(mediaId);
        }
        public IResult<string> Unlike(string mediaId)
        {
            if (String.IsNullOrEmpty(mediaId))
            {
                throw new ArgumentException("MediaId must be specified");
            }
            return _actionService.Unlike(mediaId);
        }
        public IResult<string> RequestDownloadDataInformation(string email)
        {
            if (email == null)
            {
                throw new ArgumentException("E-mail must be specified");
            }
            return _actionService.RequestDownloadDataInformation(email);
        }
        public IResult<string> Follow(string userId)
        {
            if (String.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("UserId must be specified");
            }
            return _actionService.Follow(userId);
        }
        public IResult<string> Unfollow(string userId)
        {
            if (String.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("UserId must be specified");
            }
            return _actionService.Unfollow(userId);
        }
        public IResult<CommentResponse> Comment(string mediaId, string text)
        {
            if(String.IsNullOrEmpty(text) || String.IsNullOrEmpty(mediaId))
            {
                throw new ArgumentException("MediaId and text must be specified");
            }
            return _actionService.Comment(mediaId, text);
        }
        public IResult<string> DeleteComment(string mediaId, string commentId)
        {
            if (String.IsNullOrEmpty(mediaId) || String.IsNullOrEmpty(commentId))
            {
                throw new ArgumentException("MediaId and commentId must be specified");
            }
            return _actionService.DeleteComment(mediaId, commentId);
        }
        public IResult<string> LikeComment(string commentId)
        {
            if (String.IsNullOrEmpty(commentId))
            {
                throw new ArgumentException("CommentId must be specified");
            }
            return _actionService.LikeComment(commentId);
        }
        public IResult<string> UnlikeComment(string commentId)
        {
            if (String.IsNullOrEmpty(commentId))
            {
                throw new ArgumentException("CommentId must be specified");
            }
            return _actionService.UnlikeComment(commentId);
        }
        public IResult<string> SaveMedia(string mediaId)
        {
            if (String.IsNullOrEmpty(mediaId))
            {
                throw new ArgumentException("MediaId must be specified");
            }
            return _actionService.SaveMedia(mediaId);
        }
        public IResult<string> UnsaveMedia(string mediaId)
        {
            if (String.IsNullOrEmpty(mediaId))
            {
                throw new ArgumentException("MediaId must be specified");
            }
            return _actionService.UnsaveMedia(mediaId);
        }
        public IResult<Hashtag> GetHashtag(string hashtag)
        {
            ValidateHashtag(hashtag);
            return _hashtagService.GetHashtag(hashtag.Trim().Replace(" ", ""));
        }
        public IResult<EdgeHashtagToMedia> GetHashtagMedias(string hashtag, string endCursor, int limitPerPage = 12)
        {
            if (string.IsNullOrEmpty(hashtag) || string.IsNullOrEmpty(endCursor))
            {
                throw new ArgumentException("Hashtag and end_cursor must be specified");
            }
            return _hashtagService.GetHashtagMedias(hashtag.Trim().Replace(" ", ""), endCursor, limitPerPage);
        }
        public IResult<ShortcodeHashtagMedia> GetShortcodeHashtagMedia(string shortcode)
        {
            throw new NotImplementedException();
        }        
        public IResult<ShortcodeMediaLikes> GetMediaLikes(string shortcode, string endCursor = null, int limitPerPage = 24)
        {
            if (string.IsNullOrEmpty(shortcode))
            {
                throw new ArgumentException("Shortcode must be specified");
            }
            return _userService.GetMediaLikes(shortcode, endCursor, limitPerPage);
        }
        public IResult<ShortcodeMedia> GetMediaInfoData(string shortcode)
        {
            if (string.IsNullOrEmpty(shortcode))
            {
                throw new ArgumentException("Shortcode must be specified");
            }
            return _mediaService.GetMediaInfoData(shortcode);
        }
        public IResult<EdgeMediaToParentComment> GetMediaComments(string shortcode, string endCursor, int limitPerPage = 12)
        {
            if (string.IsNullOrEmpty(shortcode) || string.IsNullOrEmpty(endCursor))
            {
                throw new ArgumentException("Hashtag and end_cursor must be specified");
            }
            return _mediaService.GetMediaComments(shortcode, endCursor, limitPerPage);
        }
        public IResult<Comment> GetLikesFromComment(string comment_id, string endCursor = null, int limitPerPage = 48)
        {
            if (string.IsNullOrEmpty(comment_id))
            {
                throw new ArgumentException("comment_id must be specified");
            }
            return _mediaService.GetLikesFromComment(comment_id, endCursor, limitPerPage);
        }
        public IResult<Comment> GetCommentReplies(string comment_id, string endCursor = null, int limitPerPage = 48)
        {
            if (string.IsNullOrEmpty(comment_id))
            {
                throw new ArgumentException("comment_id must be specified");
            }
            return _mediaService.GetCommentReplies(comment_id, endCursor, limitPerPage);
        }
        public IResult<CommentResponse> ReplyComment(string mediaId, string comment_id, string text)
        {
            if (String.IsNullOrEmpty(text) || String.IsNullOrEmpty(mediaId) || String.IsNullOrEmpty(comment_id))
            {
                throw new ArgumentException("MediaId, text and comment_id must be specified");
            }
            return _actionService.ReplyComment(mediaId, comment_id, text);
        }
        public IResult<string> DeleteReplyComment(string mediaId, string repliedId)
        {
            if (String.IsNullOrEmpty(mediaId) || String.IsNullOrEmpty(repliedId))
            {
                throw new ArgumentException("MediaId and repliedId must be specified");
            }
            return _actionService.DeleteReplyComment(mediaId, repliedId);
        }



        #region [ Private Methods ]
        private void ValidateUser()
        {
            if (string.IsNullOrEmpty(_user.Username) || string.IsNullOrEmpty(_user.Password))
            {
                throw new ArgumentException("user name and password must be specified");
            }
        }
        private void ValidateHashtag(string hashtag)
        {
            if (string.IsNullOrEmpty(hashtag))
            {
                throw new ArgumentException("Hashtag must be specified");
            }
        }
        private void ValidadeParamsUserMedia(string userid, string endCursor)
        {
            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(endCursor))
            {
                throw new ArgumentException("user id and end_cursor must be specified");
            }
        }        
        private void InvalidateServices()
        {
            _userService = new UserService(_user);
            _searchService = new SearchService(_user);
            _actionService = new ActionsService(_user);
            _hashtagService = new HashtagService(_user);
            _mediaService = new MediaService(_user);
        }        
        #endregion
    }
}
