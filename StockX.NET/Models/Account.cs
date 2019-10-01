using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static StockX.NET.Functions.JsonReturns;

namespace StockX.NET.Models
{
    public class Account
    {
        public BillingAndShipping Billing { get; set; }
        public BillingAndShipping Shipping { get; set; }
        public CreditCardInfo CCInfo { get; set; }
        public string Email { get; set; }
        public string IntercomToken { get; set; }
        public string MD5Email { get; set; }
        public string Sha1Email { get; set; }
        public string Username { get; set; }
        public string UUID { get; set; }
    
        public Account LoadAccount(JObject Object)
        {
            return new Account()
            {
                Billing = new BillingAndShipping().LoadBillingAndShipping(Object["Customer"]["Billing"]["Address"] as JObject),
                Shipping = new BillingAndShipping().LoadBillingAndShipping(Object["Customer"]["Shipping"]["Address"] as JObject),
                CCInfo = new CreditCardInfo().LoadCardInfo(Object["Customer"]["Billing"] as JObject),
                Email = String(Object["Customer"] as JObject, "email"),
                IntercomToken = String(Object["Customer"] as JObject, "intercome_token"),
                MD5Email = String(Object["Customer"] as JObject, "md5Email"),
                UUID = String(Object["Customer"] as JObject, "uuid"),
                Sha1Email = String(Object["Customer"] as JObject, "sha1Email"),
                Username = String(Object["Customer"] as JObject, "username")
            };
        }
    }
}
