using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockX.NET.Functions
{
    public class JsonReturns
    {
        public static string String(JObject jobject, string token)
        {
            JToken value;
            if (jobject.TryGetValue(token, out value))
            {
                return value.ToString();
            }
            return " ";
        }

        public static bool Bool(JObject jobject, string token)
        {
            JToken value;
            if (jobject.TryGetValue(token, out value))
            {
                bool returnable = false;
                if (bool.TryParse(value.ToString(), out returnable))
                {
                    return returnable;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public static int Int(JObject jobject, string token, int Default = 0)
        {
            JToken value;
            if (jobject.TryGetValue(token, out value))
            {
                int returnable = 0;
                if (int.TryParse(value.ToString(), out returnable))
                {
                    return returnable;
                }
                else
                {
                    return Default;
                }
            }
            else
            {
                return Default;
            }
        }

        public static DateTime DateTime(JObject jobject, string token)
        {
            JToken value;
            if (jobject.TryGetValue(token, out value))
            {
                DateTime returnable = new DateTime();
                if (System.DateTime.TryParse(value.ToString(), out returnable))
                {
                    return returnable;
                }
                else
                {
                    return new System.DateTime();
                }
            }
            else
            {
                return new System.DateTime();
            }
        }
    }
}
