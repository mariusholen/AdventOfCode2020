using System;
using System.Numerics;

namespace AdventOfCode2020.Puzzles
{
    public class Day3
    {
        public static void PuzzleA(string[] values)
        {
            int trees = Looper(values, 1);
            Console.WriteLine($"Number of trees encountered while traversing the map one down and three right");
            Console.WriteLine($"The answer to day 3 Puzzle A is: {trees} ");
            Console.WriteLine("------------------------------------------------");
        }

        public static void PuzzleB(string[] values)
        {
            int trees1 = Looper(values, 1);
            int trees3 = Looper(values, 3);
            int trees5 = Looper(values, 5);
            int trees7 = Looper(values, 7);
            int trees1down2 = Looper(values, 1, 2);
            long trees = (Convert.ToInt64(trees1) * (Convert.ToInt64(trees3)) * (Convert.ToInt64(trees5)) * (Convert.ToInt64(trees7)) * (Convert.ToInt64(trees1down2)));
            Console.WriteLine($"Number of trees encountered while traversing the map several times");
            Console.WriteLine($"The answer to day 3 Puzzle B is: {trees} ");
        }

        public static int Looper(string[] values, int slopes, int jumps = 1)
        {
            int trees = 0;
            int count = 0;
            for (int i = 0; i < values.Length; i = i + jumps)
            {
                var value = values[i];
                if (string.IsNullOrWhiteSpace(value))
                {
                    break;
                }
                if (count >= value.Length)
                {
                    count = count - value.Length;
                }
                if (value[count] == '#')
                {
                    trees++;
                }
                count = count + slopes;
            }
            //Console.WriteLine($"For {slopes}​ slopes and {jumps}​ jumps, there were {trees}​ trees");
            return trees;
        }
    }
}