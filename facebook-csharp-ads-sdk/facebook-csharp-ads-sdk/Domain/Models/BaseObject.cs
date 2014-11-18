using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;

namespace facebook_csharp_ads_sdk.Domain.Models
{
    /// <summary>
    ///     Base object to models 
    /// </summary>
    /// <typeparam name="T"> Model </typeparam>
    public abstract class BaseObject<T>
    {
        #region Properties

        /// <summary>
        /// Api error response model
        /// </summary>
        private ApiErrorModelV22 ApiErrorResponseData { get; set; }

        /// <summary>
        /// Set true id has valid data
        /// </summary>
        private bool IsValid { get; set; }

        #endregion

        /// <summary>
        /// Return true if has valid data 
        /// </summary>
        public bool IsValidData()
        {
            return IsValid;
        }

        /// <summary>
        /// Set data valid
        /// </summary>
        public void SetValid()
        {
            if (IsValid)
                return;

            IsValid = true;
        }

        /// <summary>
        /// Set data invalid
        /// </summary>
        public void SetInvalid()
        {
            if (!IsValid)
                return;

            IsValid = false;
        }

        /// <summary>
        /// Get api error response data model
        /// </summary>
        public ApiErrorModelV22 GetApiErrorResonse()
        {
            return ApiErrorResponseData;
        }

        /// <summary>
        /// Set api error response data
        /// </summary>
        public void SetApiErrorResonse(ApiErrorModelV22 errorResponse)
        {
            ApiErrorResponseData = errorResponse;
        }

        /// <summary>
        ///     Read a T in Facebook
        /// </summary>
        /// <param name="id"> Id of the object </param>
        /// <returns> Entity with the passed id  </returns>
        public abstract T Read(long id);

        /// <summary>
        ///     Does parse the response from Facebook
        /// </summary>
        /// <param name="response"> Model Json response </param>
        /// <returns> Entity </returns>
        public abstract T ParseFacebookResponse(string response);
    }
}
