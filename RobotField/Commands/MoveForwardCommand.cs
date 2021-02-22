using RobotField.Enums;
using RobotField.Exceptions;
using RobotField.Extensions;
using RobotField.Models;

namespace RobotField.Commands
{
    public class MoveForwardCommand : ICommand
    {
        private const int STEP = 1;
        private const int STEP_BACK = -1;
        public void Execute(Robot robot, Field field)
        {
            short newX = robot.X;
            short newY = robot.Y;
            switch (robot.Orientation)
            {
                case RobotOrientation.N:
                    newY += STEP;
                    break;
                case RobotOrientation.E:
                    newX += STEP;
                    break;
                case RobotOrientation.S:
                    newY -= STEP;
                    break;
                case RobotOrientation.W:
                    newX -= STEP;
                    break;
            }

            if ((newX >= field.Width || newY >= field.Height || newX < 0 || newY < 0) && field.HasScent(robot))
            {
                return;
            }

            robot.X = newX;
            robot.Y = newY;
        }

        public void Revert(Robot robot)
        {
            short newX = robot.X;
            short newY = robot.Y;
            switch (robot.Orientation)
            {
                case RobotOrientation.N:
                    newY += STEP_BACK;
                    break;
                case RobotOrientation.E:
                    newX += STEP_BACK;
                    break;
                case RobotOrientation.S:
                    newY -= STEP_BACK;
                    break;
                case RobotOrientation.W:
                    newX -= STEP_BACK;
                    break;
            }

            robot.X = newX;
            robot.Y = newY;
        }
    }
}
