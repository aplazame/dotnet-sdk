using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Aplazame.BusinessModel
{
    [TestClass]
    public class CheckoutTestsCase
    {
        [TestMethod]
        public void MinimalFields()
        {
            Checkout checkout = new Checkout(
                true,
                this.mockMerchant(),
                this.mockOrder(),
                this.mockCustomer()
            );

            string expected = @"{
  ""toc"": true,
  ""merchant"": {
    ""confirmation_url"": ""http://confirmation_url.foo"",
    ""cancel_url"": ""http://cancel_url.foo"",
    ""success_url"": ""http://success_url.foo"",
    ""checkout_url"": ""/""
  },
  ""order"": {
    ""id"": ""id1234"",
    ""currency"": ""EUR"",
    ""tax_rate"": 100,
    ""total_amount"": 200,
    ""articles"": [
      {
        ""id"": ""id1234"",
        ""name"": ""name lorem ipsum"",
        ""url"": ""http://url.foo"",
        ""image_url"": ""http://url_image.foo"",
        ""quantity"": 1,
        ""price"": 200
      }
    ]
  },
  ""customer"": {
    ""id"": ""id1234"",
    ""email"": ""foo@example.com"",
    ""type"": ""n"",
    ""gender"": 0
  }
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(checkout, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        [TestMethod]
        public void AllFields()
        {
            Checkout checkout = new Checkout(
                true,
                this.mockMerchant(),
                this.mockOrder(),
                this.mockCustomer()
            );
            checkout.shipping = this.mockShippingInfo();
            checkout.billing = this.mockAddress();

            Dictionary<int, int> meta = new Dictionary<int, int>();
            meta.Add(1, 2);
            checkout.meta = meta;

            string expected = @"{
  ""toc"": true,
  ""merchant"": {
    ""confirmation_url"": ""http://confirmation_url.foo"",
    ""cancel_url"": ""http://cancel_url.foo"",
    ""success_url"": ""http://success_url.foo"",
    ""checkout_url"": ""/""
  },
  ""order"": {
    ""id"": ""id1234"",
    ""currency"": ""EUR"",
    ""tax_rate"": 100,
    ""total_amount"": 200,
    ""articles"": [
      {
        ""id"": ""id1234"",
        ""name"": ""name lorem ipsum"",
        ""url"": ""http://url.foo"",
        ""image_url"": ""http://url_image.foo"",
        ""quantity"": 1,
        ""price"": 200
      }
    ]
  },
  ""customer"": {
    ""id"": ""id1234"",
    ""email"": ""foo@example.com"",
    ""type"": ""n"",
    ""gender"": 0
  },
  ""billing"": {
    ""first_name"": ""first name foo"",
    ""last_name"": ""last name foo"",
    ""street"": ""street foo"",
    ""city"": ""city foo"",
    ""state"": ""state foo"",
    ""country"": ""ES"",
    ""postcode"": ""10001""
  },
  ""shipping"": {
    ""name"": ""name foo"",
    ""price"": 100,
    ""first_name"": ""first name foo"",
    ""last_name"": ""last name foo"",
    ""street"": ""street foo"",
    ""city"": ""city foo"",
    ""state"": ""state foo"",
    ""country"": ""ES"",
    ""postcode"": ""10001""
  },
  ""meta"": {
    ""1"": 2
  }
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(checkout, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        private Merchant mockMerchant()
        {
            Merchant merchant = new Merchant(
                "http://confirmation_url.foo",
                "http://cancel_url.foo",
                "http://success_url.foo"
            );

            return merchant;
        }
        private Order mockOrder()
        {
            Order order = new Order(
                "id1234",
                "EUR",
                Decimal.FromDouble(1),
                Decimal.FromDouble(2),
                new Article[] {
                    this.mockArticle(),
                }
            );

            return order;
        }
        private Article mockArticle()
        {
            Article article = new Article(
                "id1234",
                "name lorem ipsum",
                "http://url.foo",
                "http://url_image.foo",
                1,
                Decimal.FromDouble(2)
            );

            return article;
        }
        private Customer mockCustomer()
        {
            Customer customer = new Customer(
                "id1234",
                "foo@example.com",
                Customer.TYPE_NEW,
                Customer.GENDER_UNKNOWN
            );

            return customer;
        }
        private Address mockAddress()
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
        private ShippingInfo mockShippingInfo()
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

            return shippingInfo;
        }
    }
}