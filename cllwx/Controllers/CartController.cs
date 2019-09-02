using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using cllwx.Utilities;

namespace cllwx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpGet("trolleyTotal")]
        public IActionResult GetLowestPossibleTotal(ActionExecutedContext context)
        {
            var httpUtil = new HttpReaders();
            string bodyData = httpUtil.ReadBodyAsString(context.HttpContext.Request);
            return Ok(bodyData);
        }
    }
}