using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aplazame.Serializer
{
    [TestClass]
    public class DateTypeTests
    {
        [TestMethod]
        public void Conversion()
        {
            foreach (KeyValuePair<string, object> dataSet in ValuesProvider())
            {
                dynamic dataSetValue = dataSet.Value;

                DateTime dateTimeValue = dataSetValue.DateTimeValue;
                string stringValue = dataSetValue.StringValue;
                
                Assert.AreEqual(stringValue, DateType.FromDateTime(dateTimeValue), "string value not match");
                Assert.AreEqual(dateTimeValue, DateType.ToDateTime(stringValue), "DateTime value not match");
            }
        }

        public Dictionary<string, object> ValuesProvider()
        {
            return new Dictionary<string, object>()
            {
                // Description => [DateTime, string]
                { "1999-12-31", new {DateTimeValue=DateTime.Parse("1999-12-31"), StringValue="1999-12-31T00:00:00+01:00" } },
                { "1999-12-31 23:59:59", new {DateTimeValue=DateTime.Parse("1999-12-31 23:59:59"), StringValue="1999-12-31T23:59:59+01:00" } },
            };
        }
    }
}
