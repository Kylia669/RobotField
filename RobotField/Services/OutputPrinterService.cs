using System.IO;
using RobotField.Abstractions;

namespace RobotField.Services
{
    public class OutputPrinterService : IOutputPrinterService
    {
        private readonly StreamWriter _stream;

        public OutputPrinterService(Stream stream)
        {
            this._stream = new StreamWriter(stream);
            this._stream.AutoFlush = true;
        }
        public void PrintLastPosition(string output)
        {
            _stream.WriteLine(output);
        }
    }
}
