using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Puzzles
{
    public class Day5
    {
        public static void PuzzleA(string[] values)
        {
            int highestSeatId = 0;

            foreach (var seat in values)
            {
                int row = 0;
                int column = 0;
                int seatId = 0;
                int upper = 127;
                int lower = 0;
                int half = 128;
                int lrhalf = 8;
                int right = 7;
                int left = 0;
                int middle;
                foreach (var letter in seat)
                {
                    if (letter == 'F')
                    {
                        half = half / 2;
                        middle = upper - half;
                        upper = middle;
                        row = upper;
                    }
                    if (letter == 'B')
                    {
                        half = half / 2;
                        middle = lower + half;
                        lower = middle;
                        row = lower;
                    }
                    if (letter == 'L')
                    {
                        lrhalf = lrhalf / 2;
                        middle = right - lrhalf;
                        right = middle;
                        column = right;
                    }
                    if (letter == 'R')
                    {
                        lrhalf = lrhalf / 2;
                        middle = left + lrhalf;
                        left = middle;
                        column = left;
                    }
                }
                seatId = ((row * 8) + column);
                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }
            }
            Console.WriteLine("highestSeatId: " + highestSeatId.ToString());
        }

        public static void PuzzleB(string[] values)
        {
            HashSet<int> s = new HashSet<int>();
            int highestSeatId = 0;
            int lowestSeatId = 600;

            foreach (var seat in values)
            {
                int row = 0;
                int column = 0;
                int seatId = 0;
                int upper = 127;
                int lower = 0;
                int half = 128;
                int lrhalf = 8;
                int right = 7;
                int left = 0;
                int middle;
                foreach (var letter in seat)
                {
                    if (letter == 'F')
                    {
                        half = half / 2;
                        middle = upper - half;
                        upper = middle;
                        row = upper;
                    }
                    if (letter == 'B')
                    {
                        half = half / 2;
                        middle = lower + half;
                        lower = middle;
                        row = lower;
                    }
                    if (letter == 'L')
                    {
                        lrhalf = lrhalf / 2;
                        middle = right - lrhalf;
                        right = middle;
                        column = right;
                    }
                    if (letter == 'R')
                    {
                        lrhalf = lrhalf / 2;
                        middle = left + lrhalf;
                        left = middle;
                        column = left;
                    }
                }
                seatId = ((row * 8) + column);
                s.Add(seatId);
                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }
                if (seatId < lowestSeatId)
                {
                    lowestSeatId = seatId;
                }
            }
            Console.WriteLine("highestSeatId: " + highestSeatId.ToString());
            Console.WriteLine("lowestSeatId: " + lowestSeatId.ToString());

            for (int x = 1; x < highestSeatId; x++)
                if (!s.Contains(x))
                    Console.WriteLine(x + " ");
        }
    }
}
