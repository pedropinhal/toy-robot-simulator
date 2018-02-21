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
            Direction = "North";
        }

        public Robot(int x, int y, string direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public string Report()
        {
            return $"{X},{Y},{Direction.ToUpper()}";
        }
    }
}
