namespace BrainfuckInterpreter
{
    public class BrainfuckBasicCommands
    {
        const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        public static void RegisterTo(IVirtualMachine vm, Func<int> read, Action<char> write)
        {
            vm.RegisterCommand('.', b => { write((char)vm.Memory[vm.MemoryPointer]); });
            vm.RegisterCommand('+', b => { vm.Memory[vm.MemoryPointer]++; });
            vm.RegisterCommand('-', b => { vm.Memory[vm.MemoryPointer]--; });
            vm.RegisterCommand(',', b => { vm.Memory[vm.MemoryPointer] = (byte)read(); });
            vm.RegisterCommand('>', b => 
            {
                if (vm.MemoryPointer >= vm.Memory.Length - 1)
                {
                    vm.MemoryPointer = -1;
                }

                vm.MemoryPointer++; 
            });
            vm.RegisterCommand('<', b =>
            {
                if(vm.MemoryPointer == 0)
                {
                    vm.MemoryPointer = vm.Memory.Length;
                }

                vm.MemoryPointer--; 
            });
            
            foreach(char symbol in alphabet) 
            {
                vm.RegisterCommand(symbol, b => { vm.Memory[vm.MemoryPointer] = (byte)symbol; });
            }
        }
    }
}
