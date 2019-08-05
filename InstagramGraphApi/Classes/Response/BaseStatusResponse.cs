/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
using Newtonsoft.Json;

namespace InstagramGraphApi.Classes.Response
{
    public class BaseStatusResponse
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        public bool IsOk()
        {
            return !string.IsNullOrEmpty(Status) && Status.ToLower() == "ok";
        }

        public bool IsFail()
        {
            return !string.IsNullOrEmpty(Status) && Status.ToLower() == "fail";
        }
    }
}
