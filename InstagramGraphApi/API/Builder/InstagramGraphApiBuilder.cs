/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGraphApi.Classes;

namespace InstagramGraphApi.API.Builder
{
    public class InstagramGraphApiBuilder : IInstagramGraphApiBuilder
    {
        private UserSessionData _user;

        private InstagramGraphApiBuilder()
        {
        }

        public static IInstagramGraphApiBuilder CreateBuilder()
        {
            return new InstagramGraphApiBuilder();
        }

        public IInstagramGraphApi Build()
        {
            if (_user == null)
                throw new ArgumentNullException("User auth data must be specified");

            var InstagramGraphApi = new InstagramGraphApi(_user);
            return InstagramGraphApi;
        }

        public IInstagramGraphApiBuilder SetUser(UserSessionData user)
        {
            _user = user;
            return this;
        }
    }
}
