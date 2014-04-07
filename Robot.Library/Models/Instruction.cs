using System;

using System.ComponentModel.DataAnnotations;

namespace Robot.Library.Models
{
    public class Instruction
    {
        public int Id { get; set; }

        [Required]
        public int PartId { get; set; }

        [Required]
        public int Value { get; set; }
    }
}
