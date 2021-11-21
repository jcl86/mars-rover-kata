using System;
using System.Linq;

namespace MarsRover.Core
{
    public class Position
    {
        public Coordinates Coordinates { get; }
        public Orientation Orientation { get; }

        public Position(InputInstructions instructions)
        {
            var slices = instructions.Slice(' ');
            if (slices.Count() != 3)
            {
                throw new ArgumentException($"{instructions} is not a valid value for position. TThree wo numbers separated by a space must be provided");
            }
            if (!int.TryParse(slices.ElementAt(0), out int x))
            {
                throw new ArgumentException($"{slices.ElementAt(0)} can not be converted to number");
            }

            if (!int.TryParse(slices.ElementAt(1), out int y))
            {
                throw new ArgumentException($"{slices.ElementAt(1)} can not be converted to number");
            }

            if (!Enum.TryParse(slices.ElementAt(2), out Orientation orientation))
            {
                throw new ArgumentException($"{slices.ElementAt(2)} can not be converted to Orientation");
            }

            Coordinates = new Coordinates(x, y);
            Orientation = orientation;
        }

        internal Position CanMove(Instruction instruction, Grid grid)
        {
            grid.CanBeLocated()
        }

        internal Position Move(Instruction instruction)
        {
            X
        }
    }
}
