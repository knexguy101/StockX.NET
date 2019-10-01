using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockX.NET.Models
{
    public class PortfolioItem
    {
        public string ChainID { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ListingAmount { get; set; }
        public int LocalMarketValue { get; set; }
        public Product Product { get; set; }
        public string ProductID { get; set; }
        public string SKUUID { get; set; }

        public void LoadItem(JObject Object)
        {

        }
    }
}
