using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Robot.Simulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var configValue = ConfigurationManager.AppSettings["MyConfig"];
            Console.WriteLine(configValue);
            Console.ReadLine();
        }
    }
}
