/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
namespace InstagramGraphApi.Classes.Interfaces
{
    public interface IResult<out TEntity>
    {
        bool Succeeded { get; }
        TEntity Data { get; }
        ResultInfo ResultInfo { get; }
    }
}
