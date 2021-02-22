using RobotField.Abstractions;
using RobotField.Models;
using RobotField.Models.Input;

namespace RobotField.Creators
{
    public class FieldCreator : IFieldCreator
    {
        private readonly IValidationService _validationService;

        public FieldCreator(IValidationService validationService)
        {
            _validationService = validationService;
        }

        public Field CreateField(FieldDimensionsInputModel inputDimensions)
        {
            this._validationService.EnsureValid(inputDimensions);

            var field = new Field
            {
                Width = inputDimensions.Width,
                Height = inputDimensions.Height
            };

            return field;
        }
    }
}
