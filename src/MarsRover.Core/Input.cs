using System;
using System.Collections.Generic;

namespace MarsRover.Core
{
    public class Input
    {
        private const int instructionMaxLength = 100;

        public string input;

        public static Input FromString(string input) => new Input(input);
        private Input(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException($"{nameof(input)} can not be null or empty");
            }

            if (input.Length > instructionMaxLength)
            {
                throw new ArgumentException($"Instruction length can not be over {instructionMaxLength}");
            }
            this.input = input;
        }

        public IEnumerable<string> Slice(char separator) => input.Split(separator);

        public IEnumerable<Instruction> ParseToInstructionList()
        {
            foreach (char instruction in input)
            {
                yield return InstructionFactory.CreateFromCharacter(instruction);
            }
        }
    }
}
