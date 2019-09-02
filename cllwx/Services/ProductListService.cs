using cllwx.Models;
using cllwx.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace cllwx.Services
{
    public interface IProductListService
    {
        List<Product> BuildProductList(string sortOption);
        List<Product> GetUnsortedProducts();
    }
    public class ProductListService
    {
        public async Task<List<Product>> BuildProductList(string sortOption)
        {
            var resourceGatherer = new ResourceGatheringService();
            var unsortedProductList = await resourceGatherer.GetUnsortedProducts();
            var productListSorter = new ProductListSorter();
            List<Product> sortedProductList = unsortedProductList;
            var triggerSortingFunction = new Dictionary<string, Action>
            {
                { "Low", () =>  sortedProductList = productListSorter.LowToHigh(unsortedProductList) },
                { "High", () => sortedProductList = productListSorter.HighToLow(unsortedProductList) },
                { "Ascending", () => sortedProductList = productListSorter.AlphabeticallyAscending(unsortedProductList) },
                { "Descending", () => sortedProductList = productListSorter.AlphabeticallyDescending(unsortedProductList) },
                { "Recommended", () => sortedProductList = productListSorter.HighestRecommendedFirst(unsortedProductList) },
            };
            triggerSortingFunction[sortOption]();
            return sortedProductList;
        }
    }
}
