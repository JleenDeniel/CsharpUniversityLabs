using System;
using System.Text;

namespace DichotomyMethod {
    class Program {
        static void Main(string[] args) {
            double res = 0;
            // Math.Pow(x, 2) - 1.0 - корень = 2
            //x + 1 - нет корня
            //Math.Sin(100*x) - корней много, поэтому - не число
            try {
                Diсhotomy.TryFindRoot(-3.0, 0, (double x) => Math.Pow(x, 2.0) - 4.0, 0.0001, out res);
                Console.WriteLine(res);
            }
            catch (ArgumentException) {
                Console.WriteLine("Incorrect args");
            }
            
            
        }

       
    }
}