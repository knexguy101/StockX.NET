using Newtonsoft.Json.Linq;
using StockX.NET.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace StockX.NET.Functions
{
    public class Sales
    {
        public static List<Sale> ListSales(string ProductID, int PagesOfSales, WebProxy Proxy = null)
        {
            List<Sale> Temp = new List<Sale>();
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

            if(string.IsNullOrEmpty(ProductID))
            {
                return Temp;
            }

            for (int x = 1; x < PagesOfSales + 1; x++)
            {
                try
                {
                    var response = client.GetAsync($"https://stockx.com/api/products/{ProductID}/activity?state=480&currency=USD&limit=10&page={x}&sort=createdAt&order=DESC").Result;
                    JObject tempObject = JObject.Parse(response.Content.ReadAsStringAsync().Result);
                    foreach (JObject temp in (tempObject.SelectToken("ProductActivity") as JArray).Children<JObject>())
                    {
                        Sale tempSale = new Sale().LoadSale(temp);
                        if(tempSale != new Sale())
                        {
                            Temp.Add(tempSale);
                        }
                    }
                }
                catch(Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
            }

            return Temp;
        }
    }
}
