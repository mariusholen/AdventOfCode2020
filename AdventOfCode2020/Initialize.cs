using System;
using System.Net.Http;
using AdventOfCode2020.Puzzles;

namespace AdventOfCode2020
{
    public class Initialize
    {
        public string ConfigureUri(int day)
        {
            string uri = ($"https://adventofcode.com/2020/day/{day}/input");
            if (string.IsNullOrWhiteSpace(uri.ToString()))
            {
                Console.WriteLine("Please insert the complete url to todays values");
                uri = Console.ReadLine();
            }
            return uri;
        }
        public string ConfigureCookie()
        { 
            string cookie = "";
            if (string.IsNullOrWhiteSpace(cookie))
            {
                Console.WriteLine("Please insert your cookie from https://adventofcode.com/ in the format 'session=xyz123'");
                cookie = Console.ReadLine();
            }
            return cookie;
        }

        public void InitializePuzzle(string path, string cookie, int day)
        {
            Uri uri = new Uri(path);
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cookie", cookie);
            var response = client.GetStringAsync(uri).Result;
            response.Replace(" ", "");
            string[] values = response.Split("\n");

            if (day == 1)
            {
                Day1.PuzzleA(values);
                Day1.PuzzleB(values);
            }
            if (day == 2)
            {
                Day2.PuzzleA(values);
                Day2.PuzzleB(values);
            }
            if (day == 3)
            {
                Day3.PuzzleA(values);
                Day3.PuzzleB(values);
            }
            if (day == 4)
            {
                Day4.PuzzleA(response);
                Day4.PuzzleB(response);
            }
            if (day == 5)
            {
                Day5.PuzzleA(values);
                Day5.PuzzleB(values);
            }
            if (day == 6)
            {
                Day6.PuzzleA(response);
                Day6.PuzzleB(response);
            }
            if (day == 7)
            {
                Day7.PuzzleA(values);
                Day7.PuzzleB(values);
            }
        }
    }
}
