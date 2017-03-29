using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using LanguageFeatures.Models;

namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var products = new[] {
                new { Name = "Kayak", Price = 275M },
                new { Name = "Lifejacket", Price = 48.95M },
                new { Name = "Soccer ball", Price = 19.50M },
                new { Name = "Corner flag", Price = 34.95M }
            };

            return View(products.Select(p => $"{nameof(p.Name)}: {p.Name}, {nameof(p.Price)}: {p.Price}"));
        }

        //public async Task<ViewResult> Index()
        //{
        //    long? length = await MyAsyncMethods.GetPageLength();
        //    return View(new string[] { $"Length: {length}" });
        //}


        //public ViewResult Index()
        //{
            //List<string> results = new List<string>();

            //foreach (Product p in Product.GetProducts())
            //{
            //    string name = p?.Name ?? "<No Name>";
            //    decimal? price = p?.Price ?? 0;
            //    string relatedName = p?.Related?.Name ?? "<None>";

            //    results.Add($"Name: {name}, Price: {price:C2}, Related: {relatedName}");
            //}

            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };
            //Product[] productArray = {
            //    new Product {Name = "Kayak", Price = 275M},
            //    new Product {Name = "Lifejacket", Price = 48.95M},
            //    new Product {Name = "Soccer ball", Price = 19.50M},
            //    new Product {Name = "Corner flag", Price = 34.95M}
            //};
            //decimal cartTotal = cart.TotalPrices();
            //decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
            //decimal nameFilterTotal = productArray.FilterByName('S').TotalPrices();

            //decimal priceFilterTotal = productArray
            //    .Filter(p => (p?.Price ?? 0) >= 20)
            //    .TotalPrices();

            //decimal nameFilterTotal = productArray
            //    .Filter(p => p?.Name?[0] == 'S')
            //    .TotalPrices();

            //return View(new string[] 
            //{
            //    $"Price Total: {priceFilterTotal:C2}",
            //    $"Name Total: {nameFilterTotal:C2}" 
            //});

            //return View(Product.GetProducts().Where(p => p != null).Select(p => p.Name));
        //}
    }
}
