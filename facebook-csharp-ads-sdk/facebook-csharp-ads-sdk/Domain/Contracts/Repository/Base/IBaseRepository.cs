using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository.Base
{
    /// <summary>
    ///     Repository base with read operation
    /// </summary>
    /// <typeparam name="T"> EntityType of entity used </typeparam>
    public interface IBaseRepository<T>
    {
        /// <summary>
        ///     Read the entity by id
        /// </summary>
        /// <param name="id"> Id of entity </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Instance of entity object </returns>
        Task<T> Read(long id);
    }
}
