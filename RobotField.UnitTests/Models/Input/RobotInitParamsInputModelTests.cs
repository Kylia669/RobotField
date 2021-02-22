using FluentAssertions;
using RobotField.Enums;
using RobotField.Models.Input;
using Xunit;

namespace RobotField.UnitTests.Models.Input
{
    public class RobotInitParamsInputModelTests
    {
        [Theory]
        [InlineData("2 2 N", 2, 2, RobotOrientation.N)]
        [InlineData("100 100 N", 100, 100, RobotOrientation.N)]
        [InlineData("-1 2 W", 0, 2, RobotOrientation.W)]
        [InlineData("1 -2 W", 1, 0, RobotOrientation.W)]
        [InlineData("a 2 N", 0, 2, RobotOrientation.N)]
        [InlineData("2 a S", 2, 0, RobotOrientation.S)]
        [InlineData("a a E", 0, 0, RobotOrientation.E)]
        public void Should_ParseInputOrReturnEmptyValues(string input, short x, short y, RobotOrientation orientation)
        {
            var model = new RobotInitParamsInputModel(input);
            model.Orientation.Should().Be(orientation);
            model.X.Should().Be(x);
            model.Y.Should().Be(y);
        }
    }
}
