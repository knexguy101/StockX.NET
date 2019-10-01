using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockX.NET;

namespace StockX.NET_Unit_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            //search testing
            Console.WriteLine("Please enter a search string:");
            string searchString = Console.ReadLine();
            var searchList = StockX.NET.Functions.Search.SearchProducts(searchString);
            foreach(var item in searchList)
            {
                Console.WriteLine($"Name: {item.Name} Retail: {item.Retail}");
            }

            //page testing
            Console.WriteLine("Please enter the amount of pages:");
            string pageString = Console.ReadLine();
            int pageInt;
            if(int.TryParse(pageString, out pageInt))
            {
                var pageList = StockX.NET.Functions.Search.ListProducts(pageInt, NET.Models.ProductType.Sneakers);
                foreach(var item in pageList)
                {
                    Console.WriteLine($"Name: {item.Name} Retail: {item.Retail}");
                }
            }

            Console.WriteLine("Please enter a search to scrape sales from:");
            string salesString = Console.ReadLine();
            var salesProductList = StockX.NET.Functions.Search.SearchProducts(salesString);
            foreach (var item in salesProductList)
            {
                Console.WriteLine($"Name: {item.Name} Retail: {item.Retail}");
                var salesList = StockX.NET.Functions.Sales.ListSales(item.ID, 1);
                foreach(var sale in salesList)
                {
                    Console.WriteLine($"Amount: {sale.Amount} Size: {sale.Size}");
                }
            }

            Console.WriteLine("Please enter an email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Please enter the password: ");
            string password = Console.ReadLine();
            var loginAccount = StockX.NET.Functions.Login.LoginToAccount(email, password);
            Console.WriteLine($"Username: {loginAccount.Username} UUID: {loginAccount.UUID}");

            Console.ReadKey();
        }
    }
}
