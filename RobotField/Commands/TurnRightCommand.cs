using RobotField.Enums;
using RobotField.Models;

namespace RobotField.Commands
{
    public class TurnRightCommand : ICommand
    {
        public void Execute(Robot robot, Field field)
        {
            var newOrientation = ((int)robot.Orientation + 1) % 4;
            robot.Orientation = (RobotOrientation)newOrientation;
            
        }

        public void Revert(Robot robot)
        {
            var newOrientation = (int)robot.Orientation - 1;
            if (newOrientation < 0)
            {
                newOrientation = 3;
            }

            robot.Orientation = (RobotOrientation)newOrientation;
        }
    }
}
