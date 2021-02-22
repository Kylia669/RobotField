using RobotField.Models;
using RobotField.Models.Input;

namespace RobotField.Abstractions
{
    public interface IRobotCreator
    {
        Robot CreateRobot(RobotInitParamsInputModel robotInitializationParams, Field field);
    }
}
