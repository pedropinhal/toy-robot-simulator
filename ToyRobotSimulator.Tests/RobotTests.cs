using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class RobotTests
    {
        [Fact]
        public void CanCreateRobotAndReportDefaultPosition()
        {
            var robot = new Robot();

            var result = robot.Report();

            Assert.Equal(result, "0,0,NORTH");
        }

        [Fact]
        public void CanCreateRobotAndReportWithCustomPosition()
        {
            var robot = new Robot(1, 3, "East");

            var result = robot.Report();

            Assert.Equal(result, "1,3,EAST");
        }
    }
}
