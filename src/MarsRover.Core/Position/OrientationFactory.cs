using System;

namespace MarsRover.Core
{
    public static class OrientationFactory
    {
        public static Orientation CreateFromString(string orientation)
        {
            return orientation switch
            {
                "N" => Orientation.N,
                "S" => Orientation.S,
                "W" => Orientation.W,
                "E" => Orientation.E,
                _ => throw new ArgumentException($"{orientation} could not be converted to {nameof(Orientation)}")
            };
        }
    }
}
