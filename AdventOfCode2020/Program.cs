using System;
using System.Net.Http;

namespace AdventOfCode2020
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to this Advent of Code 2020 program! Please enter the date (1-24) you want to explore");
            int day = Convert.ToInt32(Console.ReadLine());
            if (day < 1 && day > 24)
                Console.WriteLine("Inserted value is outside valid range. Please restart program and try again");

            Initialize initialize = new Initialize();
            var uri = initialize.ConfigureUri(day);
            var cookie = initialize.ConfigureCookie();

            initialize.InitializePuzzle(uri, cookie,day);
        }
    }
}
