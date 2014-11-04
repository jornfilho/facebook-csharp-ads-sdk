using facebook_csharp_ads_sdk.Domain.BusinessRules.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.BusinessRules.Users.UserAccessToken
{
    [TestClass]
    public class IsValidUserAccessTokenTest
    {
        private string _nullFacebookToken;
        private string _emptyFacebookToken;
        private string _validFacebookToken;

        [TestInitialize]
        public void InitializeData()
        {
            _nullFacebookToken = null;
            _emptyFacebookToken = string.Empty;
            _validFacebookToken = "a";
        }

        [TestMethod]
        public void CanTestIfNullIsAValidFacebookToken()
        {
            var isValid = _nullFacebookToken.IsValidUserAccessToken();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfEmptyIsAValidFacebookToken()
        {
            var isValid = _emptyFacebookToken.IsValidUserAccessToken();

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void CanTestIfValidStringIsAValidFacebookToken()
        {
            var isValid = _validFacebookToken.IsValidUserAccessToken();

            Assert.IsTrue(isValid);
        }
    }
}
