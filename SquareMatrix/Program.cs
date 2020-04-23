using System;

namespace SquareMatrix {
    static class Program {
        static void Main(string[] args){
            Console.WriteLine("Set the size of matrix:");
            int size = int.Parse(Console.ReadLine());
            Matrix matrix = new Matrix(size);
            Console.WriteLine("Set elements:");
            for (int i = 0; i < size; i++) {
                Console.Write($"Row number {i + 1}, ");
                for (int j = 0; j < size; j++) {
                    Console.WriteLine($"column number {j + 1}:");
                    matrix[i, j] = double.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Определитель:");
            Console.WriteLine(matrix.Determinant());
            Console.WriteLine("Обратная матрица");
            Console.WriteLine(matrix.Inverse());
        }
    }
}