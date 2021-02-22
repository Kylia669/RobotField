using System.ComponentModel.DataAnnotations;
using FluentAssertions;
using RobotField.Models.Input;
using RobotField.Validators;
using Xunit;

namespace RobotField.UnitTests.Validators
{
    public class FieldDimensionsInputModelValidatorTests
    {
        private readonly FieldDimensionsInputModelValidator _validator;

        public FieldDimensionsInputModelValidatorTests()
        {
            _validator = new FieldDimensionsInputModelValidator();
        }

        [Theory]
        [InlineData("1 1")]
        [InlineData("50 49")]
        [InlineData("25 50")]
        [InlineData("50 50")]
        public void Should_BeValid(string input)
        {
            //arrange
            var model = new FieldDimensionsInputModel(input);
            //act
            var result = this._validator.Validate(model);
            //assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("0 1")]
        [InlineData("1 0")]
        [InlineData("51 10")]
        [InlineData("10 51")]
        public void Should_BeInValid(string input)
        {
            //arrange
            var model = new FieldDimensionsInputModel(input);
            //act
            var result = this._validator.Validate(model);
            //assert
            result.IsValid.Should().BeFalse();
        }
    }
}
