using System;
using System.Linq;

namespace MarsRover.Core
{
    public class Grid
    {
        private readonly int width;
        private readonly int height;

        public Grid(InputInstructions instructions)
        {
            var slices = instructions.Slice(' ');
            if (slices.Count() != 2)
            {
                throw new ArgumentException($"{instructions} is not a valid value for the Grid. Two numbers separated by a space must be provided");
            }
            if (!int.TryParse(slices.ElementAt(0), out width))
            {
                throw new ArgumentException($"{slices.ElementAt(0)} can not be converted to number");
            }

            if (!int.TryParse(slices.ElementAt(1), out height))
            {
                throw new ArgumentException($"{slices.ElementAt(1)} can not be converted to number");
            }
        }

        public bool CanBeLocated(Coordinates coordinates) => (coordinates.X > width || coordinates.Y > height);


        
    }
}
