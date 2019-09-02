using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using cllwx.Models;
using cllwx.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace cllwx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet("sort")]
        public async Task<IActionResult> GetProductsInSortedOrder()
        {
            if (Request.Query.TryGetValue("sortOption", out StringValues val))
            {
                var sortOption = val.ToString();
                var productListBuilder = new ProductListService();
                var productList = await productListBuilder.BuildProductList(sortOption);
                return new ObjectResult(value: productList);
            } else
            {
                Response.StatusCode = 400;
                return Content("sortOption Query Parameter is required.");
            }
        }
        
}
}