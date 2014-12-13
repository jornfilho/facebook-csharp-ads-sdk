using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test.Domain.Extensions.Enums.AdCampaigns
{
    /// <summary>
    ///     Unit test the extension of the campaign status enum
    /// </summary>
    [TestClass]
    public class AdCampaignStatusEnumExtensionTest
    {
        [TestMethod]
        public void ShouldReturnCampaignStatusEnumPausedIfFacebookNamePAUSED()
        {
            const string facebookName = "PAUSED";
            Assert.AreEqual(AdCampaignStatusEnum.Paused, facebookName.GetCampaignStatus());
        }

        [TestMethod]
        public void ShouldReturnCampaignStatusEnumUndefinedIfFacebookNameEmpty()
        {
            string facebookName = string.Empty;
            Assert.AreEqual(AdCampaignStatusEnum.Undefined, facebookName.GetCampaignStatus());
        }

        [TestMethod]
        public void ShouldReturnCampaignStatusFacebookNamePAUSEDIfCampaignStatusEnumIsPaused()
        {
            var status = AdCampaignStatusEnum.Paused;

            const string facebookName = "PAUSED";
            Assert.AreEqual(facebookName, status.GetCampaignStatusFacebookName());
        }

        [TestMethod]
        public void ShouldReturnCampaignStatusFacebookNameEmptyIfCampaignStatusEnumIsUndefined()
        {
            var status = AdCampaignStatusEnum.Undefined;

            string facebookName = string.Empty;
            Assert.AreEqual(facebookName, status.GetCampaignStatusFacebookName());
        }
    }
}
