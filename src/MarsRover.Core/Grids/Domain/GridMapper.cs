namespace MarsRover.Core
{
    public static class GridMapper
    {
        public static Model.Grid Map(Grid entity)
        {
            return new Model.Grid()
            {
                Id = entity.Id,
                Width = entity.Width.Value,
                Height = entity.Height.Value
            };
        }
    }
}
