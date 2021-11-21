using System;

namespace MarsRover.Core
{
    public class Rover
    {
        private readonly Grid grid;
        public Position currentPosition;

        public Rover(Grid grid)
        {
            this.grid = grid;
        }

        public void Locate(InputInstructions input)
        {
            var position = new Position(input);
            if (grid.CanBeLocated(position.Coordinates))
            {
                throw new ArgumentException($"{position.Coordinates} can not be located into grid: {grid}");
            }
            currentPosition = position;
        }

        public Result Move(InputInstructions input)
        {
            var instructions = input.ParseToInstructionList();
            foreach (var instruction in instructions)
            {
                var nextPosition = currentPosition.Move(instruction);
            }
        }
    }
}
