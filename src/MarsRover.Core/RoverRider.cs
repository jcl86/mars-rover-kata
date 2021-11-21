using System;

namespace MarsRover.Core
{
    public class RoverRider
    {
        private readonly PathMaker path;
        private Grid grid;
        private Position startingPosition;

        public RoverRider(PathMaker path)
        {
            this.path = path;
        }

        public void Start(Grid grid)
        {
            this.grid = grid;
        }

        public void Locate(Input input)
        {
            EnsureGridIsInitialized();

            var position = new Position(input);
            if (!grid.CanBeLocated(position.Coordinates))
            {
                throw new ArgumentException($"{position.Coordinates} can not be located into grid: {grid}");
            }
            startingPosition = position;
        }

        public Result Move(Input input)
        {
            EnsureGridIsInitialized();
            EnsureStartingPositionIsSet();

            var instructions = input.ParseToInstructionList();
            var result = path.Execute(startingPosition, grid, instructions);
            startingPosition = null;
            return result;
        }

        private void EnsureGridIsInitialized()
        {
            if (grid is null)
            {
                throw new ArgumentException($"Grid must be initialized before locating or moving any robot");
            }
        }

        private void EnsureStartingPositionIsSet()
        {
            if (startingPosition is null)
            {
                throw new ArgumentException($"Starting position must be initialized before moving the robot");
            }
        }
    }
}
