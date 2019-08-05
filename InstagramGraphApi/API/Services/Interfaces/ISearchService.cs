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
    public interface ISearchService
    {
        IResult<Search> Search(string query);
    }
}
