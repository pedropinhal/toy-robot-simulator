using Moq;
using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class RobotDriverTests
    {
        Mock<IRobot> robot;

        public RobotDriverTests()
        {
            robot = new Mock<IRobot>();
        }

        public void CanFeedCommandsToRobot()
        {
            var driver = new RobotDriver(new Robot(new Map()));

            driver.AddCommand("PLACE 0,0,NORTH");

            driver.Drive();

            Assert.Equal(driver.Output(), "0,0,NORTH");
        }

        [Fact]
        public void CanAddCommandsToDriver()
        {
            var driver = new RobotDriver(new Robot(new Map()));

            driver.AddCommand("command");

            Assert.Equal(driver.Commands.Count, 1);
        }

        [Fact]
        public void CanIssuePlaceCommandToRobot()
        {
            var driver = new RobotDriver(robot.Object);
            robot.Setup(r => r.Place(0, 0, "NORTH"));

            driver.AddCommand("PLACE 0,0,NORTH");

            driver.Drive();
            robot.Verify(r => r.Place(0, 0, "NORTH"), Times.Once);
        }

        [Fact]
        public void CanIssueMoveCommandToRobot()
        {
            var driver = new RobotDriver(robot.Object);
            robot.Setup(r => r.Move());
            driver.AddCommand("PLACE 0,0,NORTH");

            driver.AddCommand("MOVE");

            driver.Drive();
            robot.Verify(r => r.Move(), Times.Once);
        }

        [Fact]
        public void CanIssueLeftCommandToRobot()
        {
            var driver = new RobotDriver(robot.Object);
            robot.Setup(r => r.Left());
            driver.AddCommand("PLACE 0,0,NORTH");

            driver.AddCommand("LEFT");

            driver.Drive();
            robot.Verify(r => r.Left(), Times.Once);
        }

        [Fact]
        public void CanIssueRightCommandToRobot()
        {
            var driver = new RobotDriver(robot.Object);
            robot.Setup(r => r.Right());
            driver.AddCommand("PLACE 0,0,NORTH");

            driver.AddCommand("RIGHT");

            driver.Drive();
            robot.Verify(r => r.Right(), Times.Once);
        }

        [Fact]
        public void CanIssueReportCommandToRobot()
        {
            var driver = new RobotDriver(robot.Object);
            robot.Setup(r => r.Report());
            driver.AddCommand("PLACE 0,0,NORTH");

            driver.AddCommand("REPORT");

            driver.Drive();
            robot.Verify(r => r.Report(), Times.Once);
        }

        [Fact]
        public void NoCommandsIssuedUntilRobotPlaced()
        {
            var driver = new RobotDriver(robot.Object);

            driver.AddCommand("MOVE");
            driver.AddCommand("REPORT");
            driver.AddCommand("LEFT");
            driver.AddCommand("RIGHT");
            driver.AddCommand("PLACE 0,0,NORTH");

            driver.Drive();
            
            robot.Verify(r => r.Move(), Times.Never);
            robot.Verify(r => r.Report(), Times.Never);
            robot.Verify(r => r.Left(), Times.Never);
            robot.Verify(r => r.Right(), Times.Never);
            robot.Verify(r => r.Place(0, 0, "NORTH"), Times.Once);
        }
    }
}