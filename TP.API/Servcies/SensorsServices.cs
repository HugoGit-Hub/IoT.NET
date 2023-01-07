using System;

namespace TP.API.Servcies
{
    public static class SensorsServices
    {
        public static int digitsNumber(string frame)
        {
            return frame.Length;
        }

        public static string payLoadSixDigits(string frame)
        {
            string payload = frame.Substring(2, 4);
            return payload;
        }

        public static string payLoadTenDigits(string frame)
        {
            string payload = frame.Substring(6, 4);
            return payload;
        }

        public static int stringToInt(string payLoad)
        {
            int value = Convert.ToInt32(payLoad, 16) / 10;
            return value;
        }
    }
}
