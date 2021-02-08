using System;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using Microsoft.Win32;

/*
 * EXTRA COMMAND! : "forfeit" - считаеться как неверный ввод
Не обрабатываеться неверный ввод в рендж, если ввести символы
(-4 балла)
Рекомендации, которые не снизили баллы:
Можно ввести цифру, которая не попадает в рендж
 */

//todo:bugfix

namespace Level2_4
{
    class Program
    {
        private const string StopWord = "exit";
        private static Random _random = new Random();
        private static int score;
        static void Main()
        {
            Console.WriteLine("More or Less game, Volokhovych");
            int[] input = Input();
            //Calculate(range);
        }

        private static int[] Input()
        {
            long value;
            long value1;
            var input = "";
            string[] tokens;
            //string[] tokens = input.Split(',');
            do
            {
                Console.WriteLine("Please input range between 0 and 1.000.000 in format\n[NUMBER],[NUMBER]\nEnter: ");
                 input = Console.ReadLine();
                 if(input.ToLower() == StopWord)
                     Environment.Exit(1);
                 else if (input.ToLower() == "rules")
                 {
                     Rules();
                     input = Console.ReadLine();
                 }
                     
                 tokens = input.Split(',');
                 Int64.TryParse(tokens[0], out value);
                 Int64.TryParse(tokens[1], out value1);
            }
            while (Regex.Matches(input, @"[a-zA-Z-?`\-+*/{}|.<>]").Count > 0 || tokens.Length > 2 || value < 0 || value > 1000000
                                  || value1 > 1000000 || value > value1);
            
            int[] range = Array.ConvertAll(tokens, int.Parse);
            Calculate(range);
            return range;
        }
        private static void Rules()
        {
            Console.WriteLine("More or Less is a quiz game in which players have to answer (numerical) questions.\n" +
                              " ... For each question, it is determined whether only guesses that are higher \n" +
                              "than the actual " +
                              "answer will count (more), or only guesses that \n" +
                              "are lower (less).\n");
        }

        private static void Calculate(int[] range)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var computerValue = _random.Next(range[0], range[1]);
            var sumrange = 0;
            var fails = 0;
            if (range[0] == 0)
                sumrange = range[1] + 1;
            else
            {
                sumrange = range[1] - range[0];
            }
            int input = 0;
            do
            {
                Console.WriteLine("EXTRA COMMAND! : \"forfeit\"\nInput your guess: ");
                var userInput = Console.In.ReadLine();
                if(userInput.ToLower() == StopWord)
                    Environment.Exit(1);
                else if (userInput.ToLower() =="rules")
                    Rules();
                if (Regex.Matches(userInput, @"[a-zA-Z-?`\-+*/{}|.<>]").Count > 0)
                {
                    Console.WriteLine("Wrong input!");
                }
                else if (userInput.ToLower() == "forfeit")
                {
                    stopwatch.Stop();
                    Console.WriteLine($"Sounds of sad trombone... You have 0 points.\nYou struggled for {stopwatch.ElapsedMilliseconds} ms");
                    Environment.Exit(1);
                }
                else
                {
                    Int32.TryParse(userInput, out input);
                    if (input < computerValue)
                    {
                        fails++;
                        Console.WriteLine("Too few!");
                        //todo: score counter
                    }

                    if (input > computerValue)
                    {
                        fails++;
                        Console.WriteLine("Too much!");
                        //todo: score counter
                    }
                }
            } while (input != computerValue);
            stopwatch.Stop();
            double score = 100.0*(PowerofTwo(sumrange) - fails)/PowerofTwo(sumrange);
            Console.WriteLine($"You guessed! It was {input}\n" +
                              $"Your scored {Math.Round(score,MidpointRounding.AwayFromZero)}\n" +
                              $"And it took you {fails} times to fail, {fails+1}th try is right!\n" +
                              $"Time in game: {stopwatch.ElapsedMilliseconds}ms.");
        }

        private static int PowerofTwo(int range)
        {
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

            return power;
        }
    }
}