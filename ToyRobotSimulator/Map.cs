using System;

namespace ToyRobotSimulator
{
    public class Map
    {
        const int DefaultWidth = 5;
        const int DefaultHeight = 5;

        public int Width { get; set; }
        public int Height { get; set; }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Map() : this(DefaultWidth, DefaultHeight)
        {
        }
    }
}