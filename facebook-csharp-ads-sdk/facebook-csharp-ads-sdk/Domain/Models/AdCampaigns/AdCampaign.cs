using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevUtils.Enum;
using DevUtils.PrimitivesExtensions;
using facebook_csharp_ads_sdk.Domain.BusinessRules.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdAccounts;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCampaigns
{
    /// <summary>
    ///     <para> Facebook Ad campaign </para>
    ///     <para>https://developers.facebook.com/docs/reference/ads-api/adcampaign</para>
    /// </summary>
    public class AdCampaign : BaseCrudObject<AdCampaign>
    {
        #region Dependencies

        /// <summary>
        ///     Interface of the campaign repository
        /// </summary>
        private readonly ICampaignRepository campaignRepository;

        #endregion Dependencies

        #region Constructor

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="campaignRepository"> Interface of the campaign repository </param>
        public AdCampaign(ICampaignRepository campaignRepository)
        {
            this.campaignRepository = campaignRepository;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        ///     <para> Id of the ad campaign </para>
        /// </summary>
        [FacebookName("id")]
        [DefaultValue(0L)]
        [FacebookFieldType(FacebookFieldType.Int64)]
        [IsFacebookCreateResponseAttribute(true)]
        public long Id { get; private set; }

        /// <summary>
        ///     <para> Id of the ad account </para> 
        /// </summary>
        [FacebookName("account_id")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int64)]
        public long? AccountId { get; private set; }

        /// <summary>
        ///     <para> Name of the ad campaign </para>
        /// </summary>
        [FacebookName("name")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.String)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public string Name { get; private set; }

        /// <summary>
        ///     <para> Objective of the ad campaign </para> 
        /// </summary>
        [FacebookName("objective")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.AdCampaignObjectiveEnum)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public AdCampaignObjectiveEnum? Objective { get; private set; }

        /// <summary>
        ///     <para> Status of the ad campaign </para> 
        /// </summary>
        [FacebookName("campaign_group_status")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.AdCampaignStatusEnum)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public AdCampaignStatusEnum? Status { get; private set; }

        /// <summary>
        ///     <para> Buying type of the ad campaign </para> 
        /// </summary>
        [FacebookName("buying_type")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.AdCampaignBuyingTypeEnum)]
        [CanCreateOnFacebook(true)]
        public AdCampaignBuyingTypeEnum? BuyingType { get; private set; }

        /// <summary>
        ///     <para> Adgroups owned by this ad campaign </para> 
        /// </summary>
        [FacebookName("adgroups")]
        [DefaultValue(null)]
        [FacebookFieldType(FacebookFieldType.Int64Array)]
        public IList<long> AdGroups { get; private set; }

        /// <summary>
        ///     Execute options on Facebook create and update
        /// </summary>
        [DefaultValue(null)]
        [FacebookName("execution_options")]
        [FacebookFieldType(FacebookFieldType.ExecutionOptionsEnumList)]
        [CanCreateOnFacebook(true)]
        [CanUpdateOnFacebook(true)]
        public IList<ExecutionOptionsEnum> ExecutionOptionsList { get; private set; }

        #endregion Properties

        /// <summary>
        ///     Create a ad campaign on Facebook
        /// </summary>
        /// <returns> This instance with id created </returns>
        public override AdCampaign Create()
        {
            try
            {
                if (!this.CreateModelIsReady)
                {
                    this.SetInvalid();
                    return this;
                }

                return this.campaignRepository.Create(this).Result;
            }
            catch (Exception)
            {
                this.SetInvalid();
                return this;
            }
        }

        /// <summary>
        ///     <para> Read ad campaign by id </para>
        /// </summary>
        /// <param name="id"> Campaign id </param>
        /// <returns> Campaign with id field </returns>
        public override AdCampaign ReadSingle(long id)
        {
            try
            {
                return id.IsValidAdCampaignId() ? this.campaignRepository.Read(id).Result : this;
            }
            catch
            {
                return this;
            }
        }

        /// <summary>
        ///     <para> Read ad campaign by id </para>
        /// </summary>
        /// <param name="id"> Campaign id </param>
        /// <param name="fields"> Ad campaign fields to read </param>
        /// <returns></returns>
        public AdCampaign ReadSingle(long id, IList<AdCampaignReadFieldsEnum> fields)
        {
            try
            {
                return id.IsValidAdCampaignId() ? this.campaignRepository.Read(id, fields).Result : this;
            }
            catch (Exception)
            {
                return this;
            }
        }

        /// <summary>
        ///     Update a ad campaign on Facebook
        /// </summary>
        /// <returns></returns>
        public override AdCampaign Update()
        {
            try
            {
                if (!this.UpdateModelIsReady 
                    || !this.Id.IsValidAdCampaignId())
                {
                    this.SetInvalid();
                    return this;
                }

                return this.campaignRepository.Update(this).Result;
            }
            catch (Exception)
            {
                this.SetInvalid();
                return this;
            }
        }

        /// <summary>
        ///     Update a ad campaign on Facebook
        /// </summary>
        /// <param name="campaignId"> Ad campaign id </param>
        /// <returns> Ad campaign updated </returns>
        public override AdCampaign Update(long campaignId)
        {
            try
            {
                this.Id = campaignId;
                return this.Update();
            }
            catch (Exception)
            {
                this.SetInvalid();
                return this;
            }
        }
        
        /// <summary>
        ///     Delete the ad campaign in facebook
        /// </summary>
        /// <returns> Success </returns>
        public override bool Delete()
        {
            try
            {
                bool success = this.Id.IsValidAdCampaignId() && this.campaignRepository.Delete(this.Id).Result;
                this.SetInvalidUpdateModel();
                return success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        ///     Delete the ad campaign in facebook
        /// </summary>
        /// <param name="id"> Id of the ad campaign </param>
        /// <returns> Success </returns>
        public override bool Delete(long id)
        {
            try
            {
                this.Id = id;
                return this.Delete();
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        ///     Overrite of the base parse method 
        /// </summary>
        /// <param name="facebookResponse"> Facebook response </param>
        public override void ParseReadSingleResponse(string facebookResponse)
        {
            base.ParseReadSingleResponse(facebookResponse);
            if (!this.IsValid)
            {
                return;
            }

            if (!this.Id.IsValidAdCampaignId())
            {
                this.SetInvalid();
                return;
            }

            this.GetAdGroupIdListFromFacebookResponse(facebookResponse);
        }

        /// <summary>
        ///     Set the attributes to create a ad campaign
        /// </summary>
        /// <param name="createData"> Ad campaign create data </param>
        /// <param name="executionOptionsList"> Execute options on Facebook create and update </param>
        /// <exception cref="InvalidAdCampaignCreateDataException"></exception>
        /// <exception cref="InvalidAdAccountId"></exception>
        /// <exception cref="InvalidAdCampaignNameException"></exception>
        /// <exception cref="InvalidAdCampaingStatusException"></exception>
        /// <exception cref="InvalidAdCampaignBuyingTypeException"></exception>
        /// <exception cref="InvalidAdCampaignObjectiveException"></exception>
        /// <returns> This instance </returns>
        public AdCampaign SetCreateData(AdCampaignCreateData createData, IList<ExecutionOptionsEnum> executionOptionsList)
        {
            this.ValidationCreateData(createData);
            try
            {
                this.AccountId = createData.AccountId;
                this.BuyingType = createData.BuyingType;
                this.Name = createData.Name;
                this.Objective = createData.Objective;
                this.Status = createData.Status;
                this.ExecutionOptionsList = executionOptionsList;

                this.SetValidCreateModel();
                return this;
            }
            catch (Exception)
            {
                this.SetInvalidCreateModel();
                return this;
            }
        }

        /// <summary>
        ///     Set the attributes to update a ad campaign
        /// </summary>
        /// <param name="updateData"></param>
        /// <param name="executionOptionsList"> Execute options on Facebook create and update </param>
        /// <exception cref="InvalidAdAccountId"></exception>
        /// <exception cref="InvalidAdCampaignObjectiveException"></exception>
        /// <exception cref="InvalidAdCampaingStatusException"></exception>
        /// <returns> This instance </returns>
        public AdCampaign SetUpdateData(AdCampaignUpdateData updateData, IList<ExecutionOptionsEnum> executionOptionsList)
        {
            if (updateData == null)
            {
                this.SetInvalidUpdateModel();
                return this;
            }

            this.ValidationUpdateData(updateData);
            try
            {
                if (String.IsNullOrEmpty(updateData.Name) &&
                    updateData.Objective == null &&
                    updateData.Status == null &&
                    (executionOptionsList == null || !executionOptionsList.Any()))
                {
                    this.SetInvalidUpdateModel();
                    return this;
                }

                this.AccountId = updateData.AccountId;
                this.Name = updateData.Name;
                this.Objective = updateData.Objective;
                this.Status = updateData.Status;
                this.ExecutionOptionsList = executionOptionsList;

                this.SetValidUpdateModel();
                return this;
            }
            catch (Exception)
            {
                this.SetInvalidUpdateModel();
                return this;
            }
        }
        
        #region Private methods

        /// <summary>
        ///     Get ids list of ad group by facebook response
        /// </summary>
        /// <param name="jsonResult"> Facebook response </param>
        private void GetAdGroupIdListFromFacebookResponse(string jsonResult)
        {
            var facebookResponse = JObject.Parse(jsonResult);

            JToken jTokenAdGroups = facebookResponse["adgroups"];
            if (jTokenAdGroups != null && jTokenAdGroups.Type == JTokenType.Object)
            {
                var adGroupList = JObject.Parse(facebookResponse["adgroups"].ToString());

                JToken adGroupIds = adGroupList["data"];
                if (adGroupIds != null && adGroupIds.Type == JTokenType.Array)
                {
                    this.AdGroups = new List<long>();
                    foreach (var jTokenAdGroupId in adGroupIds)
                    {
                        JToken id = jTokenAdGroupId["id"];
                        if (id != null && id.Type == JTokenType.String)
                        {
                            long adGroupId = id.ToString().TryParseLong();
                            if (adGroupId > 0)
                            {
                                this.AdGroups.Add(adGroupId.ToString().TryParseLong());
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Get the property value
        /// </summary>
        protected override string ParsePropertyValueToFacebookValue(FacebookFieldType fieldType, object currentValue)
        {
            switch (fieldType)
            {
                case FacebookFieldType.Int32:
                case FacebookFieldType.Int64:
                case FacebookFieldType.String:
                    return currentValue.ToString();

                case FacebookFieldType.AdCampaignObjectiveEnum:
                    return currentValue.ToString().ToEnum<AdCampaignObjectiveEnum>().GetCampaignObjectiveFacebookName();

                case FacebookFieldType.AdCampaignStatusEnum:
                    return currentValue.ToString().ToEnum<AdCampaignStatusEnum>().GetCampaignStatusFacebookName();

                case FacebookFieldType.AdCampaignBuyingTypeEnum:
                    return currentValue.ToString().ToEnum<AdCampaignBuyingTypeEnum>().GetBuyingTypeFacebookName();

                case FacebookFieldType.ExecutionOptionsEnumList:
                    if (this.ExecutionOptionsList == null)
                    {
                        return string.Empty;
                    }

                    return String.Format("[{0}]",
                        string.Join(",",
                            this.ExecutionOptionsList.Select(
                                u => "\"" + u.ToEnum<ExecutionOptionsEnum>().GetExecutionOptionsFacebookName() + "\"")));
            }

            return string.Empty;
        }

        /// <summary>
        ///     Validate the ad campaign create data
        /// </summary>
        /// <param name="createData"> Ad campaign create data </param>
        private void ValidationCreateData(AdCampaignCreateData createData)
        {
            if (createData == null)
            {
                throw new InvalidAdCampaignCreateDataException();
            }

            if (!createData.AccountId.IsValidAdAccountId())
            {
                throw new InvalidAdAccountId();
            }

            if (String.IsNullOrEmpty(createData.Name))
            {
                throw new InvalidAdCampaignNameException();
            }

            if (createData.Status == AdCampaignStatusEnum.Undefined ||
                createData.Status == AdCampaignStatusEnum.Archived ||
                createData.Status == AdCampaignStatusEnum.Delete)
            {
                throw new InvalidAdCampaingStatusException();
            }

            if (createData.BuyingType != null && createData.BuyingType == AdCampaignBuyingTypeEnum.Undefined)
            {
                throw new InvalidAdCampaignBuyingTypeException();
            }

            if (createData.Objective != null && createData.Objective == AdCampaignObjectiveEnum.Undefined)
            {
                throw new InvalidAdCampaignObjectiveException();
            }
        }

        /// <summary>
        ///     Validate the ad campaign update data
        /// </summary>
        /// <param name="updateData"> Ad campaign update data </param>
        private void ValidationUpdateData(AdCampaignUpdateData updateData)
        {
            if (!updateData.AccountId.IsValidAdAccountId())
            {
                throw new InvalidAdAccountId();
            }

            if (updateData.Objective != null && updateData.Objective == AdCampaignObjectiveEnum.Undefined)
            {
                throw new InvalidAdCampaignObjectiveException();
            }

            if (updateData.Status != null && updateData.Status == AdCampaignStatusEnum.Undefined)
            {
                throw new InvalidAdCampaingStatusException();
            }
        }

        #endregion Private methods
    }
}
