﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdSet;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;
using facebook_csharp_ads_sdk.Domain.Models.AdSets;
using facebook_csharp_ads_sdk.Domain.Utils;
using facebook_csharp_ads_sdk._Utils.WebRequests;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    public class AdSetRepository : IAdSetRepository
    {
        #region Properties

        /// <summary>
        ///     Instance of the facebook session
        /// </summary>
        private readonly IFacebookSession facebookSession;

        #endregion

        #region Constructor

        /// <summary>
        /// Repository constructor with an instance of Facebook Session
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public AdSetRepository(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
            {
                throw new ArgumentNullException();
            }

            this.facebookSession = facebookSession;
        } 

        #endregion

        /// <summary>
        ///     Read the ad set by id
        /// </summary>
        /// <param name="id"> Ad set id </param>
        /// <returns> Ad set with id passed </returns>
        public async Task<AdSet> Read(long id)
        {
            return await this.Read(id, new List<AdSetReadFieldsEnum> { AdSetReadFieldsEnum.Id });
        }

        /// <summary>
        ///     Create a ad set on Facebook
        /// </summary>
        /// <param name="adSetToCreate"> Ad set </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Ad set created with id </returns>
        public async Task<AdSet> Create(AdSet adSetToCreate)
        {
            if (adSetToCreate == null)
            {
                return null;
            }

            this.facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            Dictionary<string, string> paramsToCreate = adSetToCreate.GetSingleCreateParams();

            string campaignCreateEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().AdSetCreateEndpoint;
            campaignCreateEndpoint = String.Format(campaignCreateEndpoint, adSetToCreate.AccountId, this.facebookSession.GetUserAccessToken());

            IRequest webRequest = new Request();
            string requestResult = await webRequest.PostAsync(campaignCreateEndpoint, paramsToCreate);

            adSetToCreate.ParseCreateResponse(requestResult);
            return adSetToCreate;
        }

        /// <summary>
        ///     Delete the ad set in Facebook
        /// </summary>
        /// <param name="id"> Ad set id </param>
        /// <returns> Success </returns>
        public async Task<bool> Delete(long id)
        {
            this.facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            string deleteEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().DeleteEndpoint;
            deleteEndpoint = String.Format(deleteEndpoint, id, this.facebookSession.GetUserAccessToken());

            IRequest webRequest = new Request();
            string deleteRequest = await webRequest.DeleteAsync(deleteEndpoint);
            var account = new AdSet(this);

            return account.ParseDeleteResponse(deleteRequest);
        }

        /// <summary>
        ///     Update a ad set on Facebook
        /// </summary>
        /// <param name="entity"> Ad set to update </param>
        /// <returns> Ad set updated </returns>
        public async Task<AdSet> Update(AdSet entity)
        {
            if (entity == null)
            {
                return new AdSet(this);
            }

            this.facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            Dictionary<string, string> paramsToUpdate = entity.GetSingleUpdateParams();

            string adSetUpdateEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().AdSetUpdateEndpoint;
            adSetUpdateEndpoint = String.Format(adSetUpdateEndpoint, entity.Id, this.facebookSession.GetUserAccessToken());

            IRequest webRequest = new Request();
            string requestResult = await webRequest.PostAsync(adSetUpdateEndpoint, paramsToUpdate);

            entity.ParseUpdateResponse(requestResult);
            return entity;
        }

        /// <summary>
        ///     <para> Get the ad set by field list </para>
        /// </summary>
        /// <param name="adId"> Id of the ad set </param>
        /// <param name="fields"> Field list you wish to retrieve </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>//
        /// <returns> Ad set </returns>
        public async Task<AdSet> Read(long adId, IList<AdSetReadFieldsEnum> fields)
        {
            this.facebookSession.ValidateFacebookSessionRequirements(new[] { RequiredOnFacebookSessionEnum.UserAccessToken });
            if (fields == null || !fields.Any())
            {
                fields = new List<AdSetReadFieldsEnum> { AdSetReadFieldsEnum.Id };
            }

            string fieldNameList = RepositoryUtils.GetFieldNameQueryString(fields);
            string adSetEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().AdSetReadEndpoint;
            adSetEndpoint = String.Format(adSetEndpoint, adId, this.facebookSession.GetUserAccessToken(), fieldNameList);

            IRequest webRequest = new Request();
            string getRequest = await webRequest.GetAsync(adSetEndpoint);
            var adSet = new AdSet(this);
            adSet.ParseReadSingleResponse(getRequest);

            return adSet;
        }
    }
}