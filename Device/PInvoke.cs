using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Device
{
    class PInvoke
    {  
        [DllImport("dcrf32.dll",SetLastError=true)]
        public static extern int dc_init(Int16 port, Int32 baud);
        [DllImport("dcrf32.dll",SetLastError=true)]
        public static extern short dc_exit(int icdev);
        [DllImport("dcrf32.dll",SetLastError=true)]
        public static extern short dc_beep(int icdev, uint _Msec);
        [DllImport("dcrf32.dll",SetLastError = true,CallingConvention=CallingConvention.StdCall)]
        public static extern short dc_card_double(int icdev, byte mode, byte[] snr);
        [DllImport("dcrf32.dll",SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern short dc_read_hex(int icdev, byte addr, byte[] data);
        [DllImport("dcrf32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern short dc_srd_eeprom(int icdev,int offset,int length,byte[] buffer);
        [DllImport("dcrf32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern short dc_write_hex(int icdev,byte addr,[In] string data);
        [DllImport("dcrf32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern short dc_request(int icdev, byte mode, ref uint tagType);
        [DllImport("dcrf32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern short dc_load_key_hex(int icdev, byte mode, byte secNr, string key);
        [DllImport("dcrf32.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern short dc_authentication(int icdev, byte mode, byte secNr);

    }
}
