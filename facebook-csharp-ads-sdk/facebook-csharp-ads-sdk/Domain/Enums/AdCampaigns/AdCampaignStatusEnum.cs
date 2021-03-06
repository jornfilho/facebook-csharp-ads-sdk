﻿using facebook_csharp_ads_sdk.Domain.Models.Attributes;

namespace facebook_csharp_ads_sdk.Domain.Enums.AdCampaigns
{
    /// <summary>
    ///     StatusEnum of the campaign
    /// </summary>
    public enum AdCampaignStatusEnum
    {
        /// <summary>
        ///     Undefined
        /// </summary>
        [FacebookName("")]
        Undefined = 0,

        /// <summary>
        ///     Campaign active
        /// </summary>
        [FacebookName("ACTIVE")]
        Active,

        /// <summary>
        ///     Campaign paused
        /// </summary>
        [FacebookName("PAUSED")]
        Paused,

        /// <summary>
        ///     Campaign archived
        /// </summary>
        [FacebookName("ARCHIVED")]
        Archived,

        /// <summary>
        ///     Campaign delete
        /// </summary>
        [FacebookName("DELETED")]
        Delete
    }
}