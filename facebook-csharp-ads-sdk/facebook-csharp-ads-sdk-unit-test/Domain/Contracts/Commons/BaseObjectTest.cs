using facebook_csharp_ads_sdk.Domain.Models;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Contracts.Commons
{
    [TestClass]
    public class BaseObjectTest : BaseObject<BaseObjectTest>
    {
        [TestMethod]
        public void SetInvalidTest()
        {
            this.SetValid();
            Assert.IsTrue(this.IsValidData());

            this.SetInvalid();
            Assert.IsFalse(this.IsValidData());
            
        }
        
        [TestMethod]
        public void IsValidDataTest_false()
        {
            this.SetInvalid();
            var isValid = this.IsValidData();
            Assert.IsFalse(isValid);
            
        }

        [TestMethod]
        public void IsValidDataTest_true()
        {
            this.SetValid();
            var isValid = this.IsValidData();
            Assert.IsTrue(isValid);

        }

        [TestMethod]
        public void GetApiErrorResonse_null()
        {
            this.SetApiErrorResonse(null);
            
            Assert.IsFalse(this.IsValidData());
            Assert.IsNull(this.GetApiErrorResonse());

        }

        [TestMethod]
        public void GetApiErrorResonse_empty()
        {
            var model = new ApiErrorModelV22();
            this.SetApiErrorResonse(model);

            Assert.IsFalse(this.IsValidData());
            Assert.IsNotNull(this.GetApiErrorResonse());

        }

        public override BaseObjectTest Read(long id)
        {
            throw new System.NotImplementedException();
        }

        public override BaseObjectTest ParseFacebookResponse(string response)
        {
            throw new System.NotImplementedException();
        }
    }
}
