using System;
using System.Linq;

namespace AdventOfCode2022
{
    class Day1 {

        private static List<List<int>> init()
        {
            String file = Program.inputPath + @"/day1/prob1.txt";
            // readfile
            List<String> lines = System.IO.File.ReadAllLines(file).ToList();

            List<List<int>> elfs = new List<List<int>>();
            List<int> calories = new List<int>();

            foreach (String line in lines)
            {

                if (string.IsNullOrEmpty(line))
                {
                    elfs.Add(calories);
                    calories = new List<int>();
                }
                else
                    calories.Add(Int32.Parse(line));
            }

            return elfs;
        }
        public static void prob1()
        {
            var elfs = init();

            Console.WriteLine(elfs.Max(calories => calories.Sum()));
        }

        public static void prob2()
        {
            var elfs = init();

            var maxs = elfs.Select(calories => calories.Sum()).OrderByDescending(score => score).Take(3);
            
            // maxs.ToList().ForEach(Console.WriteLine);

            Console.WriteLine(maxs.Sum());

        }
    }
}