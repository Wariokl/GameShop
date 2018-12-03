using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestAsp.Controllers
{
    [Produces("application/json")]
    [Route("custom/")]
    public class CustomController : Controller
    {
        [HttpGet]
        public void Method()
        {

        }
    }
}