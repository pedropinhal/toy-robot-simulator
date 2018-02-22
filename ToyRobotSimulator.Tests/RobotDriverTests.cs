using Xunit;

namespace ToyRobotSimulator.Tests
{
    public class RobotDriverTests
    {
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
    }
}