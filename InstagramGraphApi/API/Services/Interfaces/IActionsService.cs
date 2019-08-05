/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using InstagramGraphApi.Classes.Interfaces;
using InstagramGraphApi.Entity;

namespace InstagramGraphApi.API.Services.Interfaces
{
    public interface IActionsService
    {
        IResult<string> Like(string mediaId);
        IResult<string> Unlike(string mediaId);
        IResult<string> RequestDownloadDataInformation(string email);
        IResult<string> Follow(string userId);
        IResult<string> Unfollow(string userId);
        IResult<CommentResponse> Comment(string mediaId, string text);
        IResult<string> DeleteComment(string mediaId, string commentId);
        IResult<string> LikeComment(string commentId);
        IResult<string> UnlikeComment(string commentId);
        IResult<string> SaveMedia(string mediaId);
        IResult<string> UnsaveMedia(string mediaId);
        IResult<CommentResponse> ReplyComment(string mediaId, string comment_id, string text);
        IResult<string> DeleteReplyComment(string mediaId, string repliedId);
    }
}
