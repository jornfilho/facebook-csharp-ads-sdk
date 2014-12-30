using System;
using System.Collections.Generic;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Models;
using facebook_csharp_ads_sdk.Domain.Models.Targetings;
using facebook_csharp_ads_sdk._Utils.Parser;
using facebook_csharp_ads_sdk._Utils.WebRequests;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    public class AdTargetingSearchRepository : IAdTargetingSearchRepository
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
        public AdTargetingSearchRepository(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
            {
                throw new ArgumentNullException();
            }

            this.facebookSession = facebookSession;
        } 

        #endregion

        /// <summary>
        ///     Get tha user device list
        /// </summary>
        /// <returns> List of the user device </returns>
        public IList<TargetingUserDevice> ReadUserDeviceList()
        {
            string readUserDeviceEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().TargetingUserDeviceReadEndpoint;
            readUserDeviceEndpoint = String.Format(readUserDeviceEndpoint, this.facebookSession.GetUserAccessToken());

            IRequest webRequest = new FacebookRequest(this.facebookSession);

            var userDeviceList = new List<TargetingUserDevice>();
            while (true)
            {
                string getRequest = webRequest.Get(readUserDeviceEndpoint);
                
                if (String.IsNullOrEmpty(getRequest))
                    break;

                BaseObjectsList<TargetingUserDevice> userDeviceParseResult = new TargetingUserDevice().ParseMultipleResponse(getRequest);
                if (userDeviceParseResult == null || !userDeviceParseResult.IsValid)
                    break;

                userDeviceList.AddRange(userDeviceParseResult.Data);

                string nextPage = getRequest.GetNextPage();
                if (String.IsNullOrEmpty(nextPage) || nextPage.Equals(readUserDeviceEndpoint))
                    break;

                readUserDeviceEndpoint = nextPage;
            }

            return userDeviceList;
        }

        /// <summary>
        ///     Get tha user device list
        /// </summary>
        /// <param name="autoComplete"> The string for which you want autocomplete values. </param>
        /// <returns> List of the interests </returns>
        public IList<TargetingInterests> ReadInterestsList(string autoComplete)
        {
            //string readTargetingInterestsEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().TargetingInterestsReadEndpoint;
            //readTargetingInterestsEndpoint = String.Format(readTargetingInterestsEndpoint, autoComplete, this.facebookSession.GetUserAccessToken());
            //IRequest webRequest = new FacebookRequest(this.facebookSession);

            //var interestsList = new List<TargetingInterests>();
            //while (true)
            //{
            //    string getRequest = webRequest.Get(readTargetingInterestsEndpoint);

            //    if (String.IsNullOrEmpty(getRequest))
            //        break;

            //    BaseObjectsList<TargetingInterests> targetingInterestsParseResult = new TargetingInterests().ParseMultipleResponse(getRequest);
            //    if (targetingInterestsParseResult == null || !targetingInterestsParseResult.IsValid)
            //        break;

            //    interestsList.AddRange(targetingInterestsParseResult.Data);

            //    string nextPage = getRequest.GetNextPage();
            //    if (String.IsNullOrEmpty(nextPage) || nextPage.Equals(readTargetingInterestsEndpoint))
            //        break;

            //    readTargetingInterestsEndpoint = nextPage;
            //}

            //return interestsList;
            return null;
        }
    }
}