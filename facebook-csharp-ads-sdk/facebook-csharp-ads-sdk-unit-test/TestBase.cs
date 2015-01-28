using System;
using System.Collections.Generic;
using DevUtils.DateTimeExtensions;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.AdUsers;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup;
using facebook_csharp_ads_sdk.Infrastructure.Repository;
using facebook_csharp_ads_sdk._Utils.WebRequests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace facebook_csharp_ads_sdk_unit_test
{
    [TestClass]
    public class TestBase
    {
        #region Web Requests
        public IRequest WebRequest;
        public string ValidUri { get; set; }
        public string InvalidUri { get; set; }
        public int InvalidRequestTimeout1 { get; set; }
        public int InvalidRequestTimeout2 { get; set; }
        public int ValidRequestTimeout { get; set; }
        public Dictionary<string,string> EmptyNameValueCollection { get; set; }
        public Dictionary<string, string> SingleValueNameValueCollection { get; set; }
        public Dictionary<string, string> MultipleValuesNameValueCollection { get; set; }
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

        #region AdAccount and related

        #region AdAccount
        public long InvalidAdAccountId1;
        public long InvalidAdAccountId2;
        public long ValidAdAccountId;
        public string InvalidAdAccountStrId1;
        public string InvalidAdAccountStrId2;
        public string ValidAdAccountStrId;
        public string ValidAdAccountName;
        public AdAccountStatusEnum InvalidAdAccountStatus;
        public AdAccountStatusEnum ValidAdAccountStatus;
        public float InvalidAdAccountAge1;
        public float InvalidAdAccountAge2;
        public float ValidAdAccountAge;
        public IList<CapabilitiesEnum> InvalidAdAccountCapabilities;
        public IList<CapabilitiesEnum> ValidAdAccountCapabilities;
        public long InvalidAdAccountEndAdvertiser1;
        public long InvalidAdAccountEndAdvertiser2;
        public long ValidAdAccountEndAdvertiser;
        public long InvalidAdAccountMediaAgency1;
        public long InvalidAdAccountMediaAgency2;
        public long ValidAdAccountMediaAgency;
        public long InvalidAdAccountPartner1;
        public long InvalidAdAccountPartner2;
        public long ValidAdAccountPartner;
        public IList<long> InvalidAdAccountTosAccepted1;
        public IList<long> InvalidAdAccountTosAccepted2;
        public IList<long> ValidAdAccountTosAccepted;
        public TaxStatusEnum InvalidAdAccountTaxStatus;
        public TaxStatusEnum InvalidAdAccountTaxStatus2;
        public TaxStatusEnum ValidAdAccountTaxStatus;
        public string ValidAdAccountSingleResultResponse1;
        public string InvalidAdAccountSingleResultResponse1;
        public string InvalidAdAccountSingleResultResponse2;
        public string InvalidAdAccountSingleResultResponse3;

        #endregion

        #region AdAccountGroup
        public long InvalidAdAccountGroupId1;
        public long InvalidAdAccountGroupId2;
        public long ValidAdAccountGroupId;
        public string InvalidAdAccountGroupName1;
        public string InvalidAdAccountGroupName2;
        public string ValidAdAccountGroupName;
        public AdAccountGroupsStatusEnum InvalidAdAccountGroupStatus;
        public AdAccountGroupsStatusEnum ValidAdAccountGroupStatus;
        public AdAccountGroup ValidAdAccountGroup;
        #endregion

        #region AdCreative

        public long ValidAdCreativeId;
        public long InvalidAdCreativeId;
        public string ValidAdCreativeTitle;
        public string InvalidAdCreativeTitle;
        public string ValidAdCreativeBody;
        public string InvalidAdCreativeBody;
        public string ValidAdCreativeObjectUrl;
        public string InvalidAdCreativeObjectUrl;
        public string ValidAdCreativeImageFile;
        public string InvalidAdCreativeImageFile;
        public string ValidAdCreativeImageHash;
        public string InvalidAdCreativeImageHash;
        public string ValidAdCreativeName;
        public string ValidAdCreativeActorId;
        public string ValidAdCreativeObjectId;
        public string InvalidAdCreativeObjectId;
        public string ValidAdCreativeLinkUrl;
        public string ValidAdCreativeImageCrops;
        public string ValidAdCreativeObjectStoryId;
        public string InvalidAdCreativeObjectStoryId;
        public string ValidAdCreativeUrlTags;
        public long ValidAdCreativePageId;
        public string ValidAdCreativeMessage;

        #endregion AdCreative

        #region ObjectStorySpec

        public long InvalidPageId;
        public string ValidSpecLink;
        public string InvalidSpecLink;
        public string ValidSpecMessage;
        public string InvalidSpecMessage;
        public string ValidSpecName;
        public string InvalidSpecName;
        public string ValidSpecCaption;
        public string InvalidSpecCaption;
        public string ValidSpecDescription;
        public string InvalidSpecDescription;
        public string ValidSpecPicture;
        public string InvalidSpecPicture;
        public string ValidSpecImageHash;
        public string InvalidSpecImageHash;
        public string ValidSpecImageCrops;
        public string InvalidSpecImageCrops;

        #endregion ObjectStorySpec

        #region BusinessInformations
        public BusinessInformations ValidBusinessInformations;
        #endregion

        #region AgencyClientDeclaration
        public string ValidClientCity;
        public string ValidClientCountryCode;
        public string ValidClientEmailAddress;
        public string ValidClientName;
        public string ValidClientPostalCode;
        public string ValidClientProvince;
        public string ValidClientStreet;
        public string ValidClientStreet2;
        public AgencyClientDeclaration ValidAgencyClientDeclaration;
        #endregion

        #region FinancialInformations
        public long InvalidAdAccountAmountSpent1;
        public long InvalidAdAccountAmountSpent2;
        public long ValidAdAccountAmountSpent;
        public long InvalidAdAccountBalance1;
        public long InvalidAdAccountBalance2;
        public long ValidAdAccountBalance;
        public long InvalidAdAccountDailySpendLimit1;
        public long InvalidAdAccountDailySpendLimit2;
        public long ValidAdAccountDailySpendLimit;

        public long InvalidAdAccountSpendCap1;
        public long InvalidAdAccountSpendCap2;
        public long ValidAdAccountSpendCap;

        public CurrenciesEnum InvalidFinancialInformationsCurrency;
        public CurrenciesEnum ValidFinancialInformationsCurrency;

        public long InvalidAdAccountFundingSourceId1;
        public long InvalidAdAccountFundingSourceId2;
        public long ValidAdAccountFundingSourceId;

        public FundingSourceDetail InvalidFundingSourceDetail1;
        public FundingSourceDetail InvalidFundingSourceDetail2;
        public FundingSourceDetail ValidFundingSourceDetail;

        public FinancialInformations ValidFinancialInformations;
        #endregion

        #region FundingSourceCoupon
        public long ValidFundingSourceCuponAmount;
        public long InvalidFundingSourceCuponAmount1;
        public long InvalidFundingSourceCuponAmount2;
        public CurrenciesEnum ValidFundingSourceCuponCurrency;
        public CurrenciesEnum InvalidFundingSourceCuponCurrency;
        public DateTime ValidFundingSourceCuponExpirationDate;
        public DateTime InvalidFundingSourceCuponExpirationDate;
        public string ValidFundingSourceCuponDisplayAmount;
        public string InvalidFundingSourceCuponDisplayAmount1;
        public string InvalidFundingSourceCuponDisplayAmount2;
        #endregion

        #region FundingSourceDetail
        public long ValidFundingSourceDetailId;
        public long InvalidFundingSourceDetailId1;
        public long InvalidFundingSourceDetailId2;
        public string ValidFundingSourceDetailDisplayString;
        public string InvalidFundingSourceDetailDisplayString1;
        public string InvalidFundingSourceDetailDisplayString2;
        public int ValidFundingSourceDetailType;
        public int InvalidFundingSourceDetailType1;
        public int InvalidFundingSourceDetailType2;
        public FundingSourceCoupon ValidFundingSourceDetailCoupon;
        public FundingSourceCoupon InvalidFundingSourceDetailCupon1;
        public FundingSourceCoupon InvalidFundingSourceDetailCupon2;
        #endregion

        #region TimezoneInformations
        public int ValidTimezoneId;
        public int InvalidTimezoneId1;
        public int InvalidTimezoneId2;
        public string ValidTimezoneName;
        public string InvalidTimezoneName1;
        public string InvalidTimezoneName2;
        public int ValidTimezoneOffsetHoursFromUtc;
        public TimezoneInformations ValidTimezoneInformations;
        #endregion

        #region User
        public IList<UserPermissionsEnum> ValidUserPermissions;
        public IList<UserPermissionsEnum> InvalidUserPermissions1;
        public IList<UserPermissionsEnum> InvalidUserPermissions2;
        public UserRoleEnum ValidUserRole;
        public UserRoleEnum InvalidUserRole;
        public long ValidUserUserId;
        public long InvalidUserUserId1;
        public long InvalidUserUserId2;
        public User ValidAdAccountUser;
        #endregion 
        #endregion

        #region Repositories
        public IFacebookSession RepositoryFacebookSession;
        public IAccountRepository RepositoryAdAccount;
        #endregion

        [TestInitialize]
        public void InitializeTestBase()
        {
            WebRequests();
            FacebookSessionData();
            AdAccountAndRelateds();
            AdCreative();
            ObjectStorySpec();
            Repositories();
        }

        private void WebRequests()
        {
            WebRequest = new Request();
            ValidUri = "http://private-5eeb3-fbcsharpadssdkbasicendpoint.apiary-mock.com/basic";
            InvalidUri = "";

            ValidRequestTimeout = 1000;
            InvalidRequestTimeout1 = 0;
            InvalidRequestTimeout2 = -1000;

            EmptyNameValueCollection = new Dictionary<string, string>();
            SingleValueNameValueCollection = new Dictionary<string, string> { { "param1", "value1" } };
            MultipleValuesNameValueCollection = new Dictionary<string, string>
            {
                {"param1", "value1"},
                {"param2", "value2"},
                {"param3", "value3"}
            };
        }

        private void FacebookSessionData()
        {
            InvalidAppId = 0;
            ValidAppId = 1;

            InvalidAppSecret1 = InvalidAccessToken1 = null;
            InvalidAppSecret2 = InvalidAccessToken2 = "";
            ValidAppSecret = ValidAccessToken = "a";
        }

        #region AdAccountAndRelateds
        private void AdAccountAndRelateds()
        {
            AdAccount();
            AdAccountGroup();
            BusinessInformations();
            AgencyClientDeclaration();
            FundingSourceCupon();
            FundingSourceDetail();
            FinancialInformations();
            TimezoneInformations();
            User();
        }

        private void AdAccount()
        {
            InvalidAdAccountId1 = 0;
            InvalidAdAccountId2 = -1;
            ValidAdAccountId = 1;
            InvalidAdAccountStrId1 = "";
            InvalidAdAccountStrId1 = string.Format("act_{0}", InvalidAdAccountId1);
            ValidAdAccountStrId = string.Format("act_{0}", ValidAdAccountId);
            ValidAdAccountName = "a";
            InvalidAdAccountStatus = AdAccountStatusEnum.Undefined;
            ValidAdAccountStatus = AdAccountStatusEnum.Active;
            InvalidAdAccountAge1 = -1;
            InvalidAdAccountAge2 = 0;
            ValidAdAccountAge = 1;
            InvalidAdAccountCapabilities = new List<CapabilitiesEnum> { CapabilitiesEnum.CustomAudienceFolders, CapabilitiesEnum.Undefined };
            ValidAdAccountCapabilities = new List<CapabilitiesEnum> { CapabilitiesEnum.CustomAudienceFolders, CapabilitiesEnum.Pemium };
            InvalidAdAccountEndAdvertiser1 = 0;
            InvalidAdAccountEndAdvertiser2 = -1;
            ValidAdAccountEndAdvertiser = 1;
            InvalidAdAccountMediaAgency1 = 0;
            InvalidAdAccountMediaAgency2 = -1;
            ValidAdAccountMediaAgency = 1;
            InvalidAdAccountPartner1 = 0;
            InvalidAdAccountPartner2 = -1;
            ValidAdAccountPartner = 1;
            InvalidAdAccountTosAccepted1 = new List<long> { -1, 1, 2 };
            InvalidAdAccountTosAccepted2 = new List<long> { 0, 1, 2 };
            ValidAdAccountTosAccepted = new List<long> { 1, 2, 3 };
            InvalidAdAccountTaxStatus = TaxStatusEnum.Undefined;
            ValidAdAccountTaxStatus = TaxStatusEnum.AccountIsAPersonalAccount;
            ValidAdAccountSingleResultResponse1 = "{\"tax_id_status\": 5, \"tos_accepted\": {\"0123\": 1}, \"end_advertiser\": {\"category\": \"Company\",\"name\": \"Lorem ipsum\",\"id\": \"123456\"},\"account_groups\":[{\"account_group_id\":1,\"name\":\"Active group\",\"status\":1},{\"account_group_id\":2,\"name\":\"Deleted group\",\"status\":2}],\"account_id\":\"987654321\",\"account_status\":1,\"age\":31.161550925926,\"amount_spent\":11203,\"balance\":0,\"business_city\":\"Sorocaba\",\"business_country_code\":\"BR\",\"business_name\":\"Lorem ipsum dolor sit amet\",\"business_state\":\"SP\",\"business_street\":\"A. Lorem ipsum, 1422\",\"business_street2\":\"Dolor sit amet\",\"business_zip\":\"12345678\",\"capabilities\":[\"PREMIUM\",\"NEW_CAMPAIGN_STRUCTURE\",\"MOBILE_ADVERTISER_ID_UPLOAD\",\"LOOKALIKE_ADVANCED_CONFIG\",\"PRORATED_BUDGET\",\"OFFSITE_CONVERSION_HIGH_BID\",\"MOBILE_APP_REENGAGEMENT_ADS\",\"NEKO_DESKTOP_CANVAS_APP_ADS\",\"MOBILE_APP_VIDEO_ADS\",\"CAN_USE_IMPROVED_GEO\",\"HAS_AVAILABLE_PAYMENT_METHODS\",\"CAN_USE_OLD_AD_TYPES\",\"HAS_AD_SET_TARGETING\",\"CAN_USE_VIDEO_METRICS_BREAKDOWN\"],\"currency\":\"BRL\",\"daily_spend_limit\":11342,\"funding_source\":102030405060,\"funding_source_details\":{\"id\":\"102030405060\",\"type\":1,\"display_string\":\"MasterCard *1573\",\"coupon\":{\"amount\":7218,\"currency\":\"BRL\",\"expiration\":1418630400,\"display_amount\":\"R$72.18 BRL\"}},\"id\":\"act_987654321\",\"is_personal\":0,\"name\":\"Lorem ipsum dolor sit amet\",\"offsite_pixels_tos_accepted\":false,\"timezone_id\":25,\"timezone_name\":\"America/Sao_Paulo\",\"timezone_offset_hours_utc\":-2,\"users\":[{\"uid\":123,\"permissions\":[1,2,3,4,5,7],\"role\":1001},{\"uid\":456,\"permissions\":[2,3,4,7],\"role\":1002},{\"uid\":789,\"permissions\":[2,3,4,7],\"role\":1003}]}";
            InvalidAdAccountSingleResultResponse1 = null;
            InvalidAdAccountSingleResultResponse2 = "";
            InvalidAdAccountSingleResultResponse3 = "{\"error\": {\"message\": \"Unsupported get request. Please read the Graph API documentation at https://developers.facebook.com/docs/graph-api\",\"type\": \"GraphMethodException\",\"code\": 100}}";
        }

        private void AdCreative()
        {
            ValidAdCreativeId = 1;
            InvalidAdCreativeId = 0;
            ValidAdCreativeTitle = "title";
            InvalidAdCreativeTitle = "";
            ValidAdCreativeBody = "body";
            InvalidAdCreativeBody = "";
            ValidAdCreativeObjectUrl = "www.object.com";
            InvalidAdCreativeObjectUrl = "";
            ValidAdCreativeImageFile = "imagefile";
            InvalidAdCreativeImageFile = "";
            ValidAdCreativeImageHash = "imageHash";
            InvalidAdCreativeImageHash = "";
            ValidAdCreativeName = "name";
            ValidAdCreativeActorId = "actorId";
            ValidAdCreativeObjectId = "objectId";
            InvalidAdCreativeObjectId = "";
            ValidAdCreativeLinkUrl = "linkurl";
            ValidAdCreativeImageCrops = "imagecrops";
            ValidAdCreativeObjectStoryId = "objectstoryid";
            InvalidAdCreativeObjectStoryId = "";
            ValidAdCreativeUrlTags = "urltags";
            ValidAdCreativePageId = 1;
            ValidAdCreativeMessage = "message";
        }

        private void ObjectStorySpec()
        {
            InvalidPageId = 0;
            ValidSpecLink = "link";
            InvalidSpecLink = "";
            ValidSpecMessage = "message";
            InvalidSpecMessage = "";
            ValidSpecName = "name";
            InvalidSpecName = "";
            ValidSpecCaption = "caption";
            InvalidSpecCaption = "";
            ValidSpecDescription = "description";
            InvalidSpecDescription = "";
            ValidSpecPicture = "picture";
            InvalidSpecPicture = "";
            ValidSpecImageHash= "imagehash";
            InvalidSpecImageHash= "";
            ValidSpecImageCrops = "imagecrops";
            InvalidSpecImageCrops = "";
        }

        private void AdAccountGroup()
        {
            InvalidAdAccountGroupId1 = 0;
            InvalidAdAccountGroupId2 = -1;
            ValidAdAccountGroupId = 1;
            InvalidAdAccountGroupName1 = null;
            InvalidAdAccountGroupName2 = string.Empty;
            ValidAdAccountGroupName = "a";
            InvalidAdAccountGroupStatus = AdAccountGroupsStatusEnum.Undefined;
            ValidAdAccountGroupStatus = AdAccountGroupsStatusEnum.Active;
            ValidAdAccountGroup = new AdAccountGroup().SetAdAccountGroupData(
                ValidAdAccountGroupId,
                ValidAdAccountGroupName,
                ValidAdAccountGroupStatus
            );
        }

        private void BusinessInformations()
        {
            ValidBusinessInformations = new BusinessInformations()
                .SetBusinessInformationsData("a", "b", "c", "d", "e", "f", "g");
        }

        private void AgencyClientDeclaration()
        {
            ValidClientCity = "a";
            ValidClientCountryCode = "b";
            ValidClientEmailAddress = "test@test.com";
            ValidClientName = "d";
            ValidClientPostalCode = "e";
            ValidClientProvince = "f";
            ValidClientStreet = "g";
            ValidClientStreet2 = "h";
            ValidAgencyClientDeclaration = new AgencyClientDeclaration()
                .SetClientSummaryInformationsData(true, true, true, true)
                .SetClientAddressInformationsData(
                    ValidClientCity,
                    ValidClientCountryCode,
                    ValidClientEmailAddress,
                    ValidClientName,
                    ValidClientPostalCode,
                    ValidClientProvince,
                    ValidClientStreet,
                    ValidClientStreet2
                );
        }

        private void FundingSourceCupon()
        {
            ValidFundingSourceCuponAmount = 1;
            InvalidFundingSourceCuponAmount1 = 0;
            InvalidFundingSourceCuponAmount2 = -1;
            ValidFundingSourceCuponCurrency = CurrenciesEnum.USD;
            InvalidFundingSourceCuponCurrency = CurrenciesEnum.UND;
            ValidFundingSourceCuponExpirationDate = DateTime.UtcNow;
            InvalidFundingSourceCuponExpirationDate = new DateTime();
            ValidFundingSourceCuponDisplayAmount = "a";
            InvalidFundingSourceCuponDisplayAmount1 = string.Empty;
            InvalidFundingSourceCuponDisplayAmount2 = null;
        }

        private void FundingSourceDetail()
        {
            ValidFundingSourceDetailId = 1;
            InvalidFundingSourceDetailId1 = 0;
            InvalidFundingSourceDetailId2 = -1;
            ValidFundingSourceDetailDisplayString = "a";
            InvalidFundingSourceDetailDisplayString1 = string.Empty;
            InvalidFundingSourceDetailDisplayString2 = null;
            ValidFundingSourceDetailType = 1;
            InvalidFundingSourceDetailType1 = 0;
            InvalidFundingSourceDetailType2 = -1;
            ValidFundingSourceDetailCoupon = new FundingSourceCoupon()
                .SetFundingSourceCuponData(
                    ValidAdAccountId,
                    ValidFundingSourceCuponCurrency,
                    ValidFundingSourceCuponExpirationDate,
                    ValidFundingSourceCuponDisplayAmount
                );
            InvalidFundingSourceDetailCupon1 = new FundingSourceCoupon();
            InvalidFundingSourceDetailCupon2 = null;
        }

        private void FinancialInformations()
        {
            InvalidAdAccountAmountSpent1 = -1;
            InvalidAdAccountAmountSpent2 = 0;
            ValidAdAccountAmountSpent = 1;
            InvalidAdAccountBalance1 = -1;
            InvalidAdAccountBalance2 = 0;
            ValidAdAccountBalance = 1;
            InvalidAdAccountDailySpendLimit1 = -1;
            InvalidAdAccountDailySpendLimit2 = 0;
            ValidAdAccountDailySpendLimit = 1;

            InvalidAdAccountSpendCap1 = -1;
            InvalidAdAccountSpendCap2 = 0;
            ValidAdAccountSpendCap = 1;

            InvalidFinancialInformationsCurrency = CurrenciesEnum.UND;
            ValidFinancialInformationsCurrency = CurrenciesEnum.AED;

            InvalidAdAccountFundingSourceId1 = -1;
            InvalidAdAccountFundingSourceId2 = 0;
            ValidAdAccountFundingSourceId = 1;

            InvalidFundingSourceDetail1 = null;
            InvalidFundingSourceDetail2 = new FundingSourceDetail();
            ValidFundingSourceDetail = new FundingSourceDetail()
                .SetFundingSourceDetailData(
                    ValidFundingSourceDetailId,
                    ValidFundingSourceDetailDisplayString,
                    ValidFundingSourceDetailType
                );

            ValidFinancialInformations = new FinancialInformations()
                .SetFinancialSummary(ValidAdAccountAmountSpent, ValidAdAccountBalance, ValidAdAccountDailySpendLimit)
                .SetFinancialSpendCap(ValidAdAccountSpendCap)
                .SetFinancialFundingSource(ValidAdAccountFundingSourceId)
                .SetFinancialFundingDetail(ValidFundingSourceDetail)
                .SetFinancialCurrency(ValidFinancialInformationsCurrency);
        }

        private void TimezoneInformations()
        {
            ValidTimezoneId = 25;
            InvalidTimezoneId1 = 0;
            InvalidTimezoneId2 = -1;
            ValidTimezoneName = "America/Sao_Paulo";
            InvalidTimezoneName1 = null;
            InvalidTimezoneName2 = string.Empty;
            ValidTimezoneOffsetHoursFromUtc =
                DateTime.UtcNow.Subtract(DateTime.UtcNow.ToTimezoneDate(ValidTimezoneName).SetAsUtc().AddSeconds(-1)).Hours * -1;
            ValidTimezoneInformations = new TimezoneInformations()
                .SetTimezoneInformationsData(ValidTimezoneId, ValidTimezoneName, ValidTimezoneOffsetHoursFromUtc);
        }

        private void User()
        {
            ValidUserPermissions = new List<UserPermissionsEnum> { UserPermissionsEnum.AccountAdmin };
            InvalidUserPermissions1 = new List<UserPermissionsEnum>
            {
                UserPermissionsEnum.AccountAdmin,
                UserPermissionsEnum.Undefined
            };
            InvalidUserPermissions2 = null;
            ValidUserRole = UserRoleEnum.Administrator;
            InvalidUserRole = UserRoleEnum.Undefined;
            ValidUserUserId = 1;
            InvalidUserUserId1 = 0;
            InvalidUserUserId2 = -1;
            ValidAdAccountUser = new User().SetUserData(
                1,
                new List<UserPermissionsEnum>
                {
                    UserPermissionsEnum.BillingRead, 
                    UserPermissionsEnum.BillingWrite
                },
                UserRoleEnum.Administrator);
        } 
        #endregion

        private void Repositories()
        {
            RepositoryFacebookSession = new FacebookSessionRepository();
            RepositoryFacebookSession.SetDefaultApplication(ValidAppId, ValidAppSecret);
            RepositoryFacebookSession.SetAppAccessToken(ValidAccessToken);

            RepositoryAdAccount = new AdAccountRespository(RepositoryFacebookSession);
        }
    }
}
