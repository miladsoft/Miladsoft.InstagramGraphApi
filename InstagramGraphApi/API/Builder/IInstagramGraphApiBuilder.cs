/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
using InstagramGraphApi.Classes;

namespace InstagramGraphApi.API.Builder
{
    public interface IInstagramGraphApiBuilder
    {
        IInstagramGraphApi Build();
        IInstagramGraphApiBuilder SetUser(UserSessionData user);
    }
}
