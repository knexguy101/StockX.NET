using Newtonsoft.Json.Linq;
using StockX.NET.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace StockX.NET.Functions
{
    public class Search
    {
        /// <summary>
        /// Returns a list of products based on the search given
        /// </summary>
        /// <param name="Condition"></param>
        /// <param name="Proxy"></param>
        /// <returns></returns>
        public static List<Product> SearchProducts(string Condition, WebProxy Proxy = null)
        {
            List<Product> Temp = new List<Product>();
            HttpClientHandler handler = new HttpClientHandler()
            {
                Proxy = Proxy,
                CookieContainer = new CookieContainer(),
                AllowAutoRedirect = true
            };
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");

            var response = client.GetAsync($"https://stockx.com/api/browse?&_search={Uri.EscapeDataString(Condition)}&dataType=product").Result;
            JObject tempObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            foreach (JObject temp in (tempObject.SelectToken("Products") as JArray).Children<JObject>())
            {
                Temp.Add(new Product().LoadJSON(temp));
            }

            return Temp;
        }

        /// <summary>
        /// Returns a list of products from the range of 1 to the page entered
        /// </summary>
        /// <param name="PageAmount"></param>
        /// <param name="Type"></param>
        /// <param name="Proxy"></param>
        /// <returns></returns>
        public static List<Product> ListProducts(int PageAmount, ProductType Type, WebProxy Proxy = null)
        {
            List<Product> Temp = new List<Product>();
            HttpClientHandler handler = new HttpClientHandler()
            {
                Proxy = Proxy,
                CookieContainer = new CookieContainer(),
                AllowAutoRedirect = true
            };
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/77.0.3865.90 Safari/537.36");

            for(int x = 1; x < PageAmount + 1; x++)
            {
                var response = client.GetAsync($"https://stockx.com/api/browse?productCategory={Type.ToString().ToLower()}&page={x}").Result;
                JObject tempObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                foreach(JObject temp in (tempObject.SelectToken("Products") as JArray).Children<JObject>())
                {
                    Temp.Add(new Product().LoadJSON(temp));
                }
            }

            return Temp;
        }
    }
}
