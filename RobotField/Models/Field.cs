using System.Collections.Generic;

namespace RobotField.Models
{
    public class Field
    {
        public short Width { get; set; }
        public short Height { get; set; }

        public List<Robot> RobotScents { get; set; } = new List<Robot>();
        public void AddRobotScent(Robot robot)
        {
            RobotScents.Add(robot);
        }
    }
}
