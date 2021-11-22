using System;
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

        [HttpPost, Route(Endpoints.Grids.Base + "/{gridId}/{}")]
        public IActionResult PostSetPosition(Guid gridId, LocationInput request)
        {
            roverRider.Locate(Input.FromString(request.Input));
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
