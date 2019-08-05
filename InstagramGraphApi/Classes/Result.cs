/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/InstagramGraphApi
 * 
 */
using System;
using System.Net;
using System.Net.Http;
using InstagramGraphApi.Classes.Enums;
using InstagramGraphApi.Classes.Interfaces;
using InstagramGraphApi.Helpers;

namespace InstagramGraphApi.Classes
{
    public class Result<TEntity> : IResult<TEntity>
    {
        public bool Succeeded { get; }
        public TEntity Data { get; }
        public ResultInfo ResultInfo { get; } = new ResultInfo("");

        public Result(bool succeeded, TEntity value, ResultInfo resultInfo)
        {
            Succeeded = succeeded;
            Data = value;
            ResultInfo = resultInfo;
        }

        public Result(bool succeeded, ResultInfo resultInfo)
        {
            Succeeded = succeeded;
            ResultInfo = resultInfo;
        }

        public Result(bool succeeded, TEntity value)
        {
            Succeeded = succeeded;
            Data = value;
        }
    }

    public static class Result
    {
        public static IResult<TEntity> Success<TEntity>(TEntity resValue)
        {
            return new Result<TEntity>(true, resValue, new ResultInfo(ResponseType.OK, "No errors detected"));
        }

        public static IResult<TEntity> Success<TEntity>(string successMsg, TEntity resValue)
        {
            return new Result<TEntity>(true, resValue, new ResultInfo(ResponseType.OK, successMsg));
        }

        public static IResult<TEntity> Fail<TEntity>(Exception exception)
        {
            return new Result<TEntity>(false, default(TEntity), new ResultInfo(exception));
        }

        public static IResult<TEntity> Fail<TEntity>(string errMsg)
        {
            return new Result<TEntity>(false, default(TEntity), new ResultInfo(errMsg));
        }

        public static IResult<TEntity> Fail<TEntity>(string errMsg, TEntity resValue)
        {
            return new Result<TEntity>(false, resValue, new ResultInfo(errMsg));
        }

        public static IResult<TEntity> Fail<TEntity>(Exception exception, TEntity resValue)
        {
            return new Result<TEntity>(false, resValue, new ResultInfo(exception));
        }

        public static IResult<TEntity> Fail<TEntity>(ResultInfo info, TEntity resValue)
        {
            return new Result<TEntity>(false, resValue, info);
        }

        public static IResult<TEntity> Fail<TEntity>(string errMsg, ResponseType responseType, TEntity resValue)
        {
            return new Result<TEntity>(false, resValue, new ResultInfo(responseType, errMsg));
        }

        public static IResult<TEntity> UnExpectedResponse<TEntity>(HttpResponseMessage response, string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                var resultInfo = new ResultInfo(ResponseType.UnExpectedResponse,
                    $"Unexpected response status: {response.StatusCode}");
                return new Result<TEntity>(false, default(TEntity), resultInfo);
            }
            else
            {
                var status = ErrorHandlingHelper.GetBadStatusFromJsonString(json);
                var responseType = ResponseType.UnExpectedResponse;
                switch (status.ErrorType)
                {
                    case "checkpoint_logged_out":
                        responseType = ResponseType.CheckPointRequired;
                        break;
                    case "login_required":
                        responseType = ResponseType.LoginRequired;
                        break;
                    case "Sorry, too many requests.Please try again later":
                        responseType = ResponseType.RequestsLimit;
                        break;
                    case "sentry_block":
                        responseType = ResponseType.SentryBlock;
                        break;
                }

                if (!status.IsOk() && status.Message.Contains("wait a few minutes"))
                    responseType = ResponseType.RequestsLimit;

                var resultInfo = new ResultInfo(responseType, status.Message);
                return new Result<TEntity>(false, default(TEntity), resultInfo);
            }
        }
        public static IResult<TEntity> UnExpectedResponse<TEntity>(HttpWebResponse response, string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                var resultInfo = new ResultInfo(ResponseType.UnExpectedResponse,
                    $"Unexpected response status: {response.StatusCode}");
                return new Result<TEntity>(false, default(TEntity), resultInfo);
            }
            else
            {
                var status = ErrorHandlingHelper.GetBadStatusFromJsonString(json);
                var responseType = ResponseType.UnExpectedResponse;
                switch (status.ErrorType)
                {
                    case "checkpoint_logged_out":
                        responseType = ResponseType.CheckPointRequired;
                        break;
                    case "login_required":
                        responseType = ResponseType.LoginRequired;
                        break;
                    case "Sorry, too many requests.Please try again later":
                        responseType = ResponseType.RequestsLimit;
                        break;
                    case "sentry_block":
                        responseType = ResponseType.SentryBlock;
                        break;
                }

                if (!status.IsOk() && status.Message.Contains("wait a few minutes"))
                    responseType = ResponseType.RequestsLimit;

                var resultInfo = new ResultInfo(responseType, status.Message);
                return new Result<TEntity>(false, default(TEntity), resultInfo);
            }
        }
    }
}
