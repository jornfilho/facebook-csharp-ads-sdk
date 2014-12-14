using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;

namespace facebook_csharp_ads_sdk.Domain.Contracts.Repository
{
    /// <summary>
    ///     Repository base with basic CRUD operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseCrudRepository<T> : IBaseRepository<T>
    {
        /// <summary>
        ///     Create the instance on Facebook
        /// </summary>
        /// <param name="entity"> Entity to create </param>
        /// <returns> Entity created with id </returns>
        T Create(T entity);

        /// <summary>
        ///     Delete the ad campaign
        /// </summary>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Success </returns>
        Task<bool> Delete(long id);

        //bool Update(T entity);
    }
}
