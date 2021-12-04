using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day4
{
    public class Day4Solver : ISolver
    {
        public string SolvePart1(Input input)
        {
            var bingoNumbers = CreateBingoNumbers(input);

            var boards = CreateBingoBoards(input);
            
            
            int score = RunGame(bingoNumbers, boards);

            return score.ToString();
        }

        private int RunGame(int[] bingoNumbers, BingoBoard[] boards)
        {
            foreach (var bingoNumber in bingoNumbers)
            {
                foreach (var bingoBoard in boards)
                {
                    bingoBoard.MarkNumber(bingoNumber);
                    if (bingoBoard.IsWinner())
                    {
                        var score = bingoBoard.SumUnmarked() * bingoNumber;
                        
                        return score;
                    }
                }
            }

            return 0;
        }

        private int[] CreateBingoNumbers(Input input)
        {
            return input.AsArrayOfString().First()
                .Split(new[] { "," }, StringSplitOptions.None)
                .Select(i => Convert.ToInt32(i)).ToArray();
        }

        private BingoBoard[] CreateBingoBoards(Input input)
        {
            var boards = new List<BingoBoard>();
            var inputRows = input.AsText().Split(new[] {"\n\n"}, StringSplitOptions.None);

            foreach (var boardInput in inputRows.Skip(1))
            {
                boards.Add(new BingoBoard(boardInput.Split(new[] {"\n"}, StringSplitOptions.None)));
            }

            return boards.ToArray();
        }

        public string SolvePart2(Input input)
        {
            throw new System.NotImplementedException();
        }
    }
}