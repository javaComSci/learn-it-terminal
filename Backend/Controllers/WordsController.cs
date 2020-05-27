using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase {
        // GET api/words
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get() {
            SQLConnector connector = new SQLConnector();
            var words = connector.GetWords();
            if(words.Count == 0){
                Console.WriteLine("No words found");
            } else  {
                Console.WriteLine("Word List:");
            }
            foreach(var word in words){
                Console.WriteLine(word);
            }
            Console.WriteLine("\n");
            return words;
        }

        // PUT api/words
        [HttpPut]
        public void Put([FromBody] string fileName) {
            SQLConnector connector = new SQLConnector();
            var lines = System.IO.File.ReadLines(fileName);
            foreach(var line in lines) {
                connector.PutWord(line.Trim());
            }
        }
    }
}
