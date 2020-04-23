﻿using System;
using System.Text;

namespace ComplexNumber {
    
        class Complex : ICloneable, IEquatable<Complex> {
        double _real;
        double _imaginary;

        public static readonly double Eps = Math.Pow(10, -10);
        public event EventHandler<ZeroDivideEventArgs> ZeroDivide; 
       
        public Complex():this(0,0) { }

        public Complex(Complex c):this(c._real, c._imaginary) { }

        public Complex(double real, double imaginary) {
            _real = real;
            _imaginary = imaginary;
        }


        public Complex(double module, double cosValue, double sinValue) {
            GetAlgebraicForm(module, cosValue, sinValue);
        }

        public static readonly Complex Zero = new Complex(0, 0);
        public static readonly Complex One = new Complex(1, 0);
        public static readonly Complex Error = new Complex(double.NaN, double.NaN);

        public static implicit operator Complex(double num) => new Complex(num, 0);


        private void GetAlgebraicForm(double module, double cosValue, double sinValue) {
            
            _real = module * cosValue;
            _imaginary = module * sinValue;
            
        }

        public static Complex ComplexConjugate(Complex complex) {
            return Multiply(complex, new Complex(-1, 0));
        }

        public double Module => Math.Pow(Math.Pow(_real, 2) + Math.Pow(_imaginary, 2), 0.5);
        
        

        public static Complex Pow(Complex complexNum, double power) {
            //Complex result = new Complex();
            double cosX = complexNum._real / complexNum.Module;
            double angle = Math.Acos(cosX);
            double resPower = Math.Pow(complexNum.Module, power);
            cosX = Math.Cos(power * angle);
            double sinX = Math.Sin(power * angle);
            return new Complex(Math.Round(resPower,2), Math.Round(cosX,2), Math.Round(sinX,2));
        }

        public static double? Arg(Complex mcomp) {
            if (mcomp._real > double.Epsilon) {
                return Math.Atan(mcomp._imaginary / mcomp._imaginary);
            }
            if (mcomp._real < double.Epsilon && mcomp._imaginary >= double.Epsilon) {
                return Math.PI + Math.Atan(mcomp._imaginary / mcomp._real);
            }
            if (mcomp._real < double.Epsilon && mcomp._imaginary < double.Epsilon) {
                return -Math.PI + Math.Atan(mcomp._imaginary / mcomp._real);
            }
            if (mcomp._real == double.Epsilon && mcomp._imaginary > double.Epsilon) {
                return Math.PI;
            }

            if (mcomp._real == double.Epsilon && mcomp._imaginary < double.Epsilon) {
                return -Math.PI;
            }

            return null;
        }
        //todo возвращать массив значений
        public static Complex[] Sqrt(Complex A, int sqrtPow)
        {
            if (sqrtPow < 0)
            {
                throw new ArgumentException("Корень отрицательной степени", nameof(sqrtPow));
            }
            if (Arg(A) == null)
            {
                throw new ArgumentException("NULL", nameof(sqrtPow));
            }
            var res = new Complex[sqrtPow];
            var complexTmpAbs = new Complex(Math.Pow(A.Module, (1.0 / sqrtPow)), 0.0);
            for (int k = 0; k < sqrtPow; k++)
            {
                var comp = new Complex(Math.Cos(((double)Arg(A) + 2 * Math.PI * k) / sqrtPow),
                                                    Math.Sin(((double)Arg(A) + 2 * Math.PI * k) / sqrtPow));
                res[k] = complexTmpAbs * comp;
                if (Math.Abs(res[k]._real) < double.Epsilon)
                {
                    res[k]._real = 0.0;
                }
                if (Math.Abs(res[k]._imaginary) < double.Epsilon)
                {
                    res[k]._imaginary = 0.0;
                }
            }
            return res;
        }

        public static Complex Add(Complex left, Complex right) {
            Complex result = new Complex();
            result._real = left._real + right._real;
            result._imaginary = left._imaginary + right._imaginary;
            return result;
        }


        public static Complex Substract(Complex left, Complex right) {
            Complex result = new Complex();
            result._real = left._real - right._real;
            result._imaginary = left._imaginary - right._imaginary;
            return result;
        }

        public static Complex Multiply(Complex left, Complex right) {
            Complex result = new Complex();
            result._real = left._real * right._real - left._imaginary * right._imaginary;
            result._imaginary = left._imaginary * right._real + left._real * right._imaginary;
            return result;
        }

       
        public static Complex Divide(Complex dividend, Complex divider) {
            if (Math.Abs(divider._real) < Eps && Math.Abs(divider._imaginary) < Eps) {
                ZeroDivideEventArgs args = new ZeroDivideEventArgs(dividend, divider);
                dividend.OnZeroDivide(args);
                return Error;
            }
            Complex result = new Complex();
            result._real = (dividend._real * divider._real + dividend._imaginary * divider._imaginary) /
                            (Math.Pow(divider._real, 2) + Math.Pow(divider._imaginary, 2));
            result._imaginary = (divider._real * dividend._imaginary - dividend._real * divider._imaginary) /
                               (Math.Pow(divider._real, 2) + Math.Pow(divider._imaginary, 2));
            return result;

        }


        


        protected void OnZeroDivide(ZeroDivideEventArgs e) {
            ZeroDivide?.Invoke(this, e);          
        }


        public static Complex operator +(Complex left, Complex right) {
            return Add(left, right);
        }


        public static Complex operator -(Complex left, Complex right) {
            return Substract(left, right);
        }


        public static Complex operator *(Complex left, Complex right) {
            return Multiply(left, right);
        }

        public static Complex operator /(Complex left, Complex right) {
            return Divide(left, right);
        }

        


        public override string ToString() {
            StringBuilder res = new StringBuilder();
            res.Append("(").Append(Math.Round(_real,2));
            if(_imaginary > 0 ) {
                res.Append(" + ");
                res.Append(Math.Round(_imaginary,2)).Append("i");
            }
            else if(_imaginary < 0) {
                res.Append(Math.Round(_imaginary, 2)).Append("i");
            }
            res.Append(")");
            return res.ToString();
        }

        public object Clone() {
            return new Complex(this._real, this._imaginary);
        }

        public override bool Equals(object obj) {
            if (obj is null)
                return false;
            if (!(obj is Complex c))
                return false;

            return Equals(c);
        }

        public bool Equals(Complex other) {
            if (other is null)
                return false;
            return Math.Abs(_real - other._real) < Eps &&
                   Math.Abs(_imaginary - other._imaginary) < Eps;
                
        }
    }
        class ZeroDivideEventArgs : EventArgs {
            public object _dividend { get; set; }
            public object _divider { get; set; }

            public ZeroDivideEventArgs(object dividend, object divider) {
                _dividend = dividend;
                _divider = divider;
            }
        }
    
}