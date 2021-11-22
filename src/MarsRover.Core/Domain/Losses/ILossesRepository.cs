using System.Collections.Generic;

namespace MarsRover.Core
{
    public interface ILossesRepository
    {
        IEnumerable<Coordinates> GetAllForbiddenLocations();
        void AddScent(Coordinates coordinates);
    }
}
