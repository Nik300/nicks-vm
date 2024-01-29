namespace NicksVM.Core;

public partial class CPU(VirtualMachine virtualMachine)
{
  private readonly VirtualMachine _vm = virtualMachine;

  public uint Execution1 { get; set; } = 0;
  public uint Execution2 { get; set; } = 0;
  public uint Execution3 { get; set; } = 0;

  public uint A { get; set; } = 0;
  public uint B { get; set; } = 0;
  public uint C { get; set; } = 0;

  public uint MAP { get; set; } = 0;
  
  public uint MDR
  {
    get => _vm.memory.Read32(MAP);
    set => _vm.memory.Write32(MAP, value);
  }

  public ushort MDRL
  {
    get => _vm.memory.Read16(MAP);
    set => _vm.memory.Write16(MAP, value);
  }
  public ushort MDRH
  {
    get => _vm.memory.Read16(MAP + 2);
    set => _vm.memory.Write16(MAP + 2, value);
  }

  public byte MDRLH
  {
    get => _vm.memory.Read8(MAP + 1);
    set => _vm.memory.Write8(MAP + 1, value);
  }
  public byte MDRHH
  {
    get => _vm.memory.Read8(MAP + 3);
    set => _vm.memory.Write8(MAP + 3, value);
  }

  public byte MDRLL
  {
    get => _vm.memory.Read8(MAP);
    set => _vm.memory.Write8(MAP, value);
  }
  public byte MDRHL
  {
    get => _vm.memory.Read8(MAP + 2);
    set => _vm.memory.Write8(MAP + 2, value);
  }
}