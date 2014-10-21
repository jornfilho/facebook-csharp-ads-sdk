using System;
using System.Collections.Specialized;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using facebook_csharp_ads_sdk._Utils.WebRequests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace facebook_csharp_ads_sdk_unit_test
{
    [TestClass]
    public class TestBase
    {
        #region Web Requests
        public Mock<IRequest> Request;
        public string ValidUri { get; set; }
        public string InvalidUri { get; set; }
        public int InvalidRequestTimeout1 { get; set; }
        public int InvalidRequestTimeout2 { get; set; }
        public int ValidRequestTimeout { get; set; }
        private NameValueCollection EmptyNameValueCollection { get; set; }
        private NameValueCollection SingleValueNameValueCollection { get; set; }
        private NameValueCollection MultipleValuesNameValueCollection { get; set; }
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

            Request = new Mock<IRequest>();

            Request.Setup(m => m.GetAsync(null)).Throws<ArgumentException>();
            Request.Setup(m => m.GetAsync(InvalidUri)).Throws<ArgumentException>();
            Request.Setup(m => m.GetAsync(InvalidUri, InvalidRequestTimeout1)).Throws<ArgumentException>();
            Request.Setup(m => m.GetAsync(ValidUri, InvalidRequestTimeout1)).Throws<ArgumentOutOfRangeException>();
            Request.Setup(m => m.GetAsync(ValidUri, InvalidRequestTimeout2)).Throws<ArgumentOutOfRangeException>();

            Request.Setup(m => m.PostAsync(null, null)).Throws<ArgumentException>();
            Request.Setup(m => m.PostAsync(InvalidUri, null)).Throws<ArgumentException>();
            Request.Setup(m => m.PostAsync(InvalidUri, null, InvalidRequestTimeout1)).Throws<ArgumentException>();
            Request.Setup(m => m.PostAsync(ValidUri, null, InvalidRequestTimeout1)).Throws<ArgumentOutOfRangeException>();
            Request.Setup(m => m.PostAsync(ValidUri, null, InvalidRequestTimeout2)).Throws<ArgumentOutOfRangeException>();
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
