namespace NicksVM.Core;

public partial class MPU : IPU
{
  public IPU.Instruction[] Instructions { get; } =
  [
    // ldprog A, x
    vm => { vm.mpu.ProgramOffset = vm.cpu.A; vm.mpu.DataOffset = vm.cpu.B; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.A; vm.mpu.DataOffset = vm.cpu.C; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.A; vm.mpu.DataOffset = vm.cpu.MDR; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.A; vm.mpu.DataOffset = vm.mpu.DR; },
    // ldprog B, x
    vm => { vm.mpu.ProgramOffset = vm.cpu.B; vm.mpu.DataOffset = vm.cpu.A; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.B; vm.mpu.DataOffset = vm.cpu.C; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.B; vm.mpu.DataOffset = vm.cpu.MDR; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.B; vm.mpu.DataOffset = vm.mpu.DR; },
    // ldprog C, x
    vm => { vm.mpu.ProgramOffset = vm.cpu.C; vm.mpu.DataOffset = vm.cpu.A; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.C; vm.mpu.DataOffset = vm.cpu.B; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.C; vm.mpu.DataOffset = vm.cpu.MDR; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.C; vm.mpu.DataOffset = vm.mpu.DR; },
    // ldprog MDR, x
    vm => { vm.mpu.ProgramOffset = vm.cpu.MDR; vm.mpu.DataOffset = vm.cpu.A; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.MDR; vm.mpu.DataOffset = vm.cpu.B; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.MDR; vm.mpu.DataOffset = vm.cpu.C; },
    vm => { vm.mpu.ProgramOffset = vm.cpu.MDR; vm.mpu.DataOffset = vm.mpu.DR; },
    // ldprog DR, x
    vm => { vm.mpu.ProgramOffset = vm.mpu.DR; vm.mpu.DataOffset = vm.cpu.A; },
    vm => { vm.mpu.ProgramOffset = vm.mpu.DR; vm.mpu.DataOffset = vm.cpu.B; },
    vm => { vm.mpu.ProgramOffset = vm.mpu.DR; vm.mpu.DataOffset = vm.cpu.C; },
    vm => { vm.mpu.ProgramOffset = vm.mpu.DR; vm.mpu.DataOffset = vm.cpu.MDR; },

    // ldsp
    vm => { vm.mpu.StackPointer = vm.cpu.A; },
    vm => { vm.mpu.StackPointer = vm.cpu.B; },
    vm => { vm.mpu.StackPointer = vm.cpu.C; },
    vm => { vm.mpu.StackPointer = vm.cpu.MDR; },
    vm => { vm.mpu.StackPointer = vm.mpu.DR; },
    //stsp
    vm => { vm.cpu.A = vm.mpu.StackPointer; },
    vm => { vm.cpu.B = vm.mpu.StackPointer; },
    vm => { vm.cpu.C = vm.mpu.StackPointer; },
    vm => { vm.cpu.MDR = vm.mpu.StackPointer; },
    vm => { vm.mpu.DR = vm.mpu.StackPointer; },

    // ldbp
    vm => { vm.mpu.BasePointer = vm.cpu.A; },
    vm => { vm.mpu.BasePointer = vm.cpu.B; },
    vm => { vm.mpu.BasePointer = vm.cpu.C; },
    vm => { vm.mpu.BasePointer = vm.cpu.MDR; },
    vm => { vm.mpu.BasePointer = vm.mpu.DR; },
    //stbp
    vm => { vm.cpu.A = vm.mpu.BasePointer; },
    vm => { vm.cpu.B = vm.mpu.BasePointer; },
    vm => { vm.cpu.C = vm.mpu.BasePointer; },
    vm => { vm.cpu.MDR = vm.mpu.BasePointer; },
    vm => { vm.mpu.DR = vm.mpu.BasePointer; },

    // ldlsp
    vm => { vm.mpu.LibraryStackPointer = vm.cpu.A; },
    vm => { vm.mpu.LibraryStackPointer = vm.cpu.B; },
    vm => { vm.mpu.LibraryStackPointer = vm.cpu.C; },
    vm => { vm.mpu.LibraryStackPointer = vm.cpu.MDR; },
    vm => { vm.mpu.LibraryStackPointer = vm.mpu.DR; },
    //stlsp
    vm => { vm.cpu.A = vm.mpu.LibraryStackPointer; },
    vm => { vm.cpu.B = vm.mpu.LibraryStackPointer; },
    vm => { vm.cpu.C = vm.mpu.LibraryStackPointer; },
    vm => { vm.cpu.MDR = vm.mpu.LibraryStackPointer; },
    vm => { vm.mpu.DR = vm.mpu.LibraryStackPointer; },

    // ldlbp
    vm => { vm.mpu.LibraryBasePointer = vm.cpu.A; },
    vm => { vm.mpu.LibraryBasePointer = vm.cpu.B; },
    vm => { vm.mpu.LibraryBasePointer = vm.cpu.C; },
    vm => { vm.mpu.LibraryBasePointer = vm.cpu.MDR; },
    vm => { vm.mpu.LibraryBasePointer = vm.mpu.DR; },
    //stlbp
    vm => { vm.cpu.A = vm.mpu.LibraryBasePointer; },
    vm => { vm.cpu.B = vm.mpu.LibraryBasePointer; },
    vm => { vm.cpu.C = vm.mpu.LibraryBasePointer; },
    vm => { vm.cpu.MDR = vm.mpu.LibraryBasePointer; },
    vm => { vm.mpu.DR = vm.mpu.LibraryBasePointer; },

    // ulkb
    vm => { vm.memory.MemoryBlocks[HSL.Memory.ReadAddress(vm.cpu.A).page] = null; },
    vm => { vm.memory.MemoryBlocks[HSL.Memory.ReadAddress(vm.cpu.B).page] = null; },
    vm => { vm.memory.MemoryBlocks[HSL.Memory.ReadAddress(vm.cpu.C).page] = null; },
    vm => { vm.memory.MemoryBlocks[HSL.Memory.ReadAddress(vm.cpu.MDR).page] = null; },
    vm => { vm.memory.MemoryBlocks[HSL.Memory.ReadAddress(vm.mpu.DR).page] = null; },

    // drch
    vm => { vm.mpu.DR = vm.cpu.A; },
    vm => { vm.mpu.DR = vm.cpu.B; },
    vm => { vm.mpu.DR = vm.cpu.C; },
    vm => { vm.mpu.DR = vm.cpu.MDR; },
    vm => { vm.mpu.DR = vm.mpu.DR; },
  ];

  public static string[] Mnemonics { get; } =
  [
    "ldprog A, B", "ldprog A, C", "ldprog A, MDR", "ldprog A, DR",
    "ldprog B, A", "ldprog B, C", "ldprog B, MDR", "ldprog B, DR",
    "ldprog C, A", "ldprog C, B", "ldprog C, MDR", "ldprog C, DR",
    "ldprog MDR, A", "ldprog MDR, B", "ldprog MDR, C", "ldprog MDR, DR",
    "ldprog DR, A", "ldprog DR, B", "ldprog DR, C", "ldprog DR, MDR",
    "ldsp A", "ldsp B", "ldsp C", "ldsp MDR", "ldsp DR",
    "stsp A", "stsp B", "stsp C", "stsp MDR", "stsp DR",
    "ldbp A", "ldbp B", "ldbp C", "ldbp MDR", "ldbp DR",
    "stbp A", "stbp B", "stbp C", "stbp MDR", "stbp DR",
    "ldlsp A", "ldlsp B", "ldlsp C", "ldlsp MDR", "ldlsp DR",
    "stlsp A", "stlsp B", "stlsp C", "stlsp MDR", "stlsp DR",
    "ldlbp A", "ldlbp B", "ldlbp C", "ldlbp MDR", "ldlbp DR",
    "stlbp A", "stlbp B", "stlbp C", "stlbp MDR", "stlbp DR",
    "ulkb A", "ulkb B", "ulkb C", "ulkb MDR", "ulkb DR",
    "drch A", "drch B", "drch C", "drch MDR", "drch DR"
  ];
}