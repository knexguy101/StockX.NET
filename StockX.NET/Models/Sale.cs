using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static StockX.NET.Functions.JsonReturns;

namespace StockX.NET.Models
{
    public class Sale
    {
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Size { get; set; }

        public Sale LoadSale(JObject Object)
        {
            if (Int(Object, "amount") > 0)
            {
                return new Sale
                {
                    Amount = Int(Object, "amount"),
                    CreatedAt = DateTime(Object, "createdAt"),
                    Size = String(Object, "shoeSize")
                };
            }
            else
            {
                return new Sale();
            }
        }
    }
}
