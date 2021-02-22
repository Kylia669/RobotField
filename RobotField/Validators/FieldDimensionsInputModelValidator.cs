using FluentValidation;
using RobotField.Models.Input;

namespace RobotField.Validators
{
    public class FieldDimensionsInputModelValidator : AbstractValidator<FieldDimensionsInputModel>
    {
        private const short REQUIRED_DIMENSIONS_COUNT = 2;
        private const short MAX_DIMENSION_SIZE = 50;

        private const string INVALID_PARAMS_MESSAGE = "Invalid field initialization params";
        private const string INVALID_PARAMS_COUNT_MESSAGE = "field initialization params should be 2";

        public FieldDimensionsInputModelValidator()
        {
            this.RuleFor(_ => _.RawInput).NotNull().NotEmpty()
                .WithMessage(INVALID_PARAMS_MESSAGE);
            this.RuleFor(_ => _.DimensionsCount).Equal(REQUIRED_DIMENSIONS_COUNT)
                .WithMessage(INVALID_PARAMS_COUNT_MESSAGE);
            this.RuleFor(_ => _.Width).NotEmpty().LessThanOrEqualTo(MAX_DIMENSION_SIZE);
            this.RuleFor(_ => _.Height).NotEmpty().LessThanOrEqualTo(MAX_DIMENSION_SIZE);
        }
    }
}
