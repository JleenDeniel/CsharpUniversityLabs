using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchNumberSystemConsoleApp {
    public static class Switcher {
        public static string ConvertToBase(double num, int system) {  
            if(system == 10) {
                return num.ToString();
            }
            var @int = Math.Truncate(num);
            var @double = num - @int;
            
            var res_int = AppliedConverter(int.Parse(@int.ToString()), system);
            if(Math.Abs(num) < 1) {
                res_int = "0";
            }
            var res_float = ConvertFloatPart( Math.Round(@double, 14) , system);
            

            return new StringBuilder(res_int).Append(',').Append(res_float).ToString();
        }

        private static string AppliedConverter(int n, int p) {
            bool flag = n < 0;
            n = Math.Abs(n);
            var result = new StringBuilder();
            for (; n > 0; n /= p) {
                var x = n % p;
                result.Insert(0, (char)(x < 0 || x > 9 ? x + 'A' - 10 : x + '0')).ToString();
            }

            return (flag ? result.Insert(0, '-') : result).ToString();
        }
        //работаю отдельно с целой и с дробной частью каждый раз, потому что сравнивать дробные части - неправильно
        private static string ConvertFloatPart(double number, int system) {
            
            StringBuilder result = new StringBuilder();
            
            int tmp;
            List<int> ints = new List<int>();
            List<int> floats = new List<int>();
            for(int i = 0; i < 10; i++) {
                number *= system;
                number = Math.Round(number, 4);
                string[] temporary = number.ToString().Split(new char[] {',', '.'});
                

                //если длина массива = 1, значит число получилось целое
                if (temporary.Length == 1) {
                    ints.Add(int.Parse(temporary[0]));
                    foreach (var ch in ints) {
                        if (ch == 0) {
                            result.Append("0");
                        }
                        else {
                            result.Append(AppliedConverter(ch, system));
                        }
                    }
                    return result.ToString();
                }

                tmp = int.Parse(temporary[1]);
                if (floats.Contains(tmp)) {
                    for(int j = 0; j < ints.Count; j++) {
                        if(tmp == floats[j]) {
                            result.Append("(");
                        }
                        result.Append(AppliedConverter(ints[j], system));
                    }
                    result.Append(")");
                    return result.ToString();

                }
                ints.Add(int.Parse(temporary[0]));
                floats.Add(tmp);
                number = double.Parse(string.Concat("0,", temporary[1]));


            }
            foreach (var ch in ints) {
                result.Append(AppliedConverter(ch, system));
            }
            return result.ToString();
        }

    }
}
