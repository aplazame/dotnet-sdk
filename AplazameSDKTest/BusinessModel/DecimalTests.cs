using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aplazame.BusinessModel
{
    [TestClass]
    public class DecimalTests
    {
        [TestMethod]
        public void Conversion()
        {

            foreach (KeyValuePair<string, object> dataSet in ValuesProvider())
            {
                dynamic dataSetValue = dataSet.Value;

                double doubleValue = dataSetValue.doubleValue;
                int intValue = dataSetValue.intValue;
                
                Assert.AreEqual(intValue, Decimal.FromDouble(doubleValue), "int value not match");
                Assert.AreEqual(doubleValue, Decimal.ToDouble(intValue), "double value not match");
            }
        }

        public Dictionary<string, object> ValuesProvider()
        {
            return new Dictionary<string, object>()
            {
                // Description => [double, int]
                { "0", new {doubleValue=0, intValue=0 } },
                { "0.1", new {doubleValue=0.1, intValue=10 } },
                { "0.01", new {doubleValue=0.01, intValue=1 } },
                { "1", new {doubleValue=1, intValue=100 } },
                { "1.10", new {doubleValue=1.10, intValue=110 } },
                { "1.01", new {doubleValue=1.01, intValue=101 } },
                { "100", new {doubleValue=100, intValue=10000 } },
                { "100.10", new {doubleValue=100.10, intValue=10010 } },
                { "100.01", new {doubleValue=100.01, intValue=10001 } },
            };
        }
    }
}
