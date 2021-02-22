using RobotField.Models;

namespace RobotField.Abstractions
{
    public interface IOutputBuilderService
    {
        string BuildOutput(Robot robot, bool isLost = false);
    }
}
