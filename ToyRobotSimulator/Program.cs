using System;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot(new Map());
            robot.Place(0,0, "North");
            robot.Move();
            Console.WriteLine(robot.Report());
        }
    }
}
