using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Contracts.Repository;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;
using facebook_csharp_ads_sdk.Domain.Models.AdCreative;

namespace facebook_csharp_ads_sdk.Infrastructure.Repository
{
    public class AdCreativeRepository : ICreativeRepository
    {
        #region Properties

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

        public Task<AdCreative> Read(long id)
        {
            throw new NotImplementedException();
        }

        public Task<AdCreative> Create(AdCreative entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(long id)
        {
            throw new NotImplementedException();
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
