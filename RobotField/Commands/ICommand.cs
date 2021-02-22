using RobotField.Models;

namespace RobotField.Commands
{
    public interface ICommand
    {
        void Execute(Robot robot, Field field);
        void Revert(Robot robot);
    }
}
