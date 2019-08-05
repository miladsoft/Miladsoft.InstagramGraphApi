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
    public interface IMediaService
    {
        IResult<ShortcodeMedia> GetMediaInfoData(string shortcode);
        IResult<EdgeMediaToParentComment> GetMediaComments(string shortcode, string endCursor, int limitPerPage = 12);
        IResult<Comment> GetLikesFromComment(string comment_id, string endCursor = null, int limitPerPage = 48);
        IResult<Comment> GetCommentReplies(string comment_id, string endCursor = null, int limitPerPage = 48);
    }
}
