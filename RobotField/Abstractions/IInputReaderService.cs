using RobotField.Models.Input;

namespace RobotField.Abstractions
{
    public interface IInputReaderService
    {
        FieldDimensionsInputModel GetFieldInitializationDimensions();
        RobotInitParamsInputModel GetInitialRobotParams();
        RobotInstructionInputModel GetRobotInstructions();
    }
}
