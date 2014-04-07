using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Robot.Library;
using Robot.Library.Models;
namespace Robot.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var connecionString = ConfigurationManager.ConnectionStrings["RobotDB"].ConnectionString;

            Manager manager = new Manager(connecionString);
            
            manager.CreateRobot("H_1_LC", new List<Part>());

            Console.ReadLine();
        }
    }
}
