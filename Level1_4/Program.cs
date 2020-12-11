using System;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace Level1_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculate();
        }

        private static void Calculate()
        {
            Console.WriteLine("Finding prime, Volokhovych\n"); //Todo: REFACTORING
            Console.WriteLine("ENTER RANGE IN FORMAT:\n NUMBER,NUMBER");
            var input = Console.ReadLine();
            string[] tokens = input.Split(',');
            int[] range = Array.ConvertAll<string, int>(tokens, int.Parse);
            ArrayList primes = prime_num(range);
            foreach(var prime in primes)
                Console.Write($"{prime} ");

        }
        
        private static ArrayList prime_num(int[] range)
        {
            ArrayList primes = new ArrayList();
            for (long i = range[0]; i <= range[1]; i++)
            {
                bool isPrime = true;
                for (long j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (i == 1)
                    isPrime = false;
                if (isPrime)
                {
                    primes.Add(i);
                }
            }
            return primes;
        }
    }
}