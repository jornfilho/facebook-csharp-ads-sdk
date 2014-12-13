using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    ///     Repository base with basic CRUD operations
    /// </summary>
    /// <typeparam name="T"> EntityType of entity used </typeparam>
    public interface IBaseRepository<T>
    {
        //bool Create(T entity);

        /// <summary>
        ///     Read the entity by id
        /// </summary>
        /// <param name="id"> Id of entity </param>
        /// <returns> Instance of entity object </returns>
        Task<T> Read(long id);

        /// <summary>
        ///     Delete the ad campaign
        /// </summary>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Success </returns>
        Task<bool> Delete(long id);

        //bool Update(T entity);
    }
}
