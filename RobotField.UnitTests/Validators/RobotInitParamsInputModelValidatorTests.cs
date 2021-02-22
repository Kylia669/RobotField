using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using RobotField.Models.Input;
using RobotField.Validators;
using Xunit;

namespace RobotField.UnitTests.Validators
{
    public class RobotInitParamsInputModelValidatorTests
    {
        private readonly RobotInitParamsInputModelValidator _validator;

        public RobotInitParamsInputModelValidatorTests()
        {
            _validator = new RobotInitParamsInputModelValidator();
        }

        [Theory]
        [InlineData("1 1 S")]
        [InlineData("50 49 N")]
        [InlineData("25 50 E")]
        [InlineData("50 50 W")]
        public void Should_BeValid(string input)
        {
            //arrange
            var model = new RobotInitParamsInputModel(input);
            //act
            var result = this._validator.Validate(model);
            //assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("1 0 S")]
        [InlineData("51 10 W")]
        [InlineData("10 51 W")]
        public void Should_BeInValid(string input)
        {
            //arrange
            var model = new RobotInitParamsInputModel(input);
            //act
            var result = this._validator.Validate(model);
            //assert
            result.IsValid.Should().BeFalse();
        }
    }
}
