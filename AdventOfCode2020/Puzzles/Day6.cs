using System;
using System.Collections.Generic;

namespace AdventOfCode2020.Puzzles
{
    public class Day6
    {
        public static void PuzzleA(string response)
        {
            string[] values = response.Split("\n\n");
            List<int> totalList = new List<int>();
            for (int i = 0; i < values.Length; i++)
            {
                int counter = 0;
                var value = values[i];
                value = value.Replace("\n", "");
                List<char> list = new List<char>();
                for (int j = 0; j < value.Length; j++)
                {
                    if (!list.Contains(value[j]))
                    {
                        list.Add(value[j]);
                        counter++;
                    }
                }
                totalList.Add(counter);
            }
            int totalCount = 0;
            for (int x = 0; x < totalList.Count; x++)
            {
                totalCount += totalList[x];
            }
            Console.WriteLine("total count is: " + totalCount);
        }

        public static void PuzzleB(string response)
        {
            string[] values = response.Split("\n\n");
            List<int> totalList = new List<int>();
            for (int i = 0; i < values.Length; i++)
            {
                int groupcounter = 0;
                var value = values[i];
                string[] groupvalues = value.Split("\n");
                Dictionary<char, int> grouplistDistinct = new Dictionary<char, int>();
                for (int j = 0; j < groupvalues.Length; j++)
                {
                    
                    var groupvalue = groupvalues[j];
                    List<char> singlelist = new List<char>();
                    for (int k = 0; k < groupvalue.Length; k++)
                    {
                        var singlevalue = groupvalue[k];
                        if (!singlelist.Contains(singlevalue))
                        {
                            singlelist.Add(singlevalue);
                            if (!grouplistDistinct.ContainsKey(singlevalue))
                            {
                                grouplistDistinct.Add(singlevalue, 1);
                            }
                            else
                            {
                                grouplistDistinct[singlevalue]++;
                            }
                        }
                    }
                }
                foreach (KeyValuePair<char, int> entry in grouplistDistinct)
                {
                    if (entry.Value == groupvalues.Length)
                    {
                        groupcounter++;
                    }
                }
                totalList.Add(groupcounter);
            }
            int totalCount = 0;
            for (int x = 0; x < totalList.Count; x++)
            {
                totalCount += totalList[x];
            }
            Console.WriteLine("total count is: " + totalCount);
        }
    }
}
