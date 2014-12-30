using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Models.ApiErrors;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.Targetings
{
    /// <summary>
    ///     Targeting mobile user device
    /// </summary>
    public class TargetingUserDevice : BaseObject
    {
        #region Dependencies
        
        /// <summary>
        ///     Targeting search reporitory
        /// </summary>
        private readonly IAdTargetingSearchRepository adTargetingSearchRepository;

        #endregion Dependencies

        #region Construtor
        
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="adTargetingSearchRepository"> Targeting search reporitory </param>
        public TargetingUserDevice(IAdTargetingSearchRepository adTargetingSearchRepository)
        {
            this.adTargetingSearchRepository = adTargetingSearchRepository;
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        public TargetingUserDevice()
        {
        }

        #endregion Construtor

        #region Properties

        /// <summary>
        ///     Audience size
        /// </summary>
        [FacebookName("audience_size")]
        [FacebookFieldType(FacebookFieldType.Int64)]
        public long? AudienceSize { get; private set; }

        /// <summary>
        ///     User device description
        /// </summary>
        [FacebookName("description")]
        [FacebookFieldType(FacebookFieldType.String)]
        public string Description { get; private set; }

        /// <summary>
        ///     User device name
        /// </summary>
        [FacebookName("name")]
        [FacebookFieldType(FacebookFieldType.String)]
        public string Name { get; private set; }

        #endregion Properties

        /// <summary>
        ///     Get tha user device list
        /// </summary>
        /// <returns> List of the user device </returns>
        public IList<TargetingUserDevice> ReadAll()
        {
            return this.adTargetingSearchRepository.ReadUserDeviceList();
        }

        /// <summary>
        ///     Parse read multiple user device
        /// </summary>
        public BaseObjectsList<TargetingUserDevice> ParseMultipleResponse(string response)
        {
            var objectResult = new BaseObjectsList<TargetingUserDevice>();
            if (String.IsNullOrEmpty(response))
            {
                return objectResult;
            }

            var jsonObject = JObject.Parse(response);
            if (jsonObject == null)
            {
                return objectResult;
            }

            #region Error

            if (jsonObject["error"] != null)
            {
                var errorModel = new ApiErrorModelV22().ParseApiResponse(jsonObject);
                objectResult.SetInvalid();
                objectResult.SetApiErrorResonse(errorModel);

                return objectResult;
            }

            #endregion Error

            if (jsonObject["data"] == null)
            {
                return objectResult;
            }

            foreach (var item in jsonObject["data"])
            {
                if (item.Type != JTokenType.Object)
                {
                    continue;
                }

                var userDevice = new TargetingUserDevice(this.adTargetingSearchRepository);
                userDevice.ParseReadSingleResponse(item.ToString());
                if (!userDevice.IsValid)
                {
                    continue;
                }

                objectResult.Add(userDevice);
            }

            objectResult.SetValid();

            return objectResult;
        }
    }
}