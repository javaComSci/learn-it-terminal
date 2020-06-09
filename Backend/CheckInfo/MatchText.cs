using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;

namespace Backend.TextMatching {
    public class MatchText {

        public string voiceInput { get; set; }
        public string word { get; set; }
        public Dictionary<String, String>  wordDictionary { get; set; }
        public MatchText(string word, string voiceInput) {
            this.word = word;
            this.voiceInput = voiceInput;
            string text = File.ReadAllText("./Dictionary/dictionary_cleaned.txt");
            wordDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
        }

        public void PrintDictionary() {
            Console.WriteLine("DICTIONARY");
            Console.WriteLine(wordDictionary);
            foreach(string key in wordDictionary.Keys){

                Console.WriteLine(key + ":" + wordDictionary[key]);
            }
        }

        public void PrintDefinitions(List<string> definitions){
            Console.WriteLine("WORD: " + word);
            foreach(string definition in definitions){
                Console.WriteLine(definition);
            }
        }

        public List<string> GetDefinition(){
            Console.WriteLine(wordDictionary.ContainsKey(word));
            if(wordDictionary.ContainsKey(word)) {
                string definitions = wordDictionary[word];
                List<string> allDefinitions = definitions.Split(";").ToList();
                for(int i = 0; i < allDefinitions.Count; i++){
                    allDefinitions[i] = allDefinitions[i].Trim();
                }
                return allDefinitions;
            }
            return null;
        }

        public bool Match() {
            List<string> definitions = this.GetDefinition();
            PrintDefinitions(definitions);
            return false;
        }
    }
}