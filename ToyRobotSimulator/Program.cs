using System;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var driver = new RobotDriver(new Robot(new Map()));
            driver.AddCommand("PLACE 0,0,NORTH");
            driver.AddCommand("MOVE");
            driver.AddCommand("REPORT");
            driver.Drive();

            driver.Reports.ForEach(r => Console.WriteLine(r));

            driver.Reset();
            driver.AddCommand("PLACE 0,0,NORTH");
            driver.AddCommand("LEFT");
            driver.AddCommand("REPORT");
            driver.Drive();

            driver.Reports.ForEach(r => Console.WriteLine(r));

            driver.Reset();
            driver.AddCommand("PLACE 1,2,EAST");
            driver.AddCommand("MOVE");
            driver.AddCommand("MOVE");
            driver.AddCommand("LEFT");
            driver.AddCommand("MOVE");
            driver.AddCommand("REPORT");
            driver.Drive();

            driver.Reports.ForEach(r => Console.WriteLine(r));

        }
    }
}
