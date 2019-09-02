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
                {new Product { name = "Test Product D", price = 5.0, quantity = 0.0} },
                {new Product { name = "Test Product C", price = 10.99, quantity = 0.0} },
                {new Product { name = "Test Product A", price = 99.99, quantity = 0.0} },
                {new Product { name = "Test Product B", price = 101.99, quantity = 0.0} },
                {new Product { name = "Test Product F", price = 999999999999.0, quantity = 0.0} }
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
                {new Product { name = "Test Product F", price = 999999999999.0, quantity = 0.0} },
                {new Product { name = "Test Product B", price = 101.99, quantity = 0.0} },
                {new Product { name = "Test Product A", price = 99.99, quantity = 0.0} },
                {new Product { name = "Test Product C", price = 10.99, quantity = 0.0} },
                {new Product { name = "Test Product D", price = 5.0, quantity = 0.0} }
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
                {new Product { name = "Test Product A", price = 99.99, quantity = 0.0} },
                {new Product { name = "Test Product B", price = 101.99, quantity = 0.0} },
                {new Product { name = "Test Product C", price = 10.99, quantity = 0.0} },
                {new Product { name = "Test Product D", price = 5.0, quantity = 0.0} },
                {new Product { name = "Test Product F", price = 999999999999.0, quantity = 0.0} }
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
                {new Product { name = "Test Product F", price = 999999999999.0, quantity = 0.0} },
                {new Product { name = "Test Product D", price = 5.0, quantity = 0.0} },
                {new Product { name = "Test Product C", price = 10.99, quantity = 0.0} },
                {new Product { name = "Test Product B", price = 101.99, quantity = 0.0} },
                {new Product { name = "Test Product A", price = 99.99, quantity = 0.0} }
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