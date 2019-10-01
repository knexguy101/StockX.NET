using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using static StockX.NET.Functions.JsonReturns;

namespace StockX.NET.Models
{
    public class BillingAndShipping
    {
        public string CountryCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string Region { get; set; }
        public string Phone { get; set; }

        public BillingAndShipping LoadBillingAndShipping(JObject Object)
        {
            return new BillingAndShipping
            {
                CountryCode = String(Object, "countryCodeAlpha2"),
                City = String(Object, "locality"),
                Address = String(Object, "streetAddress"),
                FirstName = String(Object, "firstName"),
                LastName = String(Object, "lastName"),
                Phone = String(Object, "telephone"),
                Region = String(Object, "region"),
                ZipCode = String(Object, "postalCode")
            };
        }
    }
}
