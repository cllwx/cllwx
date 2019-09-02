using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cllwx.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cllwx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpGet("user")]
        public IActionResult Get()
        {
            return new ObjectResult(new User { name = "Christopher Lyndon", token = "95ff5f68-f734-4a72-8e81-d2f8c8e983b5" }) { StatusCode = 200 };
        }  
    }
}