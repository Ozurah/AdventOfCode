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
            // result = score
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

        private static Dictionary<String, Shape> mapActionProb1 = new Dictionary<string, Shape>()
        {
            { "A", Shape.Rock },
            { "B", Shape.Paper },
            { "C", Shape.Scissors },
            { "X", Shape.Rock },
            { "Y", Shape.Paper },
            { "Z", Shape.Scissors },
        };

        private static Dictionary<String, Shape> mapActionProb2 = new Dictionary<string, Shape>()
        {
            { "A", Shape.Rock },
            { "B", Shape.Paper },
            { "C", Shape.Scissors },
        };

        private static Dictionary<String, ScoreResult> mapResultProb2 = new Dictionary<string, ScoreResult>()
        {
            { "X", ScoreResult.Lose },
            { "Y", ScoreResult.Draw },
            { "Z", ScoreResult.Win },
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
                // improvement would be by using .TryGetValue or LINQ .FirstOrDefault
                round.Add(new Tuple<Shape, Shape>(mapActionProb1[play[0]], mapActionProb1[play[1]]));
            }

            return round;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns>Tuple : Opponent, My</returns>
        private static List<Tuple<Shape, ScoreResult>> initProb2()
        {
            String file = Program.inputPath + @"/day2.txt";

            List<String> lines = System.IO.File.ReadAllLines(file).ToList();

            var round = new List<Tuple<Shape, ScoreResult>>();

            foreach (String line in lines)
            {
                var play = line.Split(" ");
                // Assuming the input is in the map (no non-existing key)
                // improvement would be by using .TryGetValue or LINQ .FirstOrDefault
                round.Add(new Tuple<Shape, ScoreResult>(mapActionProb2[play[0]], mapResultProb2[play[1]]));
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
            var rounds = initProb2();

            int sum = 0;
            foreach (var round in rounds)
            {
                sum += (int)round.Item2;

                if (round.Item2 == ScoreResult.Draw)
                    sum += (int)round.Item1; // Same result as played by opponent
                else if (round.Item2 == ScoreResult.Lose)
                    sum += (int)winAgainst[round.Item1];
                else
                    sum += (int)winAgainst.First(x => x.Value == round.Item1).Key;
            }

            Console.WriteLine(sum);
        }
    }
}