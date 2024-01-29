namespace NicksVM.Core;

public partial class IOPU : IPU
{
  public IPU.Instruction[] Instructions { get; } =
  [
    // ldktp
    vm => { vm.iopu.KTP = vm.cpu.A; },
    vm => { vm.iopu.KTP = vm.cpu.B; },
    vm => { vm.iopu.KTP = vm.cpu.C; },
    vm => { vm.iopu.KTP = vm.cpu.MDR; },
    vm => { vm.iopu.KTP = vm.mpu.DR; },
    
    // stksr xH
    vm => { vm.cpu.A = (vm.cpu.A & 0x0000FFFF) | (uint)vm.iopu.KSR << 16; },
    vm => { vm.cpu.B = (vm.cpu.B & 0x0000FFFF) | (uint)vm.iopu.KSR << 16; },
    vm => { vm.cpu.C = (vm.cpu.C & 0x0000FFFF) | (uint)vm.iopu.KSR << 16; },
    // stksr xL
    vm => { vm.cpu.A = (vm.cpu.A & 0xFFFF0000) | vm.iopu.KSR; },
    vm => { vm.cpu.B = (vm.cpu.B & 0xFFFF0000) | vm.iopu.KSR; },
    vm => { vm.cpu.C = (vm.cpu.C & 0xFFFF0000) | vm.iopu.KSR; },
    // stksr MDRx
    vm => { vm.cpu.MDRH = vm.iopu.KSR; },
    vm => { vm.cpu.MDRL = vm.iopu.KSR; },

    // ldcop
    vm => { vm.iopu.COP = vm.cpu.A; },
    vm => { vm.iopu.COP = vm.cpu.B; },
    vm => { vm.iopu.COP = vm.cpu.C; },
    vm => { vm.iopu.COP = vm.cpu.MDR; },
    vm => { vm.iopu.COP = vm.mpu.DR; },
    // stcop
    vm => { vm.cpu.A = vm.iopu.COP; },
    vm => { vm.cpu.B = vm.iopu.COP; },
    vm => { vm.cpu.C = vm.iopu.COP; },
    vm => { vm.cpu.MDR = vm.iopu.COP; },

    // ldcoc XHL
    vm => { vm.iopu.COC = (byte)((vm.cpu.A & 0x00FF0000) >> 16); },
    vm => { vm.iopu.COC = (byte)((vm.cpu.B & 0x00FF0000) >> 16); },
    vm => { vm.iopu.COC = (byte)((vm.cpu.C & 0x00FF0000) >> 16); },
    // ldcoc XLL
    vm => { vm.iopu.COC = (byte)(vm.cpu.A & 0x000000FF); },
    vm => { vm.iopu.COC = (byte)(vm.cpu.B & 0x000000FF); },
    vm => { vm.iopu.COC = (byte)(vm.cpu.C & 0x000000FF); },
    // ldcoc XHH
    vm => { vm.iopu.COC = (byte)((vm.cpu.A & 0xFF000000) >> 24); },
    vm => { vm.iopu.COC = (byte)((vm.cpu.B & 0xFF000000) >> 24); },
    vm => { vm.iopu.COC = (byte)((vm.cpu.C & 0xFF000000) >> 24); },
    // ldcoc XLH
    vm => { vm.iopu.COC = (byte)((vm.cpu.A & 0x0000FF00) >> 8); },
    vm => { vm.iopu.COC = (byte)((vm.cpu.B & 0x0000FF00) >> 8); },
    vm => { vm.iopu.COC = (byte)((vm.cpu.C & 0x0000FF00) >> 8); },

    // ldccl
    vm => { vm.iopu.CCL = vm.cpu.A; },
    vm => { vm.iopu.CCL = vm.cpu.B; },
    vm => { vm.iopu.CCL = vm.cpu.C; },
    vm => { vm.iopu.CCL = vm.cpu.MDR; },
    vm => { vm.iopu.CCL = vm.mpu.DR; },
    // stccl
    vm => { vm.cpu.A = vm.iopu.CCL; },
    vm => { vm.cpu.B = vm.iopu.CCL; },
    vm => { vm.cpu.C = vm.iopu.CCL; },
    vm => { vm.cpu.MDR = vm.iopu.CCL; },

    // ldcct
    vm => { vm.iopu.CCT = vm.cpu.A; },
    vm => { vm.iopu.CCT = vm.cpu.B; },
    vm => { vm.iopu.CCT = vm.cpu.C; },
    vm => { vm.iopu.CCT = vm.cpu.MDR; },
    vm => { vm.iopu.CCT = vm.mpu.DR; },
    // stcct
    vm => { vm.cpu.A = vm.iopu.CCT; },
    vm => { vm.cpu.B = vm.iopu.CCT; },
    vm => { vm.cpu.C = vm.iopu.CCT; },
    vm => { vm.cpu.MDR = vm.iopu.CCT; },

    // stcsr
    vm => { vm.cpu.A = vm.iopu.CSR; },
    vm => { vm.cpu.B = vm.iopu.CSR; },
    vm => { vm.cpu.C = vm.iopu.CSR; },
    vm => { vm.cpu.MDR = vm.iopu.CSR; },

    // ldgcr
    vm => { vm.iopu.GCR = vm.cpu.A; },
    vm => { vm.iopu.GCR = vm.cpu.B; },
    vm => { vm.iopu.GCR = vm.cpu.C; },
    vm => { vm.iopu.GCR = vm.cpu.MDR; },
    vm => { vm.iopu.GCR = vm.mpu.DR; },
    // stgdr
    vm => { vm.cpu.A = vm.iopu.GDR; },
    vm => { vm.cpu.B = vm.iopu.GDR; },
    vm => { vm.cpu.C = vm.iopu.GDR; },
    vm => { vm.cpu.MDR = vm.iopu.GDR; },
  
    // ldfcr XHL
    vm => { vm.iopu.FCR = (byte)((vm.cpu.A & 0x00FF0000) >> 16); },
    vm => { vm.iopu.FCR = (byte)((vm.cpu.B & 0x00FF0000) >> 16); },
    vm => { vm.iopu.FCR = (byte)((vm.cpu.C & 0x00FF0000) >> 16); },
    // ldfcr XLL
    vm => { vm.iopu.FCR = (byte)(vm.cpu.A & 0x000000FF); },
    vm => { vm.iopu.FCR = (byte)(vm.cpu.B & 0x000000FF); },
    vm => { vm.iopu.FCR = (byte)(vm.cpu.C & 0x000000FF); },
    // ldfcr XHH
    vm => { vm.iopu.FCR = (byte)((vm.cpu.A & 0xFF000000) >> 24); },
    vm => { vm.iopu.FCR = (byte)((vm.cpu.B & 0xFF000000) >> 24); },
    vm => { vm.iopu.FCR = (byte)((vm.cpu.C & 0xFF000000) >> 24); },
    // ldfcr XLH
    vm => { vm.iopu.FCR = (byte)((vm.cpu.A & 0x0000FF00) >> 8); },
    vm => { vm.iopu.FCR = (byte)((vm.cpu.B & 0x0000FF00) >> 8); },
    vm => { vm.iopu.FCR = (byte)((vm.cpu.C & 0x0000FF00) >> 8); },

    // stfcr XHL
    vm => { vm.cpu.A = (vm.cpu.A & 0xFF00FFFF) | (uint)vm.iopu.FCR << 16; },
    vm => { vm.cpu.B = (vm.cpu.B & 0xFF00FFFF) | (uint)vm.iopu.FCR << 16; },
    vm => { vm.cpu.C = (vm.cpu.C & 0xFF00FFFF) | (uint)vm.iopu.FCR << 16; },
    // stfcr XLL
    vm => { vm.cpu.A = (vm.cpu.A & 0xFFFFFF00) | vm.iopu.FCR; },
    vm => { vm.cpu.B = (vm.cpu.B & 0xFF00FF00) | vm.iopu.FCR; },
    vm => { vm.cpu.C = (vm.cpu.C & 0xFF00FF00) | vm.iopu.FCR; },
    // stfcr XHH
    vm => { vm.cpu.A = (vm.cpu.A & 0x00FFFFFF) | (uint)vm.iopu.FCR << 24; },
    vm => { vm.cpu.B = (vm.cpu.B & 0x00FFFFFF) | (uint)vm.iopu.FCR << 24; },
    vm => { vm.cpu.C = (vm.cpu.C & 0x00FFFFFF) | (uint)vm.iopu.FCR << 24; },
    // stfcr XLH
    vm => { vm.cpu.A = (vm.cpu.A & 0xFFFF00FF) | (uint)vm.iopu.FCR << 8; },
    vm => { vm.cpu.B = (vm.cpu.B & 0xFFFF00FF) | (uint)vm.iopu.FCR << 8; },
    vm => { vm.cpu.C = (vm.cpu.C & 0xFFFF00FF) | (uint)vm.iopu.FCR << 8; },
  ];
}
