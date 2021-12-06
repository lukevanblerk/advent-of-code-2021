namespace AdventOfCode.Solvers.Day6
{
    public class LanternFish
    {
        private int _age;
        
        public int Age 
        {
            get { return _age;  }
        }

        public LanternFish(int age = 8)
        {
            _age = age;
        }

        public LanternFish AddDay()
        {
            if (_age == 0)
            {
                _age = 6;
                return new LanternFish();
            }
            _age--;
            
            return null;
        }

        public override string ToString()
        {
            return $"Age: {_age}";
        }
    }
}