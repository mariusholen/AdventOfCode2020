using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdventOfCode2020.Puzzles
{
    /// <summary>
    /// 1-3 a: abcde
    ///1-3 b: cdefg
    ///2-9 c: ccccccccc
    /// </summary>
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
            Console.WriteLine($"If I have done my programming right, there is: {countOfWords} passwords being");
            Console.WriteLine("Correct, according to its criteria");
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
            Console.WriteLine($"If I have done my programming right, there is: {countOfWords} passwords being");
            Console.WriteLine("Correct, according to its criteria");
        }


        public static void Knowit()
        {
            //5433000
            int countPresents = 0;
            //int j = 0;
            for (int i = 0; i < 10; i++)
            {
                countPresents++;
                Console.WriteLine(countPresents + " + " + i);
                string value = i.ToString();
                if (value.Contains("7"))
                {
                    int k = i;
                    //var isPrime = IsPrime(k);
                    while (!IsPrime(k))
                    {
                        k--;
                    }
                    i = i + k;
                }
            }
            Console.WriteLine("Answer is: " + countPresents + " ");

            /*if (IsPrime(k))
        {
            i = i + k - 1;
        }
        for (k = i; k > 0; k--)
        {
            if (IsPrime(k))
            {
                i = i + k - 1;
                Console.WriteLine(countPresents + " ");
                break;
            }
        }
    }
    /*if (!value.Contains("7"))
    {
        j++;
    }*/
            /*}
        Console.WriteLine(countPresents + " ");*/
        }

        public static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}