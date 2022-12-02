using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
    public class VirtualMachine : IVirtualMachine
    {
        public string Instructions { get; }
        public int InstructionPointer { get; set; }
        public byte[] Memory { get; }
        public int MemoryPointer { get; set; }

        private Dictionary<char, Action<IVirtualMachine>> commands;

        public VirtualMachine(string program, int memorySize)
        {
            Instructions = program;

            Memory = new byte[memorySize];

            InstructionPointer = 0;

            commands = new Dictionary<char, Action<IVirtualMachine>>();
        }

        public void RegisterCommand(char symbol, Action<IVirtualMachine> execute)
        {
            if (!(commands.ContainsKey(symbol)))
            {
                commands.Add(symbol, execute);
            }
        }

        public void Run()
        {
            while(InstructionPointer < Instructions.Length)
            {
                if (!commands.ContainsKey(Instructions[InstructionPointer]))
                {
                    InstructionPointer++;

                    continue;
                }

                commands[Instructions[InstructionPointer]]?.Invoke(this);

                InstructionPointer++;
            }
        }
    }
}
