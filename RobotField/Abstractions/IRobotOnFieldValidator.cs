using RobotField.Models;

namespace RobotField.Abstractions
{
    public interface IRobotOnFieldValidator
    {
        void EnsureValid(Robot robot, Field field);
    }
}
