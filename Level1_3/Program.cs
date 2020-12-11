using System;

namespace Level1_3
{
    class Program
    {
        private const double eplison = 1.0 / 2000;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Calculate();
        }

        private static void Calculate()
        {
            Console.WriteLine("Calculating number series, Volokhovych");
            Console.WriteLine($"Will be calculated:\n Sum from i=1 to infinity of 1/i*(i+1)\n Accuracy epsilon {eplison}");
            var result = 0.0;
            for (var i = 1; i < Single.PositiveInfinity; i++)
            {
                var element = 1.0 / (i * (i + 1.0));
                if(element>eplison)
                    result += element;
                else
                    break;
            }

            Console.WriteLine($"Result is : {result}");
        }
    }
}