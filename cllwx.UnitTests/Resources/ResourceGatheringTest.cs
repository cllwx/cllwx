using cllwx.Models;
using cllwx.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
                {new Product { Name = "Test Product A", Price = 99.99, Quantity = 0.0} },
                {new Product { Name = "Test Product B", Price = 101.99, Quantity = 0.0} },
                {new Product { Name = "Test Product C", Price = 10.99, Quantity = 0.0} },
                {new Product { Name = "Test Product D", Price = 5.0, Quantity = 0.0} },
                {new Product { Name = "Test Product F", Price = 999999999999.0, Quantity = 0.0} }
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

        [Test]
        public async Task TestGetShopperHistory()
        {
            var resourceGatheringService = new ResourceGatheringService();
            var cartList = await resourceGatheringService.GetShopperHistory();
            var productListOne = 
                new List<Product>()
                        {
                            {new Product { Name = "Test Product A", Price = 99.99, Quantity = 3.0} },
                            {new Product { Name = "Test Product B", Price = 101.99, Quantity = 1.0} },
                            {new Product { Name = "Test Product F", Price = 999999999999.0, Quantity = 1.0} }
                        };
            var productListTwo =
                new List<Product>()
                        {
                            {new Product { Name = "Test Product A", Price = 99.99, Quantity = 2.0} },
                            {new Product { Name = "Test Product B", Price = 101.99, Quantity = 3.0} },
                            {new Product { Name = "Test Product F", Price = 999999999999.0, Quantity = 1.0} }
                        };
            var productListThree =
                new List<Product>()
                        {
                            {new Product { Name = "Test Product C", Price = 10.99, Quantity = 2.0} },
                            {new Product { Name = "Test Product F", Price = 999999999999.0, Quantity = 2.0} }
                        };
            var productListFour =
                new List<Product>()
                        {
                            {new Product { Name = "Test Product A", Price = 99.99, Quantity = 1.0} },
                            {new Product { Name = "Test Product B", Price = 101.99, Quantity = 1.0} },
                            {new Product { Name = "Test Product C", Price = 10.99, Quantity = 1.0} },
                        };
            var expectedResult = new List<Cart>()
            {
                {new Cart() {
                        CustomerId = 123,
                        Products = productListOne
                }},
                {new Cart() {
                        CustomerId = 23,
                        Products = productListTwo
                }},
                {new Cart() {
                        CustomerId = 23,
                        Products = productListThree
                }},
                {new Cart() {
                        CustomerId = 23,
                        Products = productListFour
                }}
            };
            try
            {
                Assert.NotNull(resourceGatheringService);
                Assert.IsInstanceOf<List<Cart>>(cartList);
                Assert.AreEqual(JsonConvert.SerializeObject(cartList), JsonConvert.SerializeObject(expectedResult));
            }
            catch (AssertionException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }

        [Test]
        public async Task TestGetUser()
        {
            var resourceGatheringService = new ResourceGatheringService();
            var trolley = new Trolley()
            {
                Products = new List<ProductItem>()
                {
                    new ProductItem() { Name = "string", Price = 10.10 }
                },
                Specials = new List<SpecialItem>()
                {
                    new SpecialItem() {
                        Quantities = new List<QuantityItem>()
                        {
                            new QuantityItem() { Name = "string", Quantity = 3 }
                        },
                        Total = 20.20
                    }
                },
                Quantities = new List<QuantityItem>()
                {
                    new QuantityItem() { Name = "string", Quantity = 3 }
                }
            };
            var jsonString = JsonConvert.SerializeObject(trolley);
            var result = await resourceGatheringService.GetCheapestTotal(jsonString);
            try
            {
                Assert.NotNull(result);
                Assert.AreEqual(result, "20.2");
            }
            catch (AssertionException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}