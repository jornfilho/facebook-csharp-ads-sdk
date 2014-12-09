using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace facebook_csharp_ads_sdk._Utils.WebRequests
{
    /// <summary>
    /// Implements <c>IRequest</c> methods
    /// </summary>
    public class Request : IRequest
    {
        #region Params

        /// <summary>
        /// Default timeout request
        /// </summary>
        private const int RequestTimeout = 10000;

        /// <summary>
        /// Minimum value to request timeout
        /// </summary>
        private const int RequestTimeoutMin = 500;

        #endregion

        #region Private methods

        /// <summary>
        /// Validate timeout value parameter
        /// </summary>
        /// <param name="timeout">Timeout value</param>
        /// <returns>Is valid timeout value</returns>
        private static bool IsValidTimeoutParam(int timeout)
        {
            return timeout >= RequestTimeoutMin;
        }

        /// <summary>
        /// Validate url value
        /// </summary>
        /// <param name="url">Url value</param>
        /// <returns>Is valid url value</returns>
        private static bool IsValidUrlParam(string url)
        {
            return !String.IsNullOrEmpty(url) && DevUtils.Validators.Url.IsUriValid(url);
        }

        #endregion

        #region Get

        /// <summary>
        /// Get web request async method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <param name="timeout">Request timeout value - millisseconds</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public async Task<string> GetAsync(string url, int timeout)
        {
            if (!IsValidUrlParam(url))
                throw new ArgumentException();

            if (!IsValidTimeoutParam(timeout))
                throw new ArgumentOutOfRangeException();

            string result = null;
            try
            {
                var content = new MemoryStream();
                var webReq = (HttpWebRequest) WebRequest.Create(url);
                webReq.Timeout = timeout;
                webReq.Method = "GET";
                using (var response = await webReq.GetResponseAsync())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            await responseStream.CopyToAsync(content);
                    }
                }

                result = Encoding.UTF8.GetString(content.ToArray());
            }
            catch (WebException e)
            {
                Debug.WriteLine(e);

                try
                {
                    using (var stream = e.Response.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }

                if (String.IsNullOrEmpty(result))
                    throw new WebException(e.Message, e);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return result;
        }

        /// <summary>
        /// Get web request async method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public async Task<string> GetAsync(string url)
        {
            return await GetAsync(url, RequestTimeout);
        }

        /// <summary>
        /// Get web request sync method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public string Get(string url, int timeout)
        {
            string result = null;
            try
            {
                var getRequest = WebRequest.Create(url);
                getRequest.Timeout = timeout;
                var objStream = getRequest.GetResponse().GetResponseStream();
                if (objStream != null)
                {
                    var objReader = new StreamReader(objStream);
                    result = objReader.ReadToEnd();
                }
            }
            catch (WebException e)
            {
                Debug.WriteLine(e);

                using (var stream = e.Response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            result = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            return result;
        }

        /// <summary>
        /// Get web request sync method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public string Get(string url)
        {
            return Get(url, RequestTimeout);
        }

        #endregion

        #region Post

        /// <summary>
        /// Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <param name="timeout">Request timeout value - millisseconds</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public async Task<string> PostAsync(string url, Dictionary<string, string> postData, int timeout)
        {
            #region Initial validation

            if (!IsValidUrlParam(url))
                throw new ArgumentException();

            if (!IsValidTimeoutParam(timeout))
                throw new ArgumentOutOfRangeException();

            #endregion

            #region Prepare post params

            var postParams = "";
            var postKeysCount = postData != null ? postData.Keys.Count : 0;
            if (postKeysCount > 0)
            {
                foreach (string key in postData.Keys)
                {
                    if (String.IsNullOrEmpty(key))
                        continue;

                    if (!String.IsNullOrEmpty(postParams))
                        postParams = postParams + "&";

                    var value = !String.IsNullOrEmpty(postData[key])
                        ? Uri.EscapeUriString(postData[key])
                        : "";

                    postParams += string.Format("{0}={1}", key, value);
                }
            }
            var postParamsByteArray = Encoding.UTF8.GetBytes(postParams);

            #endregion

            string result = null;
            try
            {
                var content = new MemoryStream();
                var webReq = (HttpWebRequest) WebRequest.Create(url);
                webReq.Timeout = timeout;
                webReq.Method = "POST";
                webReq.ContentType = "application/x-www-form-urlencoded";
                webReq.ContentLength = postParamsByteArray.Length;

                using (var postStream = await webReq.GetRequestStreamAsync())
                {
                    await postStream.WriteAsync(postParamsByteArray, 0, postParamsByteArray.Length);
                }

                using (var response = await webReq.GetResponseAsync())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            await responseStream.CopyToAsync(content);
                    }
                }

                result = Encoding.UTF8.GetString(content.ToArray());
            }
            catch (WebException e)
            {
                Debug.WriteLine(e);

                try
                {
                    using (var stream = e.Response.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }

                }
                catch (Exception ee)
                {
                    Debug.WriteLine(ee);
                }

                if (String.IsNullOrEmpty(result))
                    throw new WebException(e.Message, e);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return result;
        }

        /// <summary>
        /// Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public async Task<string> PostAsync(string url, Dictionary<string, string> postData)
        {
            return await PostAsync(url, postData, RequestTimeout);
        }

        /// <summary>
        /// Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public string Post(string url, Dictionary<string, string> postData, int timeout)
        {
            string result = null;
            try
            {
                result = PostAsync(url, postData, timeout).Result;
            }
            catch (AggregateException e)
            {
                e.Handle(x =>
                {
                    throw x;
                });
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public string Post(string url, Dictionary<string, string> postData)
        {
            return Post(url, postData, RequestTimeout);
        }

        #endregion

        #region Delete

        /// <summary>
        /// Requisição do tipo DELETE de modo assincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public async Task<string> DeleteAsync(string url, int timeout)
        {
            #region Initial validation

            if (!IsValidUrlParam(url))
                throw new ArgumentException();

            if (!IsValidTimeoutParam(timeout))
                throw new ArgumentOutOfRangeException();

            #endregion

            string result = null;
            try
            {
                var content = new MemoryStream();
                var webReq = (HttpWebRequest) WebRequest.Create(url);
                webReq.Timeout = timeout;
                webReq.Method = "DELETE";

                using (var response = await webReq.GetResponseAsync())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            await responseStream.CopyToAsync(content);
                    }
                }

                result = Encoding.UTF8.GetString(content.ToArray());
            }
            catch (WebException e)
            {
                Debug.WriteLine(e);

                try
                {
                    using (var stream = e.Response.GetResponseStream())
                    {
                        if (stream != null)
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                result = reader.ReadToEnd();
                            }
                        }
                    }

                }
                catch (Exception ee)
                {
                    Debug.WriteLine(ee);
                }

                if (String.IsNullOrEmpty(result))
                    throw new WebException(e.Message, e);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            return result;
        }

        /// <summary>
        /// Requisição do tipo DELETE de modo assincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public async Task<string> DeleteAsync(string url)
        {
            return await DeleteAsync(url, RequestTimeout);
        }

        /// <summary>
        /// Requisição do tipo DELETE de modo sincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public string Delete(string url, int timeout)
        {
            string result = null;
            try
            {
                result = DeleteAsync(url, timeout).Result;
            }
            catch (AggregateException e)
            {
                e.Handle(x =>
                {
                    throw x;
                });
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }

        /// <summary>
        /// Requisição do tipo DELETE de modo sincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        public string Delete(string url)
        {
            return Delete(url, RequestTimeout);
        }

        #endregion
    }
}
