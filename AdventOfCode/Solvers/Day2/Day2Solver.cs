using System;
using System.Linq;

namespace AdventOfCode.Solvers.Day2
{
    public class Day2Solver : ISolver
    {
        public string SolvePart1(Input input)
        {
            var commands = CreateInstructions(input);

            var downwardMovement = 0;
            var forwardMovement = 0;
            foreach (var command in commands)
            {
                downwardMovement += command.DownwardMovement;
                forwardMovement += command.ForwardMovement;
            }

            return (downwardMovement * forwardMovement).ToString();
        }

        private SubmarineCommand[] CreateInstructions(Input input)
        {
            return input.AsArrayOfString().Select(i => new SubmarineCommand(i)).ToArray();
        }

        public string SolvePart2(Input input)
        {
            throw new System.NotImplementedException();
        }
    }
}