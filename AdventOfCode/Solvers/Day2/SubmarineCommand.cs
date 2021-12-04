using System;

namespace AdventOfCode.Solvers.Day2
{
    public class SubmarineCommand
    {
        private readonly string _command;
        private readonly int _movement;

        public CommandType Type
        {
            get
            {
                if (_command.StartsWith("forward"))
                {
                    return CommandType.Forward;
                }
                else if (_command.StartsWith("down"))
                {
                    return CommandType.Down;
                }
                else
                {
                    return CommandType.Up;
                }
            }
        } 

        public int ForwardMovement
        {
            get
            {
                if (Type != CommandType.Forward) return 0;

                return _movement;
            }
        }

        public int DownwardMovement
        {
            get
            {
                switch (Type)
                {
                    case CommandType.Forward:
                        return 0;
                    case CommandType.Up:
                        return -_movement;
                    default:
                        return _movement;
                }
            }
        }

        public SubmarineCommand(string command)
        {
            _command = command;
            _movement = Convert.ToInt32(command.Split(' ')[1]);
        }
    }
}