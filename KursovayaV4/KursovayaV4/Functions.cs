using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursovayaV4
{
    internal static class Functions
    {
        //Значения коэффициентов ti в квадратурной формуле Гаусса
        static double[] t2g = { -0.57735027, 0.57735027 };
        static double[] t3g = { -0.77459667, 0, 0.77459667 };
        static double[] t4g = { -0.86113631, -0.33998104, 0.33998104, 0.86113631 };
        static double[] t5g = { -0.90617985, -0.53846931, 0, 0.53846931, 0.90617985 };
        static double[][] tgauss = {t2g, t3g, t4g, t5g};

        //Значчения коэффициентов Аi в квадратурной формуле Гаусса
        static double[] a2 = { 1, 1 };
        static double[] a3 = { 0.5555556, 0.8888888, 0.5555556 };
        static double[] a4 = { 0.34785484, 0.65214516, 0.65214516, 0.34785484 };
        static double[] a5 = { 0.23692688, 0.47862868, 0.568889, 0.47862868, 0.23692688 };
        static double[][] agauss = {a2, a3, a4, a5};

        //Значения коэффициентов ti в квадратурной формуле Чебышева
        static double[] t2c = { -0.577350, 0.577350 };
        static double[] t3c = { -0.707107, 0, -0.707107 };
        static double[] t4c = { -0.794654, -0.187592, 0.187592, 0.794654 };
        static double[] t5c = { -0.832498, -0.374541, 0, 0.374541, 0.832498 };
        static double[][] tcheb = { t2c, t3c, t4c, t5c };

        //Значчения коэффициентов Аi в квадратурной формуле Чебышева
        static double[] acheb = { 1, 0.666666, 0.5, 0.275 };

        //Метод Чебышева
        public static double chebishev(double a, double b, double eps, int n, int func_index)
        {

            double s = 0;
            double x;
            
            for (int i = 0; i < n; i++)
            {

                x = (a + b) / 2 + (b - a) / 2 * tcheb[n][i];

                if(func_index == 0)
                    s += acheb[n] * first_func(x);
                if (func_index == 1)
                    s += acheb[n] * second_func(x);
                if (func_index == 2)
                    s += acheb[n] * third_func(x);
            }

            s *= (b - a) / 2;

            return s;
        }

        //Метод Гаусса
        public static double gauss(double a, double b, double eps, int n, int func_index)
        {
            double s = 0;
            double x;

            for (int i = 0; i < n; i++)
            {
                x = (a + b) / 2 + (b - a) / 2 * tgauss[n][i];
                
                if (func_index == 0)
                    s += agauss[n][i] * first_func(x);
                if (func_index == 1)
                    s += agauss[n][i] * second_func(x);
                if (func_index == 2)
                    s += agauss[n][i] * third_func(x);

            }

            s *= (b - a) / 2;

            return s;
        }
        

        //Функции для графиков
        public static double first_func(double x)
        {
            return Math.Sin(x);
        }

        public static double second_func(double x)
        {
            return Math.Pow(x, 3);
        }

        public static double third_func(double x)
        {
            return Math.Sqrt(x);
        }
    }
}
