using cllwx.Controllers;
using cllwx.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ProductsControllerTest
    {
        [Test]
        public void TestGetProductList()
        {
            //var productsController = new ProductsController()
            //{
            //    ControllerContext = new ControllerContext
            //    {
            //        HttpContext = new DefaultHttpContext()
            //    }
            //};
            //(productsController.HttpContext.Request as DefaultHttpRequest).QueryString = new QueryString("?sortOption=Low");
            //var actionResult = productsController.GetProductsInSortedOrder() as ObjectResult;
            //try
            //{
            //    Assert.NotNull(actionResult);
            //    Assert.True(actionResult is ObjectResult);
            //    Assert.IsInstanceOf<List<Product>>(actionResult.Value);
            //    Assert.AreEqual(StatusCodes.Status200OK, actionResult.StatusCode);
            //}
            //catch (AssertionException e)
            //{
            //    System.Diagnostics.Debug.WriteLine(e);
            //}
        }
    }
}