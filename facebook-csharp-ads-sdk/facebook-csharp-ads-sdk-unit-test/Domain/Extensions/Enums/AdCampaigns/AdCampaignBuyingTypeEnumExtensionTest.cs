using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.AdCampaigns
{
    /// <summary>
    ///     Unit test the extension of the enum AdCampaignBuyingTypeEnum
    /// </summary>
    [TestClass]
    public class AdCampaignBuyingTypeEnumExtensionTest
    {
        [TestMethod]
        public void ShouldReturnAuctionEnumIfFacebookNameAUCTION()
        {
            const string facebookName = "AUCTION";
            Assert.AreEqual(AdCampaignBuyingTypeEnum.Auction, facebookName.GetBuyingTypeEnum());
        }

        [TestMethod]
        public void ShouldReturnUndefinedEnumIfFacebookNameEmpty()
        {
            string facebookName = string.Empty;
            Assert.AreEqual(AdCampaignBuyingTypeEnum.Undefined, facebookName.GetBuyingTypeEnum());
        }

        [TestMethod]
        public void ShouldReturnFacebookNameAuctionIfEnumAuction()
        {
            const AdCampaignBuyingTypeEnum buyingTypeEnum = AdCampaignBuyingTypeEnum.Auction;
            Assert.AreEqual("AUCTION", buyingTypeEnum.GetBuyingTypeFacebookName());
        }

        [TestMethod]
        public void ShouldReturnFacebookEmptyAuctionIfEnumUndefined()
        {
            const AdCampaignBuyingTypeEnum buyingTypeEnum = AdCampaignBuyingTypeEnum.Undefined;
            Assert.AreEqual(string.Empty, buyingTypeEnum.GetBuyingTypeFacebookName());
        }
    }
}