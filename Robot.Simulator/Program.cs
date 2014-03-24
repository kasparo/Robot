using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Robot.Library;

namespace Robot.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var connecionString = ConfigurationManager.ConnectionStrings["RobotDB"].ConnectionString;

            DataProvider provider = new DataProvider(connecionString);
            Console.WriteLine(provider.GetRobots());
            
            Console.ReadLine();
        }
    }
}
