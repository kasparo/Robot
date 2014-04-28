using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robot.Library.Models;

namespace Robot.Library
{
    public class Runner
    {
        private List<Task> _tasks = new List<Task>();

        public void RunRobot(RobotEntity robot)
        {
            Task robotTask = new Task(() => RobotAction(robot));
            robotTask.Start();

            _tasks.Add(robotTask);
        }

        private void RobotAction(RobotEntity robot)
        {
            do
            {
                foreach (Part part in robot.Parts)
                {
                    foreach (Instruction instruction in part.Instructions)
                    {
                        Console.WriteLine(
                            String.Format("Robot: {2}, part: {0}, value {1}",
                            part.Type, instruction.Value, robot.Identification));
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            } while (true);
        }
    }
}
