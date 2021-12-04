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
            var depths = input.AsArrayOfInt();

            int increased = 0;
            for (int i = 0; i < depths.Length - 3; i++)
            {
                var window1 = depths[i] + depths[i + 1] + depths[i + 2];
                var window2 = depths[i + 1] + depths[i + 2] + depths[i + 3];
                if (window1 < window2)
                {
                    increased++;
                }
            }
            return increased.ToString();
        }
    }
}
