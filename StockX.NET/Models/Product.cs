using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static StockX.NET.Functions.JsonReturns;

namespace StockX.NET.Models
{
    public class Product
    {
        public bool BelowRetail { get; set; }
        public string Brand { get; set; }
        public string Colorway { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public ProductType Category {get; set;}
        public DateTime ReleaseDateandTime { get; set; }
        public int Retail { get; set; }
        public string URLKey { get; set; }       
        public Market Market { get; set; }
        public Media Media { get; set; }

        public Product LoadJSON(JObject Object)
        {
            Market Market = new Market()
            {
                ABSChangeDecimal = String(Object["market"] as JObject, "absChangePercentage"),
                AnnualHigh = Int(Object["market"] as JObject, "annualHigh"),
                AnnualLow = Int(Object["market"] as JObject, "annualLow"),
                DeadstockRangeHigh = Int(Object["market"] as JObject, "deadstockRangeHigh"),
                DeadstockRangeLow = Int(Object["market"] as JObject, "deadstockRangeLow"),
                DeadstockSold = Int(Object["market"] as JObject, "deadstockSold"),
                HighestBid = Int(Object["market"] as JObject, "highestBid"),
                HighestBidSize = String(Object["market"] as JObject, "highestBidSize"),
                SalesInLast72Hours = Int(Object["market"] as JObject, "salesLast72Hours"),
                LastSale = Int(Object["market"] as JObject, "lastSale"),
                LastSaleSize = String(Object["market"] as JObject, "lastSaleSize"),
                LowestAsk = Int(Object["market"] as JObject, "lowestAsk"),
                LowestAskSize = String(Object["market"] as JObject, "lowestAskSize")
            };
            Media Media = new Media()
            {
                NormalURL = String(Object["media"] as JObject, "imageUrl"),
                SmallURL = String(Object["media"] as JObject, "smallImageUrl"),
                ThumbURL = String(Object["media"] as JObject, "thumbUrl")
            };
            Product p = new Product
            {
                BelowRetail = Bool(Object, "belowRetail"),
                Brand = String(Object, "brand"),
                Category = (ProductType)Enum.Parse(typeof(ProductType), String(Object, "productCategory"), true),
                Colorway = String(Object, "colorway"),
                ID = String(Object, "id"),
                Name = String(Object, "title"),
                ReleaseDateandTime = DateTime(Object, "releaseDate"),
                Retail = Int(Object, "retailPrice"),
                URLKey = String(Object, "urlKey"), 
                Market = Market,
                Media = Media
            };
            return p;
        }
    }

    public enum ProductType
    {
        Sneakers, Streetwear
    }
}
