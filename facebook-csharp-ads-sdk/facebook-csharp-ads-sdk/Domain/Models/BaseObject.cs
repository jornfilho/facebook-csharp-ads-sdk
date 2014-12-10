using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;

namespace facebook_csharp_ads_sdk.Domain.Models
{
    /// <summary>
    ///     Base object to models 
    /// </summary>
    public abstract class BaseObject
    {
        #region Properties

        /// <summary>
        /// Api error response model
        /// </summary>
        public ApiErrorModelV22 ApiErrorResponseData { get; private set; }

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
            IsValid = true;
        }

        /// <summary>
        /// Set data invalid
        /// </summary>
        public void SetInvalid()
        {
            IsValid = false;
        }

        /// <summary>
        /// Set api error response data
        /// </summary>
        public void SetApiErrorResonse(ApiErrorModelV22 errorResponse)
        {
            this.SetInvalid();
            ApiErrorResponseData = errorResponse;
        }
    }
}
