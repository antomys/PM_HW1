using System;

namespace Level1_1
{
    public class level1_1
    {
        private const double birth_year = 2000;
        private const double birth_month = 6;
        private const double birth_day = 12;
        public static void Main()
        {
            Console.WriteLine("Expression counter, Volokhovych Ihor\n");
            Console.WriteLine($"Will be calculated: y = ((e^a+4*lg(c)/sqrt(b))" +
                              "*|arctg(d)|+5/sin(a)");
            Console.WriteLine("Please write an A parameter");
            Double.TryParse(Console.ReadLine(), out double a);

            Console.WriteLine(Count(a, birth_year, birth_month, birth_day));

        }
        private static double Count(double a , double b, double c , double d)
        {
            return (Math.Exp(a) + 4 * Math.Log10(c)) / Math.Sqrt(b)
                * Math.Abs(Math.Atan(d)) + (5 / Math.Sin(a));
        }
    }
}