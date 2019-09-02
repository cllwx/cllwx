using cllwx.Controllers;
using cllwx.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tests
{
    public class CartControllerTest
    {
        [Test]
        public async Task TestGetUser()
        {
            var cartController = new CartController();
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
            var actionResult = await cartController.GetLowestPossibleTotal(JObject.FromObject(trolley)) as ObjectResult;
            try
            {
                Assert.NotNull(actionResult);
                Assert.True(actionResult is ObjectResult);
                Assert.AreEqual(StatusCodes.Status200OK, actionResult.StatusCode);
                Assert.AreEqual(actionResult.Value, "20.2");
            }
            catch (AssertionException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}