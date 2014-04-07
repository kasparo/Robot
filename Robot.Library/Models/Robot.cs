using System;
using System.ComponentModel.DataAnnotations;
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
    }
}
