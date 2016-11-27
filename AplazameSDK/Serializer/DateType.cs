using System;

namespace Aplazame.Serializer
{
    public class DateType
    {
        public static string FromDateTime(DateTime value)
        {
            return value.ToString("yyyy-MM-ddTHH:mm:sszzz");
        }

        public static DateTime ToDateTime(string value)
        {
            return DateTime.Parse(value);
        }
    }
}
