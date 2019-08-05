/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using System;
using System.Net;
using System.Web;
using Newtonsoft.Json;
using InstagramGraphApi.Entity;
using InstagramGraphApi.Classes;
using InstagramGraphApi.Classes.Interfaces;
using InstagramGraphApi.API.Services.Interfaces;
using InstagramGraphApi.Helpers;
using InstagramGraphApi.API.Constants;

namespace InstagramGraphApi.API.Services
{
    public class MediaService : IMediaService
    {
        private readonly UserSessionData _user;

        public MediaService(UserSessionData user)
        {
            _user = user;
        }

        
        public IResult<ShortcodeMedia> GetMediaInfoData(string shortcode)
        {
            try
            {
                string uri = string.Format(InstagramGraphApiConstants.MEDIA_INFO_URL, shortcode);
                var variables = string.Format("{0}:{{\"shortcode\":\"{1}\",\"child_comment_count\":10,\"fetch_comment_count\":40,\"parent_comment_count\":40,\"has_threaded_comments\":true}}", _user.UserRhxGis, shortcode);
                var signature = ApplicationHelper.CreateMD5(variables);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<ShortcodeMedia>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<ShortcodeData>(json);

                return Result.Success<ShortcodeMedia>(objRetorno.Data.ShortcodeMedia);
            }
            catch (Exception ex)
            {
                return Result.Fail<ShortcodeMedia>(ex.Message);
            }
        }
        public IResult<EdgeMediaToParentComment> GetMediaComments(string shortcode, string endCursor, int limitPerPage = 12)
        {
            try
            {
                DeserializedEndCursor DeserializedEndCursor = new DeserializedEndCursor();
                DeserializedEndCursor = JsonConvert.DeserializeObject<DeserializedEndCursor>(endCursor);

                string uri = string.Format(InstagramGraphApiConstants.MEDIA_COMMENTS_URL, shortcode, limitPerPage, DeserializedEndCursor.cached_comments_cursor, HttpUtility.UrlEncode(DeserializedEndCursor.bifilter_token));
                var variables = string.Format("{{\"shortcode\":\"{0}\", \"first\":{1}, \"after\":\"{{ \"cached_comments_cursor\": \"{2}\", \"bifilter_token\": \"{3}\" }}\"}}", shortcode, limitPerPage, DeserializedEndCursor.cached_comments_cursor, DeserializedEndCursor.bifilter_token);
                var signature = ApplicationHelper.CreateMD5(variables);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeMediaToParentComment>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<ShortcodeData>(json);

                return Result.Success<EdgeMediaToParentComment>(objRetorno.Data.ShortcodeMedia.EdgeMediaToParentComment);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeMediaToParentComment>(ex.Message);
            }
        }
        public IResult<Comment> GetLikesFromComment(string comment_id, string endCursor = null, int limitPerPage = 48)
        {
            try
            {
                string uri = string.Empty;
                string variable = string.Empty;

                if(String.IsNullOrEmpty(endCursor))
                {
                    uri = string.Format(InstagramGraphApiConstants.LIKES_FROM_COMMENT_INIT, comment_id, limitPerPage);
                    variable = string.Format("{{\"comment_id\":\"{0}\",\"first\":{1}}}", comment_id, limitPerPage);
                }
                else
                {
                    uri = string.Format(InstagramGraphApiConstants.LIKES_FROM_COMMENT_URL, comment_id, limitPerPage, endCursor);
                    variable = string.Format("{{\"comment_id\":\"{0}\",\"first\":{1},\"after\":\"{2}\"}}", comment_id, limitPerPage, endCursor);
                }

                var signature = ApplicationHelper.CreateMD5(variable);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<Comment>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<CommentData>(json);

                return Result.Success<Comment>(objRetorno.Data.Comment);
            }
            catch (Exception ex)
            {
                return Result.Fail<Comment>(ex.Message);
            }
        }
        public IResult<Comment> GetCommentReplies(string comment_id, string endCursor = null, int limitPerPage = 48)
        {
            try
            {
                string uri = string.Empty;
                string variable = string.Empty;

                if (String.IsNullOrEmpty(endCursor))
                {
                    uri = string.Format(InstagramGraphApiConstants.COMMENT_REPLIES_INIT, comment_id, limitPerPage);
                    variable = string.Format("{{\"comment_id\":\"{0}\",\"first\":{1}}}", comment_id, limitPerPage);
                }
                else
                {
                    uri = string.Format(InstagramGraphApiConstants.COMMENT_REPLIES_URL, comment_id, limitPerPage, endCursor);
                    variable = string.Format("{{\"comment_id\":\"{0}\",\"first\":{1},\"after\":\"{2}\"}}", comment_id, limitPerPage, endCursor);
                }

                var signature = ApplicationHelper.CreateMD5(variable);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<Comment>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<CommentData>(json);

                return Result.Success<Comment>(objRetorno.Data.Comment);
            }
            catch (Exception ex)
            {
                return Result.Fail<Comment>(ex.Message);
            }
        }
    }

    internal class DeserializedEndCursor
    {
        public string cached_comments_cursor { get; set; }
        public string bifilter_token { get; set; }
    }
}
