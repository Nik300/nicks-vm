using System.CommandLine;
using NicksVM.Core;
using System.Linq;

var rootCommand = new RootCommand("NicksVM CLI");

var fileOption = new Option<FileInfo>(
  aliases: ["-f", "--file"],
  description: "The file to run"
) {
  IsRequired = true
};

var listMnemonicsOption = new Option<bool>(
  aliases: ["-m", "--list-mnemonics"],
  description: "List the mnemonics",
  getDefaultValue: () => false
);

rootCommand.AddOption(fileOption);
rootCommand.AddOption(listMnemonicsOption);

rootCommand.SetHandler((file, listMnemonics) =>
{
  Console.WriteLine($"Running {file.FullName}");
  if (!listMnemonics) throw new NotImplementedException();

  if (listMnemonics)
  {
    Console.WriteLine("Mnemonics:");
    Console.WriteLine($"CPU (suffix: {(int)UnitIdentifier.CPU:X2}):");
    Console.WriteLine(string.Join("\n", CPU.Mnemonics.Select((m, i) => $"{i:X2}: {m}")));

    Console.WriteLine("--------------------------------");

    Console.WriteLine($"IOPU (suffix: {(int)UnitIdentifier.IOPU:X2}):");
    Console.WriteLine(string.Join("\n", IOPU.Mnemonics.Select((m, i) => $"{i:X2}: {m}")));

    Console.WriteLine("--------------------------------");

    Console.WriteLine($"MPU (suffix: {(int)UnitIdentifier.MPU:X2}):");
    Console.WriteLine(string.Join("\n", MPU.Mnemonics.Select((m, i) => $"{i:X2}: {m}")));

    Console.WriteLine("--------------------------------");

    Console.WriteLine($"IDPU (suffix: {(int)UnitIdentifier.IDPU:X2}):");
    Console.WriteLine(string.Join("\n", IDPU.Mnemonics.Select((m, i) => $"{i:X2}: {m}")));
  }
}, fileOption, listMnemonicsOption);

return rootCommand.Invoke(args);
