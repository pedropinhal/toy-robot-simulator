using System;

namespace ToyRobotSimulator
{
    public class Robot
    {
        private int X;
        private int Y;
        private string Direction;

        public Robot()
        {
            X = Y = 0;
            Direction = "NORTH";
        }

        public Robot(int x, int y, string direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction.ToUpper();
        }

        public string Report()
        {
            return $"{X},{Y},{Direction}";
        }

        public void Left()
        {
            switch (Direction)
            {
                case "NORTH":
                    Direction = "WEST";
                    break;
                case "SOUTH":
                    Direction = "EAST";
                    break;
                case "EAST":
                    Direction = "NORTH";
                    break;
                case "WEST":
                    Direction = "SOUTH";
                    break;
            }
        }

        public void Right()
        {
            switch (Direction)
            {
                case "NORTH":
                    Direction = "EAST";
                    break;
                case "SOUTH":
                    Direction = "WEST";
                    break;
                case "EAST":
                    Direction = "SOUTH";
                    break;
                case "WEST":
                    Direction = "NORTH";
                    break;
            }
        }

        public void Move()
        {
            switch (Direction)
            {
                case "NORTH":
                    Y++;
                    break;
                case "SOUTH":
                    Y--;
                    break;
                case "EAST":
                    X++;
                    break;
                case "WEST":
                    X--;
                    break;
            }
        }
    }
}
