using System;


namespace AGM
{
    public static class PreciseCalc
    {
        public delegate double PreciseFunc(double x);

        public static double NegExp(double x) 
        {
            return Math.Exp(-x);
        }

		public static double AbsCos(double x)
		{
			return Math.Abs(Math.Cos(x));
		}

		public static double AbsSin(double x)
		{
			return Math.Abs(Math.Sin(x));
		}

		public static double AGM(double a, double b, int precision = 4)
        {
            while (Math.Abs(a - b) > Math.Pow(10, -(precision)))
            {
                double newA;

                newA = (a + b) / 2;
                b = Math.Sqrt(a * b);

                a = newA;

                // Debug.WriteLine($"a - {a}");
                // Debug.WriteLine($"b - {b}");
            }

            return a;
        }

        public static double MAGM(double a, double b, int precision = 4)
        {
            double c = 0;

            while (Math.Abs(a - b) > Math.Pow(10, -(precision)))
            {
                double newA, newB;

                newA = (a + b) / 2;
                newB = c + Math.Sqrt((a - c) * (b - c));
                c = c - Math.Sqrt((a - c) * (b - c));

                a = newA;
                b = newB;

                // Debug.WriteLine($"a - {a}");
                // Debug.WriteLine($"b - {b}");
            }

            return a;
        }

        public static double SympsonWaveEq(PreciseFunc f, double r, double t, double R)
        {
            if (t < R + r)
            {
                return 0;
            }

            double h = r / 6,
                term1 = (4 * f(r / 2) * (r / 2)) / AGM(Math.Sqrt(Math.Pow(t, 2) - Math.Pow(R - (r / 2), 2)), Math.Sqrt(Math.Pow(t, 2) - Math.Pow(R + (r / 2), 2))),
                term2 = (f(r) * r) / AGM(Math.Sqrt(Math.Pow(t, 2) - Math.Pow(R - r, 2)), Math.Sqrt(Math.Pow(t, 2) - Math.Pow(R + r, 2)));

            return h * (term1 + term2);
        }
    }
}
