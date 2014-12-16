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
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Extensions.Enums.Global;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;
using Newtonsoft.Json.Linq;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCampaigns
{
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
        ///     Update a ad campaign on Facebook
        /// </summary>
        /// <returns> Ad campaign updated </returns>
        public override AdCampaign Update()
        {
            try
            {
                if (!this.UpdateModelIsReady || !this.Id.IsValidAdCampaignId())
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
        ///     Delete the ad campaign in facebook
        /// </summary>
        /// <returns> Success </returns>
        public override bool Delete()
        {
            try
            {
                return this.Id.IsValidAdCampaignId() && this.campaignRepository.Delete(this.Id).Result;
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
        public override void ParseReadSingleesponse(string facebookResponse)
        {
            base.ParseReadSingleesponse(facebookResponse);
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
        /// <param name="accountId"> Account id </param>
        /// <param name="name"> Ad campaign name </param>
        /// <param name="buyingType"> Ad campaign buying type </param>
        /// <param name="objective"> Ad campaign objective </param>
        /// <param name="status"> Ad campaign status </param>
        /// <param name="executionOptionsList"> Execute options on Facebook create and update </param>
        /// <returns> This instance </returns>
        public AdCampaign SetCreateData(long accountId, string name, AdCampaignBuyingTypeEnum? buyingType,
                                        AdCampaignObjectiveEnum? objective, AdCampaignStatusEnum status,
                                        IList<ExecutionOptionsEnum> executionOptionsList)
        {
            try
            {
                if (!accountId.IsValidAdAccountId())
                {
                    this.SetInvalidCreateModel();
                    return this;
                }

                if (String.IsNullOrEmpty(name))
                {
                    this.SetInvalidCreateModel();
                    return this;
                }

                if (status == AdCampaignStatusEnum.Undefined || 
                    status == AdCampaignStatusEnum.Archived || 
                    status == AdCampaignStatusEnum.Delete)
                {
                    this.SetInvalidCreateModel();
                    return this;
                }

                if (buyingType != null && buyingType == AdCampaignBuyingTypeEnum.Undefined)
                {
                    buyingType = null;
                }

                if (objective != null && objective == AdCampaignObjectiveEnum.Undefined)
                {
                    objective = null;
                }

                this.AccountId = accountId;
                this.BuyingType = buyingType;
                this.Name = name;
                this.Objective = objective;
                this.Status = status;
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
        /// <param name="accountId"> Account id </param>
        /// <param name="name"> Ad campaign name </param>
        /// <param name="objective"> Ad campaign objective </param>
        /// <param name="status"> Ad campaign status </param>
        /// <param name="executionOptionsList"> Execute options on Facebook create and update </param>
        /// <returns> This instance </returns>
        public AdCampaign SetUpdateData(long accountId, string name, AdCampaignObjectiveEnum? objective,
                                        AdCampaignStatusEnum? status,
                                        IList<ExecutionOptionsEnum> executionOptionsList)
        {
            try
            {
                if (!accountId.IsValidAdAccountId())
                {
                    this.SetInvalidCreateModel();
                    return this;
                }
                
                if (String.IsNullOrEmpty(name) &&
                    objective == null && 
                    status == null && 
                    (executionOptionsList == null || !executionOptionsList.Any()))
                {
                    this.SetInvalidUpdateModel();
                    return this;
                }

                if (objective != null && objective == AdCampaignObjectiveEnum.Undefined)
                {
                    this.SetInvalidUpdateModel();
                    return this;
                }

                if (status != null && status == AdCampaignStatusEnum.Undefined)
                {
                    this.SetInvalidUpdateModel();
                    return this;
                }

                this.AccountId = accountId;
                this.Name = name;
                this.Objective = objective;
                this.Status = status;
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

        /// <summary>
        ///     Mounts string with data for creation of a new campaign
        /// </summary>
        public override Dictionary<string, string> GetSingleCreateParams()
        {
            if (!this.CreateModelIsReady)
            {
                return null;
            }

            Dictionary<string, string> createQuery = this.GetParamsQueryDictionary(GetParamsType.Create);
            return createQuery;
        }

        /// <summary>
        ///     Mount a dictionary with parameters and values to update
        /// </summary>
        /// <returns> Dictionary with facebook name and value </returns>
        public override Dictionary<string, string> GetSingleUpdateParams()
        {
            if (!this.UpdateModelIsReady)
            {
                return null;
            }

            Dictionary<string, string> createQuery = this.GetParamsQueryDictionary(GetParamsType.Update);
            return createQuery;
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
        private string GetObjectFacebookValue(FacebookFieldType fieldType, object currentValue)
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
        ///     Mount a dictionary with parameters and values to create or update
        /// </summary>
        /// <param name="operationType"> Operations type </param>
        /// <returns> Dictionary with facebook name and value </returns>
        private Dictionary<string, string> GetParamsQueryDictionary(GetParamsType operationType)
        {
            try
            {
                var createQuery = new Dictionary<string, string>();
                foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
                {

                    if (!this.PropertyCanBeUsedInTheOperation(prop, operationType))
                    {
                        continue;
                    }

                    var facebookNameAttribute = (FacebookNameAttribute)prop.Attributes[typeof(FacebookNameAttribute)];
                    var facebookAttributeType = (FacebookFieldTypeAttribute)prop.Attributes[typeof(FacebookFieldTypeAttribute)];

                    if (facebookNameAttribute == null ||
                        facebookAttributeType == null)
                    {
                        continue;
                    }

                    string facebookName = facebookNameAttribute.Value;
                    if (String.IsNullOrEmpty(facebookName))
                    {
                        continue;
                    }

                    FacebookFieldType facebookType = facebookAttributeType.Value;
                    object currentValue = prop.GetValue(this);

                    if (currentValue == null)
                    {
                        continue;
                    }

                    string currentValueString = this.GetObjectFacebookValue(facebookType, currentValue);
                    if (String.IsNullOrEmpty(currentValueString))
                    {
                        continue;
                    }

                    createQuery.Add(facebookName, currentValueString);
                }

                return createQuery;
            }
            catch (Exception)
            {
                return null;
            }
        }

        

        #endregion Private methods
    }
}
