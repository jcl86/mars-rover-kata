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

        public Result Move(Input input)
        {
            var instructions = input.ParseToInstructionList();
            var result = path.Execute(startingPosition, grid, instructions);
            startingPosition = null;
            return result;
        }
    }

    public class RoverLocator
    {
        private readonly GridFinder gridFinder;

        public RoverLocator(GridFinder gridFinder)
        {
            this.gridFinder = gridFinder;
        }

        public Position Locate(Guid gridId, Model.InputRequest request)
        {
            var grid = gridFinder.Find(gridId);

            var position = new Position(Input.FromString(request.Input));
            if (!grid.CanBeLocated(position.Coordinates))
            {
                throw new ArgumentException($"{position.Coordinates} can not be located into grid: {grid}");
            }
            return position;
        }
    }
}
