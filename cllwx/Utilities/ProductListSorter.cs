using cllwx.Models;
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
        List<Product> HighestRecommendedFirst(List<Product> productList);
    }
    public class ProductListSorter
    {
        public List<Product> LowToHigh(List<Product> unsortedProductList)
        {
            return unsortedProductList
                    .Where(x => x != null)
                    .OrderBy(x => x.price)
                    .ToList();
        }

        public List<Product> HighToLow(List<Product> unsortedProductList)
        {
            return unsortedProductList
                    .Where(x => x != null)
                    .OrderByDescending(x => x.price)
                    .ToList();
        }

        public List<Product> AlphabeticallyAscending(List<Product> unsortedProductList)
        {
            return unsortedProductList
                    .Where(x => x != null)
                    .OrderBy(x => x.name)
                    .ToList();
        }

        public List<Product> AlphabeticallyDescending(List<Product> unsortedProductList)
        {
            return unsortedProductList
                    .Where(x => x != null)
                    .OrderByDescending(x => x.name)
                    .ToList();
        }

        public List<Product> HighestRecommendedFirst(List<Product> unsortedProductList)
        {
            throw new NotImplementedException();

        }
    }
}
