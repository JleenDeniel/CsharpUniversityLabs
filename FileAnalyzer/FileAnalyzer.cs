using System;
using System.Collections.Generic;
using System.Text.Json;

namespace FileAnalyzer {
    public static class FileAnalyzer {
        public static void Analyze(string input) {
            var dict = CountWords(Replacer(input));
            var jsonString = JsonSerializer.Serialize(dict);
            
            Console.WriteLine(jsonString);
        }

        private static Dictionary<string, int> CountWords(string input) {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string[] wordsArray = input.Split(" ");
            foreach (var word in wordsArray) {
                if (!dict.ContainsKey(word)) {
                    dict.Add(word, 1);
                }
                else {
                    dict[word]++;
                }

            }
            return dict;
        }

        private static string Replacer(string input) {
            input.Replace(",", string.Empty).Replace(".", string.Empty).Replace("/t", string.Empty);
            return input;
        }

        
    }
}
