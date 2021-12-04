namespace AdventOfCode.Solvers.Day4
{
    public class BingoNumber
    {   
        public int Row { get; }
        public int Col { get; }
        public int Number { get; }
        public bool IsMarked { get; set; }
        
        public BingoNumber(int row, int col, int number)
        {
            Row = row;
            Col = col;
            Number = number;
        }
    }
}