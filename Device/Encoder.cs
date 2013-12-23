using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Device
{
    public enum CCardType { Unknow,UL,M1}
    public class Encoder
    {
        private int _icdev;
        public int Icdev
        {
            get { return _icdev; }
        }

        private byte _mode;
        public byte Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        private CCardType _cardType;
        public CCardType Card_Type
        {
            get { return _cardType; }
        }

        public Encoder()
        {
            _icdev = -1;
            _mode = 0;
        }

        public bool Connect(out string err)
        {
            if ((_icdev = PInvoke.dc_init(100, 115200)) <= 0)
            {
                err = "Initialize the encoder failed.";
                return false;
            }

            if (!IsRegEncoder())
            {
                err = "Register the encoder failed.";
                return false;          
            }

            err = "";
            return true;
        }

        public bool Disconnect()
        {
            if (PInvoke.dc_exit(_icdev) != 0)
            {
                return false;
            }

            return true;
        }

        public bool IsRegEncoder()
        {
            byte[] buffer = new byte[32];
            if ((PInvoke.dc_srd_eeprom(_icdev, 0, 32, buffer)) != 0)
            {
                return false;
            }

            if (Encoding.ASCII.GetString(buffer).Substring(0,12) != "OBTWXY070501")
            {
                return false;
            }

            return true;
        }

        public void Beep()
        {
            PInvoke.dc_beep(_icdev, 10);
        }

        public bool CheckCard()
        {  
            //****** modify by bollen 2013-06-21
            uint tagType = 0;
            if (PInvoke.dc_request(_icdev, _mode, ref tagType) != 0)
                return false;

            switch (tagType)
            {
                case 4:
                    _cardType =  CCardType.M1;
                    break;
                case 68:
                    _cardType =  CCardType.UL;
                    break;
                default:
                    _cardType =  CCardType.Unknow;
                    break;
            }

            if (_cardType == CCardType.Unknow)
                return false;

            //****** modify by bollen 2013-06-21

            byte[] snr = new byte[8];
            if ((PInvoke.dc_card_double(_icdev, _mode, snr)) != 0)
                return false;       

            //****** modify by bollen 2013-06-21
            if (_cardType ==  CCardType.M1)
            {
                byte sector = 13;
                string hexkey = "100000000000";
                if (PInvoke.dc_load_key_hex(_icdev, 0, sector, hexkey) != 0)
                    return false;

                if (PInvoke.dc_authentication(_icdev, 0, sector) != 0)
                    return false;
            }
            //****** modify by bollen 2013-06-21

            return true;
        }

        public bool VerifyCard(out string cardNo,out string err)
        {
            cardNo = string.Empty;
            if (!CheckCard())
            {
                err = "Check the card failed.";
                return false;
            }
      
            string RD_Data = string.Empty;
            byte[] data = new byte[32];

            if (_cardType ==  CCardType.UL)
            {          
                int i = 4;
                while (i < 16)
                {
                    if (PInvoke.dc_read_hex(_icdev, (byte)i, data) != 0)
                    {
                        err = "Read data failed.";
                        return false;
                    }

                    RD_Data = RD_Data + Encoding.ASCII.GetString(data);

                    i = i + 4;
                }
            }
            else if (_cardType ==  CCardType.M1)
            {
                int i = 52;
                while (i <= 54)
                {
                    if (PInvoke.dc_read_hex(_icdev, (byte)i, data) != 0)
                    {
                        err = "Read data failed.";
                        return false;
                    }

                    RD_Data = RD_Data + Encoding.ASCII.GetString(data);

                    i = i + 1;
                }
            }
  

            string CardType = RD_Data.Substring(6,2);

            if (CardType == "0A")     //设置卡
            {
                cardNo = RD_Data.Substring(32,6);    
            }
            else if (CardType == "0B")  //时钟卡
            {
                cardNo = RD_Data.Substring(24,6);  
            }
            else if (CardType == "0C")  //总控、应急卡、封闭卡
            {
                cardNo = RD_Data.Substring(8, 6);
            }
            else if (CardType == "0D" || CardType == "0E")
            {
                cardNo = RD_Data.Substring(18, 6);
            }
            else
            {
                cardNo = string.Empty;
            }
          
            if (RD_Data.Substring(88, 8) != "01010205")
            {
                err = "Card password error, please contact suppliers.";
                return false;
            }

            err = "";
            return true;
        }

        public bool IssueCard(string[] data, out string preCardNo, out string err)
        {
            string cardNo,error;

            if (!VerifyCard(out cardNo,out error))
            {
                preCardNo = cardNo;
                err = error;
                return false;
            }

            preCardNo = cardNo;

            try
            {
                for (int cnt = 1; cnt <= Convert.ToInt32(data[48]); cnt++)
                {
                    string buffer = string.Empty;
                    byte addr;

                    if (_cardType == CCardType.UL)//UL Write data
                    {
                        for (int i = 1; i < 13; i++)
                        {
                            buffer = data[i * 4 - 4] + data[i * 4 - 3] + data[i * 4 - 2] + data[i * 4 - 1] + "000000000000000000000000";
                            addr = (byte)(i + 3);
                            if (PInvoke.dc_write_hex(_icdev, addr, buffer) != 0)
                            {
                                err = "Write data error.";
                                return false;
                            }
                        }
                    }
                    else if (_cardType == CCardType.M1) //M1 write data
                    {
                        for (int i = 1; i < 4; i++)
                        {

                            buffer = string.Empty;

                            for (int j = 16; j > 0; j--)
                            {
                                buffer = buffer + data[i * 16 - j];
                            }

                            addr = (byte)(i + 51);
                            if (PInvoke.dc_write_hex(_icdev, addr, buffer) != 0)
                            {
                                err = "Write data error.";
                                return false;
                            }
                        }
                    }

                    Beep();
                }
            }
            catch(Exception ex)
            {
                err = ex.Message;
                return false;
            }

            err = "";
            return true;
        }

        public string[] ReadCard(out string err)
        {
            err = "";
            return null;
        }

        public bool DeleteCard(out string err)
        {
            err = "";
            return false;
        }

        private string IntToHex(int org)
        {
            return Convert.ToString(org, 16);
        }
    }
}
