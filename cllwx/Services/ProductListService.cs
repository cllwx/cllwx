using cllwx.Models;
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
            return await resourceGatherer.GetUnsortedProducts();
        }
    }
}
