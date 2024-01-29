namespace NicksVM.Core;

public partial class MPU(VirtualMachine virtualMachine)
{
  private readonly VirtualMachine _vm = virtualMachine; 

  public uint ProgramOffset { get; set; }
  public uint DataOffset { get; set; }

  public uint StackPointer { get; set; }
  public uint BasePointer { get; set; }

  public uint ReturnStackPointer { get; set; }

  public uint LibraryStackPointer { get; set; }
  public uint LibraryBasePointer { get; set; }

  private uint _dataAddress = 0;

  public uint DR
  {
    get
    {
      return _vm.memory.Read32(_vm.mpu.DataOffset + _dataAddress);
    }
    set
    {
      _dataAddress = value;
    }
  }

  public ushort DRL
  {
    get
    {
      return _vm.memory.Read16(_vm.mpu.DataOffset + _dataAddress);
    }
  }
  public ushort DRH
  {
    get
    {
      return _vm.memory.Read16(_vm.mpu.DataOffset + _dataAddress + 2);
    }
  }

  public byte DRLH
  {
    get
    {
      return _vm.memory.Read8(_vm.mpu.DataOffset + _dataAddress + 1);
    }
  }
  public byte DRHH
  {
    get
    {
      return _vm.memory.Read8(_vm.mpu.DataOffset + _dataAddress + 3);
    }
  }
  public byte DRLL
  {
    get
    {
      return _vm.memory.Read8(_vm.mpu.DataOffset + _dataAddress);
    }
  }
  public byte DRHL
  {
    get
    {
      return _vm.memory.Read8(_vm.mpu.DataOffset + _dataAddress + 2);
    }
  }
}