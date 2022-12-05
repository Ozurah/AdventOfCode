using System;
using System.Linq;

namespace AdventOfCode2022
{
    class Day3 : IDay
    {

        private int getPriority(char c)
        {
            if (c >= 'a' && c <= 'z')
            {
                return 1 + c - 'a';
            }
            else if (c >= 'A' && c <= 'Z')
            {
                return 27 + +c - 'A';
            }
            else
            {
                throw new Exception("Invalid character");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A list of distinct characters who is found in both strings</returns>
        private List<char> getCharInBoth(String str1, String str2, String? str3 = null)
        {
            var result = new List<char>();
            foreach (char c in str1)
            {
                if (!result.Contains(c) && str2.Contains(c) && str3?.Contains(c) != false)
                {
                    result.Add(c);
                }
            }
            return result;
        }


        /// <summary>
        ///
        /// </summary>
        /// <returns>Tuple : backpack left, backpack right</returns>
        private List<Tuple<String, String>> init()
        {
            String file = Program.inputPath + @"/day3.txt";
            // file = Program.inputPath + @"/day3_simple.txt";

            List<String> lines = System.IO.File.ReadAllLines(file).ToList();

            var backapcks = new List<Tuple<String, String>>();

            foreach (String line in lines)
            {
                int middle = line.Length / 2;
                backapcks.Add(new Tuple<String, String>(
                    line.Substring(0, middle),
                    line.Substring(middle, middle)
                ));
            }

            return backapcks;
        }

        public void prob1()
        {
            var backpacks = init();

            var sumBadItem = backpacks
                .Select(x => getCharInBoth(x.Item1, x.Item2)) // List of List of char
                .Select(x => x.Select(y => getPriority(y))) // List of List of int
                .Select(x => x.Sum()) // List of int
                .Sum(); // int

            Console.WriteLine(sumBadItem);
        }

        public void prob2()
        {
            var backpacks = init();

            var groupedBackpacks = new List<List<Tuple<String, String>>>();

            int groupSize = 3;
            for (int i = 0; i < backpacks.Count; i += groupSize)
            {
                var group = backpacks.Concat(backpacks).Skip(i).Take(groupSize).ToList();
                groupedBackpacks.Add(group);
            }

            var sumGroup = groupedBackpacks
                .Select(x => x.Select(elem => elem.Item1 + elem.Item2).ToList()) // List of List of String
                .Select(x => getCharInBoth(x[0], x[1], x[2])) // List of List of char
                .Select(x => x.Select(elem => getPriority(elem))) // List of List of int
                .Select(x => x.Sum()) // List of int
                .Sum(); // int

            Console.WriteLine(sumGroup);
        }
    }
}