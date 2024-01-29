using NicksVM.Core;

VirtualMachine vm = new();

byte[] bootRom =
[
  // ProgramOffset section prog(.org)
  0x00,0x00,0x00,0x00,
  // DataOffset section data(.org)
  0x04,0x00,0x00,0x00,

  // PROG SECTION
  // lddr8 ALL (low 8-bits of DR into low 8-bits of A)
  0x69,0x00,
  // ldfcr ALL
  0x44,0x01, // hatls the CPU (0x02 -> FCR)

  // DATA SECTION
  0x03,
];

vm.LoadROM(bootRom);
while (vm.idpu.Cycle()) ;

Console.WriteLine(vm.cpu.A);