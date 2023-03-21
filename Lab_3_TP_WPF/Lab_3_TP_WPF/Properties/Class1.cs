using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3_TP_WPF.Properties
{
    static internal class Class1
    {
        public static double F1(double x)
        {
            return Math.Log(x);
        }
        public static double F2(double x)
        {
            return Math.Tan(1 / Math.Pow(x, 3));
        }
        public static double F3(double x)
        {
            return Math.Log(Math.Abs(Math.Tan(Math.Pow(2, x))));
        }
        public static double F4(double x)
        {
            //int[] j = new int[1000000];
            double f4 = 0;
            for (int i = 0; i < 1000000; i++)
            {
                //j[i] += 1;
                f4 += (1 / (x + Math.Sqrt(i)));
            }
            return f4;
        }
    }
}
