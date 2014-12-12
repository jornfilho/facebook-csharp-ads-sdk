namespace facebook_csharp_ads_sdk.Domain.Models
{
    /// <summary>
    ///     Base object for CRUD
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseCrudObject<T> : BaseObject
    {
        /// <summary>
        ///     Read a T in Facebook
        /// </summary>
        /// <param name="id"> Id of the object </param>
        /// <returns> Entity with the passed id  </returns>
        public abstract T ReadSingle(long id);

        /// <summary>
        ///     Does parse the response from Facebook
        /// </summary>
        /// <param name="response"> Model Json response </param>
        /// <returns> Entity </returns>
        public abstract T ParseSingleResponse(string response);
    }
}
