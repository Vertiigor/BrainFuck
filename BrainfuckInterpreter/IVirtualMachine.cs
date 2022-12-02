using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
    public interface IVirtualMachine
    {
        void RegisterCommand(char symbol, Action<IVirtualMachine> execute);
        string Instructions { get; }
        int InstructionPointer { get; set; }
        byte[] Memory { get; }
        int MemoryPointer { get; set; }
        void Run();
    }
}
