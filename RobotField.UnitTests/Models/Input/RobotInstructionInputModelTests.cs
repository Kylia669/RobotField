using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using RobotField.Commands;
using RobotField.Models.Input;
using Xunit;

namespace RobotField.UnitTests.Models.Input
{
    public class RobotInstructionInputModelTests
    {
        [Fact]
        public void Should_ReturnListOfCommands()
        {
            string input = "RlF";
            var model = new RobotInstructionInputModel(input);
            var expected = new List<Type>
            {
                typeof(TurnRightCommand),
                typeof(TurnLeftCommand),
                typeof(MoveForwardCommand)
            };

            //assert
            model.Instructions.Select(_ => _.GetType()).Should().BeEquivalentTo(expected);
        }
    }
}
