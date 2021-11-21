using System;
using System.Collections.Generic;

namespace MarsRover.Core
{
    public class InputInstructions
    {
        private const int instructionMaxLength = 100;

        public string Instructions;

        public InputInstructions(string instructions)
        {
            Ensure.IsNotNullOrEmpty(instructions, nameof(instructions));

            if (instructions.Length > instructionMaxLength)
            {
                throw new ArgumentException($"Instruction length can not be over {instructionMaxLength}");
            }
            Instructions = instructions;
        }

        public IEnumerable<string> Slice(char separator) => Instructions.Split(separator);

        public IEnumerable<Instruction> ParseToInstructionList()
        {
            foreach (char instruction in Instructions)
            {
                yield return new Instruction(instruction);
            }
        }
    }
}
