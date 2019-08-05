/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */

using System;
using System.IO;
using System.Net;

namespace InstagramGraphApi.Helpers
{
    public static class CustomExtensions
    {
        public static string[] SplitString(this string value, string separator)
        {
            return value.Split(new string[] { separator }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string ReadAsString(this HttpWebResponse response)
        {
            using(Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
