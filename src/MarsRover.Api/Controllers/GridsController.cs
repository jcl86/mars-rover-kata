using System;
using MarsRover.Core;
using MarsRover.Model;
using Microsoft.AspNetCore.Mvc;

namespace MarsRover.Api
{
    [ApiController]
    [Route(Endpoints.Grids.Base)]
    public class GridsController : ControllerBase
    {
        private readonly GridFinder gridFinder;
        private readonly GridCreator gridCreator;

        public GridsController(GridFinder gridFinder, GridCreator gridCreator)
        {
            this.gridFinder = gridFinder;
            this.gridCreator = gridCreator;
        }

        [HttpGet, Route("{gridId}")]
        public IActionResult Get(Guid gridId)
        {
            var entity = gridFinder.Find(gridId);
            return Ok(GridMapper.Map(entity));
        }

        [HttpPost]
        public IActionResult PostCreate(LocationInput request)
        {
            var entity = gridCreator.Create(request.Input);
            return Ok(GridMapper.Map(entity));
        }
    }
}
