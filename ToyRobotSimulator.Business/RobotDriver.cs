using System;
using System.Collections.Generic;

namespace ToyRobotSimulator.Business
{
    public class RobotDriver
    {
        private IRobot robot;
        private bool RobotPlaced;
        public List<Command> Commands { get; private set; }

        public List<string> Reports { get; private set; }

        public RobotDriver(IRobot robot)
        {
            this.robot = robot;
            Commands = new List<Command>();
            Reports = new List<string>();
        }

        public void AddCommand(string commandString)
        {
            var command = Command.Parse(commandString);
            
            if(command == null)
                return;

            Commands.Add(command);
        }

        public void Drive()
        {
            foreach (var command in Commands)
            {
                switch (command.Verb)
                {
                    case CommandVerb.PLACE:
                        try
                        {
                            robot.Place(Convert.ToInt32(command.Arguments[0]),
                                Convert.ToInt32(command.Arguments[1]),
                                command.Arguments[2]);
                            RobotPlaced = true;
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case CommandVerb.LEFT:
                        if (RobotPlaced)
                            robot.Left();
                        break;
                    case CommandVerb.RIGHT:
                        if (RobotPlaced)
                            robot.Right();
                        break;
                    case CommandVerb.MOVE:
                        if (RobotPlaced)
                            robot.Move();
                        break;
                    case CommandVerb.REPORT:
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
