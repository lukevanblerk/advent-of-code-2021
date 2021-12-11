using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day7
{
    public class Day7Solver : ISolver
    {
        private readonly Dictionary<int, int> _fuelCostCache = new();

        public string SolvePart1(Input input)
        {
            var crabPositions = input.FirstLineAsArrayOfInt();
            var highestPosition = crabPositions.Max();
            var fuelCosts = new Dictionary<int, int>();

            for (int position = 1; position <= highestPosition; position++)
            {
                foreach (var crabPosition in crabPositions)
                {
                    if (!fuelCosts.ContainsKey(position))
                    {
                        fuelCosts[position] = 0;
                    }
                    fuelCosts[position] += CalculatePart1FuelCost(position, crabPosition);
                }
            }

            return fuelCosts.Min(f => f.Value).ToString();
        }

        public string SolvePart2(Input input)
        {
            var crabPositions = input.FirstLineAsArrayOfInt();
            var highestPosition = crabPositions.Max();
            var fuelCosts = new Dictionary<int, int>();

            for (int position = 1; position <= highestPosition; position++)
            {
                foreach (var crabPosition in crabPositions)
                {
                    if (!fuelCosts.ContainsKey(position))
                    {
                        fuelCosts[position] = 0;
                    }
                    fuelCosts[position] += CalculatePart2FuelCost(position, crabPosition);
                }
            }

            return fuelCosts.Min(f => f.Value).ToString();
        }

        private int CalculatePart2FuelCost(int position, int crabPosition)
        {
            var totalSteps = CalculatePart1FuelCost(position, crabPosition);
            if (_fuelCostCache.ContainsKey(totalSteps))
            {
                return _fuelCostCache[totalSteps];
            }
            
            var fuelCost = 0;

            for (int step = 1; step <= totalSteps; step++)
            {
                fuelCost += step;
            }
            _fuelCostCache.Add(totalSteps, fuelCost);

            return fuelCost;
        }

        private int CalculatePart1FuelCost(int position, int crabPosition)
        {
            if (position == crabPosition)
            {
                return 0;
            }
            if (position > crabPosition)
            {
                return position - crabPosition;
            }
            return crabPosition - position;
        }
    }
}