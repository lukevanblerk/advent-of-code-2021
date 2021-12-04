using System;
using System.Collections.Generic;
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
        
        public string SolvePart2(Input input)
        {
            var diagnosticReport = input.AsArrayOfString();

            var binaryOxygenGeneratorRating = CalculateOxygenGeneratorRating(diagnosticReport);
            var oxygenGeneratorRating = Convert.ToInt32(binaryOxygenGeneratorRating, 2);

            var binaryCO2ScrubberRating = CalculateCO2ScrubberRating(diagnosticReport);
            var co2ScrubberRating = Convert.ToInt32(binaryCO2ScrubberRating, 2);

            return (oxygenGeneratorRating * co2ScrubberRating).ToString();
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

        private string CalculateGammaRate(string[] diagnosticReport)
        {
            string gammaRate = String.Empty;

            for (int i = 0; i < diagnosticReport.First().Length; i++)
            {
                gammaRate += FindMostCommonChar(diagnosticReport, i);
            }

            return gammaRate;
        }

        private string FindMostCommonChar(IEnumerable<string> diagnosticReport, int i, string defaultBit = null)
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

            if (zeros == ones)
            {
                return defaultBit;
            }

            return zeros > ones ? "0" : "1";
        }

        private string FindLeastCommonChar(IEnumerable<string> diagnosticReport, int i, string defaultBit = null)
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

            if (zeros == ones)
            {
                return defaultBit;
            }

            return zeros > ones ? "1" : "0";
        }
        
        private string CalculateOxygenGeneratorRating(string[] diagnosticReport)
        {
            var filteredReport = diagnosticReport.ToList();
            for (int i = 0; i < diagnosticReport.First().Length; i++)
            {
                var bit = FindMostCommonChar(filteredReport, i, "1");
                filteredReport = FilterReportData(filteredReport, i, bit);

                if (filteredReport.Count == 1)
                {
                    return filteredReport.First();
                }
            }

            return string.Empty;
        }

        private string CalculateCO2ScrubberRating(string[] diagnosticReport)
        {
            var filteredReport = diagnosticReport.ToList();
            for (int i = 0; i < diagnosticReport.First().Length; i++)
            {
                var bit = FindLeastCommonChar(filteredReport, i, "0");
                filteredReport = FilterReportData(filteredReport, i, bit);

                if (filteredReport.Count == 1)
                {
                    return filteredReport.First();
                }
            }

            return string.Empty;
        }

        private List<string> FilterReportData(List<string> filteredReport, int i, string bit)
        {
            return filteredReport.Where(f => f[i].ToString() == bit).ToList();
        }
    }
}