using System;

namespace MarsRover.Core
{
    public record Coordinates
    {
        private const int MaxValue = 50;

        public int X { get; }
        public int Y { get; }

        public Coordinates(int x, int y)
        {
            if (x < 0)
            {
                throw new ArgumentException($"{x} is not valid value for X. Must be a value between 0 and {MaxValue}");
            }

            if (y < 0)
            {
                throw new ArgumentException($"{y} is not valid value for Y.  Must be a value between 0 and {MaxValue}");
            }

            X = x;
            Y = y;
        }
        

    }
}
