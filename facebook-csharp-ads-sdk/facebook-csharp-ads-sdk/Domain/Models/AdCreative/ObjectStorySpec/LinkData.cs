using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using facebook_csharp_ads_sdk.Domain.Enums.AdCreative;

namespace facebook_csharp_ads_sdk.Domain.Models.AdCreative.ObjectStorySpec
{
    public class LinkData
    {
        public long PageId { get; private set; }

        public string Link { get; private set; }

        public string Message { get; private set; }

        public string Name { get; private set; }

        public string Caption { get; private set; }

        public string Description { get; private set; }

        public string Picture { get; private set; }

        public string ImageHash { get; private set; }

        public CallToActionTypeEnum CallToAction { get; private set; }

        public string ImageCrops { get; private set; }
    }
}
