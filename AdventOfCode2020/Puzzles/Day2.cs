using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdventOfCode2020.Puzzles
{
    class Day2
    {
        public static void PuzzleA(string[] values)
        {
            int countOfWords = 0;
            for (int i = 0; i < values.Length - 1; i++)
            {
                var value = values[i];
                var criteriaN = value.Substring(0, value.IndexOf(" ") + 1);
                var criteriaTrim = value.Substring(value.IndexOf(" ") + 1);
                var criteriaTrim2 = criteriaTrim.Substring(0, criteriaTrim.IndexOf(":"));
                var criteriaC = Convert.ToChar(criteriaTrim2);
                var password = value.Substring(value.LastIndexOf(": ") + 2);
                var low = Int32.Parse(criteriaN.Substring(0, criteriaN.IndexOf("-")));
                var high = Int32.Parse(criteriaN.Substring(criteriaN.IndexOf("-") + 1));
                Dictionary<char, int> characters = new Dictionary<char, int>();
                foreach (var c in password)
                {
                    if (c == criteriaC && characters.ContainsKey(criteriaC))
                    {
                        characters[c]++;
                    }
                    if (c == criteriaC && !characters.ContainsKey(criteriaC))
                    {
                        characters.Add(c, 1);
                    }
                }
                foreach (var pair in characters)
                {
                    if (pair.Value >= low && pair.Value <= high)
                    {
                        countOfWords++;
                        Console.WriteLine(value);
                    }
                }
            }
            Console.WriteLine($"Number of passwords in list being valid, according to its criteria");
            Console.WriteLine($"The answer to day 2 Puzzle A is: {countOfWords} ");
            Console.WriteLine("------------------------------------------------");
        }
        public static void PuzzleB(string[] values)
        {
            int countOfWords = 0;
            for (int i = 0; i < values.Length - 1; i++)
            {
                var value = values[i];
                var criteriaN = value.Substring(0, value.IndexOf(" ") + 1);
                var criteriaTrim = value.Substring(value.IndexOf(" ") + 1);
                var criteriaTrim2 = criteriaTrim.Substring(0, criteriaTrim.IndexOf(":"));
                var criteriaC = Convert.ToChar(criteriaTrim2);
                var password = value.Substring(value.LastIndexOf(": ") + 2);
                var firstIndex = Int32.Parse(criteriaN.Substring(0, criteriaN.IndexOf("-")));
                var secondIndex = Int32.Parse(criteriaN.Substring(criteriaN.IndexOf("-") + 1));
                if (password[firstIndex - 1] == criteriaC && password[secondIndex - 1] != criteriaC)
                {
                    countOfWords++;
                    if (countOfWords < 20)
                    {
                        Console.WriteLine(value);
                    }
                }
                if (password[firstIndex - 1] != criteriaC && password[secondIndex - 1] == criteriaC)
                {
                    countOfWords++;
                }
            }
            Console.WriteLine($"Passwords having char at position x OR y");
            Console.WriteLine($"The answer to day 2 Puzzle B is: {countOfWords} ");
        }
    }
}