using System;

namespace MarsRover.Core
{
    public record Instruction
    {
        public static Instruction L => new('L');
        public static Instruction R => new('R');
        public static Instruction F => new('F');

        private readonly char instruction;

        internal Instruction(char instruction)
        {
            if (instruction != 'L' ||instruction != 'R' || instruction != 'F')
            {
                throw new ArgumentException($"{instruction} is not a valid instruction");
            }
            this.instruction = instruction;
        }
    }
}
