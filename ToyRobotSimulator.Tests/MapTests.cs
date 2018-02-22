using ToyRobotSimulator.Business;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class MapTests
    {
        [Fact]
        public void CanCreateMapWithWidthAndHeight()
        {
            var map = new Map(15, 25);

            Assert.Equal(map.Width, 15);
            Assert.Equal(map.Height, 25);
        }

        [Fact]
        public void CanCreateMapWithDefaults()
        {
            var map = new Map();

            Assert.Equal(map.Width, 5);
            Assert.Equal(map.Height, 5);
        }
    }
}