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

        [Fact]
        public void CanTurnLeftCorrectly()
        {
            var robot = new Robot(0, 0, "North");

            robot.Left();

            var p1 = robot.Report();

            robot.Left();

            var p2 = robot.Report();

            robot.Left();

            var p3 = robot.Report();

            robot.Left();

            var p4 = robot.Report();

            Assert.Equal(p1, "0,0,WEST");
            Assert.Equal(p2, "0,0,SOUTH");
            Assert.Equal(p3, "0,0,EAST");
            Assert.Equal(p4, "0,0,NORTH");
        }

        [Fact]
        public void CanTurnRightCorrectly()
        {
            var robot = new Robot(0, 0, "North");

            robot.Right();

            var p1 = robot.Report();

            robot.Right();

            var p2 = robot.Report();

            robot.Right();

            var p3 = robot.Report();

            robot.Right();

            var p4 = robot.Report();

            Assert.Equal(p1, "0,0,EAST");
            Assert.Equal(p2, "0,0,SOUTH");
            Assert.Equal(p3, "0,0,WEST");
            Assert.Equal(p4, "0,0,NORTH");
        }
    }
}
