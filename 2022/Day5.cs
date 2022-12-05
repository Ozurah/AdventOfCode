using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    class Day5 : IDay
    {

        private List<LinkedList<char>> stacks = new List<LinkedList<char>>();
        //nb to move, from, to
        private List<Tuple<int, int, int>> procedures = new List<Tuple<int, int, int>>();
        /// <summary>
        ///
        /// </summary>
        /// <returns>Tuple : backpack left, backpack right</returns>
        private void init()
        {
            String file = Program.inputPath + @"/day5.txt";
            // file = Program.inputPath + @"/day5_simple.txt";

            stacks = new List<LinkedList<char>>();
            procedures = new List<Tuple<int, int, int>>();
            List<String> lines = System.IO.File.ReadAllLines(file).ToList();

            var backapcks = new List<Tuple<String, String>>();

            foreach (String line in lines)
            {
                if (line.Contains("[")) // Start
                {
                    for (int i = stacks.Count(); i <= line.Length / 4; i++) // <= because we can have 3, 7, 11 chars, so by divide, missing 1
                    {
                        stacks.Add(new LinkedList<char>());
                    }

                    for (int i = 0; i < line.Length; i += 4)
                    {
                        if (line[i + 1] != ' ')
                            stacks[i / 4].AddFirst(line[i + 1]);
                    }
                }
                else if (line.Contains("move")) // Procedure
                {
                    var splitedLine = line.Split(new Char[] { ' ' });

                    procedures.Add(new Tuple<int, int, int>(
                        int.Parse(splitedLine[1]),
                        int.Parse(splitedLine[3]) - 1, // 0 based
                        int.Parse(splitedLine[5]) - 1
                    ));
                }
            }
        }

        public void prob1()
        {
            init();
            foreach (var procedure in procedures)
            {
                for (int i = 0; i < procedure.Item1; i++)
                {
                    var item = stacks[procedure.Item2].Last();
                    stacks[procedure.Item2].RemoveLast();
                    stacks[procedure.Item3].AddLast(item);
                }
            }

            foreach (var stack in stacks)
            {
                if (stack.Count > 0)
                    Console.Write(stack.Last());
            }
            Console.WriteLine();
        }

        public void prob2()
        {

            init();

            foreach (var procedure in procedures)
            {
                // Could be simplified with list of list, but didn't want to change :')
                // Using Stack to preserve order when readding on the other stack
                Stack<char> temp = new Stack<char>();

                for (int i = 0; i < procedure.Item1; i++)
                {
                    var item = stacks[procedure.Item2].Last();
                    temp.Push(item);
                    stacks[procedure.Item2].RemoveLast();
                }

                while (temp.Count > 0)
                    stacks[procedure.Item3].AddLast(temp.Pop());
            }

            foreach (var stack in stacks)
            {
                if (stack.Count > 0)
                    Console.Write(stack.Last());
            }
            Console.WriteLine();
        }
    }
}