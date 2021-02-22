using FluentAssertions;
using RobotField.Models.Input;
using Xunit;

namespace RobotField.UnitTests.Models.Input
{
    public class FieldDimensionsInputModelTests
    {
        [Theory]
        [InlineData("2 2", 2, 2, 2)]
        [InlineData("100 100", 100, 100, 2)]
        [InlineData("1 2 3", 1, 2, 3)]
        [InlineData("-1 2", 0, 2, 2)]
        [InlineData("1 -2", 1, 0, 2)]
        [InlineData("a 2", 0, 2, 2)]
        [InlineData("2 a", 2, 0, 2)]
        [InlineData("a a", 0, 0, 2)]
        public void Should_ParseInputOrReturnEmptyValues(string input, short width, short height, int countDimensions)
        {
            var model = new FieldDimensionsInputModel(input);
            model.DimensionsCount.Should().Be(countDimensions);
            model.Width.Should().Be(width);
            model.Height.Should().Be(height);
        }
    }
}
