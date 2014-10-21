using System.Collections.Specialized;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using facebook_csharp_ads_sdk._Utils.WebRequests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_integration_test
{
    [TestClass]
    public class TestBase
    {
        #region Web Requests
        public IRequest Request;
        public string ValidUri { get; set; }
        public string InvalidUri { get; set; }
        public int InvalidRequestTimeout1 { get; set; }
        public int InvalidRequestTimeout2 { get; set; }
        public int ValidRequestTimeout { get; set; }
        public NameValueCollection EmptyNameValueCollection { get; set; }
        public NameValueCollection SingleValueNameValueCollection { get; set; }
        public NameValueCollection MultipleValuesNameValueCollection { get; set; }
        #endregion

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
            #region Web requests
            ValidUri = "http://private-5eeb3-fbcsharpadssdkbasicendpoint.apiary-mock.com/basic";
            InvalidUri = "";

            ValidRequestTimeout = 1000;
            InvalidRequestTimeout1 = 0;
            InvalidRequestTimeout2 = -1000;

            EmptyNameValueCollection = new NameValueCollection();
            SingleValueNameValueCollection = new NameValueCollection { { "param1", "value1" } };
            MultipleValuesNameValueCollection = new NameValueCollection
            {
                {"param1", "value1"},
                {"param2", "value2"},
                {"param3", "value3"}
            };

            Request = new Request();
            #endregion

            #region Facebook session data
            InvalidAppId = 0;
            ValidAppId = 1;

            InvalidAppSecret1 = InvalidAccessToken1 = null;
            InvalidAppSecret2 = InvalidAccessToken2 = "";
            ValidAppSecret = ValidAccessToken = "a";
            #endregion

            InvalidAccountId = 0;
            ValidAccountId = 1;

            #region Repositories
            repositoryFacebookSession = new FacebookSessionRepository();
            repositoryFacebookSession.SetDefaultApplication(ValidAppId, ValidAppSecret);
            repositoryFacebookSession.SetAccessToken(ValidAccessToken);

            repositoryAdAccount = new AdAccountRespository(repositoryFacebookSession);
            #endregion
        }
    }
}
