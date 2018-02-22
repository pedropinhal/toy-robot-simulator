namespace ToyRobotSimulator
{
    public interface IRobot
    {
        void Move();
        void Place(int x, int y, string facing);
        void Left();
        void Right();
        string Report();
    }
}
