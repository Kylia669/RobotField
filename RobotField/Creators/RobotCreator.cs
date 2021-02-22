using RobotField.Abstractions;
using RobotField.Models;
using RobotField.Models.Input;

namespace RobotField.Creators
{
    public class RobotCreator : IRobotCreator
    {
        private readonly IValidationService _validationService;
        private readonly IRobotOnFieldValidator _robotOnFieldValidator;
        public RobotCreator(IValidationService validationService, IRobotOnFieldValidator robotOnFieldValidator)
        {
            _validationService = validationService;
            _robotOnFieldValidator = robotOnFieldValidator;
        }

        public Robot CreateRobot(RobotInitParamsInputModel robotInitializationParams, Field field)
        {
            this._validationService.EnsureValid(robotInitializationParams);

            var robot = new Robot
            {
                X = robotInitializationParams.X,
                Y = robotInitializationParams.Y,
                Orientation = robotInitializationParams.Orientation.Value
            };

            this._robotOnFieldValidator.EnsureValid(robot, field);

            return robot;
        }
    }
}
