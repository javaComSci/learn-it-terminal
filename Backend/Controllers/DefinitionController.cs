using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using System.Diagnostics;


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

            string convertedText = "";

            // get information from speech recognization engine
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "/Users/indhu/anaconda3/bin/python";
            start.Arguments = "Scripts/SpeechRecognition.py " + trimmedAudio;
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            using(Process process = Process.Start(start)) {
                using(StreamReader reader = process.StandardOutput) {
                    string result = reader.ReadToEnd();
                    if(result.Equals("Cannot understand audio")){
                        convertedText = "";
                    } else {
                        convertedText = result.Substring(result.LastIndexOf(":") + 1);
                        Console.WriteLine("CONVERTED TEXT " + result);
                    }
                }
            }
        }


    }
}
