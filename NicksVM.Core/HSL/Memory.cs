namespace NicksVM.Core.HSL;

public sealed class Memory
{
  public const uint Size = 1024;
  public MemoryBlock?[] MemoryBlocks { get; } = new MemoryBlock?[Size];

  public static (uint page, uint iaddr) ReadAddress(uint address)
  {
    // the rounded number should correspond to the page
    uint page_addr = address / 4096 / 1024; 
    uint iaddr = address - page_addr * 4096 * 1024;

    return (page_addr, iaddr);
  }

  public byte Read8(uint address)
  {
    var (pg, iaddr) = ReadAddress(address);

    if (MemoryBlocks[pg] is null) return 0;
    return MemoryBlocks[pg]!.Buffer[iaddr];
  }
  public unsafe ushort Read16(uint address)
  {
    var (pg, iaddr) = ReadAddress(address);

    if (MemoryBlocks[pg] is null) return 0;
    
    fixed (byte *buffer = MemoryBlocks[pg]!.Buffer)
      return *(ushort *)(buffer + iaddr);
  }
  public unsafe uint Read32(uint address)
  {
    var (pg, iaddr) = ReadAddress(address);

    if (MemoryBlocks[pg] is null) return 0;
    
    fixed (byte *buffer = MemoryBlocks[pg]!.Buffer)
      return *(uint *)(buffer + iaddr);
  }

  public void Write8(uint address, byte data)
  {
    var (pg, iaddr) = ReadAddress(address);

    if (MemoryBlocks[pg] is null) MemoryBlocks[pg] = new MemoryBlock();
    MemoryBlocks[pg]!.Buffer[iaddr] = data;
  }
  public unsafe void Write16(uint address, ushort data)
  {
    var (pg, iaddr) = ReadAddress(address);

    if (MemoryBlocks[pg] is null) MemoryBlocks[pg] = new MemoryBlock();

    fixed (byte *buffer = MemoryBlocks[pg]!.Buffer)
      *(ushort *)(buffer + iaddr) = data;
  }
  public unsafe void Write32(uint address, uint data)
  {
    var (pg, iaddr) = ReadAddress(address);

    if (MemoryBlocks[pg] is null) MemoryBlocks[pg] = new MemoryBlock();

    fixed (byte *buffer = MemoryBlocks[pg]!.Buffer)
      *(uint *)(buffer + iaddr) = data;
  }

  public unsafe string ReadString(uint address)
  {
    var (pg, iaddr) = ReadAddress(address);

    if (MemoryBlocks[pg] is null) return String.Empty;

    fixed (byte *buffer = MemoryBlocks[pg]!.Buffer)
      return new string((sbyte *)(buffer + iaddr));
  }
}