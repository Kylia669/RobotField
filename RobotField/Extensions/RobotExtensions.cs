using RobotField.Models;

namespace RobotField.Extensions
{
    public static class RobotExtensions
    {
        public static bool IsOnTheField(this Robot robot, Field field)
        {
            return (robot.X <= field.Width && robot.Y <= field.Height);
        }
    }
}
