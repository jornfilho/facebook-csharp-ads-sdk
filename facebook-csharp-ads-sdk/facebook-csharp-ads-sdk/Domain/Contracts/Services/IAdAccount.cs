using System.Collections.Generic;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Models.AdAccounts;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Services
{
    public interface IAdAccount
    {
        //IList<Account> ReadAll(string accessToken, IList<AdAccountFieldsEnum> fields);

        Task<AdAccount> Read(long accountId, IList<AdAccountFieldsEnum> fields);

        //Account UpdateAgencyDeclaration(long accountId, AgencyClientDeclaration agencyClientDeclaration);

        //Account UpdateEndAdvertiser(long accountId, long endAdvertiser);

        //Account UpdateMediaAgency(long accountId, long mediaAgency);

        //Account UpdatePartner(long accountId, long partner);

        //Account UpdateSpendCap(long accountId, double spendCapValue, SpendCapUpdateActionEnum updateAction);
    }
}
