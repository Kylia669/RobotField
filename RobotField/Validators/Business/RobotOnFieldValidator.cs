using RobotField.Abstractions;
using RobotField.Exceptions;
using RobotField.Extensions;
using RobotField.Models;

namespace RobotField.Validators.Business
{
    public class RobotOnFieldValidator : IRobotOnFieldValidator
    {
        public void EnsureValid(Robot robot, Field field)
        {
            if (robot.IsOnTheField(field) == false)
            {
                throw new InvalidParamException("Invalid robot position out of field");
            }
        }
    }
}
