﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns;
using facebook_csharp_ads_sdk.Domain.Enums.Configurations;
using facebook_csharp_ads_sdk.Domain.Exceptions.AdSet;
using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Models.AdSets
{
    /// <summary>
    ///     Promoted Object describes the thing an ad set is promoting
    /// </summary>
    public class PromotedObject : BaseObject
    {
        /// <summary>
        ///     Pixel id
        /// </summary>
        [FacebookName("pixel_id")]
        [FacebookFieldTypeAttribute(FacebookFieldType.Int64)]
        public long? PixelId { get; private set; }

        /// <summary>
        ///     Page id
        /// </summary>
        [FacebookName("page_id")]
        [FacebookFieldTypeAttribute(FacebookFieldType.Int64)]
        public long? PageId { get; private set; }

        /// <summary>
        ///     Offer id
        /// </summary>
        [FacebookName("offer_id")]
        [FacebookFieldTypeAttribute(FacebookFieldType.Int64)]
        public long? OfferId { get; private set; }
        
        /// <summary>
        ///     Application id
        /// </summary>
        [FacebookName("application_id")]
        [FacebookFieldTypeAttribute(FacebookFieldType.Int64)]
        public long? ApplicationId { get; private set; }

        /// <summary>
        ///     Url of object promoted
        /// </summary>
        [FacebookName("object_store_url")]
        [FacebookFieldTypeAttribute(FacebookFieldType.String)]
        public string ObjectStoreUrl { get; private set; }

        /// <summary>
        ///     Set data to create on Facebook
        /// </summary>
        /// <param name="adCampaignObjective"> Ad campaign objective </param>
        /// <param name="objectId"> Object id, according to the objective </param>
        /// <param name="objectStoreUrl"> Object </param>
        /// <exception cref="InvalidObjectIdException"> Invalid object id </exception>
        /// <exception cref="InvalidObjectStoreUrlException"> Invalid object store url </exception>
        /// <returns> This instance </returns>
        public PromotedObject SetDataToCreate(AdCampaignObjectiveEnum adCampaignObjective, long objectId, string objectStoreUrl)
        {
            if (objectId <= 0)
            {
                throw new InvalidObjectIdException();
            }

            switch (adCampaignObjective)
            {
                case AdCampaignObjectiveEnum.WebsiteConversions:
                    this.PixelId = objectId;
                    break;
                case AdCampaignObjectiveEnum.PageLikes:
                    this.PageId = objectId;
                    break;
                case AdCampaignObjectiveEnum.OfferClaims:
                    this.OfferId = objectId;
                    break;
                case AdCampaignObjectiveEnum.MobileAppInstalls:
                case AdCampaignObjectiveEnum.MobileAppEngagement:
                case AdCampaignObjectiveEnum.CanvasAppInstalls:
                case AdCampaignObjectiveEnum.CanvasAppEngagement:
                    if (String.IsNullOrEmpty(objectStoreUrl))
                    {
                        throw new InvalidObjectStoreUrlException();
                    }

                    this.ApplicationId = objectId;
                    this.ObjectStoreUrl = objectStoreUrl;
                    break;
                default:
                    this.PixelId = null;
                    this.PageId = null;
                    this.OfferId = null;
                    this.ApplicationId = null;
                    this.ObjectStoreUrl = null;
                    break;
            }

            return this;
        }

        /// <summary>
        ///     Get promoted object definition
        /// </summary>
        /// <returns> String to send promoted object to create ad set </returns>
        public override string ToString()
        {
            string promotedObjectDefinition = string.Empty;

            var createQuery = new Dictionary<string, string>();
            foreach (PropertyDescriptor prop in TypeDescriptor.GetProperties(this))
            {
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

                object currentValue = prop.GetValue(this);
                if (currentValue == null)
                {
                    continue;
                }

                createQuery.Add(facebookName, currentValue.ToString());
            }

            if (createQuery.Any())
            {
                promotedObjectDefinition = "{" + string.Join(",", createQuery.Select(u => String.Format("{0}: {1}", u.Key, u.Value))) + "}";
            }

            return promotedObjectDefinition;
        }
    }
}
