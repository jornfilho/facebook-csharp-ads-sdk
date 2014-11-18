using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Common
{
    /// <summary>
    /// Class to indicate if class properties has valid data or only a new instance of class
    /// </summary>
    public abstract class ValidData
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
    }
}
