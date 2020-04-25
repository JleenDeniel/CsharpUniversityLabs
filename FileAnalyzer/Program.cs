using System;
using System.IO;
using System.Text;


namespace FileAnalyzer {
    class Program {
        public static void Main(string[] args){

            //todo читать файл и одновременно писать в словарь (возможно создать класс для этого)
            string path = @"D:\WorkFolder\C#\CsharpUniversityWorks\CsharpUniversityWorks\FileAnalyzer\Small.txt";
            FileAnalyzer analyzer = null;
            try {
                analyzer = new FileAnalyzer(path);
            }
            catch (FileNotFoundException e) {
                Console.WriteLine(e);
                
            }

            if (analyzer != null) {
                analyzer.MostFrequentWord();
                foreach (var pair in analyzer.MostFrequentWord()) {
                    Console.WriteLine($"{pair.Key}, {pair.Value}");
                }
                
            }
        }
    }
}
