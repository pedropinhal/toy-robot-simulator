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

        [Theory]
        [InlineData("North", "WEST")]
        [InlineData("East", "NORTH")]
        [InlineData("South", "EAST")]
        [InlineData("West", "SOUTH")]
        public void CanTurnLeftCorrectly(string facing, string expectedFacing)
        {
            var robot = new Robot(0, 0, facing);

            robot.Left();

            var result = robot.Report();

            Assert.Equal(result, $"0,0,{expectedFacing}");
        }

        [Theory]
        [InlineData("North", "EAST")]
        [InlineData("East", "SOUTH")]
        [InlineData("South", "WEST")]
        [InlineData("West", "NORTH")]
        public void CanTurnRightCorrectly(string facing, string expectedFacing)
        {
            var robot = new Robot(0, 0, facing);

            robot.Right();

            var result = robot.Report();

            Assert.Equal(result, $"0,0,{expectedFacing}");
        }

        [Theory]
        [InlineData("North", "1,2,NORTH")]
        [InlineData("South", "1,0,SOUTH")]
        [InlineData("East", "2,1,EAST")]
        [InlineData("West", "0,1,WEST")]
        public void CanMoveRobot(string facing, string expected)
        {
            var robot = new Robot(1, 1, facing);

            robot.Move();

            var result = robot.Report();

            Assert.Equal(result, expected);
        }
    }
}
