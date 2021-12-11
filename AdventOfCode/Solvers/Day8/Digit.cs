using System.Linq;

namespace AdventOfCode.Solvers.Day8
{
    public class Digit
    {
        public readonly string SignalPattern;

        public int Value => GetValue();

        public bool CountInPart1
        {
            get
            {
                var value = GetValue();
                if (value == 1 || value == 4 || value == 7 || value == 8)
                {
                    return true;
                }
                return false;
            }
        }

        public Digit(string signalPattern)
        {
            SignalPattern = string.Concat(signalPattern.OrderBy(s => s));
        }

        public int GetValue()
        {
            int value;
            switch (SignalPattern.Length)
            {
                case 2:
                    value = 1;
                    break;
                case 3:
                    value = 7;
                    break;
                case 4:
                    value = 4;
                    break;
                case 7:
                    value = 8;
                    break;
                default:
                    value = 0;
                    break;
            }

            return value;
        }
    }
}