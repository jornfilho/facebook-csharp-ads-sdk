using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

namespace facebook_csharp_ads_sdk._Utils.WebRequests
{
    /// <summary>
    /// Implements <c>IRequest</c> methods
    /// </summary>
    public interface IRequest
    {
        /// <summary>
        /// Get web request async method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        Task<string> GetAsync(string url, int timeout);

        /// <summary>
        /// Get web request async method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        Task<string> GetAsync(string url);

        /// <summary>
        /// Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        Task<string> PostAsync(string url, NameValueCollection postData, int timeout);

        /// <summary>
        /// Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        Task<string> PostAsync(string url, NameValueCollection postData);
    }
}
