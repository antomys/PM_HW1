using System;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text.RegularExpressions;

namespace Level2_2
{
    class Program
    {
        public static double Round(double r)
        {
            //S=pi*r^2
            double result = Math.PI*Math.Pow(r,2);
            return result;
        }
        public static double Square(double a)
        {
            //S=a^2
            double result = Math.Pow(a,2);
            return result;
        }
        public static double Rect(double a, double b)
        {
            //S=ab
            double result = a*b;
            return result;
        }
        public static double Triangle(double a, double b, double c)
        {
            //Heron's Formulae
            double p = (a + b + c) / 2.0;
            double result = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
            return result;
        }
        static int Main(string[] args)
        {
            int[]range = new int[3];
            if (args == null || args.Length == 0)
            {
                try
                {

                    var value = 0;

                    Console.WriteLine("Calculating S of \n" +
                                      "Round,Square,Triangle and Rect.\n" +
                                      "Volokhovych");
                    Console.WriteLine(
                        "NOTE: Input format: [name of figure],[first_paratemer],[second_parameter]\nExamples:\n" +
                        "\"rect,2,5\"\n\"round,5\"\n\"triangle,4,2,6\"\n\"rect,10,12\"\nNOTE:Excessive parameters will be ignored!");
                    var input = Console.ReadLine();
                    string[] tokens = input.Split(',');
                    var j = 0;
                    for (var i = 1; i < tokens.Length; i++, j++)
                    {
                        if (Regex.Matches(tokens[i], @"[a-zA-Z-?`\-+*/{}|.<>]").Count > 0
                            || Int32.TryParse(tokens[i], out value) && value < 0)
                        {
                            throw new ArgumentOutOfRangeException();
                            return -200;
                        }
                        else
                        {
                            range[j] = Int32.Parse(tokens[i]);
                        }

                    }

                    for (j = 0; j < range.Length; j++)
                        if (range[j] <= 0 || range[j] > Int32.MaxValue)
                            throw new IndexOutOfRangeException(($"{range[j]} is too big or small"));

                    var output = Calculate(tokens[0], range);

                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine($"Error in written form");
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine("Something is too big or small");
                }


            }
            else
            {
                int[] input = new int[3];
                var value = 0;
                var j = 0;
                for (int i = 1; i < args.Length; i++,j++)
                {
                    if (Regex.Matches(args[i], @"[a-zA-Z-?`\-+*/{}|.<>]").Count > 0 
                    || Int32.TryParse(args[i],out value) && value < 0 || Int32.TryParse(args[i],out value) && value > Int32.MaxValue)
                    {
                        return -1;
                    }
                    else
                    {
                        input[j] = Int32.Parse(args[i]);
                        if (input[j] <= 0 || input[j] >= Int32.MaxValue)
                            return -1;
                    }
                }
                return (int)Calculate(args[0], input);
            }

            return 0;
        }

        private static double Calculate(string operation, int[] arguments)
        {
            try
            {

                var output = -500.0;
                switch (operation)
                {
                    case "rect":
                        output = Rect(arguments[0], arguments[1]);
                        break;
                    case "round":
                        output = Round(arguments[0]);
                        break;
                    case "square":
                        output = Square(arguments[0]);
                        break;
                    case "triangle":
                        output = Triangle(arguments[0], arguments[1], arguments[2]);
                        if (double.IsNaN(output))
                            throw new Exception();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknown Operation. Try again.");
                        break;
                }

                if (output != -500)
                    Console.WriteLine($"S of your {operation} is {output}");
                return output;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured. No triangle like that!");
                Environment.Exit(1);
            }

            return 0;
        }
    }
}