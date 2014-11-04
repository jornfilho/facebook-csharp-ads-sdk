namespace facebook_csharp_ads_sdk.Domain.Contracts.Services
{
    /// <summary>
    /// Api interface
    /// </summary>
    public interface IApi
    {
        /// <summary>
        /// Change Facebook session method
        /// </summary>
        IApi ChangeFacebookSession(IFacebookSession facebookSession);

        /// <summary>
        /// Get current Facebook session instance
        /// </summary>
        IFacebookSession GetFacebookSessionInstance();
        
        /// <summary>
        /// Get AdAccount instance
        /// </summary>
        IAdAccount AdAccount();
    }
}
