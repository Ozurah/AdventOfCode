using System;
using System.Linq;

namespace AdventOfCode2022
{
    class Program
    {
        public static string inputPath = @"./inputs/";
        static void Main(string[] args)
        {
            Console.WriteLine("======== Day 1 ========");
            Console.WriteLine("--- Problem 1 ---");
            Day1.prob1();
            Console.WriteLine("--- Problem 2 ---");
            Day1.prob2();

            Console.WriteLine("======== Day 2 ========");
            Console.WriteLine("--- Problem 1 ---");
            Day2.prob1();
            Console.WriteLine("--- Problem 2 ---");
            Day2.prob2();

            Console.WriteLine("======== Day 3 ========");
            Console.WriteLine("--- Problem 1 ---");
            Day3.prob1();
            Console.WriteLine("--- Problem 2 ---");
            Day3.prob2();

            Console.WriteLine("======== Day 4 ========");
            Console.WriteLine("--- Problem 1 ---");
            // Day4.prob1();
            Console.WriteLine("--- Problem 2 ---");
            // Day4.prob2();
            
            Console.WriteLine("======== Day 5 ========");
            Console.WriteLine("--- Problem 1 ---");
            Day5.prob1();
            Console.WriteLine("--- Problem 2 ---");
            Day5.prob2();

        }
    }
}