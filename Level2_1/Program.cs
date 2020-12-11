using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.Win32;

namespace Level2_1
{
    class Program
    {
        private static Dictionary<Int32, String> game_cache = new Dictionary<Int32, string>();
        private static Dictionary<Int32, String> options = new Dictionary<Int32, string>(3)
        {
            {1, "rock"},
            {2, "paper"},
            {3, "scissors"}
        };
        private static readonly Random _random = new Random();
        private static int gameID = 0;
        
        static void Main()
        {
            Console.WriteLine("Rock,Paper,Scissors game. Vokokhovych");
            Calculate();
        }

        private static void Help()
        {
            Console.WriteLine("A player who decides to play rock will beat another player who has chosen scissors\n" +
                              "(\"rock crushes scissors\" or sometimes \"blunts scissors\"),but will lose to one who has\n" +
                              "played paper (\"paper covers rock\"); a play of paper will lose\n" +
                              "lose to a play of scissors (\"scissors cuts paper\").");
        }

        private static void Commands()
        {
            Console.WriteLine("Available commands:\n Exit - close programme;\n Help - prints game rules\n" +
                              "Game commands:\n rock - for rock\n paper - for paper\n scissors - for scissors.");
        }
        private static void Calculate()
        {
            var option = "";
            Commands();
            while (option !="exit")
            {
                option = Console.In.ReadLine();
                if (option == null)
                {
                    Console.WriteLine("Error, try again");
                    Commands();
                    Calculate();
                }
                else
                {
                    option = option.ToLower();
                }
                var computerOption = "";
                string output = "";
                switch (option)
                {
                    case "exit":
                        foreach(var pair in game_cache)
                            Console.WriteLine($"Game {pair.Key} {pair.Value}");
                        Environment.Exit(0);
                        break;
                    case "help":
                        Help();
                        break;
                    case "rock":
                        computerOption = options[_random.Next(1, 4)];
                        gameID++;
                        if (computerOption == "rock")
                        {
                            output = $"User:{option} = {computerOption} : Computer. DRAW";
                        } else if (computerOption == "paper")
                        {
                            output = $"User:{option} < {computerOption} : Computer. Computer Wins";
                        }
                        else
                        {
                            output = $"User:{option} > {computerOption} : Computer. User Wins";
                        }
                        game_cache.Add(gameID,output);
                        break;
                    case "paper":
                        computerOption = options[_random.Next(1, 4)];
                        gameID++;
                        if (computerOption == "paper")
                        {
                            output = $"User:{option} = {computerOption} : Computer. DRAW";
                        } else if (computerOption == "rock")
                        {
                            output = $"User:{option} > {computerOption} : Computer. User Wins";
                        }
                        else
                        {
                            output = $"User:{option} < {computerOption} : Computer. Computer Wins";
                        }
                        game_cache.Add(gameID,output);
                        break;
                    case "scissors":
                        computerOption = options[_random.Next(1, 4)];
                        gameID++;
                        if (computerOption == "scissors")
                        {
                            output = $"User:{option} = {computerOption} : Computer. DRAW";
                        } else if (computerOption == "paper")
                        {
                            output = $"User:{option} > {computerOption} : Computer. User Wins";
                        }
                        else
                        {
                            output = $"User:{option} < {computerOption} : Computer. Computer Wins";
                        }
                        game_cache.Add(gameID,output);
                        break;
                    default:
                        Console.WriteLine("Error! Try again");
                        Calculate();
                        break;
                }

                Console.WriteLine(output);
            }
            
        }

    }
}