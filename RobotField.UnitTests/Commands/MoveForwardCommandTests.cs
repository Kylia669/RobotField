using System.Collections.Generic;
using FluentAssertions;
using RobotField.Commands;
using RobotField.Enums;
using RobotField.Models;
using Xunit;

namespace RobotField.UnitTests.Commands
{
    public class MoveForwardCommandTests
    {
        private readonly MoveForwardCommand _command;
        private readonly Field _field;
        public MoveForwardCommandTests()
        {
            _field = new Field
            {
                Height = 5,
                Width = 5,
            };
            _command = new MoveForwardCommand();
        }

        [Theory]
        [InlineData(RobotOrientation.N, 3, 4)]
        [InlineData(RobotOrientation.W, 2, 3)]
        [InlineData(RobotOrientation.S, 3, 2)]
        [InlineData(RobotOrientation.E, 4, 3)]
        public void Should_MoveForward(RobotOrientation initial, short newX, short newY)
        {
            //arrange
            var robot = new Robot
            {
                X = 3,
                Y = 3,
                Orientation = initial
            };
            var expectedRobot = new Robot
            {
                X = newX,
                Y = newY,
                Orientation = initial
            };
            //act
            this._command.Execute(robot, _field);
            robot.Should().BeEquivalentTo(expectedRobot);
        }

        [Theory]
        [InlineData(RobotOrientation.N, 3, 4)]
        [InlineData(RobotOrientation.W, 2, 3)]
        [InlineData(RobotOrientation.S, 3, 2)]
        [InlineData(RobotOrientation.E, 4, 3)]
        public void Should_RevertMoveForward(RobotOrientation initial, short newX, short newY)
        {
            //arrange
            var robot = new Robot
            {
                X = newX,
                Y = newY,
                Orientation = initial
            };
            var expectedRobot = new Robot
            {
                X = 3,
                Y = 3,
                Orientation = initial
            };
            //act
            this._command.Revert(robot);
            robot.Should().BeEquivalentTo(expectedRobot);
        }


        [Theory]
        [InlineData(RobotOrientation.N, 3, 3, 1, 3)]
        [InlineData(RobotOrientation.W, 3, 3, 0, 1)]
        [InlineData(RobotOrientation.S, 3, 3, 1, 0)]
        [InlineData(RobotOrientation.E, 3, 3, 3, 1)]
        public void Should_SkipMoveOutOfFieldWhenFieldHasScent(RobotOrientation initial, short fieldWidth, short fieldHeight, short scentPositionX, short scentPositionY)
        {
            //arrange
            var field = new Field
            {
                Height = fieldHeight,
                Width = fieldWidth,
                RobotScents = new List<Robot>
                {
                    new Robot
                    {
                        X = scentPositionX,
                        Y = scentPositionY
                    }
                }
            };
            var robot = new Robot
            {
                X = scentPositionX,
                Y = scentPositionY,
                Orientation = initial
            };
            var expectedRobot = new Robot
            {
                X = scentPositionX,
                Y = scentPositionY,
                Orientation = initial
            };
            //act
            this._command.Execute(robot, field);
            robot.Should().BeEquivalentTo(expectedRobot);
        }
    }
}
