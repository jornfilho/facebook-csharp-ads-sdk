using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Enums.FacebookSession;
using facebook_csharp_ads_sdk.Domain.Exceptions.Users;
using facebook_csharp_ads_sdk.Domain.Models.AdCreative;
using facebook_csharp_ads_sdk._Utils.WebRequests;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    public class AdCreativeRepository : ICreativeRepository
    {
        #region Properties

        /// <summary>
        /// Instance of facebook property
        /// </summary>
        private readonly IFacebookSession facebookSession;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Repository constructor with an instance of Facebook Session
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public AdCreativeRepository(IFacebookSession facebookSession)
        {
            if (facebookSession == null)
            {
                throw new ArgumentNullException();
            }

            this.facebookSession = facebookSession;
        } 

        #endregion
        
        /// <summary>
        ///     Create the ad creative on Facebook
        /// </summary>
        /// <param name="adCreative"> Ad creative to create </param>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <returns> Ad creative created with id </returns>
        public async Task<AdCreative> Create(AdCreative adCreative)
        {
            if (adCreative == null)
            {
                return null;
            }
            this.facebookSession.ValidateFacebookSessionRequirements(new[] {RequiredOnFacebookSessionEnum.UserAccessToken});
            Dictionary<string, string> paramToCreate = adCreative.GetSingleCreateParams();

            string creativeCreateEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().AdCreativeCreateEndPoint;
            creativeCreateEndpoint = String.Format(creativeCreateEndpoint, adCreative.AccountId, this.facebookSession.GetUserAccessToken());
            
            IRequest webRequest = new Request();
            string requestResult = await webRequest.PostAsync(creativeCreateEndpoint, paramToCreate);

            adCreative.ParseCreateResponse(requestResult);
            return adCreative;
        }
        
        public Task<AdCreative> Read(long id)
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        ///     Delete the ad creative
        /// </summary>
        /// <exception cref="InvalidUserAccessToken"> Invalid token exception </exception>
        /// <param name="id"> Id of the creative to delete </param>
        /// <returns> Success </returns>
        public async Task<bool> Delete(long id)
        {
            this.facebookSession.ValidateFacebookSessionRequirements(new[] {RequiredOnFacebookSessionEnum.UserAccessToken});
            string deleteEndpoint = this.facebookSession.GetFacebookAdsApiConfiguration().DeleteEndpoint;
            deleteEndpoint = String.Format(deleteEndpoint, id, this.facebookSession.GetUserAccessToken());

            IRequest webRequest = new Request();
            string deleteRequest = await webRequest.DeleteAsync(deleteEndpoint);
            var creative = new AdCreative(this);

            return creative.ParseDeleteResponse(deleteRequest);
        }

        public Task<AdCreative> Update(AdCreative entity)
        {
            throw new NotImplementedException();
        }

        public Task<AdCreative> Read(long creativeId, IList<AdCreativeReadFieldsEnum> fields)
        {
            throw new NotImplementedException();
        }
    }
}
