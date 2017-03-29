using System;
using System.Collections.Generic;

namespace LanguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrices(this IEnumerable<Product> products)
        {
            decimal total = 0;

            foreach (Product product in products)
            {
                total += product?.Price ?? 0;
            }

            return total;
        }

        public static IEnumerable<Product> Filter( this IEnumerable<Product> products, Func<Product, bool> selector)
        {
            foreach (var product in products)
            {
                if (selector(product))
                {
                    yield return product;
                }
            }
        }

        //public static IEnumerable<Product> FilterByPrice (this IEnumerable<Product> products, decimal minimumPrice)
        //{
        //    foreach (Product product in products)
        //    {
        //        if ((product?.Price ?? 0) >= minimumPrice)
        //        {
        //            yield return product;
        //        }
        //    }
        //}

        //public static IEnumerable<Product> FilterByName(this IEnumerable<Product> products, char letter)
        //{
        //    foreach (Product product in products)
        //    {
        //        if (product?.Name?[0] == letter)
        //        {
        //            yield return product;
        //        }
        //    }
        //}
    }
}
