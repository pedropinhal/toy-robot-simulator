using System;

namespace ToyRobotSimulator.Business
{
    public enum Direction
    {
        North,
        South,
        East,
        West

    }
    public class Robot : IRobot
    {
        private int X;
        private int Y;
        private Direction Facing;
        public int MaxX { get; private set; }
        public int MaxY { get; private set; }

        public Robot(Map map)
        {
            MaxX = map.Width;
            MaxY = map.Height;
            X = Y = 0;
            Facing = Direction.North;
        }

        public Robot(int x, int y, string facing)
        {
            this.X = x;
            this.Y = y;
            this.Facing = (Direction)Enum.Parse(typeof(Direction), facing, true);
        }

        public string Report()
        {
            return $"{X},{Y},{Facing.ToString().ToUpper()}";
        }

        public void Left()
        {
            switch (Facing)
            {
                case Direction.North:
                    Facing = Direction.West;
                    break;
                case Direction.South:
                    Facing = Direction.East;
                    break;
                case Direction.East:
                    Facing = Direction.North;
                    break;
                case Direction.West:
                    Facing = Direction.South;
                    break;
            }
        }

        public void Right()
        {
            switch (Facing)
            {
                case Direction.North:
                    Facing = Direction.East;
                    break;
                case Direction.South:
                    Facing = Direction.West;
                    break;
                case Direction.East:
                    Facing = Direction.South;
                    break;
                case Direction.West:
                    Facing = Direction.North;
                    break;
            }
        }

        public void Move()
        {
            switch (Facing)
            {
                case Direction.North:
                    if (Y + 1 <= MaxY)
                    {
                        Y++;
                    }
                    break;
                case Direction.South:
                    if (Y - 1 >= 0)
                    {
                        Y--;
                    }
                    break;
                case Direction.East:
                    if (X + 1 <= MaxX)
                    {
                        X++;
                    }
                    break;
                case Direction.West:
                    if (X - 1 >= 0)
                    {
                        X--;
                    }
                    break;
            }
        }

        public void Place(int x, int y, string facing)
        {
            if (x > MaxX || x < 0 || y > MaxY || y < 0)
            {
                throw new ArgumentOutOfRangeException($"{x}:{y} is out of bounds with {MaxX}:{MaxY}");
            }

            X = x;
            Y = y;
            Facing = (Direction)Enum.Parse(typeof(Direction), facing, true);
        }
    }
}
