using System;
using System.Collections.Generic;
using System.Text;

namespace StockX.NET.Models
{
    public class Market
    {
        public string ABSChangeDecimal { get; set; }
        public int AnnualHigh { get; set; }
        public int AnnualLow { get; set; }
        public int DeadstockRangeHigh { get; set; }
        public int DeadstockRangeLow { get; set; }
        public int DeadstockSold { get; set; }
        public int HighestBid { get; set; }
        public string HighestBidSize { get; set; }
        public int LastSale { get; set; }
        public string LastSaleSize { get; set; }
        public int LowestAsk { get; set; }
        public string LowestAskSize { get; set; }
        public int SalesInLast72Hours { get; set; }
    }
}
