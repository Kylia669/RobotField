using RobotField.Models;
using RobotField.Models.Input;

namespace RobotField.Abstractions
{
    public interface IFieldCreator
    {
        Field CreateField(FieldDimensionsInputModel inputDimensions);
    }
}
