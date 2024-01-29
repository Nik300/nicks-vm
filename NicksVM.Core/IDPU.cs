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

    executingUnit.Instructions[iid](vm);
    InstructionPointer += 2;
    return true;
  }
}