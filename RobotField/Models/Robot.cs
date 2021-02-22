using RobotField.Enums;

namespace RobotField.Models
{
    public class Robot
    {
        public short X { get; set; }
        public short Y { get; set; }
        public RobotOrientation Orientation { get; set; }

        public override string ToString()
        {
            return $"{X} {Y} {Orientation.ToString()}";
        }
    }
}
