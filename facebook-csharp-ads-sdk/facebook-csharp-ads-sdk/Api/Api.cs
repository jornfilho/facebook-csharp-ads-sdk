using System;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Infrastructure.Repository;

namespace facebook_csharp_ads_sdk.Api
{
    /// <summary>
    /// Class to initialize api connection
    /// </summary>
    public class Api : IApi
    {
        #region Properties
        private IFacebookSession _facebookSession;
        private IAdAccount _adAccount; 
        #endregion

        #region Constructor
        /// <summary>
        /// Base constructor with an instance of Facebook session
        /// </summary>
        /// <exception cref="ArgumentNullException">When facebookSession is null</exception>
        public Api(IFacebookSession facebookSession)
        {
            ChangeFacebookSession(facebookSession);
        } 
        #endregion

        #region Methods
        #region Facebook sessions
        /// <summary>
        /// Change Facebook session method
        /// </summary>
        public IApi ChangeFacebookSession(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
                throw new ArgumentNullException();

            _facebookSession = facebookSession;
            return this;
        }

        /// <summary>
        /// Get current Facebook session instance
        /// </summary>
        public IFacebookSession GetFacebookSessionInstance()
        {
            return _facebookSession;
        }  
        #endregion

        #region AdAccount
        /// <summary>
        /// Get AdAccount instance
        /// </summary>
        public IAdAccount AdAccount()
        {
            return _adAccount ?? (_adAccount = new AdAccountRespository(_facebookSession));
        } 
        #endregion

        #endregion
    }
}