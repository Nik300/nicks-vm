namespace NicksVM.Core;

public partial class IOPU(VirtualMachine virtualMachine)
{
  private readonly VirtualMachine _vm = virtualMachine;

  public uint KTP { get; set; } = 0;
  public ushort KSR { get; set; } = 0;

  public uint COP
  {
    get => 0;
    set
    {
      var output = _vm.memory.ReadString(value);
      Console.WriteLine(output);
    }
  }
  public byte COC
  {
    get => 0;
    set
    {
      Console.Write((char)value);
    }
  }
  public uint CCL
  {
    get => (uint)Console.CursorLeft;
    set => Console.CursorLeft = (int)value;
  }
  public uint CCT
  {
    get => (uint)Console.CursorTop;
    set => Console.CursorTop = (int)value;
  }
  public uint CSR { get; set; } = 0;

  public uint GCR { get; set; } = 0;
  public uint GDR { get; set; } = 0;
  
  public byte FCR { get; set; } = 0;
}