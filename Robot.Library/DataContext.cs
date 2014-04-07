using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using Robot.Library.Models;

namespace Robot.Library
{
    public class DataContext : DbContext
    {
        public DbSet<RobotEntity> Robots { get; set; }

        public DataContext()
            : base()
        {
        }

        public DataContext(string connectionString)
            : base(connectionString)
        {

        }
    }
}
