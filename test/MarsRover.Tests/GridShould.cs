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
        [InlineData("0,0")]
        [InlineData("00")]
        [InlineData("-1 4")]
        [InlineData("4 -3")]
        public void Fail_to_initialize(string input)
        {
            Action action = () => new Grid(Input.FromString(input));
            action.Should().Throw<ArgumentException>();
        }

        [Theory]
        [InlineData(5, 4)]
        [InlineData(1, 1)]
        [InlineData(1, 4)]
        [InlineData(0, 0)]
        [InlineData(5, 0)]
        public void Located_coordinates(int x, int y)
        {
            var grid = new Grid(Input.FromString("5 4"));
            bool canBeLocated = grid.CanBeLocated(new Coordinates(x, y));
            canBeLocated.Should().BeTrue();
        }

        [Theory]
        [InlineData(4, 6)]
        [InlineData(5, 5)]
        [InlineData(8, 21)]
        public void Fail_to_locate_coordinates(int x, int y)
        {
            var grid = new Grid(Input.FromString("5 4"));
            bool canBeLocated = grid.CanBeLocated(new Coordinates(x, y));
            canBeLocated.Should().BeFalse();
        }
    }
}
