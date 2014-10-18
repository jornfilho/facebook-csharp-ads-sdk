using facebook_csharp_ads_sdk.Domain.Models.Accounts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace facebook_csharp_ads_sdk.test.Domain.Models.Accounts
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t = new Account().AccountGroups;
            var tt = JsonConvert.SerializeObject(t);


        }
    }
}
