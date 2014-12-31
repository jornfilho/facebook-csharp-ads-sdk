using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;

namespace facebook_csharp_ads_sdk._Utils.WebRequests
{
    /// <summary>
    ///     Facebook request
    /// </summary>
    public class FacebookRequest : IRequest
    {
        #region Properties 

        /// <summary>
        ///     Instance of the facebook session
        /// </summary>
        private readonly IFacebookSession facebookSession;

        /// <summary>
        ///     Web request object
        /// </summary>
        private readonly Request webRequest;

        #endregion Properties

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        public FacebookRequest(IFacebookSession facebookSession)
        {
            this.webRequest = new Request();
            this.facebookSession = facebookSession;
        }

        #endregion Constructor

        #region Get

        /// <summary>
        ///     Get web request async method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <param name="timeout">Request timeout value - millisseconds</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public async Task<string> GetAsync(string url, int timeout)
        {
            this.ValidateFacebookToken();
            return await this.webRequest.GetAsync(url, timeout);
        }

        /// <summary>
        ///     Get web request async method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public async Task<string> GetAsync(string url)
        {
            this.ValidateFacebookToken();
            return await this.webRequest.GetAsync(url);
        }

        /// <summary>
        ///     Get web request sync method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public string Get(string url, int timeout)
        {
            this.ValidateFacebookToken();
            return this.webRequest.Get(url, timeout);
        }

        /// <summary>
        ///     Get web request sync method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public string Get(string url)
        {
            this.ValidateFacebookToken();
            return this.webRequest.Get(url);
        }

        #endregion Get

        #region Post

        /// <summary>
        ///     Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <param name="timeout">Request timeout value - millisseconds</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public async Task<string> PostAsync(string url, Dictionary<string, string> postData, int timeout)
        {
            this.ValidateFacebookToken();
            return await this.webRequest.PostAsync(url, postData, timeout);
        }

        /// <summary>
        ///     Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public async Task<string> PostAsync(string url, Dictionary<string, string> postData)
        {
            this.ValidateFacebookToken();
            return await this.webRequest.PostAsync(url, postData);
        }

        /// <summary>
        ///     Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public string Post(string url, Dictionary<string, string> postData, int timeout)
        {
            this.ValidateFacebookToken();
            return this.webRequest.Post(url, postData, timeout);
        }

        /// <summary>
        ///     Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public string Post(string url, Dictionary<string, string> postData)
        {
            this.ValidateFacebookToken();
            return this.webRequest.Post(url, postData);
        }

        #endregion Post

        #region Delete

        /// <summary>
        ///     Requisição do tipo DELETE de modo assincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public async Task<string> DeleteAsync(string url, int timeout)
        {
            this.ValidateFacebookToken();
            return await this.webRequest.DeleteAsync(url, timeout);
        }

        /// <summary>
        ///     Requisição do tipo DELETE de modo assincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public async Task<string> DeleteAsync(string url)
        {
            this.ValidateFacebookToken();
            return await this.webRequest.DeleteAsync(url);
        }

        /// <summary>
        ///     Requisição do tipo DELETE de modo sincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public string Delete(string url, int timeout)
        {
            this.ValidateFacebookToken();
            return this.webRequest.Delete(url, timeout);
        }

        /// <summary>
        ///     Requisição do tipo DELETE de modo sincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns>Request result</returns>
        public string Delete(string url)
        {
            this.ValidateFacebookToken();
            return this.webRequest.Delete(url);
        }

        #endregion Delete

        #region Private methods

        /// <summary>
        ///     Validate the request
        /// </summary>
        public void ValidateFacebookToken()
        {
            this.facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
        }

        #endregion Private methods
    }
}