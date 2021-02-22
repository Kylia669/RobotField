using FluentAssertions;
using RobotField.Enums;
using RobotField.Extensions;
using RobotField.Models;
using Xunit;

namespace RobotField.UnitTests.Extensions
{
    public class RobotExtensionsTests
    {
        [Theory]
        [InlineData(3,3, 5,5)]
        [InlineData(5, 5, 5, 5)]
        [InlineData(0, 0, 5, 5)]
        [InlineData(5, 0, 5, 5)]
        [InlineData(0, 5, 5, 5)]
        public void Should_ReturnTrue_WhenRobotOnField(short robotX, short robotY, short fieldWidth, short fieldHeight)
        {
            var robot = new Robot
            {
                Orientation = RobotOrientation.E,
                Y = robotY,
                X = robotX
            };
            var field = new Field
            {
                Height = fieldHeight,
                Width = fieldWidth
            };
            //act
            var actual = robot.IsOnTheField(field);
            //assert
            actual.Should().BeTrue();
        }


        [Theory]
        [InlineData(6, 3, 5, 5)]
        [InlineData(3, 6, 5, 5)]
        [InlineData(6, 6, 5, 5)]
        public void Should_ReturnFalse_WhenRobotOutOfField(short robotX, short robotY, short fieldWidth, short fieldHeight)
        {
            var robot = new Robot
            {
                Orientation = RobotOrientation.E,
                Y = robotY,
                X = robotX
            };
            var field = new Field
            {
                Height = fieldHeight,
                Width = fieldWidth
            };
            //act
            var actual = robot.IsOnTheField(field);
            //assert
            actual.Should().BeFalse();
        }
    }
}
