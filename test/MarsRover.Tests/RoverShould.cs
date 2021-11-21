using Xunit;
using MarsRover.Core;
using FluentAssertions;

namespace MarsRover.Tests
{
    public class RoverShould
    {
        [Fact]
        public void Fulfill_secuence()
        {
            var mars = new Rover(5 3);
            mars.Locate("1 1 E");
            var result = mars.Move("RFRFRFRF");
            result.Coordinates.Should().BeEquivalentTo("1 1 E");
            result.IsLost.Should().BeFalse();

            mars.Locate("3 2 N");
            result = mars.Move("FRRFLLFFRRFLL");
            result.ToString().Should().BeEquivalentTo("3 3 N LOST");

            mars.Locate("0 3 W");
            result = mars.Move("LLFFFRFLFL");
            result.ToString().Should().BeEquivalentTo("4 2 N");
        }
    }
}
