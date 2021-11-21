using System;

namespace MarsRover.Core
{
    public static class Rotater
    {
        public static Orientation TurnLeft(this Orientation orientation)
        {
            return orientation switch
            {
                Orientation.N => Orientation.W,
                Orientation.S => Orientation.E,
                Orientation.E => Orientation.N,
                Orientation.W => Orientation.S,
                _ => throw new NotImplementedException()
            };
        }

        public static Orientation TurnRight(this Orientation orientation)
        {
            return orientation switch
            {
                Orientation.N => Orientation.E,
                Orientation.S => Orientation.W,
                Orientation.E => Orientation.S,
                Orientation.W => Orientation.N,
                _ => throw new NotImplementedException()
            };
        }
    }
}
