using System;


namespace ApproximatingMathConstantsConsoleApp {
    public static class CountLn2 {
        public static decimal Count() {
            decimal previousLn2 = (decimal)(1.0/2.0) ; 
            decimal ln2 = (decimal)(1.0/12.0) + previousLn2;
            int i = 2;
            while (Math.Abs(ln2 - previousLn2) > (decimal)Math.Pow(10, -15)) {
                previousLn2 = ln2;
                ln2 += (decimal)(1.0 / ((2.0 * i + 1.0) * (2.0 * i + 2.0)));
                i++;
            }
            return ln2;
        }
    }
}