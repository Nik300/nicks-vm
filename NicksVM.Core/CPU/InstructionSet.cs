namespace NicksVM.Core;

public partial class CPU : IPU
{
  public IPU.Instruction[] Instructions { get; } =
  [
    (VirtualMachine vm) => { },

    // MOVE
    (VirtualMachine vm) => { vm.cpu.B = vm.cpu.A; },
    (VirtualMachine vm) => { vm.cpu.A = vm.cpu.B; },
    (VirtualMachine vm) => { vm.cpu.C = vm.cpu.A; },
    (VirtualMachine vm) => { vm.cpu.A = vm.cpu.C; },
    (VirtualMachine vm) => { vm.cpu.C = vm.cpu.B; },
    (VirtualMachine vm) => { vm.cpu.B = vm.cpu.C; },

    // LDDR
    (VirtualMachine vm) => { vm.cpu.A = vm.mpu.DR; },
    (VirtualMachine vm) => { vm.cpu.B = vm.mpu.DR; },
    (VirtualMachine vm) => { vm.cpu.C = vm.mpu.DR; },

    // LD
    (VirtualMachine vm) => { vm.cpu.A = vm.cpu.MDR; },
    (VirtualMachine vm) => { vm.cpu.B = vm.cpu.MDR; },
    (VirtualMachine vm) => { vm.cpu.C = vm.cpu.MDR; },

    // ST
    (VirtualMachine vm) => { vm.cpu.MDR = vm.cpu.A; },
    (VirtualMachine vm) => { vm.cpu.MDR = vm.cpu.B; },
    (VirtualMachine vm) => { vm.cpu.MDR = vm.cpu.C; },

    // CH
    (VirtualMachine vm) => { vm.cpu.MAP = vm.cpu.A; },
    (VirtualMachine vm) => { vm.cpu.MAP = vm.cpu.B; },
    (VirtualMachine vm) => { vm.cpu.MAP = vm.cpu.C; },

    // CHDR & CHLD
    (VirtualMachine vm) => { vm.cpu.MAP = vm.mpu.DR; },
    (VirtualMachine vm) => { vm.cpu.MAP = vm.cpu.MAP; },

    // MOVE16
    (VirtualMachine vm) => { vm.cpu.A >>= 16; },
    (VirtualMachine vm) => { vm.cpu.A <<= 16; },
    (VirtualMachine vm) => { vm.cpu.B >>= 16; },
    (VirtualMachine vm) => { vm.cpu.B <<= 16; },
    (VirtualMachine vm) => { vm.cpu.C >>= 16; },
    (VirtualMachine vm) => { vm.cpu.C <<= 16; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x0000FFFF) | (vm.cpu.A & 0xFFFF0000); },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x0000FFFF) | (vm.cpu.B & 0xFFFF0000); },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x0000FFFF) | (vm.cpu.A & 0xFFFF0000); },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x0000FFFF) | (vm.cpu.C & 0xFFFF0000); },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x0000FFFF) | (vm.cpu.B & 0xFFFF0000); },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x0000FFFF) | (vm.cpu.C & 0xFFFF0000); },
    
    // LDDR16
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x0000FFFF) | ((uint)vm.mpu.DRH << 16); },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF0000) | vm.mpu.DRL; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x0000FFFF) | ((uint)vm.mpu.DRH << 16); },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFF0000) | vm.mpu.DRL; },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x0000FFFF) | ((uint)vm.mpu.DRH << 16); },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFF0000) | vm.mpu.DRL; },
    
    // LD16
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x0000FFFF) | ((uint)vm.cpu.MDRH << 16); },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF0000) | vm.cpu.MDRL; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x0000FFFF) | ((uint)vm.cpu.MDRH << 16); },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFF0000) | vm.cpu.MDRL; },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x0000FFFF) | ((uint)vm.cpu.MDRH << 16); },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFF0000) | vm.cpu.MDRL; },

    // ST16
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x0000FFFF) | ((uint)vm.cpu.MDRH << 16); },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF0000) | vm.cpu.MDRL; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x0000FFFF) | ((uint)vm.cpu.MDRH << 16); },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFF0000) | vm.cpu.MDRL; },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x0000FFFF) | ((uint)vm.cpu.MDRH << 16); },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFF0000) | vm.cpu.MDRL; },

    // move8 AXX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x0000FFFF) | (vm.cpu.A & 0x00FF0000) << 8; },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x0000FFFF) | (vm.cpu.A & 0xFF000000) >> 8; },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF0000) | (vm.cpu.A & 0x000000FF) << 8; },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF0000) | (vm.cpu.A & 0x0000FF00) >> 8; },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFF00FF00) | (vm.cpu.A & 0x00FF0000) >> 16; },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x00FF0FFF) | (vm.cpu.A & 0xFF000000) >> 16; },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFF00FF00) | (vm.cpu.A & 0x000000FF) << 16; },
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x00FF00FF) | (vm.cpu.A & 0x0000FF00) << 16; },
    // move8 BXX
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x0000FFFF) | (vm.cpu.B & 0x00FF0000) << 8; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x0000FFFF) | (vm.cpu.B & 0xFF000000) >> 8; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFF0000) | (vm.cpu.B & 0x000000FF) << 8; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFF0000) | (vm.cpu.B & 0x0000FF00) >> 8; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFF00FF00) | (vm.cpu.B & 0x00FF0000) >> 16; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x00FF0FFF) | (vm.cpu.B & 0xFF000000) >> 16; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFF00FF00) | (vm.cpu.B & 0x000000FF) << 16; },
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x00FF00FF) | (vm.cpu.B & 0x0000FF00) << 16; },
    // move8 CXX
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x0000FFFF) | (vm.cpu.C & 0x00FF0000) << 8; },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x0000FFFF) | (vm.cpu.C & 0xFF000000) >> 8; },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFF0000) | (vm.cpu.C & 0x000000FF) << 8; },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFF0000) | (vm.cpu.C & 0x0000FF00) >> 8; },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFF00FF00) | (vm.cpu.C & 0x00FF0000) >> 16; },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x00FF0FFF) | (vm.cpu.C & 0xFF000000) >> 16; },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFF00FF00) | (vm.cpu.C & 0x000000FF) << 16; },
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x00FF00FF) | (vm.cpu.C & 0x0000FF00) << 16; },
    // move8 AHX -> XHX
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFF00FFFF) | (vm.cpu.A & 0x00FF0000); }, // BHL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x00FFFFFF) | (vm.cpu.A & 0xFF000000); }, // BHH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFF00FFFF) | (vm.cpu.A & 0x00FF0000); }, // CHL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x00FFFFFF) | (vm.cpu.A & 0xFF000000); }, // CHH
    // move8 ALX -> XLX
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFFFF00) | (vm.cpu.A & 0x000000FF); }, // BLL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFF00FF) | (vm.cpu.A & 0x0000FF00); }, // BLH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFFFF00) | (vm.cpu.A & 0x000000FF); }, // CLL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFF00FF) | (vm.cpu.A & 0x0000FF00); }, // CLH
    // move8 BHX -> XHX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFF00FFFF) | (vm.cpu.B & 0x00FF0000); }, // AHL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x00FFFFFF) | (vm.cpu.B & 0xFF000000); }, // AHH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFF00FFFF) | (vm.cpu.B & 0x00FF0000); }, // CHL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x00FFFFFF) | (vm.cpu.B & 0xFF000000); }, // CHH
    // move8 BLX -> XLX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFFFF00) | (vm.cpu.B & 0x000000FF); }, // ALL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF00FF) | (vm.cpu.B & 0x0000FF00); }, // ALH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFFFF00) | (vm.cpu.B & 0x000000FF); }, // CLL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFF00FF) | (vm.cpu.B & 0x0000FF00); }, // CLH
    // move8 CHX -> XHX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFF00FFFF) | (vm.cpu.C & 0x00FF0000); }, // AHL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x00FFFFFF) | (vm.cpu.C & 0xFF000000); }, // AHH
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFF00FFFF) | (vm.cpu.C & 0x00FF0000); }, // BHL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x00FFFFFF) | (vm.cpu.C & 0xFF000000); }, // BHH
    // move8 CLX -> XLX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFFFF00) | (vm.cpu.C & 0x000000FF); }, // ALL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF00FF) | (vm.cpu.C & 0x0000FF00); }, // ALH
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFFFF00) | (vm.cpu.C & 0x000000FF); }, // BLL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFF00FF) | (vm.cpu.C & 0x0000FF00); }, // BLH

    // lddr8 XHX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFF00FFFF) | ((uint)vm.mpu.DRHL << 16); }, // AHL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x00FFFFFF) | ((uint)vm.mpu.DRHH << 24); }, // AHH
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFF00FFFF) | ((uint)vm.mpu.DRHL << 16); }, // BHL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x00FFFFFF) | ((uint)vm.mpu.DRHH << 24); }, // BHH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFF00FFFF) | ((uint)vm.mpu.DRHL << 16); }, // CHL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x00FFFFFF) | ((uint)vm.mpu.DRHH << 24); }, // CHH
    // lddr8 XLX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFFFF00) | vm.mpu.DRLL; },              // ALL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF00FF) | ((uint)vm.mpu.DRHH << 8); }, // ALH
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFFFF00) | vm.mpu.DRLL; },              // BLL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x00FF00FF) | ((uint)vm.mpu.DRHH << 8); }, // BLH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFFFF00) | vm.mpu.DRLL; },              // CLL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x00FF00FF) | ((uint)vm.mpu.DRHH << 8); }, // CLH

    // ld8 XHX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFF00FFFF) | ((uint)vm.cpu.MDRHL << 16); }, // AHL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x00FFFFFF) | ((uint)vm.cpu.MDRHH << 24); }, // AHH
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFF00FFFF) | ((uint)vm.cpu.MDRHL << 16); }, // BHL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x00FFFFFF) | ((uint)vm.cpu.MDRHH << 24); }, // BHH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFF00FFFF) | ((uint)vm.cpu.MDRHL << 16); }, // CHL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x00FFFFFF) | ((uint)vm.cpu.MDRHH << 24); }, // CHH
    // ld8 XLX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFFFF00) | vm.cpu.MDRLL; },              // ALL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF00FF) | ((uint)vm.cpu.MDRHH << 8); }, // ALH
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFFFF00) | vm.cpu.MDRLL; },              // BLL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x00FF00FF) | ((uint)vm.cpu.MDRHH << 8); }, // BLH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFFFF00) | vm.cpu.MDRLL; },              // CLL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x00FF00FF) | ((uint)vm.cpu.MDRHH << 8); }, // CLH

    // st8 XHX
    (VirtualMachine vm) => { vm.cpu.MDRHL = (byte)((vm.cpu.A & 0x00FF0000) >> 16); }, // st8 AHL
    (VirtualMachine vm) => { vm.cpu.MDRHH = (byte)((vm.cpu.A & 0xFF000000) >> 24); }, // st8 AHH
    (VirtualMachine vm) => { vm.cpu.MDRHL = (byte)((vm.cpu.B & 0x00FF0000) >> 16); }, // st8 BHL
    (VirtualMachine vm) => { vm.cpu.MDRHH = (byte)((vm.cpu.B & 0xFF000000) >> 24); }, // st8 BHH
    (VirtualMachine vm) => { vm.cpu.MDRHL = (byte)((vm.cpu.C & 0x00FF0000) >> 16); }, // st8 CHL
    (VirtualMachine vm) => { vm.cpu.MDRHH = (byte)((vm.cpu.C & 0xFF000000) >> 24); }, // st8 CHH
    // st8 XLX
    (VirtualMachine vm) => { vm.cpu.MDRHL = (byte)(vm.cpu.A & 0x000000FF); },        // st8 ALL
    (VirtualMachine vm) => { vm.cpu.MDRHH = (byte)((vm.cpu.A & 0x0000FF00) >> 8); }, // st8 ALH
    (VirtualMachine vm) => { vm.cpu.MDRHL = (byte)(vm.cpu.B & 0x000000FF); },        // st8 BLL
    (VirtualMachine vm) => { vm.cpu.MDRHH = (byte)((vm.cpu.B & 0x0000FF00) >> 8); }, // st8 BLH
    (VirtualMachine vm) => { vm.cpu.MDRHL = (byte)(vm.cpu.C & 0x000000FF); },        // st8 CLL
    (VirtualMachine vm) => { vm.cpu.MDRHH = (byte)((vm.cpu.C & 0x0000FF00) >> 8); }, // st8 CLH

    // ldimm32 X
    (VirtualMachine vm) => { vm.cpu.A = vm.idpu.ReadNext32(); }, // A
    (VirtualMachine vm) => { vm.cpu.B = vm.idpu.ReadNext32(); }, // B
    (VirtualMachine vm) => { vm.cpu.C = vm.idpu.ReadNext32(); }, // C

    // ldimm16 XL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF0000) | vm.idpu.ReadNext16(); }, // AL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFF0000) | vm.idpu.ReadNext16(); }, // BL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFF0000) | vm.idpu.ReadNext16(); }, // CL
    // ldimm16 XH
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x0000FFFF) | (uint)vm.idpu.ReadNext16() << 16; }, // AH
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x0000FFFF) | (uint)vm.idpu.ReadNext16() << 16; }, // BH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x0000FFFF) | (uint)vm.idpu.ReadNext16() << 16; }, // CH

    // ldimm8 XHX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFF00FFFF) | ((uint)vm.idpu.ReadNext8() << 16); }, // AHL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0x00FFFFFF) | ((uint)vm.idpu.ReadNext8() << 24); }, // AHH
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFF00FFFF) | ((uint)vm.idpu.ReadNext8() << 16); }, // BHL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x00FFFFFF) | ((uint)vm.idpu.ReadNext8() << 24); }, // BHH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFF00FFFF) | ((uint)vm.idpu.ReadNext8() << 16); }, // CHL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x00FFFFFF) | ((uint)vm.idpu.ReadNext8() << 24); }, // CHH
    // ldimm8 XLX
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFFFF00) | vm.idpu.ReadNext8(); },              // ALL
    (VirtualMachine vm) => { vm.cpu.A = (vm.cpu.A & 0xFFFF00FF) | ((uint)vm.idpu.ReadNext8() << 8); }, // ALH
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0xFFFFFF00) | vm.idpu.ReadNext8(); },              // BLL
    (VirtualMachine vm) => { vm.cpu.B = (vm.cpu.B & 0x00FF00FF) | ((uint)vm.idpu.ReadNext8() << 8); }, // BLH
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0xFFFFFF00) | vm.idpu.ReadNext8(); },              // CLL
    (VirtualMachine vm) => { vm.cpu.C = (vm.cpu.C & 0x00FF00FF) | ((uint)vm.idpu.ReadNext8() << 8); }, // CLH
  ];

  public static string[] Mnemonics { get; } =
  [
    "nop",
    "move A, B", "move B, A", "move A, C", "move C, A", "move B, C", "move C, B",
    "lddr A", "lddr B", "lddr C",
    "ld A", "ld B", "ld C",
    "st A", "st B", "st C",
    "ch A", "ch B", "ch C",
    "chdr", "chld",
    "move16 A >> 16", "move16 A << 16", "move16 B >> 16", "move16 B << 16", "move16 C >> 16", "move16 C << 16",
    "move16 B, A", "move16 A, B", "move16 C, A", "move16 A, C", "move16 C, B", "move16 B, C",
    "lddr16 A", "lddr16 A", "lddr16 B", "lddr16 B", "lddr16 C", "lddr16 C",
    "ld16 A", "ld16 A", "ld16 B", "ld16 B", "ld16 C", "ld16 C",
    "st16 A", "st16 A", "st16 B", "st16 B", "st16 C", "st16 C",
    "move8 A", "move8 A", "move8 A", "move8 A", "move8 A", "move8 A", "move8 A", "move8 A",
    "move8 B", "move8 B", "move8 B", "move8 B", "move8 B", "move8 B", "move8 B", "move8 B",
    "move8 C", "move8 C", "move8 C", "move8 C", "move8 C", "move8 C", "move8 C", "move8 C",
    "move8 AHX -> BHL", "move8 AHX -> BHH", "move8 AHX -> CHL", "move8 AHX -> CHH",
    "move8 ALX -> BLL", "move8 ALX -> BLH", "move8 ALX -> CLL", "move8 ALX -> CLH",
    "move8 BHX -> AHL", "move8 BHX -> AHH", "move8 BHX -> CHL", "move8 BHX -> CHH",
    "move8 BLX -> ALL", "move8 BLX -> ALH", "move8 BLX -> CLL", "move8 BLX -> CLH",
    "move8 CHX -> AHL", "move8 CHX -> AHH", "move8 CHX -> BHL", "move8 CHX -> BHH",
    "move8 CLX -> ALL", "move8 CLX -> ALH", "move8 CLX -> BLL", "move8 CLX -> BLH",
    "lddr8 AHL", "lddr8 AHH", "lddr8 BHL", "lddr8 BHH", "lddr8 CHL", "lddr8 CHH",
    "lddr8 ALL", "lddr8 ALH", "lddr8 BLL", "lddr8 BLH", "lddr8 CLL", "lddr8 CLH",
    "ld8 AHL", "ld8 AHH", "ld8 BHL", "ld8 BHH", "ld8 CHL", "ld8 CHH",
    "ld8 ALL", "ld8 ALH", "ld8 BLL", "ld8 BLH", "ld8 CLL", "ld8 CLH",
    "st8 AHL", "st8 AHH", "st8 BHL", "st8 BHH", "st8 CHL", "st8 CHH",
    "st8 ALL", "st8 ALH", "st8 BLL", "st8 BLH", "st8 CLL", "st8 CLH",
    "ldimm32 A", "ldimm32 B", "ldimm32 C",
    "ldimm16 AL", "ldimm16 BL", "ldimm16 CL",
    "ldimm16 AH", "ldimm16 BH", "ldimm16 CH",
    "ldimm8 AHL", "ldimm8 AHH", "ldimm8 BHL", "ldimm8 BHH", "ldimm8 CHL", "ldimm8 CHH",
    "ldimm8 ALL", "ldimm8 ALH", "ldimm8 BLL", "ldimm8 BLH", "ldimm8 CLL", "ldimm8 CLH"
  ];
}