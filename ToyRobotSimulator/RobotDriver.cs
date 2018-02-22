using System;
using System.Collections.Generic;

namespace ToyRobotSimulator
{
    public class RobotDriver
    {
        private IRobot robot;
        private bool RobotPlaced;
        public List<string> Commands { get; private set; }

        public List<string> Reports { get; private set; }

        public RobotDriver(IRobot robot)
        {
            this.robot = robot;
            Commands = new List<string>();
            Reports = new List<string>();
        }

        public void AddCommand(string command)
        {
            Commands.Add(command);
        }

        public void Drive()
        {
            foreach (string command in Commands)
            {
                var parts = command.Split(" ");
                switch (parts[0])
                {
                    case "PLACE":
                        var args = parts[1].Split(",");
                        robot.Place(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]), args[2]);
                        RobotPlaced = true;
                        break;
                    case "LEFT":
                        if (RobotPlaced)
                            robot.Left();
                        break;
                    case "RIGHT":
                        if (RobotPlaced)
                            robot.Right();
                        break;
                    case "MOVE":
                        if (RobotPlaced)
                            robot.Move();
                        break;
                    case "REPORT":
                        if (RobotPlaced)
                            Reports.Add(robot.Report());
                        break;
                }
            }
        }

        public void Reset()
        {
            Commands.Clear();
            Reports.Clear();
        }
    }
}