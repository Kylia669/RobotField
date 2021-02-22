using System;
using System.Collections.Generic;
using RobotField.Abstractions;
using RobotField.Commands;
using RobotField.Extensions;
using RobotField.Models;
using RobotField.Models.Input;

namespace RobotField.Services
{
    public class MoveService : IMoveService
    {
        public bool ProcessInstructions(Field field, Robot robot, List<ICommand> instructions)
        {
            var isLost = false;
            foreach (var instruction in instructions)
            {
                instruction.Execute(robot, field);
                if (robot.IsOnTheField(field) == false)
                {
                    instruction.Revert(robot);
                    field.AddRobotScent(robot);
                    isLost = true;
                    break;
                }
            }

            return isLost;
            
        }
    }
}
