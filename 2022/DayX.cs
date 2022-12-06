using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022
{
    class DayX : IDay
    {

        private const string INPUT_BASE_NAME = "dayX";
        private void init()
        {
            String file = Program.inputPath + @"/"+INPUT_BASE_NAME+".txt";
            // file = Program.inputPath + @"/"+INPUT_BASE_NAME+"_simple.txt";

            List<String> lines = System.IO.File.ReadAllLines(file).ToList();

            foreach (String line in lines)
            {
                
            }
        }

        public void prob1()
        {
            init();
            
        }

        public void prob2()
        {

            init();

        }
    }
}