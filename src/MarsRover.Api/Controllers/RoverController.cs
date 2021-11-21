using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MarsRover.Core;
using MarsRover.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MarsRover.Api
{
    [ApiController]
    public class RoverController : ControllerBase
    {
        private readonly RoverRider roverRider;

        public RoverController(RoverRider roverRider)
        {
            this.roverRider = roverRider;
        }

        [HttpPost, Route(Endpoints.Rover.PostStart)]
        public IActionResult PostStart(StringInput input)
        {
            var grid = new Grid(Input.FromString(input.Content));
            roverRider.Start(grid);
            return Ok();
        }

        [HttpPost, Route(Endpoints.Rover.PostSetPosition)]
        public IActionResult PostSetPosition(StringInput input)
        {
            roverRider.Locate(Input.FromString(input.Content));
            return Ok();
        }

        [HttpPost, Route(Endpoints.Rover.PostMove)]
        public IActionResult PostMove(StringInput input)
        {
            var result = roverRider.Move(Input.FromString(input.Content));

            return Ok(new StringOutput()
            {
                Content = result.ToString()
            });
        }
    }
}
