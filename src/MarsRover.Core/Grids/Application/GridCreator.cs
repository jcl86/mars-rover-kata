namespace MarsRover.Core
{
    public class GridCreator
    {
        private readonly IGridRepository gridRepository;

        public GridCreator(IGridRepository gridRepository)
        {
            this.gridRepository = gridRepository;
        }

        public Grid Create(string input)
        {
            var grid = new Grid(Input.FromString(input));
            gridRepository.Save(grid);
            return grid;
        }
    }
}
