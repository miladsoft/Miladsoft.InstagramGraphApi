/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
namespace InstagramGraphApi.Classes.Enums
{
    public enum ResponseType
    {
        Unknown = 0,
        LoginRequired = 1,
        CheckPointRequired = 2,
        RequestsLimit = 3,
        SentryBlock = 4,
        OK = 5,
        WrongRequest = 6,
        SomePagesSkipped = 7,
        UnExpectedResponse = 8,
        InternalException = 9
    }
}
