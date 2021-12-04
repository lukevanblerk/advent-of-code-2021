using System;
using AdventOfCode.Solvers;
using AdventOfCode.Solvers.Day4;
using NUnit.Framework;

namespace AdventOfCodeTests
{
    public class Day4Tests
    {
        private ISolver _solver;

        [SetUp]
        public void Setup()
        {
            _solver = new Day4Solver();
        }

        [Test]
        public void TestPart1()
        {
            // Arrange
            var input = new Input(day: 4);
            
            // Act
            var result = _solver.SolvePart1(input);
            
            // Assert
            Console.WriteLine(result);
        }

        [Test]
        public void TestPart2()
        {
            // Arrange
            var input = new Input(day: 4);
            
            // Act
            var result = _solver.SolvePart2(input);
            
            // Assert
            Console.WriteLine(result);
        }
    }
}