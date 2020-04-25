using System;

namespace ComplexAndVector {
    class Program {
        static void Main(string[] args){
            Complex complex = new Complex(2, 1);
            complex.ZeroDivide += ZeroDivide;
            Console.WriteLine(complex / new Complex(0,0));
            Console.WriteLine(Environment.NewLine);
            
            UnitTests.ComplexSum();
            UnitTests.ComplexSubtraction();
            UnitTests.ComplexMultiplication();
            UnitTests.ComplexDivide();
            UnitTests.ComplexPow();
            UnitTests.VectorSum();
            UnitTests.VectorOrthogonolization();
            foreach (var root in Complex.Root(4, 2)) {
                Console.WriteLine(root);
            }
        }
        static void ZeroDivide(object sender, ZeroDivideEventArgs e) {
            Console.WriteLine($"something in division is not ok.  Blame them: {e._dividend} and {e._divider}");
        }
    }
}