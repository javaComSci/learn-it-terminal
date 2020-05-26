using System;
using System.IO;
using System.Collections.Generic;

namespace learn_it_terminal {
    public class WordViewer {
        public void ViewWords() {
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
        }
    }
}