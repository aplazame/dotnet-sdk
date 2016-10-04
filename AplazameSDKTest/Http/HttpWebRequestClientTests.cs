using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aplazame.Http
{
    [TestClass]
    public class HttpWebRequestClientTests : AbstractClientTestCase
    {
        protected override IClient CreateClient()
        {
            return new HttpWebRequestClient();
        }
    }
}
