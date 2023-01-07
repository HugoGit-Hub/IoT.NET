using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumidityController : ControllerBase
    {
        [HttpPost]
        public void receivceFrames([FromBody] Dictionary<string, string> data)
        {
            Console.WriteLine(data["data"]);
        }
    }
}
