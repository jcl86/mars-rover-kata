using System;

namespace MarsRover.Model
{
    public class Endpoints
    {
        public class Grids
        {
            public const string Base = "api/grids";
            public static string Get(Guid gridId) => $"{Base}/{gridId}";
            public const string PostCreate = Base;
        }

        public class Rover
        {
            public const string PostStart = "api/rovers/start";
            public const string PostSetPosition = "api/rovers/set-position";
            public const string PostMove = "api/rovers";
        }
    }
}
