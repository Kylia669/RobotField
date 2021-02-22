using FluentAssertions;
using RobotField.Commands;
using RobotField.Enums;
using RobotField.Models;
using Xunit;

namespace RobotField.UnitTests.Commands
{
    public class TurnRightCommandTests
    {
        private readonly TurnRightCommand _command;
        private readonly Field _field;
        public TurnRightCommandTests()
        {
            _field = new Field
            {
                Height = 2,
                Width = 2,
            };
            _command = new TurnRightCommand();
        }

        [Theory]
        [InlineData(RobotOrientation.N, RobotOrientation.E)]
        [InlineData(RobotOrientation.W, RobotOrientation.N)]
        [InlineData(RobotOrientation.S, RobotOrientation.W)]
        [InlineData(RobotOrientation.E, RobotOrientation.S)]
        
        public void Should_TurnRight(RobotOrientation initial, RobotOrientation expected)
        {
            //arrange
            var robot = new Robot
            {
                X = 1,
                Y = 1,
                Orientation = initial
            };
            //act
            this._command.Execute(robot,_field);
            robot.Orientation.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(RobotOrientation.N, RobotOrientation.W)]
        [InlineData(RobotOrientation.W, RobotOrientation.S)]
        [InlineData(RobotOrientation.S, RobotOrientation.E)]
        [InlineData(RobotOrientation.E, RobotOrientation.N)]
        public void Should_RevertTurnRight(RobotOrientation initial, RobotOrientation expected)
        {
            //arrange
            var robot = new Robot
            {
                X = 1,
                Y = 1,
                Orientation = initial
            };
            //act
            this._command.Revert(robot);
            robot.Orientation.Should().BeEquivalentTo(expected);
        }
    }
}
