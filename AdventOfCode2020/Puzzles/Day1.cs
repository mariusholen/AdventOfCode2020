using System;
namespace AdventOfCode2020.Puzzles
{
    public class Day1
    {
        public static void PuzzleA(string[] values)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                int firstvalue = Int32.Parse(values[i]);
                for (int j = i + 1; j < values.Length - 1; j++)
                {
                    int secondvalue = Int32.Parse(values[j]);
                    if (firstvalue + secondvalue == 2020)
                    {
                        Console.WriteLine($"The two numbers adding up to 2020 are {firstvalue} and {secondvalue}");
                        var total = firstvalue * secondvalue;
                        Console.WriteLine($"And the answer to Day 1 Puzzle A is: {total}");
                        Console.WriteLine("------------------------------------------------");
                    }
                }
            }
        }

        public static void PuzzleB(string[] values)
        {
            for (int i = 0; i < values.Length - 1; i++)
            {
                int firstvalue = Int32.Parse(values[i]);
                for (int j = i + 1; j < values.Length - 1; j++)
                {
                    int secondvalue = Int32.Parse(values[j]);
                    for (int k = j + 1; k < values.Length - 1; k++)
                    {
                        int thirdvalue = Int32.Parse(values[k]);
                        if (firstvalue + secondvalue + thirdvalue == 2020)
                        {
                            Console.WriteLine($"The three numbers adding up to 2020 are {firstvalue}, {secondvalue} and {thirdvalue}");
                            var total = firstvalue * secondvalue * thirdvalue;
                            Console.WriteLine($"And the answer to Day 1 Puzzle B is: {total}");
                        }
                    }
                }
            }
        }
    }
}
