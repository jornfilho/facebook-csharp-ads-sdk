using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCreatives;
using facebook_csharp_ads_sdk.Domain.Models.AdCreative;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.AdCreatives.AdCreative
{
    [TestClass]
    public class SetPagePostAdDataTest : TestBase
    {
        readonly ICreativeRepository _creativeRepository = new AdCreativeRepository(new FacebookSessionRepository());
        private facebook_csharp_ads_sdk.Domain.Models.AdCreative.AdCreative _model;

        [TestInitialize]
        public void Initialize()
        {
            _model = new facebook_csharp_ads_sdk.Domain.Models.AdCreative.AdCreative(_creativeRepository);
        }

        #region Object Story Spec


        [TestMethod]
        [ExpectedException(typeof(InvalidAdCreativeIdException))]
        public void MustThrowExceptionToSetEventAdDataIfCreativeIdIsInvalid()
        {
            _model.SetPagePostAdData(InvalidAdCreativeId, ValidAdAccountId, null as ObjectStorySpec, null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidAdAccountId))]
        public void MustThrowExceptionToSetEventAdDataIfAccountIdIsInvalid()
        {
            _model.SetPagePostAdData(ValidAdCreativeId, InvalidAdAccountId1, null as ObjectStorySpec, null, null);
        }

        #endregion
    }
}
