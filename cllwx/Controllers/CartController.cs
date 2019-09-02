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
using cllwx.Services;
using Newtonsoft.Json.Linq;

namespace cllwx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        [HttpPost("trolleyTotal")]
        public async Task<IActionResult> GetLowestPossibleTotal([FromBody] JObject trolley)
        {
            var jsonString = JsonConvert.SerializeObject(trolley);
            var cheapestTotal = await (new ResourceGatheringService()).GetCheapestTotal(jsonString);
            return new ObjectResult(cheapestTotal) { StatusCode = 200 };
        }
    }
}