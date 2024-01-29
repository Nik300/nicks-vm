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
    (VirtualMachine vm) => { Console.WriteLine("executing"); vm.cpu.A = (vm.cpu.A & 0xFFFF00FF) | ((uint)vm.mpu.DRHH << 8); }, // ALH
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
  ];
}