using System;
using System.IO;

namespace learn_it_terminal {
    public class WordAdder {
        public void AddWordsFromFile(string fileName) {
            SQLConnector connector = new SQLConnector();
            var lines = File.ReadLines(fileName);
            foreach(var line in lines) {
                connector.PutWord(line.Trim());
            }
        }
    }
}