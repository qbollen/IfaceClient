using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Device
{
    class PInvoke
    {  
        [DllImport("CLock.dll", SetLastError=true, CallingConvention=CallingConvention.StdCall)]
        public static extern short dv_connect(short beep);

        [DllImport("CLock.dll", SetLastError=true, CallingConvention=CallingConvention.StdCall)]
        public static extern short dv_disconnect();

        [DllImport("CLock.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern short dv_check_card();

        [DllImport("CLock.dll", SetLastError=true, CallingConvention=CallingConvention.StdCall)]
        public static extern short dv_read_card(
            string auth,
            byte[] cardno,
            byte[] building, 
            byte[] room,
            byte[] commdoors,
            byte[] arrival, 
            byte[] departure
        );

        [DllImport("CLock.dll", SetLastError=true, CallingConvention=CallingConvention.StdCall)]
        public static extern short dv_write_card(
            string auth, 
			string building,
			string room,
			string commdoors,
			string arrival,
			string departure
        );

        [DllImport("CLock.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern short dv_delete_card();

        [DllImport("CLock.dll", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        public static extern short dv_get_card_number(byte[] cardno);
    }
}
