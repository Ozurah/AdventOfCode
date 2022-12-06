using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    class Day6 : IDay
    {

        private const string INPUT_BASE_NAME = "day6";
        private List<string> init()
        {
            List<string> stream = new List<string>();

            String file = Program.inputPath + @"/" + INPUT_BASE_NAME + ".txt";
            // file = Program.inputPath + @"/" + INPUT_BASE_NAME + "_simple.txt";

            List<String> lines = System.IO.File.ReadAllLines(file).ToList();

            foreach (var line in lines)
            {
                stream.Add(line);
            }

            return stream;
        }

        public void prob1()
        {
            var streams = init();

            int markerSize = 4; // start-of-packet marker
            int markerIndex = 0;

            foreach (var stream in streams)
            {
                for (int i = 0; i < stream.Length - markerSize; i++)
                {
                    var distinctPart = stream.Substring(i, markerSize).Distinct().ToList();
                    if (distinctPart.Count == markerSize)
                    {
                        markerIndex = i + markerSize;
                        break;
                    }
                }

                Console.WriteLine(markerIndex);
            }
        }

        public void prob2()
        {
            var streams = init();

            int markerSize = 14; // start-of-message marker
            int markerIndex = 0;

            foreach (var stream in streams)
            {
                for (int i = 0; i < stream.Length - markerSize; i++)
                {
                    var distinctPart = stream.Substring(i, markerSize).Distinct().ToList();
                    if (distinctPart.Count == markerSize)
                    {
                        markerIndex = i + markerSize;
                        break;
                    }
                }

                Console.WriteLine(markerIndex);
            }
        }
    }
}