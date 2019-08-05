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
    public interface IHashtagService
    {
        IResult<Hashtag> GetHashtag(string hashtag);
        IResult<EdgeHashtagToMedia> GetHashtagMedias(string hashtag, string endCursor, int limitPerPage = 12);
        IResult<ShortcodeHashtagMedia> GetShortcodeHashtagMedia(string shortcode);
    }
}
