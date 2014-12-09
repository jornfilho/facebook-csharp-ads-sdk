using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace facebook_csharp_ads_sdk._Utils.WebRequests
{
    /// <summary>
    /// Implements <c>IRequest</c> methods
    /// </summary>
    public interface IRequest
    {
        #region Get
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
        /// Get web request sync method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        string Get(string url, int timeout);

        /// <summary>
        /// Get web request sync method
        /// </summary>
        /// <param name="url">Url to get request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        string Get(string url);
        #endregion

        #region Post
        /// <summary>
        /// Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        Task<string> PostAsync(string url, Dictionary<string, string> postData, int timeout);

        /// <summary>
        /// Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        Task<string> PostAsync(string url, Dictionary<string, string> postData);

        /// <summary>
        /// Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        string Post(string url, Dictionary<string, string> postData, int timeout);

        /// <summary>
        /// Post web request async method
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="postData">Post params collection</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        string Post(string url, Dictionary<string, string> postData);
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
        Task<string> DeleteAsync(string url, int timeout);

        /// <summary>
        /// Requisição do tipo DELETE de modo assincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        Task<string> DeleteAsync(string url);

        /// <summary>
        /// Requisição do tipo DELETE de modo sincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <param name="timeout">Request timeout value</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        string Delete(string url, int timeout);

        /// <summary>
        /// Requisição do tipo DELETE de modo sincrono
        /// </summary>
        /// <param name="url">Url to post request</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>Request result</returns>
        string Delete(string url);
        #endregion
    }
}
