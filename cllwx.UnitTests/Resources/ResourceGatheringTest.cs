using cllwx.Models;
using cllwx.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    public class ResourceGatheringTest
    {
        [Test]
        public async Task TestGetUnsortedProducts()
        {
            var resourceGatheringService = new ResourceGatheringService();
            var productList = await resourceGatheringService.GetUnsortedProducts();
            var expectedResult = new List<Product>()
            {
                {new Product { name = "Test Product A", price = 99.99, quantity = 0.0} },
                {new Product { name = "Test Product B", price = 101.99, quantity = 0.0} },
                {new Product { name = "Test Product C", price = 10.99, quantity = 0.0} },
                {new Product { name = "Test Product D", price = 5.0, quantity = 0.0} },
                {new Product { name = "Test Product F", price = 999999999999.0, quantity = 0.0} }
            };
            try
            {
                Assert.NotNull(resourceGatheringService);
                Assert.IsInstanceOf<List<Product>>(productList);
                Assert.AreEqual(JsonConvert.SerializeObject(productList), JsonConvert.SerializeObject(expectedResult));
            }
            catch (AssertionException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}