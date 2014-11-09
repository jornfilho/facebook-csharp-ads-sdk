using facebook_csharp_ads_sdk.Domain.Contracts.Services;

namespace facebook_csharp_ads_sdk.Michel_Test.Interface.Repository
{
    public interface IBaseRepository<T>
    {
        //bool Create(T entity);

        T Read(long id);

        //bool Delete(long id);

        //bool Update(T entity);
    }
}
