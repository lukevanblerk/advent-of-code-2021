using System;
using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day3;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class Day3Tests
    {
        private ISolver _solver;

        [SetUp]
        public void Setup()
        {
            _solver = new Day3Solver();
        }

        [Test]
        public void TestPart1()
        {
            // Arrange
            var input = new Input(day: 3);
            
            // Act
            var result = _solver.SolvePart1(input);
            
            // Assert
            Console.WriteLine(result);
        }

        [Test]
        public void TestPart2()
        {
            // Arrange
            var input = new Input(day: 3);
            
            // Act
            var result = _solver.SolvePart2(input);
            
            // Assert
            Console.WriteLine(result);
        }
    }
}