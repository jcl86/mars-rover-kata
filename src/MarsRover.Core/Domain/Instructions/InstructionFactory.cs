using System;

namespace MarsRover.Core
{
    public static class InstructionFactory
    {
        public static Instruction CreateFromCharacter(char instruction)
        {
            return instruction switch
            {
                'L' => Instruction.L,
                'R' => Instruction.R,
                'F' => Instruction.F,
                _ => throw new ArgumentException($"{instruction} could not be converted to {nameof(Instruction)}")
            };
        }
    }
}
