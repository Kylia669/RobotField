using System.Collections.Generic;
using FluentAssertions;
using RobotField.Exceptions;
using RobotField.Extensions;
using RobotField.Models;
using Xunit;

namespace RobotField.UnitTests.Extensions
{
    public class FieldExtensionsTests
    {
        [Fact]
        public void Should_ReturnTrue_WhenHasScent()
        {
            //arrange
            var field = new Field
            {
                RobotScents = new List<Robot>
                {
                    new Robot
                    {
                        X =1,
                        Y=2
                    }
                }
            };
            var robot = new Robot
            {
                X = 1,
                Y = 2
            };
            //act
            var actual = field.HasScent(robot);
            //assert
            actual.Should().BeTrue();
        }

        [Fact]
        public void Should_ReturnFalse_WhenNoScent()
        {
            //arrange
            var field = new Field
            {
                RobotScents = new List<Robot>
                {
                    new Robot
                    {
                        X =2,
                        Y=2
                    }
                }
            };
            var robot = new Robot
            {
                X = 1,
                Y = 2
            };
            //act
            var actual = field.HasScent(robot);
            //assert
            actual.Should().BeFalse();
        }
    }
}
