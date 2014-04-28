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

        /// <summary>
        /// Method for robot creating
        /// </summary>
        /// <param name="place">place of robot</param>
        /// <param name="parts">robot´s parts</param>
        public string CreateRobot(string place, List<Part> parts)
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

            return newRobot.Identification;
        }

        public void AddPart(PartType type, RobotEntity robot)
        {
            var newPart = new Part()
            {
                Type = type,
                Robot = robot
            };

            _context.Parts.Add(newPart);
            _context.SaveChanges();
        }

        public void CreateInstruction(int idPart, int value, RobotEntity robot)
        {
            var existPart = robot.Parts.Any(p => p.Id == idPart);
            if (!existPart)
                return;
            
            var instruction = new Instruction()
            {
                PartId = idPart,
                Value = value
            };
            _context.Instructions.Add(instruction);
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
