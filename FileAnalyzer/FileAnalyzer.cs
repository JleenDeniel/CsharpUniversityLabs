using System;
using System.Collections.Generic;
using  System.Linq;


namespace FileAnalyzer {
    public static class FileAnalyzer {
        public static Dictionary<string, int> Analyze(string input) {
            var dict = new Dictionary<string, int>(CountWords(Replacer(input)));
            return dict;
        }

        
        public static Dictionary<string, int> MostFrequentWord(Dictionary<string, int> dictionary){
            var resultDict = new Dictionary<string, int>();
            var maxValue = dictionary.Values.Max();
            foreach (var pair in dictionary) {
                if (pair.Value == maxValue) {
                    resultDict[pair.Key] = maxValue;
                }
            }

            return resultDict;
        }

        public static Dictionary<string, int> MostFrequentWord(string input){
            var res = Analyze(Replacer(input));
            return MostFrequentWord(res);
        }

            private static Dictionary<string, int> CountWords(string input) {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string[] wordsArray = input.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in wordsArray) {
                if (!dict.ContainsKey(word.ToLower())) {
                    dict.Add(word.ToLower(), 1);
                }
                else {
                    dict[word.ToLower()]++;
                }

            }
            return dict;
        }

        public static string[] FindWord(string text, string wordToFind){ 
            var dict = Analyze(text); 
            if (!dict.ContainsKey(wordToFind)) { 
                throw new ArgumentException("No such word");
            } 
            string[] res = new string[1]; 
            res[0] = wordToFind.Length.ToString();
            return res;
        }

        private static string Replacer(string input) {
            string res = input.Replace(",", string.Empty).Replace(".", string.Empty).Replace("/t", string.Empty)
                .Replace("!",string.Empty).Replace("?", string.Empty);
            return res;
        }

        
    }
}
