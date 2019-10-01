using Newtonsoft.Json.Linq;
using StockX.NET.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace StockX.NET.Functions
{
    public class Login
    {
        public static Account LoginToAccount(string Email, string Password, WebProxy Proxy = null)
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

            JObject temp = new JObject()
            {
                {"email", Email },
                {"password", Password }
            };

            var response = client.PostAsync("https://stockx.net/api/login", new StringContent(temp.ToString(), Encoding.UTF8, "application/json")).Result;
            JObject tempObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            return new Account().LoadAccount(tempObject);
        }
    }
}
