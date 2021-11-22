using System;

namespace MarsRover.Core
{
    public class GridFinder
    {
        private readonly IGridRepository gridRepository;

        public GridFinder(IGridRepository gridRepository)
        {
            this.gridRepository = gridRepository;
        }

        public Grid Find(Guid gridId)
        {
            var grid = gridRepository.Get(gridId);
            if (grid is null)
            {
                throw new NotFoundException($"Grid with {gridId} id was not found");
            }
            return grid;
        }
    }
}
