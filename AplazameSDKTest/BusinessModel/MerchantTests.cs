using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Aplazame.BusinessModel
{
    [TestClass]
    public class MerchantTestsCase
    {
        [TestMethod]
        public void MinimalFields()
        {
            Merchant merchant = new Merchant(
                "http://confirmation_url.foo",
                "http://cancel_url.foo",
                "http://success_url.foo"
            );

            string expected = @"{
  ""confirmation_url"": ""http://confirmation_url.foo"",
  ""cancel_url"": ""http://cancel_url.foo"",
  ""success_url"": ""http://success_url.foo"",
  ""checkout_url"": ""/""
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(merchant, Formatting.Indented));
        }

        [TestMethod]
        public void AllFields()
        {
            Merchant merchant = new Merchant(
                "http://confirmation_url.foo",
                "http://cancel_url.foo",
                "http://success_url.foo"
            );
            merchant.checkout_url = "http://checkout_url.foo";

            string expected = @"{
  ""confirmation_url"": ""http://confirmation_url.foo"",
  ""cancel_url"": ""http://cancel_url.foo"",
  ""success_url"": ""http://success_url.foo"",
  ""checkout_url"": ""http://checkout_url.foo""
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(merchant, Formatting.Indented));
        }
    }
}