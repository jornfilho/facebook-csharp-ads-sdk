using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;

namespace facebook_csharp_ads_sdk.Domain.Models
{
    /// <summary>
    ///     Base object to models 
    /// </summary>
    public class BaseObjectsList<T>
    {
        #region Properties
        /// <summary>
        /// Api error response model
        /// </summary>
        private ApiErrorModelV22 ApiErrorResponseData { get; set; }

        /// <summary>
        /// Set true id has valid data
        /// </summary>
        private bool IsValid { get; set; }

        /// <summary>
        /// Lista de objetos resultantes
        /// </summary>
        public IList<T> Data { get; private set; }
        #endregion

        #region Métodos para adição de objetos a lista
        /// <summary>
        /// Adiciona item na lista objetos
        /// </summary>
        public void Add(T item)
        {
            if (item.Equals(null))
                return;

            if (Data == null)
                Data = new List<T>();

            Data.Add(item);
        }

        /// <summary>
        /// Adiciona uma lista de itens na lista objetos
        /// </summary>
        public void AddRange(IList<T> itens)
        {
            if (itens.Equals(null))
                return;

            if (Data == null)
                Data = new List<T>();

            foreach (var item in itens)
                this.Add(item);
        } 
        #endregion

        #region Métodos de validação do objeto
        /// <summary>
        /// Return true if has valid data 
        /// </summary>
        public bool IsValidData()
        {
            return IsValid;
        }

        /// <summary>
        /// Set data valid
        /// </summary>
        public void SetValid()
        {
            if (IsValid)
                return;

            IsValid = true;
        }

        /// <summary>
        /// Set data invalid
        /// </summary>
        public void SetInvalid()
        {
            if (!IsValid)
                return;

            IsValid = false;
        } 
        #endregion

        #region API error response model
        /// <summary>
        /// Get api error response data model
        /// </summary>
        public ApiErrorModelV22 GetApiErrorResonse()
        {
            return ApiErrorResponseData;
        }

        /// <summary>
        /// Set api error response data
        /// </summary>
        public void SetApiErrorResonse(ApiErrorModelV22 errorResponse)
        {
            ApiErrorResponseData = errorResponse;
        } 
        #endregion
    }
}
