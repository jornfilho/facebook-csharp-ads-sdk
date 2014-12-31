using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.Targetings;
using facebook_csharp_ads_sdk.Domain.Exceptions.Targetings;
using facebook_csharp_ads_sdk.Domain.Models.Targetings;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Models.Targetings
{
    [TestClass]
    public class TargetingDemographicsSetCreateDataTest
    {
        private int? ageMin;
        private int? ageMax;
        private IList<GenderTypeEnum> genderTypeList;

        [TestInitialize]
        public void Initialize()
        {
            this.ageMin = 20;
            this.ageMax = 50;
            this.genderTypeList = new List<GenderTypeEnum>
                                  {
                                      GenderTypeEnum.NotSpecified
                                  };
        }

        [TestMethod]
        [ExpectedException(typeof(TargetingDemographicsAgeMinMustBeGreatherThan13Exception))]
        public void MustBeThrowExceptionIfMinAgeLessThan13()
        {
            this.ageMin = 10;
            new TargetingDemographics().SetAttributesToCreate(this.ageMin, this.ageMax, this.genderTypeList);
        }

        [TestMethod]
        [ExpectedException(typeof(TargetingDemographicsAgeMaxMustBeLessThan65Exception))]
        public void MustBeThrowExceptionIfMaxAgeGreatherThan65()
        {
            this.ageMax = 70;
            new TargetingDemographics().SetAttributesToCreate(this.ageMin, this.ageMax, this.genderTypeList);
        }

        [TestMethod]
        public void ShouldSetAttributesIfAllCorretly()
        {
            var targetingDemographics = new TargetingDemographics().SetAttributesToCreate(this.ageMin, this.ageMax, this.genderTypeList);
            Assert.IsNotNull(targetingDemographics);
            Assert.AreEqual(this.ageMin, targetingDemographics.AgeMin);
            Assert.AreEqual(this.ageMax, targetingDemographics.AgeMax);
            Assert.AreEqual(this.genderTypeList, targetingDemographics.Genders);
        }
    }
}
