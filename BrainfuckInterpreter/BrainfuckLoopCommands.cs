using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfuckInterpreter
{
    public class BrainfuckLoopCommands
	{
		private static Stack<int> openBrackets = new Stack<int>();
		private static Dictionary<int, int> brackets = new Dictionary<int, int>();

		public static void RegisterTo(IVirtualMachine vm)
		{
			for(int i = 0; i < vm.Instructions.Length; i++)
			{
				if (vm.Instructions[i] == '[')
				{
					openBrackets.Push(i);
				}
				else if(vm.Instructions[i] == ']')
				{
					brackets[openBrackets.Peek()] = i;
                    brackets[i] = openBrackets.Pop();
                }
			}

			vm.RegisterCommand('[', b => 
			{
				if (vm.Memory[vm.MemoryPointer] == 0)
				{
					vm.InstructionPointer = brackets[vm.InstructionPointer];
				}
			});
			vm.RegisterCommand(']', b => 
			{
                if (!(vm.Memory[vm.MemoryPointer] == 0))
                {
                    vm.InstructionPointer = brackets[vm.InstructionPointer];
                }
            });
		}
	}
}
