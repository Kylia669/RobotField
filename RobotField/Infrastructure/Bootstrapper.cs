using System.IO;
using RobotField.Abstractions;
using RobotField.Creators;
using RobotField.Models.Input;
using RobotField.Processor;
using RobotField.Services;
using RobotField.Validators;
using RobotField.Validators.Business;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace RobotField.Infrastructure
{
    public class Bootstrapper
    {
        private readonly Container _container;

        public Bootstrapper()
        {
            this._container = new Container();
            this._container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
        }

        public Container Bootstrap(Stream input, Stream output)
        {
            // input / output 
            this._container.Register<IInputReaderService>(() => new InputReaderService(input), Lifestyle.Scoped);
            this._container.Register<IOutputPrinterService>(() => new OutputPrinterService(output), Lifestyle.Scoped);
            // creators
            this._container.Register<IFieldCreator, FieldCreator>(Lifestyle.Scoped);
            this._container.Register<IRobotCreator, RobotCreator>(Lifestyle.Scoped);

            //processors
            this._container.Register<IRobotsProcessor, RobotsProcessor>(Lifestyle.Scoped);

            //services
            this._container.Register<IMoveService, MoveService>(Lifestyle.Scoped);
            this._container.Register<IOutputBuilderService, OutputBuilderService>(Lifestyle.Scoped);
            this._container.Register<IValidationService, ValidationService>(Lifestyle.Scoped);

            //validators
            this._container.Register<IRobotOnFieldValidator, RobotOnFieldValidator>(Lifestyle.Scoped);
            //validators
            this._container.Register<FieldDimensionsInputModelValidator>();
            this._container.Register<RobotInitParamsInputModelValidator>();

            // check everything is ok
            this._container.Verify(VerificationOption.VerifyAndDiagnose);

            return this._container;
        }
    }
}
