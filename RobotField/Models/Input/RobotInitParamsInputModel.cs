using System;
using System.Linq;
using RobotField.Enums;
using RobotField.Extensions;

namespace RobotField.Models.Input
{
    public class RobotInitParamsInputModel
    {
        public RobotInitParamsInputModel(string input)
        {
            this.RawInput = input;
        }
        public string RawInput { get; set; }

        public short X
        {
            get
            {
                return RawInput.GetFromParts(0);
            }
        }

        public short Y {
            get
            {
                return RawInput.GetFromParts(1);
            }
        }

        public RobotOrientation? Orientation
        {
            get
            {
                var orientation = RawInput.GetInputParts()?.Last();
                var canParse = Enum.TryParse(orientation, true, out RobotOrientation parsedValue);
                if (canParse == false)
                {
                    return null;
                }
                return parsedValue;
            }
        }
    }
}
