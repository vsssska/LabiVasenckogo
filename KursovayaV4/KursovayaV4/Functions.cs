using System;
using System.Collections.Generic;
using System.IO;
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
        static double[] t3c = { -0.707107, 0, 0.707107 };
        static double[] t4c = { -0.794654, -0.187592, 0.187592, 0.794654 };
        static double[] t5c = { -0.832498, -0.374541, 0, 0.374541, 0.832498 };
        static double[][] tcheb = { t2c, t3c, t4c, t5c };

        //Значчения коэффициентов Аi в квадратурной формуле Чебышева
        static double[] acheb = { 1, 0.666666, 0.5, 0.4 };

        //Метод Чебышева
        private static double chebishev(double a, double b, double eps, int node_index, int func_index)
        {
            int array_node_index = node_index - 2; //Получение индекса для массива исходя из кол-ва узлов
            double s = 0;
            double pastS, va, vb, h, s0;
            int c = 1;
            double x;

            
            do
            {
                va = a;
                h = (b - a) / c;
                vb = va + h;
                pastS = s;
                s = 0;

                while(va < b)
                {
                    s0 = 0;
                    for (int i = 0; i < node_index; i++)
                    {

                        x = (va + vb) / 2 + (vb - va) / 2 * tcheb[array_node_index][i];

                        if (func_index == 0)
                            s0 += first_func(x);
                        if (func_index == 1)
                            s0 += second_func(x);
                        if (func_index == 2)
                            s0 += third_func(x);
                    }

                    s0 *= acheb[array_node_index] * (vb - va) / 2;
                    s += s0;

                    va += h;
                    vb = va + h;
                }

                c++;

            } while(Math.Abs(pastS - s) > eps);


            return s;
        }

        //Метод Гаусса
        private static double gauss(double a, double b, double eps, int node_index, int func_index)
        {
            double s = 0;
            double x;
            double pastS, va, vb, h, s0;
            int c = 1;
            int array_node_index = node_index - 2;

            do
            {
                va = a;
                h = (b - a) / c;
                vb = va + h;
                pastS = s;
                s = 0;

                while (va < b)
                {
                    s0 = 0;
                    for (int i = 0; i < node_index; i++)
                    {

                        x = (va + vb) / 2 + (vb - va) / 2 * tgauss[array_node_index][i];

                        if (func_index == 0)
                            s0 += agauss[array_node_index][i] * first_func(x);
                        if (func_index == 1)
                            s0 += agauss[array_node_index][i] * second_func(x);
                        if (func_index == 2)
                            s0 += agauss[array_node_index][i] * third_func(x);
                    }

                    s0 *= (vb - va) / 2;
                    s += s0;

                    va += h;
                    vb = va + h;
                }
                c++;

            } while (Math.Abs(pastS - s) > eps);

            return s;
        }


        //Функции для графиков
        private static double first_func(double x)
        {
            return Math.Sin(x);
        }

        private static double second_func(double x)
        {
            return Math.Pow(x, 3);
        }

        private static double third_func(double x)
        {
            return Math.Sqrt(x);
        }

        public static double graph_func(double x, int func_flag)
        {
            if (func_flag == 0)
                return first_func(x);
            else if (func_flag == 1)
                return second_func(x);
            else if (func_flag == 2)
                return third_func(x);
            else
                return 0;
        }

        public static double calc_func(double a, double b, double eps, int node_index, int func_index, int method_index)
        {
            if (method_index == 0)
                return chebishev(a, b, eps, node_index, func_index);
            if (method_index == 1)
                return gauss(a, b, eps, node_index, func_index);
            else
                return 0;
        }
    }
}
