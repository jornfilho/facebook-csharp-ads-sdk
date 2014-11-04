using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using DevUtils.DateTimeExtensions;
using facebook_csharp_ads_sdk.Domain.Contracts.Services;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Enums.AdUsers;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;
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
        public NameValueCollection EmptyNameValueCollection { get; set; }
        public NameValueCollection SingleValueNameValueCollection { get; set; }
        public NameValueCollection MultipleValuesNameValueCollection { get; set; }
        #endregion

        #region Repositories
        public IFacebookSession RepositoryFacebookSession; 
        public IAdAccount RepositoryAdAccount; 
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

        public double InvalidAdAccountSpendCap1;
        public double InvalidAdAccountSpendCap2;
        public double ValidAdAccountSpendCap;

        public CurrenciesEnum InvalidFinancialInformationsCurrency;
        public CurrenciesEnum ValidFinancialInformationsCurrency;

        public long InvalidAdAccountFundingSourceId1;
        public long InvalidAdAccountFundingSourceId2;
        public long ValidAdAccountFundingSourceId;

        public FundingSourceDetail InvalidFundingSourceDetail1;
        public FundingSourceDetail InvalidFundingSourceDetail2;
        public FundingSourceDetail ValidFundingSourceDetail;
        #endregion

        #region FundingSourceCupon
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
        public FundingSourceCupon ValidFundingSourceDetailCupon;
        public FundingSourceCupon InvalidFundingSourceDetailCupon1;
        public FundingSourceCupon InvalidFundingSourceDetailCupon2;
        #endregion

        #region TimezoneInformations
        public int ValidTimezoneId;
        public int InvalidTimezoneId1;
        public int InvalidTimezoneId2;
        public string ValidTimezoneName;
        public string InvalidTimezoneName1;
        public string InvalidTimezoneName2;
        public int ValidTimezoneOffsetHoursFromUtc; 
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
        #endregion

        [TestInitialize]
        public void InitializeTestBase()
        {
            #region Web requests
            WebRequest = new Request();
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
            #endregion

            #region Facebook session data
            InvalidAppId = 0;
            ValidAppId = 1;

            InvalidAppSecret1 = InvalidAccessToken1 = null;
            InvalidAppSecret2 = InvalidAccessToken2 = "";
            ValidAppSecret = ValidAccessToken = "a";
            #endregion


            #region AdAccount
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
            #endregion

            #region AdAccountGroup
            InvalidAdAccountGroupId1 = 0;
            InvalidAdAccountGroupId2 = -1;
            ValidAdAccountGroupId = 1;
            InvalidAdAccountGroupName1 = null;
            InvalidAdAccountGroupName2 = string.Empty;
            ValidAdAccountGroupName = "a";
            InvalidAdAccountGroupStatus = AdAccountGroupsStatusEnum.Undefined;
            ValidAdAccountGroupStatus = AdAccountGroupsStatusEnum.Active; 
            #endregion

            #region AgencyClientDeclaration
            ValidClientCity = "a";
            ValidClientCountryCode = "b";
            ValidClientEmailAddress = "test@test.com";
            ValidClientName = "d";
            ValidClientPostalCode = "e";
            ValidClientProvince = "f";
            ValidClientStreet = "g";
            ValidClientStreet2 = "h";
            #endregion

            #region FundingSourceCupon
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
            #endregion

            #region FundingSourceDetail
            ValidFundingSourceDetailId = 1;
            InvalidFundingSourceDetailId1 = 0;
            InvalidFundingSourceDetailId2 = -1;
            ValidFundingSourceDetailDisplayString = "a";
            InvalidFundingSourceDetailDisplayString1 = string.Empty;
            InvalidFundingSourceDetailDisplayString2 = null;
            ValidFundingSourceDetailType = 1;
            InvalidFundingSourceDetailType1 = 0;
            InvalidFundingSourceDetailType2 = -1;
            ValidFundingSourceDetailCupon = new FundingSourceCupon()
                .SetFundingSourceCuponData(
                    ValidAdAccountId, 
                    ValidFundingSourceCuponCurrency, 
                    ValidFundingSourceCuponExpirationDate, 
                    ValidFundingSourceCuponDisplayAmount
                );
            InvalidFundingSourceDetailCupon1 = new FundingSourceCupon();
            InvalidFundingSourceDetailCupon2 = null;
            #endregion

            #region FinancialInformations
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
            #endregion

            #region TimezoneInformations
            ValidTimezoneId = 25;
            InvalidTimezoneId1 = 0;
            InvalidTimezoneId2 = -1;
            ValidTimezoneName = "America/Sao_Paulo";
            InvalidTimezoneName1 = null;
            InvalidTimezoneName2 = string.Empty;
            ValidTimezoneOffsetHoursFromUtc = DateTime.UtcNow.Subtract(DateTime.UtcNow.ToTimezoneDate(ValidTimezoneName).SetAsUtc().AddSeconds(-1)).Hours*-1; 
            #endregion

            #region User
            ValidUserPermissions = new List<UserPermissionsEnum> { UserPermissionsEnum.AccountAdmin };
            InvalidUserPermissions1 = new List<UserPermissionsEnum> { UserPermissionsEnum.AccountAdmin, UserPermissionsEnum.Undefined };
            InvalidUserPermissions2 = null;
            ValidUserRole = UserRoleEnum.Administrator;
            InvalidUserRole = UserRoleEnum.Undefined;
            ValidUserUserId = 1;
            InvalidUserUserId1 = 0; 
            InvalidUserUserId2 = -1; 
            #endregion

            #region Repositories
            RepositoryFacebookSession = new FacebookSessionRepository();
            RepositoryFacebookSession.SetDefaultApplication(ValidAppId, ValidAppSecret);
            RepositoryFacebookSession.SetAccessToken(ValidAccessToken);

            RepositoryAdAccount = new AdAccountRespository(RepositoryFacebookSession); 
            #endregion
        }
    }
}
