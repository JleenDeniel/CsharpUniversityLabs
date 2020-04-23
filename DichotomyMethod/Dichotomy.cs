using System;
using System.Collections.Generic;
using System.Text;

namespace DichotomyMethod {

    
    public class Diсhotomy {
        public delegate double Equation(double x);
        public static bool TryFindRoot(double leftBorder, double rightBorder, Equation equation, double accuracy, out double result) {
            Checker(leftBorder, rightBorder, accuracy);
            double newBorder = (leftBorder + rightBorder) / 2;
            while (Math.Abs(equation(newBorder)) > accuracy) {
                
                if(equation(newBorder) == double.Epsilon) {
                    result = newBorder;
                    return true;
                }
                if (equation(leftBorder)*equation(newBorder) < double.Epsilon) {
                    rightBorder = newBorder;
                }
                else if (equation(newBorder)*equation(rightBorder) < double.Epsilon) {
                    leftBorder = newBorder;
                }
                else {
                    result = double.NaN;
                    //Console.WriteLine("либо корней нет либо их больше одного");
                    return false;
                }
                newBorder = (leftBorder + rightBorder) / 2;
            }
            result = newBorder;
            return true;
            
        }

            private static void Checker(double leftBoder, double rightBorder, double accuracy) {
                if (leftBoder > rightBorder) {
                    throw new ArgumentException();
                    //return false;
                }
                if (accuracy > Math.Abs(rightBorder - leftBoder) || accuracy > 1) {
                    throw new ArgumentException();
                    //return false;
                }
            }

            
        }
        public class NoRootException : Exception {
            public NoRootException() { }
            public NoRootException(string message) : base(message) { }
            public NoRootException(string message, Exception inner) : base(message, inner) { }
            protected NoRootException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }



    } 

