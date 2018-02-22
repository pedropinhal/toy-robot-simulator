using System;
using System.Collections.Generic;

namespace ToyRobotSimulator
{
    public class RobotDriver
    {
        private Robot robot;
        public List<string> Commands {get; private set;}

        public RobotDriver()
        {
        }

        public RobotDriver(Robot robot)
        {
            this.robot = robot;
            Commands = new List<string>();
        }

        public void AddCommand(string command)
        {
            Commands.Add(command);
        }

        public IEnumerable<char> Output()
        {
            throw new NotImplementedException();
        }

        public void Drive()
        {
            throw new NotImplementedException();
        }
    }
}