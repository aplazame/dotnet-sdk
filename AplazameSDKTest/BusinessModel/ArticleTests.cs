using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace Aplazame.BusinessModel
{
    [TestClass]
    public class ArticleTests
    {
        [TestMethod]
        public void MinimalFields()
        {
            Article article = new Article(
                "id1234",
                "name lorem ipsum",
                "http://url.foo",
                "http://url_image.foo",
                1,
                Decimal.FromDouble(2)
            );

            string expected = @"{
  ""id"": ""id1234"",
  ""name"": ""name lorem ipsum"",
  ""url"": ""http://url.foo"",
  ""image_url"": ""http://url_image.foo"",
  ""quantity"": 1,
  ""price"": 200
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(article, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        [TestMethod]
        public void AllFields()
        {
            Article article = new Article(
                "id1234",
                "name lorem ipsum",
                "http://url.foo",
                "http://url_image.foo",
                1,
                Decimal.FromDouble(2)
            );
            article.description = "description lorem ipsum";
            article.tax_rate = Decimal.FromDouble(3);
            article.discount = Decimal.FromDouble(4);
            article.discount_rate = Decimal.FromDouble(5);

            string expected = @"{
  ""id"": ""id1234"",
  ""name"": ""name lorem ipsum"",
  ""url"": ""http://url.foo"",
  ""image_url"": ""http://url_image.foo"",
  ""quantity"": 1,
  ""price"": 200,
  ""description"": ""description lorem ipsum"",
  ""tax_rate"": 300,
  ""discount"": 400,
  ""discount_rate"": 500
}";

            Assert.AreEqual(expected, JsonConvert.SerializeObject(article, Formatting.Indented, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}