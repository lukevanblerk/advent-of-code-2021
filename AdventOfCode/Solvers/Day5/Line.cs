using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solvers.Day5
{
    public class Line
    {
        private readonly string _line;

        public readonly int X1;
        public readonly int X2;
        public readonly int Y1;
        public readonly int Y2;

        public bool IsDiagonal => !IsHorizontal && !IsVertical;
        public bool IsHorizontal => Y1 == Y2;
        public bool IsVertical => X1 == X2;

        private IList<Point> _points;
        
        public IList<Point> Points => _points;

        public Line(string line)
        {
            _line = line;
            var regex = new Regex(@"(\d+),(\d+) -> (\d+),(\d+)");
            var match = regex.Match(_line);

            X1 = Convert.ToInt32(match.Groups[1].Value);
            Y1 = Convert.ToInt32(match.Groups[2].Value);
            X2 = Convert.ToInt32(match.Groups[3].Value);
            Y2 = Convert.ToInt32(match.Groups[4].Value);

            CreatePoints();
        }

        private void CreatePoints()
        {
            if (IsDiagonal)
            {
                return;
            }
            _points = new List<Point>();
            if (IsHorizontal)
            {
                var startX = Math.Min(X1, X2);
                var finishX = Math.Max(X1, X2);
                for (var x = startX; x <= finishX; x++)
                {
                    _points.Add(new Point(x, Y1));
                }
            } 
            else if (IsVertical)
            {
                var startY = Math.Min(Y1, Y2);
                var finishY = Math.Max(Y1, Y2);
                for (var y = startY; y <= finishY; y++)
                {
                    _points.Add(new Point(X1, y));
                }
            }
        }

        public override string ToString()
        {
            return _line;
        }
    }
}