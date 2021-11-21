namespace MarsRover.Core
{
    public record Result
    {
        public Position Position { get; }
        public bool IsLost { get; }

        private Result(Position position, bool isLost)
        {
            Position = position;
            IsLost = isLost;
        }

        public static Result Lost(Position position) => new Result(position, isLost: true);
        public static Result Create(Position position) => new Result(position, isLost: false);
        public override string ToString() => $"{Position} {(IsLost ? "LOST" : "")}".Trim();
    }
}
