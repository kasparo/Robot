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
        private static Manager _manager;
        private static Runner _runner = new Runner();

        static void Main(string[] args)
        {
            //instance of manager
            var connecionString = ConfigurationManager.ConnectionStrings["RobotDB"].ConnectionString;
            _manager = new Manager(connecionString);

            // main
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Robot Simulator");

            string command = "";
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("> ");

                command = Console.ReadLine();
                ProcessCommand(command);
            } while (command != "exit");

        }

        /// <summary>
        /// Process method for command
        /// </summary>
        /// <param name="command">command string</param>
        private static void ProcessCommand(string command)
        {

            switch (command)
            {
                case "create-robot":
                    Console.WriteLine("Created robot: " +
                        _manager.CreateRobot("H_1_LC", new List<Part>())
                    );
                    break;
                case "add-part":
                    Console.Write("Type: ");
                    string type = Console.ReadLine();
                    Console.Write("Identification: ");
                    string identification = Console.ReadLine();

                    PartType partType = (PartType)Enum.Parse(typeof(PartType), type);
                    RobotEntity robot = _manager.GetRobot(identification);
                    if (robot != null)
                        _manager.AddPart(partType, robot);

                    break;
                case "create-instruction":
                    Console.Write("ID part: ");
                    string idPart = Console.ReadLine();
                    Console.Write("Value: ");
                    string value = Console.ReadLine();
                    Console.Write("Identification: ");
                    string ident = Console.ReadLine();

                    RobotEntity robik = _manager.GetRobot(ident);

                    _manager.CreateInstruction(
                        int.Parse(idPart),
                        int.Parse(value),
                        robik);
                    
                    break;
                case "start":
                     
                    _runner.RunRobot(_manager.GetRobot("H_1_LC_291"));
                    _runner.RunRobot(_manager.GetRobot("H_1_LC_619"));
                    break;


            }
        }
    }
}
