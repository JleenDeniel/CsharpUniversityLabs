using System;
using System.Collections.Generic;
using System.Text;

namespace ApproximatingMathConstantsConsoleApp {
    public static class CountPi {

        public static decimal CountSum() {
            int n = 1;
            decimal pi = (decimal)(1.0 / Math.Pow(16, 0)) * (decimal)((4.0 / (8.0 * 0 + 1.0)) - (2.0 / (8.0 * 0 + 4.0)) - (1.0 / (8.0 * 0 + 5.0)) - (1.0 / (8.0 * 0 + 6.0)));
            decimal previosValue = 0;
            
            while(Math.Abs(pi - previosValue) > (decimal)Math.Pow(10, -16)) {
                previosValue = pi;

                pi += (decimal)(1.0 / Math.Pow(16, n)) * (decimal)((4.0 / (8.0 * n + 1.0)) - (2.0 / (8.0 * n + 4.0)) - (1.0 / (8.0 * n + 5.0)) - (1.0 / (8.0 * n + 6.0)));

                n++;
            }
            return pi;
        }


    }
}