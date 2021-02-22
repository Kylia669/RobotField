using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using RobotField.Commands;
using RobotField.Enums;
using RobotField.Models;
using RobotField.Models.Input;
using RobotField.Services;
using Xunit;

namespace RobotField.UnitTests.Services
{
    public class MoveServiceTests
    {
        private readonly MoveService _service;
        
        public MoveServiceTests()
        {
            _service = new MoveService();
        }
        [Fact]
        public void Should_ProcessAllInstructions()
        {
            //arrange
            var robot = new Robot();
            var field = new Field();
            var instruction = Substitute.For<ICommand>();
            var instructions =  new List<ICommand>()
            {
                instruction,
                instruction,
                instruction
            };
            //act
            this._service.ProcessInstructions(field, robot, instructions);
            //assert
            instruction.Received(3).Execute(robot, field);

        }
        [Fact]
        public void Should_StopWhenRobotOutOfField()
        {
            //arrange
            var robot = new Robot
            {
                X = 1,
                Y = 1,
                Orientation = RobotOrientation.N
            };
            var field = new Field
            {
                Height = 1,
                Width = 1
            };
            var instruction = Substitute.For<ICommand>();
            instruction.When(_ => _.Execute(robot, field)).Do(_=> _.Arg<Robot>().X=2);
            var instructions = new List<ICommand>()
            {
                instruction,
                instruction,
                instruction
            };
            //act
            this._service.ProcessInstructions(field, robot, instructions);
            //assert
            instruction.Received(1).Execute(robot, field);
        }
        [Fact]
        public void Should_AddLostRobotToFieldScent()
        {
            //arrange
            var robot = new Robot
            {
                X = 1,
                Y = 1,
                Orientation = RobotOrientation.N
            };
            var field = new Field
            {
                Height = 1,
                Width = 1
            };
            var instruction = Substitute.For<ICommand>();
            instruction.When(_ => _.Execute(robot, field)).Do(_ => _.Arg<Robot>().X = 2);
            var instructions = new List<ICommand>()
            {
                instruction,
                instruction,
                instruction
            };
            var expectedScent = new List<Robot>
            {
                robot
            };
            //act
            this._service.ProcessInstructions(field, robot, instructions);
            //assert
            field.RobotScents.Should().BeEquivalentTo(expectedScent);
            instruction.Received(1).Execute(robot, field);
        }

        [Fact]
        public void Should_ReturnTrueWhenRobotLost()
        {
            //arrange
            var robot = new Robot
            {
                X = 1,
                Y = 1,
                Orientation = RobotOrientation.N
            };
            var field = new Field
            {
                Height = 1,
                Width = 1
            };
            var instruction = Substitute.For<ICommand>();
            instruction.When(_ => _.Execute(robot, field)).Do(_ => _.Arg<Robot>().X = 2);
            var instructions = new List<ICommand>()
            {
                instruction,
                instruction,
                instruction
            };
            //act
            var actual = this._service.ProcessInstructions(field, robot, instructions);
            //assert
            actual.Should().BeTrue();
        }


        [Fact]
        public void Should_ReturnFalseWhenRobotStillOnField()
        {
            //arrange
            var robot = new Robot
            {
                X = 1,
                Y = 1,
                Orientation = RobotOrientation.N
            };
            var field = new Field
            {
                Height = 1,
                Width = 1
            };
            var instruction = Substitute.For<ICommand>();
            var instructions = new List<ICommand>()
            {
                instruction,
                instruction,
                instruction
            };
            //act
            var actual = this._service.ProcessInstructions(field, robot, instructions);
            //assert
            actual.Should().BeFalse();
        }
    }
}
