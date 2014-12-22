using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Enums.AdAccountGroup;
using facebook_csharp_ads_sdk.Domain.Models.AdAccountsGroup;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    /// Interface com métodos para manipulação dos dados de grupo de contas
    /// </summary>
    public interface IAccountGroupRepository
    {
        /// <summary>
        /// Método para leitura dos dados de um único grupo de contas
        /// </summary>
        AdAccountGroup ReadSingle(long accountGroupId, IList<AdAccountGroupFieldsEnum> fields);

        /// <summary>
        /// Método para leitura de todos os grupos de conta de um token
        /// </summary>
        IList<AdAccountGroup> ReadAll(IList<AdAccountGroupFieldsEnum> fields);
    }
}