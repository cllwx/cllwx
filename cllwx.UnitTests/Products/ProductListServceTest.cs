using cllwx.Models;
using cllwx.Services;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    public class ProductListServiceTest
    {
        [Test]
        public async Task BuildSortedProductListLowToHighTest()
        {
            var productListService = new ProductListService();
            var productList = await productListService.BuildProductList("Low");
            var expectedResult = new List<Product>()
            {
                {new Product { Name = "Test Product D", Price = 5.0, Quantity = 0.0} },
                {new Product { Name = "Test Product C", Price = 10.99, Quantity = 0.0} },
                {new Product { Name = "Test Product A", Price = 99.99, Quantity = 0.0} },
                {new Product { Name = "Test Product B", Price = 101.99, Quantity = 0.0} },
                {new Product { Name = "Test Product F", Price = 999999999999.0, Quantity = 0.0} }
            };
            try
            {
                Assert.NotNull(productListService);
                Assert.IsInstanceOf<List<Product>>(productList);
                Assert.AreEqual(JsonConvert.SerializeObject(productList), JsonConvert.SerializeObject(expectedResult));
            }
            catch (AssertionException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        [Test]
        public async Task BuildSortedProductListHighToLowTest()
        {
            var productListService = new ProductListService();
            var productList = await productListService.BuildProductList("High");
            var expectedResult = new List<Product>()
            {
                {new Product { Name = "Test Product F", Price = 999999999999.0, Quantity = 0.0} },
                {new Product { Name = "Test Product B", Price = 101.99, Quantity = 0.0} },
                {new Product { Name = "Test Product A", Price = 99.99, Quantity = 0.0} },
                {new Product { Name = "Test Product C", Price = 10.99, Quantity = 0.0} },
                {new Product { Name = "Test Product D", Price = 5.0, Quantity = 0.0} }
            };
            try
            {
                Assert.NotNull(productListService);
                Assert.IsInstanceOf<List<Product>>(productList);
                Assert.AreEqual(JsonConvert.SerializeObject(productList), JsonConvert.SerializeObject(expectedResult));
            }
            catch (AssertionException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        [Test]
        public async Task BuildSortedProductListAToZTest()
        {
            var productListService = new ProductListService();
            var productList = await productListService.BuildProductList("Ascending");
            var expectedResult = new List<Product>()
            {
                {new Product { Name = "Test Product A", Price = 99.99, Quantity = 0.0} },
                {new Product { Name = "Test Product B", Price = 101.99, Quantity = 0.0} },
                {new Product { Name = "Test Product C", Price = 10.99, Quantity = 0.0} },
                {new Product { Name = "Test Product D", Price = 5.0, Quantity = 0.0} },
                {new Product { Name = "Test Product F", Price = 999999999999.0, Quantity = 0.0} }
            };
            try
            {
                Assert.NotNull(productListService);
                Assert.IsInstanceOf<List<Product>>(productList);
                Assert.AreEqual(JsonConvert.SerializeObject(productList), JsonConvert.SerializeObject(expectedResult));
            }
            catch (AssertionException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        [Test]
        public async Task BuildSortedProductListZToATest()
        {
            var productListService = new ProductListService();
            var productList = await productListService.BuildProductList("Descending");
            var expectedResult = new List<Product>()
            {
                {new Product { Name = "Test Product F", Price = 999999999999.0, Quantity = 0.0} },
                {new Product { Name = "Test Product D", Price = 5.0, Quantity = 0.0} },
                {new Product { Name = "Test Product C", Price = 10.99, Quantity = 0.0} },
                {new Product { Name = "Test Product B", Price = 101.99, Quantity = 0.0} },
                {new Product { Name = "Test Product A", Price = 99.99, Quantity = 0.0} }
            };
            try
            {
                Assert.NotNull(productListService);
                Assert.IsInstanceOf<List<Product>>(productList);
                Assert.AreEqual(JsonConvert.SerializeObject(productList), JsonConvert.SerializeObject(expectedResult));
            }
            catch (AssertionException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        [Test]
        public async Task BuildSortedProductListRecommendedTest()
        {
            var productListService = new ProductListService();
            var productList = await productListService.BuildProductList("Recommended");
            var expectedResult = new List<Product>()
            {
                {new Product { Name = "Test Product A", Price = 99.99, Quantity = 6.0} },
                {new Product { Name = "Test Product B", Price = 101.99, Quantity = 5.0} },
                {new Product { Name = "Test Product F", Price = 999999999999.0, Quantity = 4.0} },
                {new Product { Name = "Test Product C", Price = 10.99, Quantity = 3.0} }
            };
            try
            {
                Assert.NotNull(productListService);
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