using FluentAssertions;
using NSubstitute;
using RobotField.Abstractions;
using RobotField.Creators;
using RobotField.Models;
using RobotField.Models.Input;
using Xunit;

namespace RobotField.UnitTests.Creators
{
    public class FieldCreatorTests
    {
        private readonly FieldCreator _fieldCreator;
        private readonly IValidationService _validationService;

        public FieldCreatorTests()
        {
            this._validationService = Substitute.For<IValidationService>();
            _fieldCreator = new FieldCreator(this._validationService);
        }

        [Fact]
        public void Should_ValidateInputModel()
        {
            //arrange
            var inputModel = new FieldDimensionsInputModel("");
            //act
            this._fieldCreator.CreateField(inputModel);
            //assert
            this._validationService.Received(1).EnsureValid(inputModel);
        }

        [Fact]
        public void Should_ReturnInitializedField()
        {
            //arrange
            var inputModel = new FieldDimensionsInputModel("2 2");
            var expected = new Field
            {
                Width = 2,
                Height = 2
            };
            //act
            var actual = this._fieldCreator.CreateField(inputModel);
            //assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
