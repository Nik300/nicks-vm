namespace NicksVM.Core;

public sealed class VirtualMachine
{
  public readonly HSL.Memory memory = new();
  public readonly CPU cpu;
  public readonly IOPU iopu;
  public readonly MPU mpu;
  public readonly IDPU idpu;

  public VirtualMachine()
  {
    mpu = new(this);
    cpu = new(this);
    iopu = new(this);
    idpu = new(this);
  }

  public unsafe void LoadROM(byte[] romData)
  {
    fixed (byte *data = romData) { mpu.ProgramOffset = *(uint *)data; mpu.DataOffset = *(uint *)(data + 4); }
    for (uint x = 8, addr = mpu.ProgramOffset; x < romData.Length; x++, addr++) memory.Write8(addr, romData[x]);
    idpu.InstructionPointer = mpu.ProgramOffset;
  }
}