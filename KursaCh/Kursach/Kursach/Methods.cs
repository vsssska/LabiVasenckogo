using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kursach
{
    static internal class Methods
    {
        //Metod Chebusheva 
        public static double Chebushev(double a, double b, int n, Func<double, double> f)
        {
            double[] x = new double[n];
            for (int k = 0; k < n; k++)
            {
                x[k] = 0.5 * (a + b) + 0.5 * (b - a) * Math.Cos((2 * k + 1) * Math.PI / (2 * n));
            }

            double sum = 0;
            for (int k = 0; k < n; k++)
            {
                sum += f(x[k]);
            }

            return (b - a) / n * sum;
        }

        //Metod Gaussa
        public static double Gauss(double a, double b, int n, Func<double, double> f)
        {
            double[] x = new double[n];
            double[] w = new double[n];

            // Вычисляем нули многочлена Лежандра трансформацией Якоби
            for (int i = 0; i < n; i++)
            {
                double z = Math.Cos(Math.PI * (i + 1) / (n + 1));
                double p = 0;
                double dp = 1;

                for (int j = 0; j < n; j++)
                {
                    double dj = 2 * (j + 1) - 1;
                    double pj = ((j == 0 ? 1 : z) * dp - j * p) / dj;
                    p = dp;
                    dp = pj;
                }

                x[i] = z;
                w[i] = 2 / ((1 - z * z) * dp * dp);
            }

            double sum = 0;
            for (int i = 0; i < n; i++)
            {
                sum += w[i] * f(0.5 * (b - a) * x[i] + 0.5 * (a + b));
            }

            return 0.5 * (b - a) * sum;
        }
    }
}
