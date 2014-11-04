using System;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;

namespace facebook_csharp_ads_sdk.Api
{
    /// <summary>
    /// Class to initialize api connection
    /// </summary>
    public class Api
    {
        #region Properties
        private IFacebookSession _facebookSession; 
        #endregion

        /// <summary>
        /// Base constructor with an instance of Facebook session
        /// </summary>
        /// <exception cref="ArgumentNullException">When facebookSession is null</exception>
        public Api(IFacebookSession facebookSession)
        {
            ChangeFacebookSession(facebookSession);
        }

        /// <summary>
        /// Base Facebook session instance
        /// </summary>
        /// <exception cref="ArgumentNullException">When facebookSession is null</exception>
        public void ChangeFacebookSession(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
                throw new ArgumentNullException();

            _facebookSession = facebookSession;
        }

        /// <summary>
        /// Get current facebook session
        /// </summary>
        public IFacebookSession GetFacebookSessionInstance()
        {
            return _facebookSession;
        }

        
    }
}
