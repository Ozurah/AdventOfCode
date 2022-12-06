using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    class Day4 : IDay
    {

        private const string INPUT_BASE_NAME = "day4";

        /// <summary>
        ///
        /// </summary>
        /// <returns>Groupe, member, range, values</returns>
        /// <example>
        /// 2-3,6-7 => groupe[0][0][0] = 2, groupe[0][0][1] = 3, groupe[0][1][0] = 6, groupe[0][1][1] = 7
        /// 1-3,5-7 => groupe[1][0][0] = 1, groupe[1][0][1] = 2, groupe[1][0][2] = 3, groupe[1][1][0] = 5, groupe[1][1][1] = 6, groupe[1][1][2] = 7
        /// </example>
        private List<List<List<int>>> init()
        {
            String file = Program.inputPath + @"/" + INPUT_BASE_NAME + ".txt";
            // file = Program.inputPath + @"/" + INPUT_BASE_NAME + "_simple.txt";

            List<String> lines = System.IO.File.ReadAllLines(file).ToList();

            List<List<List<int>>> groups = new List<List<List<int>>>();
            foreach (String line in lines)
            {
                var paires = line.Split(",");
                var ranges = paires.Select(p => p.Split("-")).Select(p => new Tuple<String, String>(p[0], p[1])).ToList();

                var values = ranges.Select(
                    r => Enumerable.Range(int.Parse(r.Item1), int.Parse(r.Item2) - int.Parse(r.Item1) + 1) // range(start, count) / +1 because : 6..8 => 8 - 6 = 2 -> would return 6,7 (2 numbers)
                        .ToList() // List<int>
                    )
                    .ToList(); // List<List<int>>
                groups.Add(values);
            }

            return groups;
        }

        public void prob1()
        {
            var groups = init();

            int fullOverlap = 0;
            foreach (var group in groups)
            {
                var member1 = group[0];
                var member2 = group[1];

                if ((member1[0] <= member2[0] && member1[^1] >= member2[^1]) // member 1 fully overlap member 2
                    || (member2[0] <= member1[0] && member2[^1] >= member1[^1]) // member 2 fully overlap member 1
                )
                {
                    fullOverlap++;
                }
            }

            Console.WriteLine(fullOverlap);
        }

        public void prob2()
        {

            init();

        }
    }
}