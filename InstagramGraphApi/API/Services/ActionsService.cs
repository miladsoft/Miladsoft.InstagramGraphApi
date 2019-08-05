/*
 * Developer: Milad Raeisi [ miladsoft@yahoo.com ] [ My Telegram Account: https://t.me/miladsoft ]
 * 
 * Github source: https://github.com/miladsoft/InstagramGraphApi
 * Nuget package: https://www.nuget.org/packages/Miladsoft.InstagramGraphApi/
 * 
 */
using System;
using System.Net;
using System.IO;
using System.Web;
using System.Text;
using InstagramGraphApi.API.Constants;
using InstagramGraphApi.API.Services.Interfaces;
using InstagramGraphApi.Classes.Interfaces;
using InstagramGraphApi.Classes;
using InstagramGraphApi.Entity;
using Newtonsoft.Json;

namespace InstagramGraphApi.API.Services
{
    public class ActionsService : IActionsService
    {
        private readonly UserSessionData _user;

        public ActionsService(UserSessionData user)
        {
            _user = user;
        }


        public IResult<string> Like(string mediaId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.LIKE_URL, mediaId);

                var data = Encoding.ASCII.GetBytes(string.Empty);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }        
        public IResult<string> Unlike(string mediaId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.UNLIKE_URL, mediaId);

                var data = Encoding.ASCII.GetBytes(string.Empty);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }
        public IResult<string> RequestDownloadDataInformation(string email)
        {
            try
            {
                var uri = InstagramGraphApiConstants.REQUEST_DOWNLOAD_DATA_URL;

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString.Add("email", email);
                queryString.Add("password", _user.Password);

                var formData = queryString.ToString();
                var data = Encoding.ASCII.GetBytes(formData);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }
        public IResult<string> Follow(string userId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.FOLLOW_URL, userId);

                var data = Encoding.ASCII.GetBytes(string.Empty);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }
        public IResult<string> Unfollow(string userId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.UNFOLLOW_URL, userId);

                var data = Encoding.ASCII.GetBytes(string.Empty);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }
        public IResult<CommentResponse> Comment(string mediaId, string text)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.COMMENT_URL, mediaId);

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString.Add("comment_text", text);
                queryString.Add("replied_to_comment_id", string.Empty);

                var formData = queryString.ToString();
                var data = Encoding.ASCII.GetBytes(formData);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var objRetorno = JsonConvert.DeserializeObject<CommentResponse>(responseString);

                return Result.Success(objRetorno);
            }
            catch (Exception ex)
            {
                return Result.Fail<CommentResponse>(ex.Message);
            }
        }
        public IResult<string> DeleteComment(string mediaId, string commentId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.DELETE_COMMENT_URL, mediaId, commentId);

                var data = Encoding.ASCII.GetBytes(string.Empty);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }
        public IResult<string> LikeComment(string commentId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.LIKE_COMMENT_URL, commentId);

                var data = Encoding.ASCII.GetBytes(string.Empty);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }
        public IResult<string> UnlikeComment(string commentId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.UNLIKE_COMMENT_URL, commentId);

                var data = Encoding.ASCII.GetBytes(string.Empty);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }
        public IResult<string> SaveMedia(string mediaId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.SAVE_MEDIA_URL, mediaId);

                var data = Encoding.ASCII.GetBytes(string.Empty);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }
        public IResult<string> UnsaveMedia(string mediaId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.UNSAVE_MEDIA_URL, mediaId);

                var data = Encoding.ASCII.GetBytes(string.Empty);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }
        public IResult<CommentResponse> ReplyComment(string mediaId, string comment_id, string text)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.COMMENT_URL, mediaId);

                var queryString = HttpUtility.ParseQueryString(string.Empty);
                queryString.Add("comment_text", text);
                queryString.Add("replied_to_comment_id", comment_id);

                var formData = queryString.ToString();
                var data = Encoding.ASCII.GetBytes(formData);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                var objRetorno = JsonConvert.DeserializeObject<CommentResponse>(responseString);

                return Result.Success(objRetorno);
            }
            catch (Exception ex)
            {
                return Result.Fail<CommentResponse>(ex.Message);
            }
        }
        public IResult<string> DeleteReplyComment(string mediaId, string repliedId)
        {
            try
            {
                var uri = string.Format(InstagramGraphApiConstants.DELETE_COMMENT_URL, mediaId, repliedId);

                var data = Encoding.ASCII.GetBytes(string.Empty);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                request.Headers["x-csrftoken"] = _user.CsrfToken;
                request.Headers["Cookie"] = _user.UserCookie;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                request.UserAgent = InstagramGraphApiConstants.USER_AGENT;
                request.Accept = "*/*";

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return Result.Success(responseString);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>(ex.Message);
            }
        }
    }
}
