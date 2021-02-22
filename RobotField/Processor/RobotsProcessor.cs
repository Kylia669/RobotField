using RobotField.Abstractions;

namespace RobotField.Processor
{
    public class RobotsProcessor : IRobotsProcessor
    {
        private readonly IInputReaderService _inputReader;
        private readonly IFieldCreator _fieldCreator;
        private readonly IRobotCreator _robotCreator;
        private readonly IMoveService _moveService;
        private readonly IOutputBuilderService _outputBuilderService;
        private readonly IOutputPrinterService _outputPrinterService;

        public RobotsProcessor(IInputReaderService inputReader, 
            IFieldCreator fieldCreator, 
            IRobotCreator robotCreator, 
            IMoveService moveService, 
            IOutputBuilderService outputBuilderService, 
            IOutputPrinterService outputPrinterService)
        {
            _inputReader = inputReader;
            _fieldCreator = fieldCreator;
            _robotCreator = robotCreator;
            _moveService = moveService;
            _outputBuilderService = outputBuilderService;
            _outputPrinterService = outputPrinterService;
        }

        public void Process()
        {
            var fieldInitializationDimensions = _inputReader.GetFieldInitializationDimensions();

            var field = _fieldCreator.CreateField(fieldInitializationDimensions);
            var robotInitializationParams = _inputReader.GetInitialRobotParams();
            while (robotInitializationParams != null)
            {
                var robot = _robotCreator.CreateRobot(robotInitializationParams, field);
                var robotInstructions = _inputReader.GetRobotInstructions();

                var isLost = _moveService.ProcessInstructions(field, robot, robotInstructions.Instructions);

                var output = _outputBuilderService.BuildOutput(robot, isLost);
                _outputPrinterService.PrintLastPosition(output);

                // try get next robot params
                robotInitializationParams = _inputReader.GetInitialRobotParams();
            }
        }
    }
}
