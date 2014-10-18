using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk.test
{
    [TestClass]
    public class TestBase
    {
        #region Repositories
        public IFacebookSession repositoryFacebookSession; 
        public IAdAccount repositoryAdAccount; 
        #endregion

        #region Facebook session data
        public long InvalidAppId;
        public long ValidAppId;

        public string ValidAppSecret;
        public string InvalidAppSecret1;
        public string InvalidAppSecret2; 

        public string ValidAccessToken; 
        public string InvalidAccessToken1; 
        public string InvalidAccessToken2;
        #endregion

        public long InvalidAccountId;
        public long ValidAccountId;

        [TestInitialize]
        public void InitializeTestBase()
        {
            repositoryFacebookSession = new FacebookSessionRepository();
            repositoryAdAccount = new AdAccountRespository(repositoryFacebookSession);

            #region Facebook session data
            InvalidAppId = 0;
            ValidAppId = 1;

            InvalidAppSecret1 = InvalidAccessToken1 = null;
            InvalidAppSecret2 = InvalidAccessToken2 = "";
            ValidAppSecret = ValidAccessToken = "a";
            #endregion

            InvalidAccountId = 0;
            ValidAccountId = 1;
        }
    }
}
