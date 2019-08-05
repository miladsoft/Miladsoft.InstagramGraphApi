/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
namespace InstagramGraphApi.Classes
{
    public class UserSessionData
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string CsrfToken { get; set; }
        public string UserCookie { get; set; }
        public string UserRhxGis { get; set; }
    }
}
