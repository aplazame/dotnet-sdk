using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aplazame.Serializer
{
    [TestClass]
    public class JsonSerializerTests
    {
        [TestMethod]
        public void Conversion()
        {
            foreach (KeyValuePair<string, object> dataSet in ValuesProvider())
            {
                dynamic dataSetValue = dataSet.Value;

                dynamic value = dataSetValue.Value;
                string serialized = dataSetValue.Serialized;
                
                Assert.AreEqual(serialized, JsonSerializer.AsJsonString(value));
            }
        }

        public Dictionary<string, object> ValuesProvider()
        {
            string dateValue = DateType.FromDateTime(DateTime.Parse("2000-01-02 03:04:05"));
            int decimalValue = DecimalType.FromDouble(1.23);

            return new Dictionary<string, object>()
            {
                // Description => [value, serialized]
                { "string", new {Value="foo", Serialized="\"foo\""} },
                { "[string]", new {Value=new dynamic[] {"foo"}, Serialized="[\"foo\"]"} },
                { "{string}", new {Value=new {a = "foo"}, Serialized="{\"a\":\"foo\"}"} },
                { "int", new {Value=1, Serialized=1.ToString()} },
                { "[int]", new {Value=new dynamic[] {1}, Serialized="[1]"} },
                { "{int}", new {Value=new {a = 1}, Serialized="{\"a\":1}"} },
                { "Decimal", new {Value=decimalValue, Serialized="123"} },
                { "[Decimal]", new {Value=new dynamic[] {decimalValue}, Serialized="[123]"} },
                { "{Decimal}", new {Value=new {a = decimalValue}, Serialized="{\"a\":123}"} },
                { "true", new {Value=true, Serialized="true"} },
                { "[true]", new {Value=new dynamic[] {true}, Serialized="[true]"} },
                { "{true}", new {Value=new {a = true}, Serialized="{\"a\":true}"} },
                { "false", new {Value=false, Serialized="false"} },
                { "[false]", new {Value=new dynamic[] {false}, Serialized="[false]"} },
                { "{false}", new {Value=new {a = false}, Serialized="{\"a\":false}"} },
                { "Date", new {Value=dateValue, Serialized="\"2000-01-02T03:04:05+01:00\""} },
                { "[Date]", new {Value=new dynamic[] {dateValue}, Serialized="[\"2000-01-02T03:04:05+01:00\"]"} },
                { "{Date}", new {Value=new {a = dateValue}, Serialized="{\"a\":\"2000-01-02T03:04:05+01:00\"}"} },
            };
        }
    }
}
