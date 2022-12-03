using System;
using System.Linq;

namespace AdventOfCode2022
{
    class Day3
    {

        private static int getPriority(char c)
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
        /// <param name="input"></param>
        /// <returns>A list of distinct characters who is found in both strings</returns>
        private static List<char> getCharInBoth(String str1, String str2)
        {
            var result = new List<char>();
            foreach (char c in str1)
            {
                if (!result.Contains(c) && str2.Contains(c))
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
        private static List<Tuple<String, String>> init()
        {
            String file = Program.inputPath + @"/day3.txt";

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

        public static void prob1()
        {
            var backpacks = init();

            var sumBadItem = backpacks
                .Select(x => getCharInBoth(x.Item1, x.Item2)) // List of List of char
                .Select(x => x.Select(y => getPriority(y))) // List of List of int
                .Select(x => x.Sum()) // List of int
                .Sum(); // int

            Console.WriteLine(sumBadItem);
        }

        public static void prob2()
        {

        }
    }
}