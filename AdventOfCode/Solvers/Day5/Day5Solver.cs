using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day5
{
    public class Day5Solver : ISolver
    {
        public string SolvePart1(Input input)
        {
            var linesInput = input.AsArrayOfString();
            var lines = new List<Line>();

            foreach (var lineInput in linesInput)
            {
                lines.Add(new Line(lineInput));
            }

            var verticalOrHorizontalLines = lines.Where(l => !l.IsDiagonal).ToList();

            var areaCovered = new Dictionary<Point, int>();

            foreach (var line in verticalOrHorizontalLines)
            {
                MarkAreaCovered(areaCovered, line);
            }
            
            return areaCovered.Count(area => area.Value > 1).ToString();
        }

        private void MarkAreaCovered(Dictionary<Point, int> areaCovered, Line line)
        {
            foreach (var point in line.Points)
            {
                if (areaCovered.ContainsKey(point))
                {
                    areaCovered[point]++;
                }
                else
                {
                    areaCovered[point] = 1;
                }
            }
        }

        public string SolvePart2(Input input)
        {
            throw new System.NotImplementedException();
        }
    }
}