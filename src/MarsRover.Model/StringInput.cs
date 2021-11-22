using System;
using System.ComponentModel.DataAnnotations;

namespace MarsRover.Model
{
    public class InputRequest
    {
        [Required]
        public string Input { get; set; }
    }
}
