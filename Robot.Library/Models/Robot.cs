using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace Robot.Library.Models
{
    public class RobotEntity
    {
        public int ID { get; set; }

        [StringLength(10)]
        [Required]
        public string Place { get; set; }

        [StringLength(10)]
        [Required]
        public string Identification { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}
