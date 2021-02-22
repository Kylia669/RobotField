using FluentValidation;
using RobotField.Models.Input;

namespace RobotField.Validators
{
    public class RobotInitParamsInputModelValidator : AbstractValidator<RobotInitParamsInputModel>
    {
        private const short MAX_DIMENSION_SIZE = 50;

        private const string INVALID_PARAMS_MESSAGE = "Invalid field initialization params";

        public RobotInitParamsInputModelValidator()
        {
            this.RuleFor(_ => _.RawInput).NotNull().NotEmpty()
                .WithMessage(INVALID_PARAMS_MESSAGE);
  
            this.RuleFor(_ => _.X).LessThanOrEqualTo(MAX_DIMENSION_SIZE);
            this.RuleFor(_ => _.Y).LessThanOrEqualTo(MAX_DIMENSION_SIZE);

            this.RuleFor(_ => _.Orientation).NotNull().NotEmpty().IsInEnum();
        }
    }
}
