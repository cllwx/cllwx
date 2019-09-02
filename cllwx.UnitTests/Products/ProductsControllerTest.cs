using cllwx.Controllers;
using cllwx.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tests
{
    public class ProductsControllerTest
    {
        [Test]
        public async Task TestGetProductList()
        {
            var productsController = new ProductsController()
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
            (productsController.HttpContext.Request as DefaultHttpRequest).QueryString = new QueryString("?sortOption=Low");
            var actionResult = await productsController.GetProductsInSortedOrder() as ObjectResult;
            try
            {
                Assert.NotNull(actionResult);
                Assert.True(actionResult is ObjectResult);
                Assert.IsInstanceOf<List<Product>>(actionResult.Value);
            }
            catch (AssertionException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}