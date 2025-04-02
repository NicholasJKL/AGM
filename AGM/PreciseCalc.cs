using System;
using System.Diagnostics;

namespace AGM
{
    public static class PreciseCalc
    {
        public static double AGM(double a, double b, int precision = 8)
        {
            while (Math.Abs(a - b) > Math.Pow(10, -(precision)))
            {
                double temp = a;

                temp = (a + b) / 2;
                b = Math.Sqrt(a * b);
                a = temp;

                // Debug.WriteLine($"a - {a}");
                // Debug.WriteLine($"b - {b}");
            }

            return a;
        }

        public static double MAGM(double a, double b, int precision = 4) // Переделать
        {
            double c = 0;

            while (Math.Abs(a - b) > Math.Pow(10, -(precision)))
            {
                a = (a + b) / 2;
                b = c + Math.Sqrt((a - c) * (b - c));
                c = c - Math.Sqrt((a - c) * (b - c));

                // Debug.WriteLine($"a - {a}");
                // Debug.WriteLine($"b - {b}");
            }

            return a;
        }

        public static double SympsonWaveEq(double r, double t, double R)
        {
            if (t < R + r)
            {
                return 0;
            }

            double h = r / 6,
                term1 = (4 * Math.Exp(-r / 2) * (r / 2)) / AGM(Math.Sqrt(Math.Pow(t, 2) - Math.Pow(R - (r / 2), 2)), Math.Sqrt(Math.Pow(t, 2) - Math.Pow(R + (r / 2), 2))),
                term2 = (Math.Exp(-r) * r) / AGM(Math.Sqrt(Math.Pow(t, 2) - Math.Pow(R - r, 2)), Math.Sqrt(Math.Pow(t, 2) - Math.Pow(R + r, 2)));

            Debug.Print($"term1 = {term1}");
            Debug.Print($"term2 = {term2}");

            return h * (term1 + term2);
        }

        public static double ExpWaveEq(double r)
        {
            double res = -((r - Math.Exp(r) + 1) / (Math.Exp(r)));

            return res;
        }
    }
}
