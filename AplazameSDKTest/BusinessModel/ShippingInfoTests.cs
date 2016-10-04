using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Aplazame.BusinessModel
{
    [TestClass]
    public class ShippingInfoTests : AddressTests
    {
        [TestMethod]
        public new void MinimalFields()
        {
            ShippingInfo shippingInfo = new ShippingInfo(
                "first name foo",
                "last name foo",
                "street foo",
                "city foo",
                "state foo",
                "ES",
                "10001",
                "name foo",
                Decimal.FromDouble(1)
            );

            string expected = @"{
  ""name"": ""name foo"",
  ""price"": 100,
  ""first_name"": ""first name foo"",
  ""last_name"": ""last name foo"",
  ""street"": ""street foo"",
  ""city"": ""city foo"",
  ""state"": ""state foo"",
  ""country"": ""ES"",
  ""postcode"": ""10001""
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(shippingInfo, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        [TestMethod]
        public new void AllFields()
        {
            ShippingInfo shippingInfo = new ShippingInfo(
                "first name foo",
                "last name foo",
                "street foo",
                "city foo",
                "state foo",
                "ES",
                "10001",
                "name foo",
                Decimal.FromDouble(1)
            );
            shippingInfo.phone = "0099123456789";
            shippingInfo.alt_phone = "+99123456789";
            shippingInfo.address_addition = "address_addition foo";
            shippingInfo.tax_rate = Decimal.FromDouble(2);
            shippingInfo.discount = Decimal.FromDouble(3);
            shippingInfo.discount_rate = Decimal.FromDouble(4);

            string expected = @"{
  ""name"": ""name foo"",
  ""price"": 100,
  ""tax_rate"": 200,
  ""discount"": 300,
  ""discount_rate"": 400,
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

            Assert.AreEqual(expected, JsonConvert.SerializeObject(shippingInfo, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}