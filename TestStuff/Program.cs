using System;
using System.Xml;

namespace TestStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            var range = 300;
            int power = 0;
            var t = double.MaxValue;

            for (int i = 0; i < range; i++)
            {
                var value = Math.Pow(2, i);
                double a = Math.Abs(Math.Abs(range) - Math.Abs(value));

                if (a < t)
                {
                    power = i;
                    t = a;
                }
            }

            Console.WriteLine(power);
        }
    }
}