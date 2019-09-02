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
using cllwx.Models;
using Newtonsoft.Json;

namespace cllwx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpPost("trolleyTotal")]
        public IActionResult GetLowestPossibleTotal([FromBody] Trolley trolley)
        {
            //var httpUtil = new HttpReaders();
            //string bodyData = httpUtil.ReadBodyAsString(context.HttpContext.Request);
            var jsonObj = JsonConvert.SerializeObject(trolley);
            return new ObjectResult(jsonObj) { StatusCode = 200 };
        }
    }
}