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

        public bool Is45Degress => (FinishX - StartX) == (FinishY - StartY);

        private int StartX => Math.Min(X1, X2);
        private int FinishX => Math.Max(X1, X2);
        private int StartY => Math.Min(Y1, Y2);
        private int FinishY => Math.Max(Y1, Y2);

        private bool IsDownLeft => Y1 < Y2 && X1 > X2;
        private bool IsDownRight => Y1 < Y2 && X1 < X2;
        private bool IsUpLeft => Y1 > Y2 && X1 > X2;
        private bool IsUpRight => Y1 > Y2 && X1 < X2;

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
            _points = new List<Point>();
            if (IsDiagonal && Is45Degress)
            {
                if (IsDownLeft)
                {
                    CreateDownLeftPoints();
                }
                else if (IsDownRight)
                {
                    CreateDownRightPoints();
                }
                else if (IsUpLeft)
                {
                    CreateUpLeftPoints();
                }
                else if (IsUpRight)
                {
                    CreateUpRightPoints();
                }
            }
            if (IsHorizontal)
            {
                for (var x = StartX; x <= FinishX; x++)
                {
                    _points.Add(new Point(x, Y1));
                }
            }
            else if (IsVertical)
            {
                for (var y = StartY; y <= FinishY; y++)
                {
                    _points.Add(new Point(X1, y));
                }
            }
        }

        private void CreateDownLeftPoints()
        {
            for (int x = X1, y = Y1; x >= X2; x--, y++)
            {
                _points.Add(new Point(x, y));
            }
        }

        private void CreateDownRightPoints()
        {
            for (int x = X1, y = Y1; x <= X2; x++, y++)
            {
                _points.Add(new Point(x, y));
            }
        }

        private void CreateUpRightPoints()
        {
            for (int x = X1, y = Y1; x <= X2; x++, y--)
            {
                _points.Add(new Point(x, y));
            }
        }

        private void CreateUpLeftPoints()
        {
            for (int x = X1, y = Y1; x >= X2; x--, y--)
            {
                _points.Add(new Point(x, y));
            }
        }
        
        public override string ToString()
        {
            return _line;
        }
    }
}