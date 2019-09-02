using cllwx.Models;
using cllwx.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cllwx.Utilities
{
    public interface IProductListSorter
    {
        List<Product> LowToHigh(List<Product> productList);
        List<Product> HighToLow(List<Product> productList);
        List<Product> AlphabeticallyAscending(List<Product> productList);
        List<Product> AlphabeticallyDescending(List<Product> productList);
        List<Product> HighestRecommendedFirst(List<Cart> customerOrderList);
    }
    public class ProductListSorter
    {
        public List<Product> LowToHigh(List<Product> unsortedProductList)
        {
            return unsortedProductList
                    .Where(x => x != null)
                    .OrderBy(x => x.Price)
                    .ToList();
        }

        public List<Product> HighToLow(List<Product> unsortedProductList)
        {
            return unsortedProductList
                    .Where(x => x != null)
                    .OrderByDescending(x => x.Price)
                    .ToList();
        }

        public List<Product> AlphabeticallyAscending(List<Product> unsortedProductList)
        {
            return unsortedProductList
                    .Where(x => x != null)
                    .OrderBy(x => x.Name)
                    .ToList();
        }

        public List<Product> AlphabeticallyDescending(List<Product> unsortedProductList)
        {
            return unsortedProductList
                    .Where(x => x != null)
                    .OrderByDescending(x => x.Name)
                    .ToList();
        }

        public List<Product> HighestRecommendedFirst(List<Cart> customerOrderList)
        {
            var uniqueProductList = filterProductQuantititesFromOrderList(customerOrderList);
            return uniqueProductList
                    .Where(x => x != null)
                    .OrderByDescending(x => x.Quantity)
                    .ToList();
        }

        private List<Product> filterProductQuantititesFromOrderList(List<Cart> customerOrderList)
        {
            var uniqueProducts = new Dictionary<string, double>();
            foreach (Cart cartItem in customerOrderList)
            {
                foreach (Product product in cartItem.Products)
                {
                    double currentCount;
                    var uniqueId = $"{product.Name}_{product.Price}";
                    uniqueProducts.TryGetValue(uniqueId, out currentCount);
                    uniqueProducts[uniqueId] = currentCount + product.Quantity;
                }
            }
            var uniqueProductList = uniqueProducts
                .Select(kvp => {
                    string[] uniqueIdSplit = kvp.Key.Split("_");
                    return new Product() {
                            Name = uniqueIdSplit[0],
                            Price = Convert.ToDouble(uniqueIdSplit[1]),
                            Quantity = kvp.Value
                        };
                    }
                )
                .ToList();
            return uniqueProductList;
        }
    }
}
