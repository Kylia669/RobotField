using System;
using RobotField.Abstractions;
using RobotField.Models;

namespace RobotField.Services
{
    public class OutputBuilderService : IOutputBuilderService
    {
        private const string LOST_MARKER = "LOST";
        public string BuildOutput(Robot robot, bool isLost = false)
        {
            string output = $"{robot}";
            if (isLost == true)
            {
                output += $" {LOST_MARKER}";
            }

            return output;
        }
    }
}
