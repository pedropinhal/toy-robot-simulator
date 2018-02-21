using System;

namespace ToyRobotSimulator
{
    public class Robot
    {
        private int X;
        private int Y;
        private string Facing;
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public Robot(Map map)
        {
            MaxX = map.Width;
            MaxY = map.Height;
            X = Y = 0;
            Facing = "NORTH";
        }

        public Robot(int x, int y, string facing)
        {
            this.X = x;
            this.Y = y;
            this.Facing = facing.ToUpper();
        }

        public string Report()
        {
            return $"{X},{Y},{Facing}";
        }

        public void Left()
        {
            switch (Facing)
            {
                case "NORTH":
                    Facing = "WEST";
                    break;
                case "SOUTH":
                    Facing = "EAST";
                    break;
                case "EAST":
                    Facing = "NORTH";
                    break;
                case "WEST":
                    Facing = "SOUTH";
                    break;
            }
        }

        public void Right()
        {
            switch (Facing)
            {
                case "NORTH":
                    Facing = "EAST";
                    break;
                case "SOUTH":
                    Facing = "WEST";
                    break;
                case "EAST":
                    Facing = "SOUTH";
                    break;
                case "WEST":
                    Facing = "NORTH";
                    break;
            }
        }

        public void Move()
        {
            switch (Facing)
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

        public void Place(int x, int y, string facing)
        {
            if (x > MaxX || x < 0 || y > MaxY || y < 0)
            {
                throw new ArgumentOutOfRangeException($"{MaxX}{MaxY}");
            }
            
            X = x;
            Y = y;
            Facing = facing.ToUpper();
        }
    }
}
