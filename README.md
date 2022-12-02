# BrainFuck
A simple Brainfuck interpreter created in C# on the .Net Core platform.

I accidentally caught cyberpsychosis.

I decided to create this interpreter in order to improve my skills.

# How it works

Scheme of the virtual machine:

![](https://github.com/Vertiigor/BrainFuck/blob/master/BrainFuck/Pics/VirtualMachineScheme.png)

Instructions - it's a program on BrainFuck.

InstructionsPointer - pointer to the current function (instruction).

Memory - byte array. The default size is 30000.

MemoryPointer - pointer to the current memory location. Initially, the pointer points to the null cell.

# Instructions

| Instruction   | Action        |
| ------------- | ------------- |
| .             | Print the byte of memory pointed to by the pointer, converting to a character according to ASCII.  |
| +             | Increment the byte of memory pointed to by the pointer.  |
| -             | Decrement the byte of memory pointed to by the pointer.  |
| ,             | Enter a character and store its ASCII code in the byte of memory pointed to by the pointer.  |
| >             | Shift memory pointer right by 1 byte.  |
| <             | Shift memory pointer left by 1 byte.  |
| a - z, 0 - 9  | store the ASCII code of this character in the byte of memory pointed to by the pointer.  |
