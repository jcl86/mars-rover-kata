using System;
using Xunit;
using MarsRover.Core;
using FluentAssertions;

namespace MarsRover.Tests
{
    public class PositionShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData("  something   ")]
        [InlineData("  something  1")]
        [InlineData("1, 2, E")]
        [InlineData("1 2 3")]
        [InlineData("1 n")]
        [InlineData("1 2 a")]
        [InlineData("-1 2 N")]
        [InlineData("5 -1 N")]
        public void Fail_to_initialize(string input)
        {
            Action action = () => new Position(Input.FromString(input));
            action.Should().Throw<ArgumentException>();
        }
    }
}
