using System.Runtime.InteropServices;

namespace NicksVM.Core;

public class IDPU(VirtualMachine vm) : IPU
{
  public ushort InstructionRegister { get; set; }
  public uint InstructionPointer { get; set; }

  public IPU.Instruction[] Instructions { get; } =
  [
    // ldip
    vm => { vm.idpu.InstructionPointer = vm.cpu.A; },
    vm => { vm.idpu.InstructionPointer = vm.cpu.B; },
    vm => { vm.idpu.InstructionPointer = vm.cpu.C; },
    vm => { vm.idpu.InstructionPointer = vm.cpu.MDR; },
    vm => { vm.idpu.InstructionPointer = vm.mpu.DR; },
    // stip
    vm => { vm.cpu.A = vm.idpu.InstructionPointer; },
    vm => { vm.cpu.B = vm.idpu.InstructionPointer; },
    vm => { vm.cpu.C = vm.idpu.InstructionPointer; },
    vm => { vm.cpu.MDR = vm.idpu.InstructionPointer; },
  ];

  public static string[] Mnemonics { get; } =
  [
    "ldip A", "ldip B", "ldip C", "ldip MDR", "ldip DR",
    "stip A", "stip B", "stip C", "stip MDR",
  ];

  public bool Cycle()
  {
    if (vm.iopu.FCR != 0) return false;

    if (vm.mpu.DataOffset <= vm.mpu.ProgramOffset)
    {
      vm.iopu.FCR = 0xFF;
      vm.cpu.Execution1 = (uint)0b_1001 << 28;
      return false;
    }

    InstructionRegister = vm.memory.Read16(vm.mpu.ProgramOffset + InstructionPointer);

    UnitIdentifier unit = (UnitIdentifier)(InstructionRegister >> 8);
    byte iid = (byte)(InstructionRegister & 0x00FF);

    IPU? executingUnit = unit switch {
      UnitIdentifier.CPU => vm.cpu,
      UnitIdentifier.IOPU => vm.iopu,
      UnitIdentifier.MPU => vm.mpu,
      UnitIdentifier.IDPU => vm.idpu,
      _ => null
    };

    if (executingUnit is null)
    {
      vm.iopu.FCR = 0xFF;
      vm.cpu.Execution1 = (uint)0b_1001 << 24;
      return false;
    }
    else if (iid > executingUnit.Instructions.Length)
    {
      vm.iopu.FCR = 0xFF;
      vm.cpu.Execution1 = (uint)0b_1010 << 24;
      return false;
    }

    InstructionPointer += 2;
    executingUnit.Instructions[iid](vm);
    return true;
  }

  public uint ReadNext32()
  {
    uint result = vm.memory.Read32(vm.mpu.ProgramOffset + InstructionPointer);
    InstructionPointer += 4;
    return result;
  }
  public ushort ReadNext16()
  {
    ushort result = vm.memory.Read16(vm.mpu.ProgramOffset + InstructionPointer);
    InstructionPointer += 2;
    return result;
  }
  public byte ReadNext8() {
    byte result = vm.memory.Read8(vm.mpu.ProgramOffset + InstructionPointer);
    InstructionPointer++;
    return result;
  }
}