using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Device
{
    public class Encoder
    {
        public Encoder()
        {
        }

        private string IntToHex(int org)
        {
            return "0X" + Convert.ToString(org, 16);
        }

        private string Error(short code, out string hex)
        {
            hex = IntToHex(Math.Abs(code));

            switch(code)
            {
                case 0:  return "";
                case -1: return	"Interface error";
                case -2: return	"Connect encoder failed";
                case -3: return	"Register encoder failed";
                case -4: return	"Buzzer mute";
                case -5: return	"Not supported card type";
                case -6: return	"Wrong card password";
                case -7: return	"Wrong supplier password";
                case -8: return	"Wrong card type";
                case -9: return "Wrong authorization code";
                default: return "Unknow";
            }
        }

        public bool Connect(out string err)
        {
            string hex = string.Empty;
            if ((err = Error(PInvoke.dv_connect(1), out hex)) != string.Empty)
                return false;

            return true;
        }

        public bool Disconnect()
        {
            if (PInvoke.dv_disconnect() != 0)
            {
                return false;
            }

            return true;
        }       

        public bool IssueCard(string[] data, out string preCardNo, out string err, out string hex)
        {
            byte[] cardno = new byte[6];
            if ((err = Error(PInvoke.dv_get_card_number(cardno),out hex)) != string.Empty)
            {
                preCardNo = string.Empty;
                return false;
            }
                
            preCardNo = Encoding.ASCII.GetString(cardno);

            /* Data Struct
             * data[0] Guid
             * data[1] key count
             * data[2] auth
             * data[3] building
             * data[4] room
             * data[5] commdoors
             * data[6] arrival
             * data[7] departure
             */
            int cnt = Convert.ToInt32(data[1]);
            int i = 0;
            while (i < cnt)
            {
                if (PInvoke.dv_check_card() < 0)
                    continue;

                if ((err = Error(PInvoke.dv_write_card(
                                    data[2],
                                    data[3],
                                    data[4],
                                    data[5],
                                    data[6],
                                    data[7]
                                ), out hex)) != string.Empty)
                    return false;

                i++;
            }

            return true;
        }

        public string[] ReadCard(string auth, out string err, out string hex)
        {
            byte[] cardno = new byte[6];
            byte[] building = new byte[2];
            byte[] room = new byte[4];
            byte[] commdoors = new byte[3];
            byte[] arrival = new byte[19];
            byte[] departure = new byte[19];
            if ((err = Error(PInvoke.dv_read_card(
                                auth, 
                                cardno, 
                                building, 
                                room, 
                                commdoors, 
                                arrival, 
                                departure
                             ),out hex)) != string.Empty)
                return null;

            /* data struct
             * data[0] Card No
             * data[1] Building
             * data[2] Room
             * data[3] Common Doors
             * data[4] Arrival
             * data[5] Departure
             */
            string[] keys = new string[6];
            keys[0] = Encoding.ASCII.GetString(cardno);
            keys[1] = Encoding.ASCII.GetString(building);
            keys[2] = Encoding.ASCII.GetString(room);
            keys[3] = Encoding.ASCII.GetString(commdoors);
            keys[4] = Encoding.ASCII.GetString(arrival);
            keys[5] = Encoding.ASCII.GetString(departure);

            return keys;
        }

        public bool DeleteCard(out string preCardNo, out string err, out string hex)
        {
            byte[] cardno = new byte[6];
            if ((err = Error(PInvoke.dv_get_card_number(cardno), out hex)) != string.Empty)
            {
                preCardNo = string.Empty;
                return false;
            }

            preCardNo = Encoding.ASCII.GetString(cardno);

            if ((err = Error(PInvoke.dv_delete_card(),out hex)) != string.Empty)
                return false;

            return true;
        }
    }
}
