using System;

namespace AdventOfCode.Solvers.Day1
{
    public class Day1Solver : ISolver
    {
        public string SolvePart1(Input input)
        {
            var depths = input.AsArrayOfInt();

            int increased = 0;
            for (int i = 0; i < depths.Length - 1; i++)
            {
                if (depths[i] < depths[i + 1])
                {
                    increased++;
                }
            }

            return increased.ToString();
        }

        public string SolvePart2(Input input)
        {
            throw new NotImplementedException();
        }
    }
}
