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
            // Insert cookie from https://adventofcode.com/ in format session=xyz 
            string cookie = "";
            if (string.IsNullOrWhiteSpace(cookie))
            {
                Console.WriteLine("Please insert the cookie");
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
                Day1 day1 = new Day1();
                Day1.PuzzleA(values);
                Day1.PuzzleB(values);
            } 
        }
    }
}
