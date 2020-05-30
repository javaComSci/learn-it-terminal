using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefinitionController : ControllerBase {
        // PUT api/definition
        [HttpPut]
        public void Put([FromBody] DefinitionInfo definitioninfo) {
           Console.WriteLine("RECIEVED AUDIO");
        }
    }
}
