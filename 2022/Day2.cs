using System;
using System.Linq;

namespace AdventOfCode2022
{
    class Day2
    {

        enum Shape
        {
            // play = score
            Rock = 1,
            Paper = 2,
            Scissors = 3,
        }

        enum ScoreResult
        {
            Win = 6,
            Draw = 3,
            Lose = 0,
        }

        private static Dictionary<Shape, Shape> winAgainst = new Dictionary<Shape, Shape>()
        {
            { Shape.Rock, Shape.Scissors },
            { Shape.Paper, Shape.Rock },
            { Shape.Scissors, Shape.Paper },
        };

        private static Dictionary<String, Shape> mapAction = new Dictionary<string, Shape>()
            {
                { "A", Shape.Rock },
                { "B", Shape.Paper },
                { "C", Shape.Scissors },
                { "X", Shape.Rock },
                { "Y", Shape.Paper },
                { "Z", Shape.Scissors },
            };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns>Tuple : Opponent, My</returns>
        private static List<Tuple<Shape, Shape>> init()
        {
            String file = Program.inputPath + @"/day2.txt";

            List<String> lines = System.IO.File.ReadAllLines(file).ToList();

            var round = new List<Tuple<Shape, Shape>>();

            foreach (String line in lines)
            {
                var play = line.Split(" ");
                // Assuming the input is in the map (no non-existing key)
                round.Add(new Tuple<Shape, Shape>(mapAction[play[0]], mapAction[play[1]]));
            }

            return round;
        }

        public static void prob1()
        {
            var rounds = init();

            int sum = 0;
            foreach (var round in rounds)
            {
                sum += (int)round.Item2;

                if (round.Item2 == round.Item1)
                    sum += (int)ScoreResult.Draw;
                else if (winAgainst[round.Item2] == round.Item1)
                    sum += (int)ScoreResult.Win;
                else
                    sum += (int)ScoreResult.Lose;
            }

            Console.WriteLine(sum);
        }

        public static void prob2()
        {

        }
    }
}