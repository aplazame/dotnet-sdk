using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;

namespace Aplazame.BusinessModel
{
    [TestClass]
    public class OrderTestsCase
    {
        [TestMethod]
        public void ThrowExceptionIfArticlesCollectionIsEmpty()
        {
            try
            {
                new Order(
                    "id1234",
                    "EUR",
                    Decimal.FromDouble(1),
                    Decimal.FromDouble(2),
                    new Article[] { }
                );
                Assert.Fail("Excepted ArgumentException 'articles must not be empty' to be thrown");
            }
            catch (ArgumentException e)
            {
                Assert.AreEqual("articles must not to be empty", e.Message);
            }
        }

        [TestMethod]
        public void MinimalFields()
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

            string expected = @"{
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
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(order, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        [TestMethod]
        public void AllFields()
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
            order.discount = Decimal.FromDouble(3);
            order.discount_rate = Decimal.FromDouble(4);
            order.cart_discount = Decimal.FromDouble(5);
            order.cart_discount_rate = Decimal.FromDouble(6);

            string expected = @"{
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
  ],
  ""discount"": 300,
  ""discount_rate"": 400,
  ""cart_discount"": 500,
  ""cart_discount_rate"": 600
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(order, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
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
    }
}