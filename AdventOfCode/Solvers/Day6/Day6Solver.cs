using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day6
{
    public class Day6Solver : ISolver
    {
        public string SolvePart1(Input input)
        {
            var lanternFishes = CreateLanternFishes(input.AsText());

            AddDays(80, lanternFishes);
            
            return lanternFishes.Count().ToString();
        }

        private void AddDays(int days, List<LanternFish> lanternFishes)
        {
            for (int i = 0; i < days; i++)
            {
                foreach (var lanternFish in lanternFishes.ToArray())
                {
                    var newLanternFish = lanternFish.AddDay();
                    if (newLanternFish != null)
                    {
                        lanternFishes.Add(newLanternFish);
                    }
                }
            }
        }

        private List<LanternFish> CreateLanternFishes(string input)
        {
            var lanternFishes = new List<LanternFish>();
            foreach (var age in input.Split(',').Select(i => Convert.ToInt32(i)))
            {
                lanternFishes.Add(new LanternFish(age));
            }
            return lanternFishes;
        }


        public string SolvePart2(Input input)
        {
            throw new System.NotImplementedException();
        }
    }
}