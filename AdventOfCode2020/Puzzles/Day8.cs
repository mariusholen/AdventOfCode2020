using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AdventOfCode2020.Puzzles
{
    class Day8
    {
        public static void PuzzleA(string[] values)
        {
            int accumulator = 0;
            List<string> usedCommands = new List<string>();
            for (int i = 0; i <= values.Length; i++)
            {
                if (i.Equals(values.Length))
                {
                    Console.WriteLine(accumulator);
                }
                Console.WriteLine(accumulator);
                var value = values[i];
                var storingValue = $"{i} {value}";
                int num = Int32.Parse(value.Substring(value.IndexOf(" ")));
                string val = value.Substring(0, value.IndexOf(" "));
                if (usedCommands.Contains(storingValue))
                {
                    Console.WriteLine("current accumulator: " + accumulator);
                    accumulator += 5;
                    Console.WriteLine("with accumulator +5: " + accumulator);
                }
                if (val.Equals("acc"))
                {
                    usedCommands.Add(storingValue);
                    accumulator += num;
                }
                if (val.Equals("nop"))
                {
                    usedCommands.Add(storingValue);
                }
                if (val.Equals("jmp"))
                {
                    usedCommands.Add(storingValue);
                    i += num - 1;
                }
            }
        }
        public static void PuzzleB(string response)
        {
            string[] values = response.Split("\n");
            for (int i = 0; i < values.Length; i++)
            {
                if (i.Equals(values.Length))
                {
                    Console.WriteLine("");
                }
                string[] editedValues = response.Split("\n");
                var value = values[i];
                if (value.Contains("jmp"))
                {
                    var newValue = value.Replace("jmp", "nop");
                    editedValues[i] = newValue;
                    var returnValue = PuzzleBLooper(editedValues);
                    if (!returnValue.Equals(-1))
                    {
                        Console.WriteLine("You made it to the bottom!!!! with accumulator : " + returnValue);
                    }
                }
                if (value.Contains("nop"))
                {
                    var newValue = value.Replace("nop", "jmp");
                    editedValues[i] = newValue;
                    var returnValue = PuzzleBLooper(editedValues);
                    if (!returnValue.Equals(-1))
                    {
                        Console.WriteLine("You made it to the bottom!!!! with accumulator : " + returnValue);
                    }
                }
                
                
            }
        }

        public static int PuzzleBLooper(string[] values)
        {
            int accumulator = 0;
            List<string> usedCommands = new List<string>();
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];
                var storingValue = $"{i} {value}";
                int num = Int32.Parse(value.Substring(value.IndexOf(" ")));
                string val = value.Substring(0, value.IndexOf(" "));
                if (usedCommands.Contains(storingValue))
                {
                    return -1;
                }
                if (val.Equals("acc"))
                {
                    usedCommands.Add(storingValue);
                    accumulator += num;
                }
                if (val.Equals("nop"))
                {
                    usedCommands.Add(storingValue);
                }
                if (val.Equals("jmp"))
                {
                    usedCommands.Add(storingValue);
                    i += num - 1;
                }
                Console.WriteLine(accumulator);
            }
            Console.WriteLine("You made it to the bottom!!!! with accumulator: " + accumulator + " and value: " /*+ storingValue*/ );
            return accumulator;
        }
    }
}