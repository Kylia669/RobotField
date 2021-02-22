using FluentAssertions;
using NSubstitute;
using RobotField.Abstractions;
using RobotField.Creators;
using RobotField.Enums;
using RobotField.Models;
using RobotField.Models.Input;
using Xunit;

namespace RobotField.UnitTests.Creators
{
    public class RobotCreatorTests
    {
        private readonly RobotCreator _fieldCreator;
        private readonly IValidationService _validationService;
        private readonly Field _field;
        private readonly IRobotOnFieldValidator _robotOnFieldValidator;

        public RobotCreatorTests()
        {
           
            this._field = new Field
            {
                Height = 10,
                Width = 10
            };
            
            this._validationService = Substitute.For<IValidationService>();
            _robotOnFieldValidator = Substitute.For<IRobotOnFieldValidator>();
            _fieldCreator = new RobotCreator(this._validationService, this._robotOnFieldValidator);
        }

        [Fact]
        public void Should_ValidateInputModel()
        {
            //arrange
            var inputModel = new RobotInitParamsInputModel("2 2 S");
            //act
            this._fieldCreator.CreateRobot(inputModel, this._field);
            //assert
            this._validationService.Received(1).EnsureValid(inputModel);
        }

        [Fact]
        public void Should_ValidateRobotOnField()
        {
            //arrange
            var inputModel = new RobotInitParamsInputModel("2 2 S");
            //act
            this._fieldCreator.CreateRobot(inputModel, this._field);
            //assert
            this._robotOnFieldValidator.Received(1).EnsureValid(Arg.Any<Robot>(), _field);
        }

        [Fact]
        public void Should_ReturnInitializedRobot()
        {
            //arrange
            var inputModel = new RobotInitParamsInputModel("2 2 S");
            var expected = new Robot()
            {
               Orientation = RobotOrientation.S,
               X = 2,
               Y = 2
            };
            //act
            var actual = this._fieldCreator.CreateRobot(inputModel, _field);
            //assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
