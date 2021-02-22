using System.IO;
using RobotField.Abstractions;
using RobotField.Models.Input;

namespace RobotField.Services
{
    public class InputReaderService : IInputReaderService
    {
        private readonly StreamReader _stream;

        public InputReaderService(Stream stream)
        {
            this._stream = new StreamReader(stream);
        }
        public FieldDimensionsInputModel GetFieldInitializationDimensions()
        {
            var input = this._stream.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            return new FieldDimensionsInputModel(input);
        }

        public RobotInitParamsInputModel GetInitialRobotParams()
        {
            var input = this._stream.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            return new RobotInitParamsInputModel(input);
        }

        public RobotInstructionInputModel GetRobotInstructions()
        {
            var input = this._stream.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return null;
            }
            return new RobotInstructionInputModel(input);
        }
    }
}
