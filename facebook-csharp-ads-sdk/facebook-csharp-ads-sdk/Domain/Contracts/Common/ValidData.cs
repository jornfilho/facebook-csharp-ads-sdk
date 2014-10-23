namespace facebook_csharp_ads_sdk.Domain.Contracts.Common
{
    /// <summary>
    /// Class to indicate if class properties has valid data or only a new instance of class
    /// </summary>
    public abstract class ValidData
    {
        /// <summary>
        /// Set true id has valid data
        /// </summary>
        private bool IsValid { get; set; }

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
    }
}
