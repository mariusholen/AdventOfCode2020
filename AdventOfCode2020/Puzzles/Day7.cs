using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Puzzles
{
    class Day7
    {
        public static void PuzzleA(string[] values)
        {
            List<string> colors = new List<string>();
            colors.AddRange(Looper("shiny gold", values, colors));
            Console.WriteLine(colors.Count);
        }
        public static List<string> Looper(string color, string[] values, List<string> colors)
        {
            List<string> newColors = new List<string>();
            foreach(var value in values)
            {
                if (value.Contains(color))
                {
                    var newcolor = value.Substring(0, value.IndexOf("bags contain") - 1);
                    if (!newcolor.Equals(color))
                    {
                        if (!colors.Contains(newcolor))
                        {
                            colors.Add(newcolor);
                            newColors.AddRange(Looper(newcolor, values, colors));
                        }
                    }
                }
            }
            return newColors;
        }


        public static void PuzzleB(string[] values)
        {
            int counter = 0;
            counter += (Counter("shiny gold", values));
            Console.WriteLine(counter);
        }

        public static int Counter(string sentvalue, string[] values)
        {
            int counter = 0;
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                if (value.Contains(sentvalue))
                {
                    var checkValue = value.Substring(0, value.IndexOf("bags") - 1);
                    if (checkValue.Equals(sentvalue))
                    {
                        if (!checkValue.Equals("shiny gold")){
                            counter += 1;
                        }
                        if (value.Contains("no other bags"))
                        {
                            return 1;
                        }
                        else
                        {
                            string[] newValues = value.Substring(value.IndexOf("contain ") + 8).Split(", ");
                            for (int j = 0; j < newValues.Length; j++)
                            {
                                var newValue = newValues[j];
                                var newValue2 = newValue.Replace(".", "");
                                var tempnew = newValue2.Substring(newValue2.IndexOf(" ") + 1);
                                var bagsindex = tempnew.IndexOf(" bags") != -1 ? tempnew.IndexOf(" bags") : tempnew.IndexOf(" bag");
                                var tempnew2 = tempnew.Substring(0, bagsindex);
                                int results = Counter(tempnew2, values);
                                int val = Int32.Parse(newValue.Substring(0, newValue.IndexOf(" ") + 1));
                                int sum = val * results;
                                counter += sum;
                            }
                        }
                    }
                }
            }
            return counter;
        }
    }
}