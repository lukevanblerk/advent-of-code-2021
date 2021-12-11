using System.Collections.Generic;

namespace AdventOfCode.Solvers.Day8
{
    public class Day8Solver : ISolver
    {
        public string SolvePart1(Input input)
        {
            var part1Count = 0;
            foreach (var entryInput in input.AsArrayOfString())
            {
                var entry = new Entry(entryInput);
                part1Count += entry.Part1Count();
            }

            return part1Count.ToString();
        }

        public string SolvePart2(Input input)
        {
            var totalOutput = 0;
            foreach (var entryInput in input.AsArrayOfString())
            {
                var entry = new Entry(entryInput);
                totalOutput += entry.CalculateOutput();
                //part2Count += entry.Part2Count();
            }

            return totalOutput.ToString();
        }
    }
}