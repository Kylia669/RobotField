using RobotField.Models;

namespace RobotField.Abstractions
{
    public interface IOutputPrinterService
    {
        void PrintLastPosition(string output);
    }
}
