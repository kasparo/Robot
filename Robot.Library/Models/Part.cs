using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Robot.Library.Models
{
    public enum PartType
    {
        Joint = 1,
        Paw = 2,
        Base = 3
    }

    public class Part
    {
        public int Id { get; set; }

        [Required]
        public PartType Type { get; set; }

        [Required]
        public int RobotId { get; set; }

        public virtual RobotEntity Robot { get; set; }

        public virtual ICollection<Instruction> Instructions { get; set; }
    }
}
