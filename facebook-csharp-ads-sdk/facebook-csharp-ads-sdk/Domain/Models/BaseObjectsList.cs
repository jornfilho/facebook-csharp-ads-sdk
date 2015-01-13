using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using facebook_csharp_ads_sdk._Utils.Parser;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models
{
    /// <summary>
    ///     Base object to models 
    /// </summary>
    public class BaseObjectsList<T> where T : BaseObject, new()
    {
        #region Properties
        /// <summary>
        /// Api error response model
        /// </summary>
        public ApiErrorModelV22 ApiErrorResponseData { get; private set; }

        /// <summary>
        /// Set true id has valid data
        /// </summary>
        public bool IsValid { get; private set; }

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
        /// Set api error response data
        /// </summary>
        public void SetApiErrorResonse(ApiErrorModelV22 errorResponse)
        {
            ApiErrorResponseData = errorResponse;
        } 
        #endregion

        #region parse facebook response methods
        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public virtual BaseObjectsList<T> ParseReadMultipleResponse(string facebookResponse)
        {
            try
            {
                if (String.IsNullOrEmpty(facebookResponse))
                    this.SetInvalid();

                var response = JObject.Parse(facebookResponse);
                return this.ParseReadMultipleResponse(response);
            }
            catch (Exception)
            {
                this.SetInvalid();
                return this;
            }
        }

        /// <summary>
        /// Parse Facebook Api response to model
        /// </summary>
        public virtual BaseObjectsList<T> ParseReadMultipleResponse(JToken facebookResponse)
        {
            try
            {
                if (facebookResponse == null)
                {
                    this.SetInvalid();
                    return this;
                }

                #region Error
                if (facebookResponse["error"] != null)
                {
                    var errorModel = new ApiErrorModelV22().ParseApiResponse(facebookResponse);
                    this.SetInvalid();
                    this.SetApiErrorResonse(errorModel);

                    return this;
                }
                #endregion

                if (facebookResponse["data"] == null)
                    return this;

                foreach (var item in facebookResponse["data"])
                {
                    if (item.Type != JTokenType.Object)
                        continue;

                    var responseItem = new T();
                    responseItem.ParseReadSingleResponse(item.ToString());
                    if (!responseItem.IsValid)
                        continue;

                    this.Add(responseItem);
                }

                this.SetValid();

                return this;
            }
            catch (Exception)
            {
                this.SetInvalid();
                return this;
            }
        }
        #endregion

    }
}
