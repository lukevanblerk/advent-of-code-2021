using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Solvers.Day8
{
    public class Entry
    {
        public List<Digit> SignalPatterns = new();
        public List<Digit> Output = new();
        private readonly Dictionary<int, Digit> Digits = new();
        private readonly Dictionary<char, char> Segments = new();

        private readonly string _entry;

        public Entry(string entry)
        {
            _entry = entry;
            var splitEntry = entry.Split(" | ");
            
            foreach (var signalPatternInput in splitEntry.First().Split(' '))
            {
                SignalPatterns.Add(new Digit(signalPatternInput));
            }
            
            foreach (var outputInput in splitEntry.Last().Split(' '))
            {
                Output.Add(new Digit(outputInput));
            }

            DeduceSegments();
        }

        public int Part1Count()
        {
            return Output.Count(o => o.CountInPart1);
        }

        public int CalculateOutput()
        {
            var outputString = string.Empty;
            foreach (var output in Output)
            {
                var digit = Digits.First(d => d.Value.SignalPattern == output.SignalPattern);
                outputString += digit.Key.ToString();
            }

            return Convert.ToInt32(outputString);
        }
        
        private void DeduceSegments()
        {
            Digits[1] = SignalPatterns.First(s => s.Value == 1);
            Digits[4] = SignalPatterns.First(s => s.Value == 4);
            Digits[7] = SignalPatterns.First(s => s.Value == 7);
            Digits[8] = SignalPatterns.First(s => s.Value == 8);
            
            DeduceA();
            DeduceG();
            DeduceE();
            DeduceD();
            DeduceB();
            DeduceF();
            DeduceC();
            Find2();
            Find6();
            Validate();
        }

        private void Find6()
        {
            Digits[6] = SignalPatterns.Where(s => s.SignalPattern.Length == 6)
                .Where(s => s != Digits[0])
                .First(s => s != Digits[9]);
        }

        private void Find2()
        {
            Digits[2] = SignalPatterns.Where(s => s.SignalPattern.Length == 5)
                .Where(s => s != Digits[3])
                .First(s => s != Digits[5]);
        }

        private void DeduceA()
        {
            Segments['a'] = Digits[7].SignalPattern.First(s => !Digits[1].SignalPattern.Any(o => o == s));
        }

        private void DeduceG()
        {
            var search = Digits[4].SignalPattern + Segments['a'];

            Digits[9] = SignalPatterns.Where(s => s.SignalPattern.Length == 6)
                .First(sp => search.All(s => sp.SignalPattern.Contains(s)));

            Segments['g'] = Digits[9].SignalPattern.First(s => !search.Contains(s));
        }

        private void DeduceE()
        {
            Digits[0] = SignalPatterns.Where(s => s.SignalPattern.Length == 6)
                .Where(s => s != Digits[9])
                .First(s => Digits[1].SignalPattern.All(ds => s.SignalPattern.Contains(ds)));
            
            Segments['e'] = Digits[0].SignalPattern.First(s => !Digits[9].SignalPattern.Contains(s));
        }

        private void DeduceD()
        {
            var search = Digits[1].SignalPattern + Segments['a'] + Segments['g'];

            Digits[3] = SignalPatterns.Where(s => s.SignalPattern.Length == 5)
                .First(sp => search.All(s => sp.SignalPattern.Contains(s)));
            
            Segments['d'] = Digits[3].SignalPattern.First(s => !search.Contains(s));
        }

        private void DeduceB()
        {
            Segments['b'] = Digits[4].SignalPattern
                .Where(sp => sp != Segments['d'])
                .First(sp => !Digits[1].SignalPattern.Contains(sp));
        }

        private void DeduceF()
        {
            Digits[5] = SignalPatterns.Where(s => s.SignalPattern.Length == 5)
                .First(sp => sp.SignalPattern.Contains(Segments['b']));

            var search = String.Concat(Segments['a'], Segments['b'], Segments['d'], Segments['g']);

            Segments['f'] = Digits[5].SignalPattern.First(sp => !search.Contains(sp));
        }

        private void DeduceC()
        {
            Segments['c'] = Digits[1].SignalPattern.First(s => s != Segments['f']);
        }

        private void Validate()
        {
            foreach (var segment in Segments)
            {
                if (Segments.Any(s => s.Key != segment.Key && s.Value == segment.Value))
                {
                    throw new Exception();
                }
            }
        }
    }
}

