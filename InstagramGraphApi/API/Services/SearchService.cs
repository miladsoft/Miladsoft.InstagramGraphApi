/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using System;
using System.Net;
using System.Web;
using InstagramGraphApi.API.Services.Interfaces;
using InstagramGraphApi.Classes;
using InstagramGraphApi.Classes.Interfaces;
using InstagramGraphApi.Helpers;
using InstagramGraphApi.Entity;
using InstagramGraphApi.API.Constants;
using Newtonsoft.Json;

namespace InstagramGraphApi.API.Services
{
    public class SearchService : ISearchService
    {
        private readonly UserSessionData _user;

        public SearchService(UserSessionData user)
        {
            _user = user;
        }

        public IResult<Search> Search(string query)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.SEARCH_URL, FormattedQuerySearch(query));

                var request = HttpHelper.GetDefaultRequest(uri);
                request.Headers["Cookie"] = _user.UserCookie;

                var response = HttpHelper.GetDefaultResponse(request);
                var json = response.ReadAsString();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    return Result.UnExpectedResponse<Search>(response, json);
                }

                var searchData = JsonConvert.DeserializeObject<Search>(json);
                
                return Result.Success(searchData);
            }
            catch (Exception ex)
            {
                return Result.Fail<Search>(ex.Message);
            }
        }


        #region [ Private Methods ]
        private static string FormattedQuerySearch(string query)
        {
            return HttpUtility.UrlEncode(query);
        }
        #endregion
    }
}
