namespace NicksVM.Core.HSL;

public sealed class MemoryBlock
{
  // Represents a 4mb block size
  public const uint Size = 4_194_304;

  public byte[] Buffer { get; } = new byte[Size];

  public MemoryBlock()
  {
  }
}