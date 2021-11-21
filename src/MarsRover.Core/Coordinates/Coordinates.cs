namespace MarsRover.Core
{
    public record Coordinates
    {
        public Point X { get; private set; }
        public bool FitsInWidth(Point width) => X.Value <= width.Value;
        public Point Y { get; private set; }
        public bool FitsInHeight(Point height) => Y.Value <= height.Value;

        private Coordinates() { }
        public Coordinates(int x, int y)
        {
            X = new Point(x);
            Y = new Point(y);
        }

        public Coordinates GoNorth()
        {
            return new Coordinates()
            {
                X = X ,
                Y = Y.Increment()
            };
        }

        public Coordinates GoSouth()
        {
            return new Coordinates()
            {
                X = X,
                Y = Y.Decrement()
            };
        }

        public Coordinates GoEast()
        {
            return new Coordinates()
            {
                X = X.Increment(),
                Y = Y
            };
        }

        public Coordinates GoWest()
        {
            return new Coordinates()
            {
                X = X.Decrement(),
                Y = Y
            };
        }

        public override string ToString() => $"{X} {Y}";
    }
}
