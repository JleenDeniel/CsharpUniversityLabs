using System;

namespace  ApproximatingMathConstantsConsoleApp{
    public static class CountExponent {
        public static decimal Count() {
            decimal e = 1 / Factorial(0);
            decimal prevoiusE = 0;
            int n = 1;

            while (Math.Abs(prevoiusE - e) > (decimal)Math.Pow(10, -15)) {
                prevoiusE = e;
                e += 1 / Factorial(n);
                n++;
            }
            return e;
        }

        public static  decimal Factorial(int num) {
            decimal res = 1;
            for(int i = 1; i <= num; i++) {
                res *= i;
            }
            return res;
        }
    }
}