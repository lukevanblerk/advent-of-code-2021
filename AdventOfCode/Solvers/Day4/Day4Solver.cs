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
            
            RunGame(bingoNumbers, boards, out int firstWinnerScore, out int lastWinnerScore);

            return firstWinnerScore.ToString();
        }

        public string SolvePart2(Input input)
        {
            var bingoNumbers = CreateBingoNumbers(input);

            var boards = CreateBingoBoards(input);
            
            RunGame(bingoNumbers, boards, out int firstWinnerScore, out int lastWinnerScore);

            return lastWinnerScore.ToString();
        }

        private void RunGame(int[] bingoNumbers, BingoBoard[] boards, out int firstWinnerScore, out int lastWinnerScore)
        {
            firstWinnerScore = 0;
            lastWinnerScore = 0;
            
            foreach (var bingoNumber in bingoNumbers)
            {
                foreach (var bingoBoard in boards.Where(b => !b.IsWinner()))
                {
                    bingoBoard.MarkNumber(bingoNumber);
                    if (bingoBoard.IsWinner())
                    {
                        if (firstWinnerScore == 0)
                        {
                            firstWinnerScore = bingoBoard.SumUnmarked() * bingoNumber;
                        }
                        lastWinnerScore = bingoBoard.SumUnmarked() * bingoNumber;
                    }
                }
            }
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
    }
}