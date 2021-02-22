using FluentAssertions;
using RobotField.Enums;
using RobotField.Models;
using RobotField.Services;
using Xunit;

namespace RobotField.UnitTests.Services
{
    public class OutputBuilderServiceTests
    {
        private readonly OutputBuilderService _service;

        public OutputBuilderServiceTests()
        {
            _service = new OutputBuilderService();
        }

        [Fact]
        public void Should_BuildOutputForPosition()
        {
            //arrange
            var robot = new Robot
            {
                X=2,
                Y=2,
                Orientation=RobotOrientation.N
            };
            var expected = "2 2 N";
            //act
            var actual = this._service.BuildOutput(robot);
            actual.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void Should_BuildOutputForLostRobot()
        {
            //arrange
            var robot = new Robot
            {
                X = 2,
                Y = 2,
                Orientation = RobotOrientation.N
            };
            var expected = "2 2 N LOST";
            //act
            var actual = this._service.BuildOutput(robot, true);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
