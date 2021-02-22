using System.Linq;
using RobotField.Models;

namespace RobotField.Extensions
{
    public static class FieldExtensions
    {
        public static bool HasScent(this Field field, Robot robot)
        {
            return field.RobotScents.Any(_ => _.X == robot.X && _.Y == robot.Y);
        }
    }
}
