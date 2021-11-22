using System;

namespace MarsRover.Core
{
    public interface IGridRepository
    {
        Grid Get(Guid gridId);
        void Save(Grid grid);
    }
}
