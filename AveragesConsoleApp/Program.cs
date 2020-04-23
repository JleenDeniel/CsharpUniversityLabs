using System;

namespace AveragesConsoleApp {
    class Program {
        static void Main(string[] args) {
            double a = AverageAlgebraic.CountMedian();
            Console.WriteLine(a);
            double b = AverageGeometric.CountMedianGeometric();            
            Console.WriteLine(b);
        }
        public static class AverageAlgebraic {

            public static double CountMedian() {
                Console.WriteLine("Type symbols:");
                string[] stringArray = Console.ReadLine().Replace(".", ",").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach(var st in stringArray) {
                    if(st.Length != 1) {
                        Console.WriteLine("incorrect input");
                        Environment.Exit(-1);
                    }
                }
                double res = 0;
                int counter = 0;

                foreach (string st in stringArray) {
                    if (double.TryParse(st, out double b)) {
                        res += b;
                        
                    }
                    else {
                        foreach (char ch in st) {
                            res += ch;
                        }
                    }
                    counter++;
                    
                }           
                return Math.Round(res /= counter, 3);
            }
        }

        class AverageGeometric {
            public static double CountMedianGeometric() {
                Console.WriteLine("Type symbols:");
                string[] splitedStr = Console.ReadLine().Replace(".", ",").Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);


                double resutGeomet = 1;
                int counter = 0;
                foreach (string item in splitedStr) {
                    if(item == string.Empty) {
                        return resutGeomet = 0;
                    }
                   
                   if (double.TryParse(item, out double number)) {
                        resutGeomet *= number;
                        counter++;
                   }
                   else {
                        Console.WriteLine("там есть кака, не буду это считать");
                        System.Environment.Exit(2);
                            
                        }
                    }
                return Math.Round(Math.Pow(resutGeomet, 1.0 / counter), 3);
            }  
        }
    }
}
