using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace Aplazame.BusinessModel
{
    [TestClass]
    public class CustomerTestsCase
    {
        [TestMethod]
        public void MinimalFields()
        {
            Customer customer = new Customer(
                "id1234",
                "foo@example.com",
                Customer.TYPE_NEW,
                Customer.GENDER_UNKNOWN
            );

            string expected = @"{
  ""id"": ""id1234"",
  ""email"": ""foo@example.com"",
  ""type"": ""n"",
  ""gender"": 0
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(customer, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        [TestMethod]
        public void AllFields()
        {
            Customer customer = new Customer(
                "id1234",
                "foo@example.com",
                Customer.TYPE_NEW,
                Customer.GENDER_UNKNOWN
            );
            customer.first_name = "description lorem ipsum";
            customer.last_name = "last name";
            customer.birthday = DateTime.Parse("2000-12-31 23:59:59+0000");
            customer.language = "de";
            customer.date_joined = DateTime.Parse("2001-12-31 23:59:59+0100");
            customer.last_login = DateTime.Parse("2002-12-31 23:59:59-0800");
            customer.address = this.MockAddress();

            string expected = @"{
  ""id"": ""id1234"",
  ""email"": ""foo@example.com"",
  ""type"": ""n"",
  ""gender"": 0,
  ""first_name"": ""description lorem ipsum"",
  ""last_name"": ""last name"",
  ""birthday"": ""2001-01-01T00:59:59+01:00"",
  ""language"": ""de"",
  ""date_joined"": ""2001-12-31T23:59:59+01:00"",
  ""last_login"": ""2003-01-01T08:59:59+01:00"",
  ""address"": {
    ""first_name"": ""first name foo"",
    ""last_name"": ""last name foo"",
    ""street"": ""street foo"",
    ""city"": ""city foo"",
    ""state"": ""state foo"",
    ""country"": ""ES"",
    ""postcode"": ""10001""
  }
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(customer, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
        private Address MockAddress()
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

            return address;
        }
    }
}