using facebook_csharp_ads_sdk.Domain.Models;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Contracts.Commons
{
    [TestClass]
    public class BaseObjectTest : BaseCrudObject<BaseObjectTest>
    {
        [TestMethod]
        public void SetInvalidTest()
        {
            this.SetValid();
            Assert.IsTrue(this.IsValid);

            this.SetInvalid();
            Assert.IsFalse(this.IsValid);
            
        }
        
        [TestMethod]
        public void IsValidDataTest_false()
        {
            this.SetInvalid();
            var isValid = this.IsValid;
            Assert.IsFalse(isValid);
            
        }

        [TestMethod]
        public void IsValidDataTest_true()
        {
            this.SetValid();
            var isValid = this.IsValid;
            Assert.IsTrue(isValid);

        }

        [TestMethod]
        public void GetApiErrorResonse_null()
        {
            this.SetApiErrorResonse(null);
            
            Assert.IsFalse(this.IsValid);
            Assert.IsNull(this.ApiErrorResponseData);

        }

        [TestMethod]
        public void GetApiErrorResonse_empty()
        {
            var model = new ApiErrorModelV22();
            this.SetApiErrorResonse(model);

            Assert.IsFalse(this.IsValid);
            Assert.IsNotNull(this.ApiErrorResponseData);

        }

        public override BaseObjectTest Create()
        {
            throw new System.NotImplementedException();
        }

        public override BaseObjectTest ReadSingle(long id)
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete()
        {
            throw new System.NotImplementedException();
        }

        public override bool Delete(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
