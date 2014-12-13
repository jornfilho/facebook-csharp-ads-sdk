using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.AdCampaigns
{
    /// <summary>
    ///     Unit test the extension of the campaign objective enum
    /// </summary>
    [TestClass]
    public class AdCampaignObjectiveEnumExtensionTest
    {
        [TestMethod]
        public void ShouldReturnnCampaignObjectiveEnumPageLikeIfFacebookNamePAGE_LIKES()
        {
            string facebookName = "PAGE_LIKES";
            Assert.AreEqual(AdCampaignObjectiveEnum.PageLikes, facebookName.GetCampaignObjective());
        }

        [TestMethod]
        public void ShouldReturnnCampaignObjectiveEnumUndefinedIfFacebookNameEmpty()
        {
            string facebookName = string.Empty;
            Assert.AreEqual(AdCampaignObjectiveEnum.Undefined, facebookName.GetCampaignObjective());
        }

        [TestMethod]
        public void ShouldReturnnFacebookNameEmptyIfCampaignObjectiveEnumIsUndefined()
        {
            var facebookName = AdCampaignObjectiveEnum.Undefined;
            Assert.AreEqual(string.Empty, facebookName.GetCampaignObjectiveFacebookName());
        }

        [TestMethod]
        public void ShouldReturnnFacebookNamePAGE_LIKESIfCampaignObjectiveEnumIsPageLikes()
        {
            var facebookName = AdCampaignObjectiveEnum.PageLikes;
            Assert.AreEqual("PAGE_LIKES", facebookName.GetCampaignObjectiveFacebookName());
        }
    }
}