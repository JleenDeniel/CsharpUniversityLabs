﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileAnalyzer {
    public class FileAnalyzer {
        private readonly Dictionary<string, int> _textDictionary = new Dictionary<string, int>();
        
        public FileAnalyzer(){ }

        public FileAnalyzer(string path){
            _textDictionary = FileParser(path);
        }

        private Dictionary<string, int> FileParser(string path){
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            
            using (var reader = new StreamReader(path)) {
                while (!reader.EndOfStream) {
                    string[] line = reader.ReadLine()?.Split(new[] {' ', '\t', ',', '.'}, StringSplitOptions.RemoveEmptyEntries);
                    if (line != null) {
                        foreach (var word in line) { 
                            string updWord = word.Trim(new[] {',', '.', '?', '!'});
                            if (dictionary.ContainsKey(updWord)) {
                                dictionary[updWord]++;
                            }
                            else {
                                dictionary.Add(updWord, 1);
                            }
                        }
                    }
                }
            }

            return dictionary;
        }

        public Dictionary<string, int> GetDictionary => _textDictionary;
        
        public  Dictionary<string, int> MostFrequentWord(){
            var resultDict = new Dictionary<string, int>();
            var maxValue = _textDictionary.Values.Max();
            foreach (var pair in _textDictionary) {
                if (pair.Value == maxValue) {
                    resultDict[pair.Key] = maxValue;
                }
            }

            return resultDict;
        }
        
        public  Tuple<string, int> FindWord(string wordToFind){
            if(!_textDictionary.ContainsKey(wordToFind)) { 
                throw new ArgumentException("No such word");
            }
            else {
                //todo вернуть кортеж
                return Tuple.Create(wordToFind, _textDictionary[wordToFind]);
            }
        }
        
        //todo поменять логику: сначала парсить а потом джоинить
        // UPD этого метода больше нет 

        
    }
}
