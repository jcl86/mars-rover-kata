using System;
using System.Linq;

namespace MarsRover.Core
{
    public record Grid
    {
        public Guid Id { get; }
        public Point Width { get; }
        public Point Height { get; }

        public Grid(Guid id, int width, int height)
        {
            Id = id;
            Width = new Point(width);
            Height = new Point(height);
        }

        public Grid(Input instructions)
        {
            var slices = instructions.Slice(' ');
            if (slices.Count() != 2)
            {
                throw new ArgumentException($"{instructions} is not a valid value for the Grid. Two numbers separated by a space must be provided");
            }
            if (!int.TryParse(slices.ElementAt(0), out int widthResult))
            {
                throw new ArgumentException($"{slices.ElementAt(0)} can not be converted to number");
            }
            Width = new Point(widthResult);
            if (!int.TryParse(slices.ElementAt(1), out int heightResult))
            {
                throw new ArgumentException($"{slices.ElementAt(1)} can not be converted to number");
            }
            Height = new Point(heightResult);
            Id = Guid.NewGuid();
        }

        public bool CanBeLocated(Coordinates coordinates) => coordinates.FitsInWidth(Width) && coordinates.FitsInHeight(Height);
    }
}
