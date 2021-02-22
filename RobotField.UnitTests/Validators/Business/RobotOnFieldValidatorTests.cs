using System;
using FluentAssertions;
using RobotField.Exceptions;
using RobotField.Models;
using RobotField.Models.Input;
using RobotField.Validators.Business;
using Xunit;

namespace RobotField.UnitTests.Validators.Business
{
    public class RobotOnFieldValidatorTests
    {
        private readonly RobotOnFieldValidator _validator;

        public RobotOnFieldValidatorTests()
        {
            _validator = new RobotOnFieldValidator();
        }

        [Fact]
        public void Should_BeValid()
        {
            //arrange
            var field = new Field
            {
                Height = 1,
                Width = 1
            };
            var robot = new Robot
            {
                X = 1,
                Y = 1
            };
            //act
            Action action = () => this._validator.EnsureValid(robot, field);
            //assert
            action.Should().NotThrow();
        }

        [Fact]
        public void Should_BeInValid()
        {
            //arrange
            var field = new Field
            {
                Height = 1,
                Width = 1
            };
            var robot = new Robot
            {
                X = 2,
                Y = 2
            };
            //act
            Action action = () => this._validator.EnsureValid(robot, field);
            //assert
            action.Should().Throw<InvalidParamException>();
        }
    }
}
