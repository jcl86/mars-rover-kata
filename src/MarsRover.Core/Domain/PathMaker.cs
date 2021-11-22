using System.Collections.Generic;

namespace MarsRover.Core
{
    public class PathMaker
    {
        private Position currentPosition;
        private readonly ILossesRepository lossesRepository;

        public PathMaker(ILossesRepository lossesRepository)
        {
            this.lossesRepository = lossesRepository;
        }

        public Result Execute(Position startingPosition, Grid grid, IEnumerable<Instruction> instructions)
        {
            var forbiddenLocations = lossesRepository.GetAllForbiddenLocations();
            currentPosition = startingPosition;
            foreach (var instruction in instructions)
            {
                var nextPosition = currentPosition.Move(instruction);
                if (!nextPosition.IsOver(forbiddenLocations))
                {
                    if (!grid.CanBeLocated(nextPosition.Coordinates))
                    {
                        lossesRepository.AddScent(nextPosition.Coordinates);
                        return Result.Lost(currentPosition);
                    }
                    else currentPosition = nextPosition;
                }
            }
            return Result.Create(currentPosition);
        }
    }
}
