namespace NicksVM.Core;

public interface IPU
{
  public delegate void Instruction(VirtualMachine vm);
  public Instruction[] Instructions { get; }
}