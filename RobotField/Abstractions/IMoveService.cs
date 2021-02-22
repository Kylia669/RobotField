using System.Collections.Generic;
using RobotField.Commands;
using RobotField.Models;
using RobotField.Models.Input;

namespace RobotField.Abstractions
{
    public interface IMoveService
    {
        bool ProcessInstructions(Field field, Robot robot, List<ICommand> instructions);
    }
}
