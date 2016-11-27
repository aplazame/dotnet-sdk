namespace Aplazame.Serializer
{
    public class DecimalType
    {
        public static int FromDouble(double value)
        {
            return (int)(value * 100);
        }

        public static double ToDouble(int value)
        {
            return ((float)value / 100);
        }
    }
}
