using System.Collections.Generic;
using System.Linq;
using RobotField.Commands;

namespace RobotField.Models.Input
{
    public class RobotInstructionInputModel
    {
        public RobotInstructionInputModel(string input)
        {
            this.RawInput = input;
        }
        public string RawInput { get; set; }

        public List<ICommand> Instructions
        {
            get
            {
                var instructions = new List<ICommand>();
                var commandChars = RawInput.ToCharArray().ToList();
                foreach (var commandChar in RawInput)
                {
                    var character = $"{commandChar}".ToLowerInvariant();
                    switch (character)
                    {
                        case "r":
                            instructions.Add(new TurnRightCommand());
                            break;
                        case "l":
                            instructions.Add(new TurnLeftCommand());
                            break;
                        case "f":
                            instructions.Add(new MoveForwardCommand());
                            break;
                    }
                }
                return instructions;
            }
        }
    }
}
