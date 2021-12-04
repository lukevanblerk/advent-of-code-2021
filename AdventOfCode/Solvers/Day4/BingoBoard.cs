using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day4
{
    public class BingoBoard
    {
        private List<BingoNumber> _numbers;
        
        public BingoBoard(string[] boardInput)
        {
            _numbers = new List<BingoNumber>();

            for (int row = 0; row < boardInput.Length; row++)
            {
                var boardRow = boardInput[row].Trim().Replace("  ", " ").Split(new[] {" "}, StringSplitOptions.None);
                for (int col = 0; col < boardRow.Length; col++)
                {
                    var number = Convert.ToInt32(boardRow[col]);
                    _numbers.Add(new BingoNumber(row, col, number));
                }
            }
        }

        public void MarkNumber(int numberToMark)
        {
            var bingoNumber = _numbers.FirstOrDefault(n => n.Number == numberToMark);
            if (bingoNumber != null)
            {
                bingoNumber.IsMarked = true;
            }
        }

        public bool IsWinner()
        {
            var cols = _numbers.GroupBy(n => n.Col, n => n.IsMarked, (Col, IsMarked) => new {Col, IsMarked}).ToList();
            var hasAllColsMarked = cols.Any(c => c.IsMarked.All(isMarked => isMarked));

            if (hasAllColsMarked)
            {
                return true;
            }
            var rows = _numbers.GroupBy(n => n.Row, n => n.IsMarked, (Row, IsMarked) => new {Row, IsMarked}).ToList();
            var hasAllRowsMarked = rows.Any(r => r.IsMarked.All(isMarked => isMarked));

            return hasAllRowsMarked;
        }

        public int SumUnmarked()
        {
            return _numbers.Where(n => !n.IsMarked).Select(n => n.Number).Sum();
        }
    }
}