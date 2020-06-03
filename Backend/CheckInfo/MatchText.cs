using System;
using System.IO;

namespace Backend.TextMatching {
    public class MatchText {

        public string voiceInput { get; set; }
        public string word { get; set; }
        public MatchText(string word, string voiceInput) {
            this.word = word;
            this.voiceInput = voiceInput;
        }

        public string GetDefinition(){
            return null;
        }

        public bool Match() {
            return false;
        }
    }
}