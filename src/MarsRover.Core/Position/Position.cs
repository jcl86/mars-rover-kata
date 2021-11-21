using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Core
{
    public class Position
    {
        public Coordinates Coordinates { get; }
        public Orientation Orientation { get; }

        public Position(Input instructions)
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

            Orientation = OrientationFactory.CreateFromString(slices.ElementAt(2));

            Coordinates = new Coordinates(x, y);
        }



        public Position(Coordinates coordinates, Orientation orientation)
        {
            Coordinates = coordinates;
            Orientation = orientation;
        }

        internal Position Move(Instruction instruction)
        {
            return instruction switch
            {
                Instruction.F => GoFordward(),
                Instruction.L => TurnLeft(),
                Instruction.R => TurnRight(),
                _ => throw new NotImplementedException()
            };
        }

        private Position TurnLeft() => new Position(Coordinates, Orientation.TurnLeft());
        private Position TurnRight() => new Position(Coordinates, Orientation.TurnRight());

        private Position GoFordward()
        {
            return Orientation switch
            {
                Orientation.N => new Position(Coordinates.GoNorth(), Orientation),
                Orientation.S => new Position(Coordinates.GoSouth(), Orientation),
                Orientation.E => new Position(Coordinates.GoEast(), Orientation),
                Orientation.W => new Position(Coordinates.GoWest(), Orientation),
                _ => throw new NotImplementedException()
            };
        }

        internal bool IsOver(IEnumerable<Coordinates> forbiddenLocations)
        {
            return forbiddenLocations.Any(forbiddenLocation => Coordinates == forbiddenLocation);
        }

        public override string ToString() => $"{Coordinates} {Orientation}";
    }
}
