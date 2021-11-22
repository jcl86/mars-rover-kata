using System;

namespace MarsRover.Core
{
    public record Point
    {
        private const int MaxValue = 50;

        public int Value { get; private set; }

        private Point() { }
        public Point(int value)
        {
            if (value < 0 || value > MaxValue)
            {
                throw new ArgumentException($"{value} is not valid value for a point. " +
                    $"Must be a value between 0 and {MaxValue}");
            }
            Value = value;
        }

        public Point Increment() => new Point() { Value = Value + 1 };
        public Point Decrement() => new Point() { Value = Value - 1 };

        public override string ToString() => Value.ToString();
    }
}
