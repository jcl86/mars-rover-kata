using System;
using System.ComponentModel.DataAnnotations;

namespace MarsRover.Model
{
    public class StringInput
    {
        [Required]
        public string Content { get; set; }
    }
}
