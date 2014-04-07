using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot.Library.Models;

namespace Robot.Library
{
    public class Manager
    {
        private DataContext _context;

        public Manager(string connectionString)
        {
            _context = new DataContext(connectionString);
        }

        public void CreateRobot(string place, List<Part> parts)
        {
            var newRobot = new RobotEntity()
            {
                Parts = parts,
                Place = place
            };

            do
            {
                newRobot.Identification = String.Format("{0}_{1}",
                                place,
                                GetIdentifactionNumber());
                var existedRobot = GetRobot(newRobot.Identification);
                if (existedRobot == null)
                    break;
            }
            while (true);

            _context.Robots.Add(newRobot);
            _context.SaveChanges();
        }

        public RobotEntity GetRobot(string identification)
        {
            var robot =_context.Robots
                .FirstOrDefault(r => r.Identification == identification);

            return robot;
        }

        private int GetIdentifactionNumber()
        {
            Random random = new Random();
            return random.Next(100, 999);
        }
    }

}
