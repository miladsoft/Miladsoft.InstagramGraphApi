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
using System.Net;
using InstagramGraphApi.API.Services.Interfaces;
using InstagramGraphApi.Classes;
using InstagramGraphApi.Classes.Enums;
using InstagramGraphApi.Classes.Interfaces;
using InstagramGraphApi.Helpers;
using InstagramGraphApi.Entity;
using InstagramGraphApi.API.Constants;
using Newtonsoft.Json;

namespace InstagramGraphApi.API.Services
{
    public class HashtagService : IHashtagService
    {
        private readonly UserSessionData _user;

        public HashtagService(UserSessionData user)
        {
            _user = user;
        }

        public IResult<Hashtag> GetHashtag(string hashtag)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.EXPLORE_TAG_DATA_INIT, hashtag);

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var html = response.ReadAsString();
                var json = ApplicationHelper.ExtractJsonFromHtml(html);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<Hashtag>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<TagData>(json);
                _user.UserRhxGis = objRetorno.RhxGis;

                var hashtagRetorno = objRetorno.EntryData.TagPage[0].Graphql.Hashtag;

                Hashtag Hashtag = new Hashtag();
                Hashtag.Name = hashtagRetorno.Name;
                Hashtag.Id = hashtagRetorno.Id;
                Hashtag.MediaCount = hashtagRetorno.MediaCount;
                Hashtag.SearchResultSubtitle = hashtagRetorno.SearchResultSubtitle;
                Hashtag.AllowFollowing = hashtagRetorno.AllowFollowing;
                Hashtag.IsFollowing = hashtagRetorno.IsFollowing;
                Hashtag.IsTopMediaOnly = hashtagRetorno.IsTopMediaOnly;
                Hashtag.ProfilePicUrl = hashtagRetorno.ProfilePicUrl;
                Hashtag.EdgeHashtagToTopPosts = hashtagRetorno.EdgeHashtagToTopPosts;
                Hashtag.EdgeHashtagToMedia = GetEdgeHashtagToMedia(hashtagRetorno);

                return Result.Success(Hashtag);
            }
            catch (Exception ex)
            {
                return Result.Fail<Hashtag>(ex.Message);
            }
        }
        public IResult<EdgeHashtagToMedia> GetHashtagMedias(string hashtag, string endCursor, int limitPerPage = 12)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.EXPLORE_TAG_DATA, hashtag, limitPerPage, endCursor);

                var variables = string.Format("{0}:{{\"tag_name\":\"{1}\",\"show_ranked\":false,\"first\":{2},\"after\":\"{3}\"}}", _user.UserRhxGis, hashtag, limitPerPage, endCursor);
                var signature = ApplicationHelper.CreateMD5(variables);                

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<EdgeHashtagToMedia>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<HashtagMedias>(json);
                
                EdgeHashtagToMedia EdgeHashtagToMedia = GetEdgeHashtagToMedia(objRetorno.Data.Hashtag);

                return Result.Success(EdgeHashtagToMedia);
            }
            catch (Exception ex)
            {
                return Result.Fail<EdgeHashtagToMedia>(ex.Message);
            }
        }
        public IResult<ShortcodeHashtagMedia> GetShortcodeHashtagMedia(string shortcode)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.EXPLORE_TAG_SHORTCODE_DATA, shortcode);

                var variables = string.Format("{0}:{{\"shortcode\":\"{1}\",\"child_comment_count\":10,\"fetch_comment_count\":40,\"parent_comment_count\":24,\"has_threaded_comments\":true }}", _user.UserRhxGis, shortcode);
                var signature = ApplicationHelper.CreateMD5(variables);                

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["X-Instagram-GIS"] = signature;
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<ShortcodeHashtagMedia>(response, json);
                }

                var objRetorno = JsonConvert.DeserializeObject<ShortcodeHashtagMediaData>(json);
                var medias = objRetorno.Data;

                return Result.Success(medias);
            }
            catch (Exception ex)
            {
                return Result.Fail<ShortcodeHashtagMedia>(ex.Message);
            }
        }


        #region [ Private Methods ]
        private EdgeHashtagToMedia GetEdgeHashtagToMedia(Hashtag Hashtag)
        {
            EdgeHashtagToMedia EdgeHashtagToMedia = new EdgeHashtagToMedia();
            EdgeHashtagToMedia.PageInfo = Hashtag.EdgeHashtagToMedia.PageInfo;
            EdgeHashtagToMedia.Edges = new List<EdgeHashtagToMediaEdges>();

            if (Hashtag.EdgeHashtagToMedia == null)
                return null;

            var medias = Hashtag.EdgeHashtagToMedia;

            var ImageMedias = medias.Edges.Where(c => c.Node.Typename == MediaType.Image).ToList();
            var SidecarMedias = medias.Edges.Where(c => c.Node.Typename == MediaType.Sidecar).ToList();
            var VideosMedias = medias.Edges.Where(c => c.Node.Typename == MediaType.Video).ToList();

            foreach (var image in ImageMedias)
            {
                EdgeHashtagToMedia.Edges.Add(new EdgeHashtagToMediaEdges() { Node = image.Node });
            }

            foreach (var sidecar in SidecarMedias)
            {
                var shortcode = sidecar.Node.Shortcode;

                var sidecarShortcodeData = GetShortcodeHashtagMedia(shortcode);

                EdgeHashtagToMedia.Edges.Add(new EdgeHashtagToMediaEdges() { ShortcodeNode = sidecarShortcodeData.Data.ShortcodeMediaHashtag });
            }

            foreach (var video in VideosMedias)
            {
                var shortcode = video.Node.Shortcode;

                var videoShortcodeData = GetShortcodeHashtagMedia(shortcode);

                EdgeHashtagToMedia.Edges.Add(new EdgeHashtagToMediaEdges() { ShortcodeNode = videoShortcodeData.Data.ShortcodeMediaHashtag });
            }

            return EdgeHashtagToMedia;
        }
        #endregion
    }
}
