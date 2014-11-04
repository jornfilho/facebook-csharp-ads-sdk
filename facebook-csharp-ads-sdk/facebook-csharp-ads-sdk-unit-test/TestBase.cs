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

        public long InvalidAdAccountId;
        public long ValidAdAccountId;
        public string InvalidAdAccountStrId1;
        public string InvalidAdAccountStrId2;
        public string ValidAdAccountStrId;

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


            InvalidAdAccountId = 0;
            ValidAdAccountId = 1;
            InvalidAdAccountStrId1 = "";
            InvalidAdAccountStrId1 = string.Format("act_{0}", InvalidAdAccountId);
            ValidAdAccountStrId = string.Format("act_{0}", ValidAdAccountId);

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
