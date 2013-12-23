using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using XmlUtils;

using Utils;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;

namespace InterfaceClient
{
    public partial class FrmMain : Form
    {
        Device.Encoder myEncoder = new Device.Encoder();
        BollenSocket clientSocket;
        Thread clientThread;
        private bool reconn;
        private Color currConnStaColor;
        private bool exit = false;
        public FrmMain()
        {
            InitializeComponent();
            clientSocket = null;
            reconn = true;
        }

        private void EnableEdit(bool edit)
        {
            this.txtKeyCoderName.ReadOnly = !edit;
            this.txtIp.ReadOnly = !edit;
            this.txtPort.ReadOnly = !edit;
        }

        private Dictionary<string, string> CheckKeyContent()
        {
            Dictionary<string, string> content = null;
            string keyCoderName = this.txtKeyCoderName.Text.Trim();
            string ip = this.txtIp.Text.Trim();
            string port = this.txtPort.Text.Trim();
            if (keyCoderName == string.Empty || ip == string.Empty || port == string.Empty)
            {
                SetConnectStatus("The key content cannot be empty.", Status.error);
                return content;
            }

            string pattern = @"\b(?:(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.){3}(?:25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\b";
            Regex regex = new Regex(pattern);
            if (!regex.IsMatch(ip))
            {
                SetConnectStatus("Ip error.", Status.error);
                return content;
            }


            content = new Dictionary<string, string>();
            content.Add("KeyCoderName", keyCoderName);
            content.Add("IP",ip);
            content.Add("Port", port);
            SetConnectStatus("", Status.info);

            return content;
        }

        private void ConnectToServer()
        {
            string workstation = string.Empty;
            reconn = false;
            Dictionary<string,string> content;
       
            if ((content = CheckKeyContent()) == null)
            {
                reconn = true;
                return;
            }
            byte[] data = new byte[1024];
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(content["IP"]), Convert.ToInt32(content["Port"]));
            clientSocket = new BollenSocket(endPoint);
            if (clientSocket.Connect())
            {
                while (true)
                {
                    SocketEntity entity;
                    try
                    {
                        entity = BollenSocket.Receive(clientSocket.NetStream);
                        if (entity == null)
                        {
                            continue;
                        }
                        
                        switch(entity.Cmd)
                        {
                            case Command.IF:
                                workstation = entity.ClientIP;
                                this.Invoke(new DelegateSetConnectStatus(SetConnectStatus), "Connected to ORBITA server.[" + entity.ServerIP + "]", Status.info);
                                BollenSocket.Send(clientSocket.NetStream,
                                    new SocketEntity(
                                        Command.RQ,
                                        new String[] { this.txtKeyCoderName.Text },
                                        "",
                                        ""));
                                break;
                            case Command.KD:  //delete card
                                break;
                            case Command.KR:  //issue card                 
                                string result,cardNo,err;
                                if (myEncoder.IssueCard(entity.Data,out cardNo,out err))
                                {
                                    result = "Success";
                                    ShowCardStatus("");
                                }
                                else
                                {
                                    result = "Failure";
                                    ShowCardStatus(err);
                                }
                                BollenSocket.Send(
                                    clientSocket.NetStream,
                                    new SocketEntity(
                                         Command.KA,
                                         new string[] { result, cardNo, entity.Data[49],workstation,DateTime.Now.ToString()},
                                         "",""
                                        ));
                                break;
                            case Command.KG: //read card

                                break;
                            default:
                                break;
                        }
                        
                    }
                    catch
                    {
                        this.Invoke(new DelegateSetConnectStatus(SetConnectStatus), "Receive Error.", Status.error);
                        break;
                    }
                }
            }
                
            if (clientSocket == null || !clientSocket.TCPClient.Connected)
            {
                this.Invoke(new DelegateSetConnectStatus(SetConnectStatus), "Not connected to the server.", Status.error);
                reconn = true;
                return;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Dictionary<string,string> content = CheckKeyContent();
            if (content == null)
            {
                MessageBox.Show("The key content cannot be empty.", "hint", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IList<MyDictionary> list = new List<MyDictionary>();
            list.Add(new MyDictionary { key = "First", value = ""});
            list.Add(new MyDictionary { key = "KeyCoderName", value = content["KeyCoderName"]});
            list.Add(new MyDictionary { key = "IP", value = content["IP"] });
            list.Add(new MyDictionary { key = "Port", value = content["Port"]});
            CMySection mySection = config.GetSection("MySection") as CMySection;
            mySection.KeyValues.Clear();
            (from v in list.AsQueryable()
             select new KeyValueSetting { Key = v.key, Value = v.value }).ToList()
                .ForEach(kv => mySection.KeyValues.Add(kv));
            try
            {
                config.Save();
                MessageBox.Show("Data has been modified.", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Write data error: " + ex.Message);
                return;
            }
            setEditable(false);
            this.timer1.Enabled = true;
        }

        private void btnTestEncoder_Click(object sender, EventArgs e)
        {
            string err;
            if (!myEncoder.Connect(out err))
            {
                SetEncoderStatus(err, Status.error);
                return;
            }
            SetEncoderStatus("Encoder connect successful.", Status.info);
            myEncoder.Beep();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.statusStrip1.Items.Insert(1,new ToolStripSeparator());

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CMySection mySection = config.GetSection("MySection") as CMySection;
            string lFirst = mySection.KeyValues["First"].Value;
            this.txtKeyCoderName.Text = mySection.KeyValues["KeyCoderName"].Value;
            this.txtIp.Text = mySection.KeyValues["IP"].Value;
            this.txtPort.Text = mySection.KeyValues["Port"].Value;

            if (lFirst == "yes")
            {
                setEditable(true);
                this.timer1.Enabled = false;
            }
            else
            {
                setEditable(false);
                this.timer1.Enabled = true;
            }

            string err;
            if (myEncoder.Connect(out err))
            {
                SetEncoderStatus("Encoder connect successful.", Status.info);
            }
            else
            {
                SetEncoderStatus(err,Status.error);
            }
        }

        private void SetEncoderStatus(string text,Status sta)
        {
            Image image = null;
            Color currColor;
            
            ToolStripStatusLabel tssl = this.toolStripStatusLabelEncoder;
            switch (sta)
            {
                case Status.info:
                    currColor = Color.Green;
                    image = this.imageList1.Images[0];
                    break;
                case Status.error:
                    currColor = Color.Red;
                    image = this.imageList1.Images[1];
                    break;
                default:
                    currColor = Color.Black;
                    image = null;
                    break;
            }

            tssl.Text = text;
            tssl.ForeColor = currColor;
            tssl.Image = image;
        }

        delegate void DelegateSetConnectStatus(string text, Status sta);
        private void SetConnectStatus(string text, Status sta)
        {
            Image image = null;
            ToolStripStatusLabel tssl = this.toolStripStatusLabelNetwrok;
            switch (sta)
            {
                case Status.info:
                    currConnStaColor = Color.Green;
                    image = this.imageList1.Images[2];
                    break;
                case Status.error:
                    currConnStaColor = Color.Red;
                    image = this.imageList1.Images[3];
                    break;
                default:
                    currConnStaColor = Color.Black;
                    image = null;
                    break;
            }
           
            tssl.Text = text;
            //tssl.ForeColor = currColor;
            tssl.Image = image;
        }

        delegate void ShowCardStatusHandler(string text);
        private void ShowCardStatus(string text)
        {
            if (this.txtCardStatus.InvokeRequired)
            {
                ShowCardStatusHandler d = new ShowCardStatusHandler(ShowCardStatus);
                this.Invoke(d, new Object[] { text });
            }
            else
            {
                this.txtCardStatus.Text = text;
            }
        }

        private bool PingHost(string addr, int timeout = 1000)
        {
            using (System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping())
            {
                PingOptions options = new PingOptions();
                options.DontFragment = true;
                string Data = "testing...";
                byte[] DataBuffer = Encoding.ASCII.GetBytes(Data);
                PingReply reply = pingSender.Send(addr, timeout, DataBuffer, options);
                if (reply.Status == IPStatus.Success)
                    return true;

                return false;
            }

        }

        private void btmTestLink_Click(object sender, EventArgs e)
        {
            string host = this.txtIp.Text.Trim();
            if (host == string.Empty)
            {
                MessageBox.Show("The IP cannot be empty.","hint",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (PingHost(host))
            {
                MessageBox.Show("Link success.", "hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Link failed.", "hint", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setEditable(bool edit)
        {
            this.txtKeyCoderName.ReadOnly = !edit;
            this.txtIp.ReadOnly = !edit;
            this.txtPort.ReadOnly = !edit;
            this.btnSave.Enabled = edit;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            setEditable(true);
            this.timer1.Enabled = false;
            SetConnectStatus("", Status.NULL);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frmAbout = new FrmAbout();
            frmAbout.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            exit = true;
            this.Close();
        }

        private void MaximumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Interval = 5000;
            if (!reconn)
            {
                return;
            }
            clientThread = new Thread(ConnectToServer);
            clientThread.Name = "Client Thread";
            clientThread.IsBackground = true;
            clientThread.Start();
        }

        private void toolStripStatusLabelNetwrok_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.toolStripStatusLabelNetwrok.ForeColor = currConnStaColor;
            }
            catch
            {

            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }          
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            myEncoder.Disconnect();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAbout about = new FrmAbout();
            about.ShowDialog();
        }

 
    }

    class MyDictionary
    {
        public string key;
        public string value;
    }

    public enum Status
    {
        NULL,
        info,
        warning,
        error
    }
}
