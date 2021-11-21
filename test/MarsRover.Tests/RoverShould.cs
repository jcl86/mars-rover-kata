using Xunit;
using MarsRover.Core;
using FluentAssertions;

namespace MarsRover.Tests
{
    public class RoverShould
    {
        private readonly RoverRider rover;

        public RoverShould()
        {
            var repository = new InMemoryLossesRepository();
            var path = new PathMaker(repository);
            rover = new RoverRider(path);
        }

        [Fact]
        public void Fulfill_secuence()
        {
            var grid = new Grid(Input.FromString("5 3"));
            rover.Start(grid);
            rover.Locate(Input.FromString("1 1 E"));
            var result = rover.Move(Input.FromString("RFRFRFRF"));
            result.ToString().Should().Be("1 1 E");

            rover.Locate(Input.FromString("3 2 N"));
            result = rover.Move(Input.FromString("FRRFLLFFRRFLL"));
            result.ToString().Should().Be("3 3 N LOST");

            rover.Locate(Input.FromString("0 3 W"));
            result = rover.Move(Input.FromString("LLFFFRFLFL"));
            result.ToString().Should().Be("4 2 N");
        }
    }
}
