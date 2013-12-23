namespace InterfaceClient
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtKeyCoderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btmTestLink = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnTestEncoder = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnMin = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelEncoder = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNetwrok = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txtCardStatus = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(33, 138);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 131);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtKeyCoderName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(46, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 298);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Key Coder";
            // 
            // txtKeyCoderName
            // 
            this.txtKeyCoderName.Location = new System.Drawing.Point(36, 52);
            this.txtKeyCoderName.Name = "txtKeyCoderName";
            this.txtKeyCoderName.Size = new System.Drawing.Size(185, 20);
            this.txtKeyCoderName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Each workstation has a unique \r\nkey coder name. (e.g. K1,K2...)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Key Coder Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btmTestLink);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtPort);
            this.groupBox2.Controls.Add(this.txtIp);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(334, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(269, 167);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ORBITA Server";
            // 
            // btmTestLink
            // 
            this.btmTestLink.Image = ((System.Drawing.Image)(resources.GetObject("btmTestLink.Image")));
            this.btmTestLink.Location = new System.Drawing.Point(180, 127);
            this.btmTestLink.Name = "btmTestLink";
            this.btmTestLink.Size = new System.Drawing.Size(83, 30);
            this.btmTestLink.TabIndex = 2;
            this.btmTestLink.Text = "Test link";
            this.btmTestLink.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btmTestLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btmTestLink.UseVisualStyleBackColor = true;
            this.btmTestLink.Click += new System.EventHandler(this.btmTestLink_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 26);
            this.label5.TabIndex = 3;
            this.label5.Text = "Please enter ip and port of ORBITA server.\r\n(default port: 6008)";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(71, 101);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(141, 20);
            this.txtPort.TabIndex = 1;
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(71, 65);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(141, 20);
            this.txtIp.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "IP :";
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(360, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnTestEncoder
            // 
            this.btnTestEncoder.Image = ((System.Drawing.Image)(resources.GetObject("btnTestEncoder.Image")));
            this.btnTestEncoder.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTestEncoder.Location = new System.Drawing.Point(360, 282);
            this.btnTestEncoder.Name = "btnTestEncoder";
            this.btnTestEncoder.Size = new System.Drawing.Size(104, 30);
            this.btnTestEncoder.TabIndex = 4;
            this.btnTestEncoder.Text = "Test encoder";
            this.btnTestEncoder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTestEncoder.UseVisualStyleBackColor = true;
            this.btnTestEncoder.Click += new System.EventHandler(this.btnTestEncoder_Click);
            // 
            // btnReset
            // 
            this.btnReset.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.Image")));
            this.btnReset.Location = new System.Drawing.Point(472, 239);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(104, 30);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnMin
            // 
            this.btnMin.Image = ((System.Drawing.Image)(resources.GetObject("btnMin.Image")));
            this.btnMin.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMin.Location = new System.Drawing.Point(472, 282);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(104, 30);
            this.btnMin.TabIndex = 5;
            this.btnMin.Text = "Close";
            this.btnMin.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMin.UseVisualStyleBackColor = true;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelEncoder,
            this.toolStripStatusLabelNetwrok});
            this.statusStrip1.Location = new System.Drawing.Point(0, 371);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(649, 30);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelEncoder
            // 
            this.toolStripStatusLabelEncoder.AutoSize = false;
            this.toolStripStatusLabelEncoder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabelEncoder.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabelEncoder.Name = "toolStripStatusLabelEncoder";
            this.toolStripStatusLabelEncoder.Size = new System.Drawing.Size(250, 25);
            // 
            // toolStripStatusLabelNetwrok
            // 
            this.toolStripStatusLabelNetwrok.AutoSize = false;
            this.toolStripStatusLabelNetwrok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabelNetwrok.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripStatusLabelNetwrok.Name = "toolStripStatusLabelNetwrok";
            this.toolStripStatusLabelNetwrok.Size = new System.Drawing.Size(350, 25);
            this.toolStripStatusLabelNetwrok.TextChanged += new System.EventHandler(this.toolStripStatusLabelNetwrok_TextChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "conn24.png");
            this.imageList1.Images.SetKeyName(1, "disconn24.png");
            this.imageList1.Images.SetKeyName(2, "netok24.png");
            this.imageList1.Images.SetKeyName(3, "disconnect24.png");
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txtCardStatus
            // 
            this.txtCardStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCardStatus.ForeColor = System.Drawing.Color.Red;
            this.txtCardStatus.Location = new System.Drawing.Point(334, 325);
            this.txtCardStatus.Multiline = true;
            this.txtCardStatus.Name = "txtCardStatus";
            this.txtCardStatus.ReadOnly = true;
            this.txtCardStatus.Size = new System.Drawing.Size(269, 31);
            this.txtCardStatus.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(649, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 401);
            this.Controls.Add(this.txtCardStatus);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnTestEncoder);
            this.Controls.Add(this.btnMin);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Interface Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKeyCoderName;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btmTestLink;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnTestEncoder;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEncoder;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNetwrok;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txtCardStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;

    }
}

