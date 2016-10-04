using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Aplazame.BusinessModel
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void MinimalFields()
        {
            Address address = new Address(
                "first name foo",
                "last name foo",
                "street foo",
                "city foo",
                "state foo",
                "ES",
                "10001"
            );

            string expected = @"{
  ""first_name"": ""first name foo"",
  ""last_name"": ""last name foo"",
  ""street"": ""street foo"",
  ""city"": ""city foo"",
  ""state"": ""state foo"",
  ""country"": ""ES"",
  ""postcode"": ""10001""
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(address, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        [TestMethod]
        public void AllFields()
        {
            Address address = new Address(
                "first name foo",
                "last name foo",
                "street foo",
                "city foo",
                "state foo",
                "ES",
                "10001"
            );
            address.phone = "0099123456789";
            address.alt_phone = "+99123456789";
            address.address_addition = "address_addition foo";

            string expected = @"{
  ""first_name"": ""first name foo"",
  ""last_name"": ""last name foo"",
  ""street"": ""street foo"",
  ""city"": ""city foo"",
  ""state"": ""state foo"",
  ""country"": ""ES"",
  ""postcode"": ""10001"",
  ""phone"": ""0099123456789"",
  ""alt_phone"": ""+99123456789"",
  ""address_addition"": ""address_addition foo""
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(address, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}
