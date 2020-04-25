using System;
using System.IO;


namespace FileAnalyzer {
    class Program {
        public static void Main(string[] args){

            //todo читать файл и одновременно писать в словарь (возможно создать класс для этого)
            string path = @"D:\WorkFolder\C#\CsharpUniversityWorks\CsharpUniversityWorks\FileAnalyzer\Empty.txt";
            FileAnalyzer analyzer = null;
            try {
                analyzer = new FileAnalyzer(path);
            }
            catch (FileNotFoundException e) {
                Console.WriteLine(e);
                
            }

            try {
                if (analyzer != null) {
                    analyzer.MostFrequentWord();
                    foreach (var pair in analyzer.MostFrequentWord()) {
                        Console.WriteLine($"{pair.Key}, {pair.Value}");
                    }

                }
            }
            catch (FileWithoutWordsException e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
