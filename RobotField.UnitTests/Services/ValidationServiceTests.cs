using System;
using FluentAssertions;
using RobotField.Abstractions;
using RobotField.Exceptions;
using RobotField.Models.Input;
using RobotField.Services;
using RobotField.Validators;
using SimpleInjector;
using Xunit;

namespace RobotField.UnitTests.Services
{
    public class ValidationServiceTests
    {
        private readonly IValidationService _validationService;

        public ValidationServiceTests()
        {
            var container = new Container();
            container.Register<FieldDimensionsInputModelValidator>();
            _validationService = new ValidationService(container);
        }

        [Fact]
        public void EnsureValid_ShouldThrow_WhenMissingValidator()
        {
            var request = new ValidationServiceTests();
            //act
            Action action = () => this._validationService.EnsureValid(request);
            //assert
            action.Should().Throw<Exception>();
        }

        [Fact]
        public void EnsureValid_ShouldThrow_WhenValidationError()
        {
            var model = new FieldDimensionsInputModel("");
            //act
            Action action = () => this._validationService.EnsureValid(model);
            //assert
            action.Should().Throw<InvalidParamException>();
        }

        [Fact]
        public void EnsureValid_ShouldNotThrow_WhenNotValidationError()
        {
            var model = new FieldDimensionsInputModel("3 3");
            //act
            Action action = () => this._validationService.EnsureValid(model);
            //assert
            action.Should().NotThrow<InvalidParamException>();
        }
    }
}
