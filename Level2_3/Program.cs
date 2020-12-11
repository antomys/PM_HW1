using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Level2_3
{
    class Program
    {
        static int Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Please enter length of array");
                var length = 0;
                Console.WriteLine("Enter elements (Ints only)\n Example of correct input: 5 2 4 3 2\nInput: ");
                Int32.TryParse(Console.In.ReadLine(), out length);
                var input = Console.ReadLine();
                try
                {
                    if (string.IsNullOrEmpty(input))
                    {
                        throw new InvalidDataException();
                    }
                }
                catch (InvalidDataException exception)
                {
                    Console.WriteLine($"Invalid Data {input}");
                    return 1;
                }
                catch (FormatException exception)
                {
                    Console.WriteLine($"Invalid Data {input}");
                    return 1;
                }
                
                string[] tokens = input.Split(' ');
                int[] range = new int[tokens.Length];
                if (tokens.Length > length)
                {
                    Console.WriteLine("Index out of bounds");
                    return 1;
                } 
                for (var i = 0; i < tokens.Length; i++)
                {
                    try
                    {
                        if (Regex.Matches(tokens[i], @"[a-zA-Z]").Count > 0 ||
                               Int32.TryParse(tokens[i], out int result) && result > Int32.MaxValue)
                        {
                            throw new IndexOutOfRangeException();
                        }
                    }
                    catch (IndexOutOfRangeException exception)
                    {
                        Console.WriteLine($"Index {tokens[i]} was out of range or invalid.");
                        return 1;
                    }
                    try
                    {
                        range = Array.ConvertAll(tokens, int.Parse);

                    }
                    catch(Exception exception)
                    {
                        Console.WriteLine("Too large or small number occured in array!");
                        return 1;
                    }

                }
                
                Calculate(range);

            }
            else
            {
                int[] range = new int[args.Length];
                try
                {
                    for (var i = 0; i < args.Length; i++)
                        if (Regex.Matches(args[i], @"[a-zA-Z]").Count > 0 ||
                            Int32.TryParse(args[i], out int result) && result > Int32.MaxValue)
                        {
                            throw new IndexOutOfRangeException();
                        }
                    range = Array.ConvertAll(args, int.Parse);
                    Calculate(range);
                    
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Error occured");
                }
            }

            return 0;
        }

        private static void Calculate(int[] sortedarray)
        {
            sortedarray = ArraySort(sortedarray);
            Console.WriteLine( $"Minimal: {MinValue(sortedarray)}");
            Console.WriteLine( $"Maximal: {MaxValue(sortedarray)}");
            Console.WriteLine( $"Average: {Average(sortedarray)}");
            Console.WriteLine( $"Sum of Elements: {SumElement(sortedarray)}");
            Console.WriteLine( $"Standart Deviation: {StDer(sortedarray)}");
            Console.WriteLine($"Sorted array:");
            foreach (var VARIABLE in sortedarray)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        private static int[] ArraySort(int[] unsortedarray)
        {
            int[] sortedarray = unsortedarray;
            int temp;
            for (int i = 0; i < sortedarray.Length - 1; i++)
            for (int j = i + 1; j < sortedarray.Length; j++)
                if (sortedarray[i] < sortedarray[j])
                {

                    temp = sortedarray[i];
                    sortedarray[i] = sortedarray[j];
                    sortedarray[j] = temp;
                }

            return sortedarray;
        }

        private static int MinValue(int[] sortedarray)
        {
            int temp = sortedarray[0];
            for (int i = 0; i < sortedarray.Length - 1; i++)
            for (int j = i + 1; j < sortedarray.Length; j++)
                if (sortedarray[i] > sortedarray[j])
                {
                    temp = sortedarray[i];
                }

            return temp;
        }
        
        private static int MaxValue(int[] sortedarray)
        {
            int temp = sortedarray[0];
            for (int i = 0; i < sortedarray.Length - 1; i++)
            for (int j = i + 1; j < sortedarray.Length; j++)
                if (sortedarray[i] < sortedarray[j])
                {
                    temp = sortedarray[i];
                }

            return temp;
        }
        
        private static int SumElement(int[] sortedarray)
        {
            int temp = 0;
            for (int i = 0; i < sortedarray.Length; i++)
                temp += sortedarray[i];

            return temp;
        }
        
        private static double Average(int[] sortedarray)
        {
            double output = SumElement(sortedarray) / sortedarray.Length;
            return output;
        }
        
        private static double StDer(int[] sortedarray)
        {
            var _dash_x = Average(sortedarray);
            var xi_dash_x = 0.0;
            for (var i = 0; i < sortedarray.Length; i++)
            {
                xi_dash_x += Math.Pow((sortedarray[i] - _dash_x), 2);
            }

            var sss = xi_dash_x / (sortedarray.Length - 1);

            var output = Math.Sqrt(sss);
            return output;
        }
        
    }
}