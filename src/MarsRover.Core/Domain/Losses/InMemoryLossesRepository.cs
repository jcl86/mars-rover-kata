using System.Collections.Generic;

namespace MarsRover.Core
{
    public class InMemoryLossesRepository : ILossesRepository
    {
        private readonly List<Coordinates> lostCoordinates = new List<Coordinates>();

        public void AddScent(Coordinates coordinates)
        {
            lostCoordinates.Add(coordinates);
        }

        public IEnumerable<Coordinates> GetAllForbiddenLocations() => lostCoordinates;
    }
}
