using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static StockX.NET.Functions.JsonReturns;

namespace StockX.NET.Models
{
    public class CreditCardInfo
    {
        public BillingAndShipping Shipping { get; set; }
        public string CreditCardName { get; set; }
        public string CardType { get; set; }
        public string Last4Digits { get; set; }
        public string ExpDate { get; set; }
        public string CCToken { get; set; }

        public CreditCardInfo LoadCardInfo(JObject Object)
        {
            var addressObj = Object["Address"] as JObject;
            return new CreditCardInfo
            {
                Shipping = new BillingAndShipping()
                {
                    CountryCode = String(addressObj, "countryCodeAlpha2"),
                    City = String(addressObj, "locality"),
                    Address = String(addressObj, "streetAddress"),
                    FirstName = String(addressObj, "firstName"),
                    LastName = String(addressObj, "lastName"),
                    Phone = String(addressObj, "telephone"),
                    Region = String(addressObj, "region"),
                    ZipCode = String(addressObj, "postalCode")
                },
                CardType = String(Object, "cardType"),
                CCToken = String(Object, "token"),
                CreditCardName = String(Object, "cardholderName"),
                ExpDate = String(Object, "expirationDate"),
                Last4Digits = String(Object, "last4")
            };
        }
    }
}
