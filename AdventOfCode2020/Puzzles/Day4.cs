using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace AdventOfCode2020.Puzzles
{
    class Day4
    {
        public static void PuzzleA(string response)
        {
            string[] values = response.Split("\n\n");
            string[] reqfields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            List<string> list = new List<string>();
            int counter;
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                for (int j = 0; j < reqfields.Length; j++)
                {
                    if (!value.Contains(reqfields[j]))
                    {
                        if (!list.Contains(value))
                        {
                            list.Add(value);
                        }
                    }
                }
            }
            counter = values.Length - list.Count;
            Console.WriteLine($"Number of passports are: {counter}​");
        }
        public static void PuzzleB(string response)
        {
            string[] values = response.Split("\n\n");
            string[] reqfields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            Dictionary<string, int> count = new Dictionary<string, int>();
            int counter;
            foreach (var initvalue in values)
            {
                var value = initvalue.Replace("\n", " ");
                foreach (string field in reqfields)
                {
                    if (value.Contains(field))
                    {
                        string start = value.Substring(value.IndexOf($"{field}​:"));
                        string end;
                        if (start.LastIndexOf(" ") == -1)
                        {
                            end = start;
                        }
                        else
                        {
                            end = start.Substring(0, start.IndexOf(" "));
                        }
                        string result = end.Substring(end.IndexOf(":") + 1);

                        if (field == "byr")
                        {
                            if (!CheckYear(result, 1920, 2002))
                            {
                                if (!count.ContainsKey(initvalue))
                                {
                                    count.Add(initvalue,1);
                                }
                                else
                                {
                                    count[initvalue]++;
                                }
                            }
                        }

                        if (field == "iyr")
                        {
                            if (!CheckYear(result, 2010, 2020))
                            {
                                if (!count.ContainsKey(initvalue))
                                {
                                    count.Add(initvalue, 1);
                                }
                                else
                                {
                                    count[initvalue]++;
                                }
                            }
                        }

                        if (field == "eyr")
                        {
                            if (!CheckYear(result, 2020, 2030))
                            {
                                if (!count.ContainsKey(initvalue))
                                {
                                    count.Add(initvalue, 1);
                                }
                                else
                                {
                                    count[initvalue]++;
                                }
                            }
                        }

                        if (field == "hgt")
                        {
                            if (!CheckHeight(result))
                            {
                                if (!count.ContainsKey(initvalue))
                                {
                                    count.Add(initvalue, 1);
                                }
                                else
                                {
                                    count[initvalue]++;
                                }
                            }
                        }

                        if (field == "hcl")
                        {
                            if (!CheckHairColor(result))
                            {
                                if (!count.ContainsKey(initvalue))
                                {
                                    count.Add(initvalue, 1);
                                }
                                else
                                {
                                    count[initvalue]++;
                                }
                            }
                        }
                        if (field == "ecl")
                        {
                            if (!CheckEyeColor(result))
                            {
                                if (!count.ContainsKey(initvalue))
                                {
                                    count.Add(initvalue, 1);
                                }
                                else
                                {
                                    count[initvalue]++;
                                }
                            }
                        }
                        if (field == "pid")
                        {
                            if (!CheckPassport(result))
                            {
                                if (!count.ContainsKey(initvalue))
                                {
                                    count.Add(initvalue, 1);
                                }
                                else
                                {
                                    count[initvalue]++;
                                }
                            }
                        }
                    }
                    if (!value.Contains(field))
                    {
                        if (!count.ContainsKey(initvalue))
                        {
                            count.Add(initvalue, 1);
                        }
                        else
                        {
                            count[initvalue]++;
                        }
                    }
                }
            }
            counter = values.Length - count.Keys.Count();
            Console.WriteLine($"Number of passports are: {counter}​");
        }

        public static bool CheckYear(string result,int low, int high)
        {
            int r = Convert.ToInt32(result);
            if (result.Length == 4)
            {
                if (r >= low)
                {
                    if ( r <= high)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        public static bool CheckHeight(string result)
        {
            string number = result.Remove(result.Length - 2);
            if (Int32.TryParse(number, out int r))
            {
                if (result.Contains("in"))
                {
                    if (r >= 59)
                    {
                        if (r <= 76)
                        {
                            return true;
                        }
                        return false;
                    }
                    return false;
                }
                if (result.Contains("cm"))
                {
                    if (r >= 150)
                    {
                        if (r <= 193)
                        {
                            return true;
                        }
                        return false;
                    }
                }
                return false;
            }
            return false;
        }

        public static bool CheckHairColor(string result)
        {
            if (result.Contains('#'))
            {
                var trim = result.Substring(result.IndexOf('#') + 1);
                if (trim.Length == 6)
                {
                    char[] characters = { 'a', 'b', 'c', 'd', 'e', 'f','1','2','3','4','5','6','7','8','9','0' };
                    foreach (var value in trim)
                    {
                        if (!characters.Contains(value))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool CheckEyeColor(string result)
        {
            string[] colors = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            if (!colors.Contains(result))
            {
                return false;
            }
            return true;
        }

        public static bool CheckPassport(string result)
        {
            if (result.Length == 9)
            {
                char[] numbers = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                foreach (var value in result)
                {
                    if (!numbers.Contains(value))
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}