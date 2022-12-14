using System;
using System.Linq;

namespace AdventOfCode2022
{
    class Program
    {
        public static string inputPath = @"./inputs/";
        static void Main(string[] args)
        {
            int runDay = 4;

            Dictionary<int, IDay> days = new Dictionary<int, IDay>()
            {
                { 1, new Day1() },
                { 2, new Day2() },
                { 3, new Day3() },
                { 4, new Day4() },
                { 5, new Day5() },
                { 6, new Day6() },
                // { 7, new Day7() },
                // { 8, new Day8() },
                // { 9, new Day9() },
                // { 10, new Day10() },
                // { 11, new Day11() },
                // { 12, new Day12() },
                // { 13, new Day13() },
                // { 14, new Day14() },
                // { 15, new Day15() },
                // { 16, new Day16() },
                // { 17, new Day17() },
                // { 18, new Day18() },
                // { 19, new Day19() },
                // { 20, new Day20() },
                // { 21, new Day21() },
                // { 22, new Day22() },
                // { 23, new Day23() },
                // { 24, new Day24() },
                // { 25, new Day25() },
            };


            Console.WriteLine("======== Day " + (runDay) + " ========");
            Console.WriteLine("--- Problem 1 ---");
            days[runDay].prob1();
            Console.WriteLine("--- Problem 2 ---");
            days[runDay].prob2();

        }
    }
}