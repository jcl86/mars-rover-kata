using System;
using Xunit;
using MarsRover.Core;
using FluentAssertions;

namespace MarsRover.Tests
{
    public class GridShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData("  something   ")]
        [InlineData("  something  1 2 ")]
        [InlineData("1, 2")]
        [InlineData("1 2 3")]
        [InlineData("1 n")]
        [InlineData("1 2 a")]
        [InlineData("0 0")]
        [InlineData("-1 4")]
        [InlineData("4 -3")]
        public void Fail_to_initialize(string input)
        {
            Action action = () => new Grid(new InputInstructions(input));
            action.Should().Throw<ArgumentException>();
        }
    }
}
