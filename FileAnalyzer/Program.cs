using System;
using System.IO;
using System.Text;


namespace FileAnalyzer {
    class Program {
        public static void Main(string[] args) {
            var str = new StringBuilder();
            try {
                using var sr = new StreamReader(@"D:\WorkFolder\C#\CsharpUniversityWorks\CsharpUniversityWorks\FileAnalyzer\Big.txt");
                while (!sr.EndOfStream) {
                    string fileStr = sr.ReadLine();
                    str.Append(fileStr);
                }
            }
            catch (FileNotFoundException) {
                Console.WriteLine("File not found!");
            }

            var dictAboutWholeFile = FileAnalyzer.Analyze(str.ToString());
            Console.WriteLine("Info about all words from file:");
            foreach (var pair in dictAboutWholeFile) {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

            Console.WriteLine("Самые часто встречающиеся слова(слово):");
            var dictAboutFrequency = FileAnalyzer.MostFrequentWord(str.ToString());
            foreach (var pair in dictAboutFrequency) {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }

            Console.WriteLine("Введите слово, которое хотите найти:");
            var info = FileAnalyzer.FindWord(str.ToString(), Console.ReadLine());
            Console.WriteLine($"The length of this word is {info[0]}");
        }
    }

    
}
