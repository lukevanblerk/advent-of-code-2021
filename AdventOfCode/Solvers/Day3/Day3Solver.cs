using System;
using System.Linq;

namespace AdventOfCode.Solvers.Day3
{
    public class Day3Solver : ISolver
    {
        public string SolvePart1(Input input)
        {
            var diagnosticReport = input.AsArrayOfString();

            var binaryGammaRate = CalculateGammaRate(diagnosticReport);
            var gammaRate = Convert.ToInt32(binaryGammaRate, 2);
            var binaryEpsilonRate = CalculateEpsilonFromGammaRate(binaryGammaRate);
            var epsilonRate = Convert.ToInt32(binaryEpsilonRate, 2);

            return (gammaRate * epsilonRate).ToString();
        }

        private string CalculateEpsilonFromGammaRate(string binaryGammaRate)
        {
            var epsilonRate = string.Empty;
            foreach (var bit in binaryGammaRate)
            {
                epsilonRate += bit == '0' ? "1" : "0";
            }
            return epsilonRate;
        }

        public string SolvePart2(Input input)
        {
            throw new System.NotImplementedException();
        }

        private string CalculateGammaRate(string[] diagnosticReport)
        {
            string gammaRate = String.Empty;

            for (int i = 0; i < diagnosticReport.First().Length; i++)
            {
                gammaRate += FindMostCommonChar(diagnosticReport, i);
            }

            return gammaRate;
        }

        private string FindMostCommonChar(string[] diagnosticReport, int i)
        {
            var zeros = 0;
            var ones = 0;
            foreach (var reportData in diagnosticReport)
            {
                if (reportData[i] == '0')
                {
                    zeros++;
                }
                else
                {
                    ones++;
                }
            }

            return zeros > ones ? "0" : "1";
        }
    }
}