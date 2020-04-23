using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SquareMatrix {
    class Matrix: IEnumerable, ICloneable, IComparable<Matrix>, IEnumerable<double> {
        private readonly double[,] _values;

        public Matrix() { }
        public Matrix(double[,] values) {
            _values = values;
        }


        public Matrix(int size) {
            _values = SetValuesAsZero(size);
        }

        public double[,] SetValuesAsZero(int size) {
            double[,] values = new double[size, size];
            for (int i = 0; i < size; i++) {
                for (int j = 0; j < size; j++) {
                    values[i, j] = 0;
                }
            }
            return values;
        }
        public double this[int i, int j] {
            get => _values[i, j];
            set { _values[i, j] = value; }
        }

        public int GetSize() => (_values.GetLength(0));

        private Matrix Minor(int row, int col) {
            Matrix result = new Matrix(GetSize() - 1);
            int currRow = 0, cuurCol = 0;
            for (int i = 0; i < result.GetSize(); i++) {
                for (int j = 0; j < result.GetSize(); j++) {
                    if (i != row && j != col) {
                        result[currRow, cuurCol++] = this[i, j];
                    }

                }
                if (i != row)
                    currRow++;
                cuurCol = 0;
            }
            return result;
        }

        public double Determinant() {
            if (GetSize() == 1) {
                return this[0, 0];
            }
            else if (GetSize() == 2) {
                return this[0, 0] * this[1, 1] - (this[1, 0] * this[0, 1]);
            }
            else {
                double result = 0;
                for (int i = 0; i < GetSize(); i++) {
                    result = result + this[i, 0] * Minor(i, 0).Determinant() * (int)Math.Pow(-1, i);
                }
                return result;
            }
        }

        public static Matrix Transponate(Matrix matrix) {
            Matrix res = new Matrix(matrix.GetSize());
            for (int i = 0; i < matrix._values.GetLength(0); i++) {
                for (int j = 0; j < matrix._values.GetLength(0); j++) {
                    res[j, i] = matrix[i, j];
                }
            }

            return res;
        }

        public Matrix Inverse() {
            double EPS = Math.Pow(10, -10);
            
            if(Math.Abs(Determinant()) < EPS) {
                Matrix result = new Matrix(_values);
                for (int i = 0; i < result.GetSize(); i++) {
                    for (int j = 0; j < result.GetSize(); j++) {
                        //Matrix minor = Minor(i, j);
                        double value = Minor(i, j).Determinant() * (int)Math.Pow(-1, i + j);
                        result[i, j] =  value / Determinant();
                    }
                }
                return Transponate(result);
            }
            return new Matrix();
            //throw new DegenerateMatrixException("Матрица вырожденная, обратной не существует!");
        }

        public static Matrix MatrixPow(Matrix matrix, int power) {
            Matrix result = new Matrix(matrix._values);
            for(int i = 0; i < power; i++) {
                result *= matrix;
            }
            return result;
        }

        public static Matrix Add(Matrix left, Matrix right) {
            if (!CheckSize(left, right)) {
                throw new ArgumentException("Different size of 2 matrix");
            }
            Matrix result = new Matrix(left.GetSize());
            for (int i = 0; i < left.GetSize(); i++) {
                for (int j = 0; j < left.GetSize(); j++) {
                    result[i,j] = left[i, j] + right[i, j];
                }
            }
            return result;
        }

        public static Matrix Substract(Matrix left, Matrix right) {
            if (!CheckSize(left, right)) {
                throw new ArgumentException("Different size of 2 matrix");
            }
            Matrix result = new Matrix(left.GetSize());
            for (int i = 0; i < left.GetSize(); i++) {
                for (int j = 0; j < left.GetSize(); j++) {
                    result[i, j] = left[i, j] - right[i, j];
                }
            }
            return result;
        }

        public static Matrix Multiply(Matrix left, Matrix right) {
            if (!CheckSize(left, right)) {
                throw new ArgumentException("Different size of 2 matrix");
            }
            double sum = 0;
            Matrix result = new Matrix(left.GetSize());
            for (int i = 0; i < left.GetSize(); i++) {
                for (int j = 0; j < left.GetSize(); j++) {
                    sum = 0;
                    for (int k = 0; k < left.GetSize(); k++) {
                        double item = left[i, k] * right[k, j];
                        sum += item;
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }

        public static Matrix Divide(Matrix dividend, Matrix divider) {
            if (!CheckSize(dividend, divider)) {
                throw new ArgumentException("Different size of 2 matrix");
            }
            return Multiply(dividend, divider.Inverse());
        }

        public static Matrix operator +(Matrix left, Matrix right) {
            return Matrix.Add(left, right);
        }

        public static Matrix operator -(Matrix left, Matrix right) {
            return Matrix.Substract(left, right);
        }

        public static Matrix operator *(Matrix left, Matrix right) {
            return Matrix.Multiply(left, right);
        }

        public static Matrix operator /(Matrix dividend, Matrix divider) {
            return Divide(dividend, divider);
        }

        private static bool CheckSize(Matrix left, Matrix right) {
            return left._values.GetLength(0) == right._values.GetLength(0);
        }

        

        public object Clone() {
            return _values.Clone();
        }

        public int CompareTo(Matrix obj) {
            return Determinant().CompareTo(obj.Determinant());
        }

        public override string ToString() {
            StringBuilder result = new StringBuilder();
            int counter = 0;
            foreach (var value in _values) {
                if (counter % _values.GetLength(0) == 0) {
                    result.Append(Environment.NewLine);
                }

                result.Append(value);
                counter++;
            }
            return result.ToString();
        }

        public IEnumerator<double> GetEnumerator() {
            foreach (var value in _values)
                yield
                return value;
        }

          IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
