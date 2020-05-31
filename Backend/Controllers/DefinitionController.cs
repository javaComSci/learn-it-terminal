using System;
using System.IO;
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

            // modify base 64 encoding
            string audioFile = definitioninfo.definitionaudio;
            string trimmedAudio = audioFile.Substring(audioFile.LastIndexOf(',') + 1);

            // get information from speech recognization engine
            

        }
    }
}
