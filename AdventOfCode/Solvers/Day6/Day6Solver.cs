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
        
        public string SolvePart2(Input input)
        { 
            var inputFishes = input.AsText().Split(',').Select(i => Convert.ToInt32(i));
            var daysLeftCount = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            foreach (var fishDaysLeft in inputFishes)
            {
                daysLeftCount[fishDaysLeft]++;
            }

            for (int i = 0; i < 256; i++)
            {
                var previousDayCounts = new double[9];
                daysLeftCount.CopyTo(previousDayCounts, 0);

                daysLeftCount[0] = previousDayCounts[1];
                daysLeftCount[1] = previousDayCounts[2];
                daysLeftCount[2] = previousDayCounts[3];
                daysLeftCount[3] = previousDayCounts[4];
                daysLeftCount[4] = previousDayCounts[5];
                daysLeftCount[5] = previousDayCounts[6];
                daysLeftCount[6] = previousDayCounts[7] + previousDayCounts[0];
                daysLeftCount[7] = previousDayCounts[8];
                daysLeftCount[8] = previousDayCounts[0];
            }

            var totalFish = daysLeftCount.Sum(d => d);

            return totalFish.ToString();
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
    }
}