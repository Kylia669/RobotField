using System.Runtime.InteropServices.ComTypes;
using RobotField.Extensions;

namespace RobotField.Models.Input
{
    public class FieldDimensionsInputModel
    {
        public FieldDimensionsInputModel(string input)
        {
            this.RawInput = input;
        }

        public string RawInput { get; private set; }

        public int DimensionsCount
        {
            get
            {
                return (RawInput.GetInputParts()?.Length ?? 0);
            }
        }

        public short Width
        {
            get
            {
                return RawInput.GetFromParts(0);
            }
        }

        public short Height
        {
            get
            {
                return RawInput.GetFromParts(1);
            }
        }
    }
}
