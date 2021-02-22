using System;
using System.Collections.Generic;
using FluentValidation;
using RobotField.Abstractions;
using RobotField.Exceptions;
using RobotField.Models.Input;
using RobotField.Validators;
using SimpleInjector;

namespace RobotField.Services
{
    public class ValidationService : IValidationService
    {
        private readonly Container _container;
        private readonly IDictionary<Type, Type> _validators;

        public ValidationService(Container container)
        {
            _container = container;
            this._validators = new Dictionary<Type, Type>
            {
                {typeof(FieldDimensionsInputModel) ,typeof(FieldDimensionsInputModelValidator)},
                {typeof(RobotInitParamsInputModel), typeof(RobotInitParamsInputModelValidator)}
            };
        }

        private AbstractValidator<T> GetValidator<T>()
        {
            var modelType = typeof(T);
            var hasValidator = this._validators.ContainsKey(modelType);
            if (hasValidator == false)
            {
                throw new Exception("Missing validator");
            }

            var validatorType = this._validators[modelType];
            var validator = _container.GetInstance(validatorType) as AbstractValidator<T>;
            return validator;
        }

        public void EnsureValid<T>(T model)
        {
            var validator = this.GetValidator<T>();
            var result = validator.Validate(model);
            if (result.IsValid == false)
            {
                throw new InvalidParamException(result.ToString());
            }
        }
    }
}
