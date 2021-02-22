using System.Collections.Generic;
using NSubstitute;
using RobotField.Abstractions;
using RobotField.Commands;
using RobotField.Enums;
using RobotField.Models;
using RobotField.Models.Input;
using RobotField.Processor;
using Xunit;

namespace RobotField.UnitTests.Processors
{
    public class RobotsProcessorTests
    {
        private readonly RobotsProcessor _robotsProcessor;

        private readonly IInputReaderService _inputReader;
        private readonly IFieldCreator _fieldCreator;
        private readonly IRobotCreator _robotCreator;
        private readonly IMoveService _moveService;
        private readonly IOutputBuilderService _outputBuilderService;
        private readonly IOutputPrinterService _outputPrinterService;
        public RobotsProcessorTests()
        {
            this._inputReader = Substitute.For<IInputReaderService>();
            this._fieldCreator = Substitute.For<IFieldCreator>();
            this._robotCreator = Substitute.For<IRobotCreator>();
            this._moveService = Substitute.For<IMoveService>();
            this._outputBuilderService = Substitute.For<IOutputBuilderService>();
            this._outputPrinterService = Substitute.For<IOutputPrinterService>();

            _robotsProcessor = new RobotsProcessor(this._inputReader, this._fieldCreator, this._robotCreator, this._moveService,
                this._outputBuilderService, this._outputPrinterService);
        }

        [Fact]
        public void Should_InitializeField()
        {
            var initFieldParams = new FieldDimensionsInputModel("2 2");
            this._inputReader.GetFieldInitializationDimensions().Returns(initFieldParams);
            //act
            this._robotsProcessor.Process();
            //assert
            this._inputReader.Received(1).GetFieldInitializationDimensions();
            this._fieldCreator.Received(1).CreateField(initFieldParams);
        }

        [Fact]
        public void Should_CreateRobotsByParams()
        {
            var initFieldParams = new FieldDimensionsInputModel("2 2");
            var field = new Field
            {
                Height = 2,
                Width = 2
            };
            this._inputReader.GetFieldInitializationDimensions().Returns(initFieldParams);
            this._fieldCreator.CreateField(initFieldParams).Returns(field);
            var initRobotParams = new RobotInitParamsInputModel("1 1 N");
            this._inputReader.GetInitialRobotParams().Returns((_) => initRobotParams, (_) => null);
            var robot = new Robot
            {
                X = 1,
                Y = 1,
                Orientation = RobotOrientation.N
            };
            this._robotCreator.CreateRobot(initRobotParams, field).Returns(robot);
            var instructions = new RobotInstructionInputModel("RRR");
            this._inputReader.GetRobotInstructions().Returns(instructions);
            //act
            this._robotsProcessor.Process();
            //assert
            this._inputReader.Received(2).GetInitialRobotParams();
            this._robotCreator.Received(1).CreateRobot(initRobotParams, field);
        }

        [Fact]
        public void Should_ProcessInstructionsByEachRobot()
        {
            var initFieldParams = new FieldDimensionsInputModel("2 2");
            var field = new Field
            {
                Height = 2,
                Width = 2
            };
            this._inputReader.GetFieldInitializationDimensions().Returns(initFieldParams);
            this._fieldCreator.CreateField(initFieldParams).Returns(field);
            var initRobotParams = new RobotInitParamsInputModel("1 1 N");
            var robot = new Robot
            {
                X = 1,
                Y = 1,
                Orientation = RobotOrientation.N
            };
            this._inputReader.GetInitialRobotParams().Returns((_) => initRobotParams, (_) => null);
            this._robotCreator.CreateRobot(initRobotParams, field).Returns(robot);
            var instructions = new RobotInstructionInputModel("RRR");
            this._inputReader.GetRobotInstructions().Returns(instructions);
            //act
            this._robotsProcessor.Process();
            //assert
            this._inputReader.Received(1).GetRobotInstructions();
            this._moveService.Received(1).ProcessInstructions(field, robot, Arg.Any<List<ICommand>>());
        }

        [Fact]
        public void Should_PrintLastRobotPosition()
        {
            var initFieldParams = new FieldDimensionsInputModel("2 2");
            var field = new Field
            {
                Height = 2,
                Width = 2
            };
            this._inputReader.GetFieldInitializationDimensions().Returns(initFieldParams);
            this._fieldCreator.CreateField(initFieldParams).Returns(field);
            var initRobotParams = new RobotInitParamsInputModel("1 1 N");
            var robot = new Robot
            {
                X = 1,
                Y = 1,
                Orientation = RobotOrientation.N
            };
            this._inputReader.GetInitialRobotParams().Returns((_) => initRobotParams, (_) => null);
            this._robotCreator.CreateRobot(initRobotParams, field).Returns(robot);
            var instructions = new RobotInstructionInputModel("RRR");
            this._inputReader.GetRobotInstructions().Returns(instructions);
            this._moveService.ProcessInstructions(field, robot, Arg.Any<List<ICommand>>()).Returns(true);
            string output = "output";
            this._outputBuilderService.BuildOutput(robot, true).Returns(output);

            //act
            this._robotsProcessor.Process();
            //assert
            this._outputBuilderService.Received(1).BuildOutput(robot, true);
            this._outputPrinterService.Received(1).PrintLastPosition(output);
        }
    }
}
