using System.Drawing;
using System.Windows.Forms;

namespace Button
{
    partial class comboBoxCameras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(comboBoxCameras));
            this.connect = new System.Windows.Forms.Button();
            this.disconnect = new System.Windows.Forms.Button();
            this.Start = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.m_vanxilanh = new System.Windows.Forms.Button();
            this.m_bt2 = new System.Windows.Forms.Button();
            this.m_bt1 = new System.Windows.Forms.Button();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.dirX = new System.Windows.Forms.Button();
            this.dirZ = new System.Windows.Forms.Button();
            this.Z = new System.Windows.Forms.Button();
            this.X = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxCam = new System.Windows.Forms.PictureBox();
            this.textBoxQR = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.standardControl1 = new SymbolFactoryDotNet.StandardControl();
            this.standardControl2 = new SymbolFactoryDotNet.StandardControl();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mode = new System.Windows.Forms.Button();
            this.xuatkho = new System.Windows.Forms.Button();
            this.luukho = new System.Windows.Forms.Button();
            this.btnToggleCamera = new System.Windows.Forms.Button();
            this.comboBoxCameraSource = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBoxThongTin = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataGridViewHistory = new System.Windows.Forms.DataGridView();
            this.Time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QRCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLuuKhoTay = new System.Windows.Forms.Button();
            this.btnXoaThongBao = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnViTri3 = new System.Windows.Forms.Button();
            this.btnViTri2 = new System.Windows.Forms.Button();
            this.btnViTri1 = new System.Windows.Forms.Button();
            this.btnViTri5 = new System.Windows.Forms.Button();
            this.btnViTri4 = new System.Windows.Forms.Button();
            this.btnViTri6 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCam)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.standardControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.standardControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connect
            // 
            this.connect.Location = new System.Drawing.Point(15, 15);
            this.connect.Margin = new System.Windows.Forms.Padding(4);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(100, 25);
            this.connect.TabIndex = 0;
            this.connect.Text = "Connect";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.button1_Click);
            // 
            // disconnect
            // 
            this.disconnect.Location = new System.Drawing.Point(123, 15);
            this.disconnect.Margin = new System.Windows.Forms.Padding(4);
            this.disconnect.Name = "disconnect";
            this.disconnect.Size = new System.Drawing.Size(100, 25);
            this.disconnect.TabIndex = 1;
            this.disconnect.Text = "Disconnect";
            this.disconnect.UseVisualStyleBackColor = true;
            this.disconnect.Click += new System.EventHandler(this.button2_Click);
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Start.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(150)))), ((int)(((byte)(55)))));
            this.Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Start.ForeColor = System.Drawing.Color.White;
            this.Start.Location = new System.Drawing.Point(17, 620);
            this.Start.Margin = new System.Windows.Forms.Padding(4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 65);
            this.Start.TabIndex = 2;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Stop
            // 
            this.Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.Stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Stop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Stop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Stop.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Stop.ForeColor = System.Drawing.Color.White;
            this.Stop.Location = new System.Drawing.Point(125, 620);
            this.Stop.Margin = new System.Windows.Forms.Padding(4);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(100, 65);
            this.Stop.TabIndex = 3;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_click);
            // 
            // Home
            // 
            this.Home.Location = new System.Drawing.Point(83, 196);
            this.Home.Margin = new System.Windows.Forms.Padding(4);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(57, 28);
            this.Home.TabIndex = 5;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // Reset
            // 
            this.Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Reset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Reset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(0)))));
            this.Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.Reset.ForeColor = System.Drawing.Color.White;
            this.Reset.Location = new System.Drawing.Point(233, 620);
            this.Reset.Margin = new System.Windows.Forms.Padding(4);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(100, 65);
            this.Reset.TabIndex = 4;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = false;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // m_vanxilanh
            // 
            this.m_vanxilanh.Location = new System.Drawing.Point(64, 123);
            this.m_vanxilanh.Margin = new System.Windows.Forms.Padding(4);
            this.m_vanxilanh.Name = "m_vanxilanh";
            this.m_vanxilanh.Size = new System.Drawing.Size(100, 28);
            this.m_vanxilanh.TabIndex = 8;
            this.m_vanxilanh.Text = "Van Từ";
            this.m_vanxilanh.UseVisualStyleBackColor = true;
            this.m_vanxilanh.Click += new System.EventHandler(this.m_vanxilanh_Click);
            // 
            // m_bt2
            // 
            this.m_bt2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.m_bt2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_bt2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_bt2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.m_bt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bt2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.m_bt2.ForeColor = System.Drawing.Color.Black;
            this.m_bt2.Location = new System.Drawing.Point(40, 71);
            this.m_bt2.Margin = new System.Windows.Forms.Padding(4);
            this.m_bt2.Name = "m_bt2";
            this.m_bt2.Size = new System.Drawing.Size(127, 43);
            this.m_bt2.TabIndex = 7;
            this.m_bt2.Text = "Băng Tải 2";
            this.m_bt2.UseVisualStyleBackColor = false;
            this.m_bt2.Click += new System.EventHandler(this.m_bt2_Click);
            // 
            // m_bt1
            // 
            this.m_bt1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.m_bt1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_bt1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.m_bt1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.m_bt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_bt1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.m_bt1.ForeColor = System.Drawing.Color.Black;
            this.m_bt1.Location = new System.Drawing.Point(40, 21);
            this.m_bt1.Margin = new System.Windows.Forms.Padding(4);
            this.m_bt1.Name = "m_bt1";
            this.m_bt1.Size = new System.Drawing.Size(128, 41);
            this.m_bt1.TabIndex = 6;
            this.m_bt1.Text = "Băng Tải 1";
            this.m_bt1.UseVisualStyleBackColor = false;
            this.m_bt1.Click += new System.EventHandler(this.m_bt1_Click);
            // 
            // txtStation
            // 
            this.txtStation.Location = new System.Drawing.Point(232, 15);
            this.txtStation.Margin = new System.Windows.Forms.Padding(4);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(132, 22);
            this.txtStation.TabIndex = 10;
            this.txtStation.Text = "1";
            this.txtStation.TextChanged += new System.EventHandler(this.txtStation_TextChanged);
            // 
            // dirX
            // 
            this.dirX.Location = new System.Drawing.Point(17, 196);
            this.dirX.Margin = new System.Windows.Forms.Padding(4);
            this.dirX.Name = "dirX";
            this.dirX.Size = new System.Drawing.Size(57, 28);
            this.dirX.TabIndex = 11;
            this.dirX.Text = "x-";
            this.dirX.UseVisualStyleBackColor = true;
            this.dirX.Click += new System.EventHandler(this.dirX_Click);
            this.dirX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DirX_MouseDown);
            this.dirX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DirX_MouseUp);
            // 
            // dirZ
            // 
            this.dirZ.Location = new System.Drawing.Point(83, 159);
            this.dirZ.Margin = new System.Windows.Forms.Padding(4);
            this.dirZ.Name = "dirZ";
            this.dirZ.Size = new System.Drawing.Size(51, 28);
            this.dirZ.TabIndex = 11;
            this.dirZ.Text = "z+";
            this.dirZ.UseVisualStyleBackColor = true;
            this.dirZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DirZ_MouseDown);
            this.dirZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DirZ_MouseUp);
            // 
            // Z
            // 
            this.Z.Location = new System.Drawing.Point(83, 231);
            this.Z.Margin = new System.Windows.Forms.Padding(4);
            this.Z.Name = "Z";
            this.Z.Size = new System.Drawing.Size(57, 28);
            this.Z.TabIndex = 12;
            this.Z.Text = "z-";
            this.Z.UseVisualStyleBackColor = true;
            this.Z.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Z_MouseDown);
            this.Z.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Z_MouseUp);
            // 
            // X
            // 
            this.X.Location = new System.Drawing.Point(148, 196);
            this.X.Margin = new System.Windows.Forms.Padding(4);
            this.X.Name = "X";
            this.X.Size = new System.Drawing.Size(57, 28);
            this.X.TabIndex = 13;
            this.X.Text = "x+";
            this.X.UseVisualStyleBackColor = true;
            this.X.MouseDown += new System.Windows.Forms.MouseEventHandler(this.X_MouseDown);
            this.X.MouseUp += new System.Windows.Forms.MouseEventHandler(this.X_MouseUp);
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(150)))), ((int)(((byte)(55)))));
            this.btnLuu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuu.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnLuu.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(150)))), ((int)(((byte)(55)))));
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuu.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Location = new System.Drawing.Point(1160, 115);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 65);
            this.btnLuu.TabIndex = 15;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.UseVisualStyleBackColor = false;
            this.btnLuu.Click += new System.EventHandler(this.btnCaiDatQR_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(775, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(205, 90);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Xung ngỏ ra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Trục Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trục Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trục X";
            // 
            // pictureBoxCam
            // 
            this.pictureBoxCam.Location = new System.Drawing.Point(16, 62);
            this.pictureBoxCam.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBoxCam.Name = "pictureBoxCam";
            this.pictureBoxCam.Size = new System.Drawing.Size(533, 347);
            this.pictureBoxCam.TabIndex = 17;
            this.pictureBoxCam.TabStop = false;
            // 
            // textBoxQR
            // 
            this.textBoxQR.Location = new System.Drawing.Point(196, 427);
            this.textBoxQR.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxQR.Name = "textBoxQR";
            this.textBoxQR.Size = new System.Drawing.Size(168, 22);
            this.textBoxQR.TabIndex = 18;
            this.textBoxQR.Text = "Dữ liệu mã QR:";
            this.textBoxQR.TextChanged += new System.EventHandler(this.textBoxQR_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.X);
            this.groupBox2.Controls.Add(this.Home);
            this.groupBox2.Controls.Add(this.m_bt1);
            this.groupBox2.Controls.Add(this.m_bt2);
            this.groupBox2.Controls.Add(this.m_vanxilanh);
            this.groupBox2.Controls.Add(this.dirX);
            this.groupBox2.Controls.Add(this.dirZ);
            this.groupBox2.Controls.Add(this.Z);
            this.groupBox2.Location = new System.Drawing.Point(557, 115);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(205, 287);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chế độ vận hành tay";
            // 
            // standardControl1
            // 
            this.standardControl1.AnalogIntValue1 = ((short)(0));
            this.standardControl1.AnalogValue1 = 0D;
            this.standardControl1.AnimationMode = SymbolFactoryNetEngine.AnimationModeOptions.DiscreteColorFill;
            this.standardControl1.BackColor = System.Drawing.Color.Transparent;
            this.standardControl1.BackStyle = SymbolFactoryNetEngine.BackStyleOptions.Transparent;
            this.standardControl1.BandsCollection.Add(new SymbolFactoryNetEngine.Band(0D, 0, false, SymbolFactoryNetEngine.BandStyleOptions.Shaded, System.Drawing.Color.Lime, "Band1"));
            this.standardControl1.BlinkColor = System.Drawing.Color.Red;
            this.standardControl1.Category = "1Btn.cat2";
            this.standardControl1.DebugData = new SymbolFactoryDotNet.DebugClass(resources.GetString("standardControl1.DebugData"));
            this.standardControl1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.standardControl1.Location = new System.Drawing.Point(733, 119);
            this.standardControl1.Name = "standardControl1";
            this.standardControl1.Size = new System.Drawing.Size(26, 23);
            this.standardControl1.SymbolHandle = ((long)(703557272));
            this.standardControl1.TabIndex = 26;
            // 
            // standardControl2
            // 
            this.standardControl2.AnalogIntValue1 = ((short)(0));
            this.standardControl2.AnalogValue1 = 0D;
            this.standardControl2.AnimationMode = SymbolFactoryNetEngine.AnimationModeOptions.DiscreteColorFill;
            this.standardControl2.BackColor = System.Drawing.Color.Transparent;
            this.standardControl2.BackStyle = SymbolFactoryNetEngine.BackStyleOptions.Transparent;
            this.standardControl2.BandsCollection.Add(new SymbolFactoryNetEngine.Band(0D, 0, false, SymbolFactoryNetEngine.BandStyleOptions.Shaded, System.Drawing.Color.Lime, "Band1"));
            this.standardControl2.BlinkColor = System.Drawing.Color.Red;
            this.standardControl2.Category = "1Btn.cat2";
            this.standardControl2.DebugData = new SymbolFactoryDotNet.DebugClass(resources.GetString("standardControl2.DebugData"));
            this.standardControl2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.standardControl2.Location = new System.Drawing.Point(684, 119);
            this.standardControl2.Name = "standardControl2";
            this.standardControl2.Size = new System.Drawing.Size(26, 23);
            this.standardControl2.SymbolHandle = ((long)(703557272));
            this.standardControl2.TabIndex = 27;
            this.standardControl2.Load += new System.EventHandler(this.standardControl2_Load);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(592, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Auto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(685, 20);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 16);
            this.label5.TabIndex = 29;
            this.label5.Text = "Man";
            // 
            // mode
            // 
            this.mode.Location = new System.Drawing.Point(601, 68);
            this.mode.Margin = new System.Windows.Forms.Padding(4);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(100, 28);
            this.mode.TabIndex = 30;
            this.mode.Text = "Mode";
            this.mode.UseVisualStyleBackColor = true;
            this.mode.Click += new System.EventHandler(this.button3_Click);
            // 
            // xuatkho
            // 
            this.xuatkho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.xuatkho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xuatkho.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.xuatkho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xuatkho.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.xuatkho.ForeColor = System.Drawing.Color.White;
            this.xuatkho.Location = new System.Drawing.Point(215, 558);
            this.xuatkho.Margin = new System.Windows.Forms.Padding(4);
            this.xuatkho.Name = "xuatkho";
            this.xuatkho.Size = new System.Drawing.Size(151, 43);
            this.xuatkho.TabIndex = 32;
            this.xuatkho.Text = "📦  Xuất Kho";
            this.xuatkho.UseVisualStyleBackColor = true;
            this.xuatkho.Click += new System.EventHandler(this.xuatkho_Click);
            // 
            // luukho
            // 
            this.luukho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.luukho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.luukho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.luukho.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.luukho.ForeColor = System.Drawing.Color.White;
            this.luukho.Location = new System.Drawing.Point(15, 558);
            this.luukho.Margin = new System.Windows.Forms.Padding(4);
            this.luukho.Name = "luukho";
            this.luukho.Size = new System.Drawing.Size(149, 43);
            this.luukho.TabIndex = 31;
            this.luukho.Text = "💾  Lưu Kho";
            this.luukho.UseVisualStyleBackColor = false;
            this.luukho.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnToggleCamera
            // 
            this.btnToggleCamera.Location = new System.Drawing.Point(15, 423);
            this.btnToggleCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnToggleCamera.Name = "btnToggleCamera";
            this.btnToggleCamera.Size = new System.Drawing.Size(68, 28);
            this.btnToggleCamera.TabIndex = 34;
            this.btnToggleCamera.Text = "Camera";
            this.btnToggleCamera.UseVisualStyleBackColor = true;
            this.btnToggleCamera.Click += new System.EventHandler(this.btnToggleCamera_Click_1);
            // 
            // comboBoxCameraSource
            // 
            this.comboBoxCameraSource.FormattingEnabled = true;
            this.comboBoxCameraSource.Location = new System.Drawing.Point(91, 425);
            this.comboBoxCameraSource.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxCameraSource.Name = "comboBoxCameraSource";
            this.comboBoxCameraSource.Size = new System.Drawing.Size(96, 24);
            this.comboBoxCameraSource.TabIndex = 35;
            this.comboBoxCameraSource.SelectedIndexChanged += new System.EventHandler(this.comboBoxCameraSource_SelectedIndexChanged_1);
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(35)))), ((int)(((byte)(51)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.White;
            this.btnReset.Location = new System.Drawing.Point(1160, 299);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 65);
            this.btnReset.TabIndex = 40;
            this.btnReset.Text = "🗑️  Xoá";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnCaiDatViTri_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(775, 115);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(377, 249);
            this.dataGridView1.TabIndex = 41;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.HeaderText = "Mã QR";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Loại hàng\t";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Vị trí lưu kho\t";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 90;
            // 
            // textBoxThongTin
            // 
            this.textBoxThongTin.Location = new System.Drawing.Point(16, 472);
            this.textBoxThongTin.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxThongTin.Multiline = true;
            this.textBoxThongTin.Name = "textBoxThongTin";
            this.textBoxThongTin.ReadOnly = true;
            this.textBoxThongTin.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxThongTin.Size = new System.Drawing.Size(349, 80);
            this.textBoxThongTin.TabIndex = 42;
            this.textBoxThongTin.TextChanged += new System.EventHandler(this.textBoxThongTin_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(105)))), ((int)(((byte)(217)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(341, 620);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 65);
            this.button1.TabIndex = 44;
            this.button1.Text = "⚙️  Setting";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(100)))), ((int)(((byte)(110)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(449, 620);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 65);
            this.button2.TabIndex = 45;
            this.button2.Text = "🕘  Lịch sử";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // dataGridViewHistory
            // 
            this.dataGridViewHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Time,
            this.QRCode,
            this.Product,
            this.Position,
            this.Action});
            this.dataGridViewHistory.Location = new System.Drawing.Point(773, 370);
            this.dataGridViewHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewHistory.Name = "dataGridViewHistory";
            this.dataGridViewHistory.RowHeadersWidth = 51;
            this.dataGridViewHistory.RowTemplate.Height = 24;
            this.dataGridViewHistory.Size = new System.Drawing.Size(555, 314);
            this.dataGridViewHistory.TabIndex = 46;
            this.dataGridViewHistory.Visible = false;
            this.dataGridViewHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewHistory_CellContentClick);
            // 
            // Time
            // 
            this.Time.HeaderText = "Thời gian";
            this.Time.MinimumWidth = 6;
            this.Time.Name = "Time";
            this.Time.Width = 125;
            // 
            // QRCode
            // 
            this.QRCode.HeaderText = "Mã QR";
            this.QRCode.MinimumWidth = 6;
            this.QRCode.Name = "QRCode";
            this.QRCode.Width = 125;
            // 
            // Product
            // 
            this.Product.HeaderText = "Loại hàng";
            this.Product.MinimumWidth = 6;
            this.Product.Name = "Product";
            this.Product.Width = 125;
            // 
            // Position
            // 
            this.Position.HeaderText = "Vị trí";
            this.Position.MinimumWidth = 6;
            this.Position.Name = "Position";
            this.Position.Width = 125;
            // 
            // Action
            // 
            this.Action.HeaderText = "Hành động";
            this.Action.MinimumWidth = 6;
            this.Action.Name = "Action";
            this.Action.Width = 125;
            // 
            // btnLuuKhoTay
            // 
            this.btnLuuKhoTay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnLuuKhoTay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuKhoTay.FlatAppearance.BorderSize = 0;
            this.btnLuuKhoTay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnLuuKhoTay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuKhoTay.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnLuuKhoTay.ForeColor = System.Drawing.Color.White;
            this.btnLuuKhoTay.Location = new System.Drawing.Point(556, 620);
            this.btnLuuKhoTay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuuKhoTay.Name = "btnLuuKhoTay";
            this.btnLuuKhoTay.Size = new System.Drawing.Size(149, 65);
            this.btnLuuKhoTay.TabIndex = 47;
            this.btnLuuKhoTay.Text = "📦 Lưu kho tay";
            this.btnLuuKhoTay.UseVisualStyleBackColor = false;
            this.btnLuuKhoTay.Visible = false;
            this.btnLuuKhoTay.Click += new System.EventHandler(this.btnLuuKhoTay_Click);
            // 
            // btnXoaThongBao
            // 
            this.btnXoaThongBao.Location = new System.Drawing.Point(372, 560);
            this.btnXoaThongBao.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoaThongBao.Name = "btnXoaThongBao";
            this.btnXoaThongBao.Size = new System.Drawing.Size(31, 23);
            this.btnXoaThongBao.TabIndex = 48;
            this.btnXoaThongBao.Text = "🗑️";
            this.btnXoaThongBao.UseVisualStyleBackColor = true;
            this.btnXoaThongBao.Click += new System.EventHandler(this.btnXoaThongBao_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tableLayoutPanel1.Controls.Add(this.btnViTri3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnViTri2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnViTri1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnViTri5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnViTri4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnViTri6, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(419, 415);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(348, 199);
            this.tableLayoutPanel1.TabIndex = 49;
            // 
            // btnViTri3
            // 
            this.btnViTri3.BackColor = System.Drawing.Color.Lime;
            this.btnViTri3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViTri3.ForeColor = System.Drawing.Color.White;
            this.btnViTri3.Location = new System.Drawing.Point(235, 101);
            this.btnViTri3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViTri3.Name = "btnViTri3";
            this.btnViTri3.Size = new System.Drawing.Size(108, 94);
            this.btnViTri3.TabIndex = 5;
            this.btnViTri3.UseVisualStyleBackColor = false;
            // 
            // btnViTri2
            // 
            this.btnViTri2.BackColor = System.Drawing.Color.Lime;
            this.btnViTri2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViTri2.ForeColor = System.Drawing.Color.White;
            this.btnViTri2.Location = new System.Drawing.Point(119, 101);
            this.btnViTri2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViTri2.Name = "btnViTri2";
            this.btnViTri2.Size = new System.Drawing.Size(109, 94);
            this.btnViTri2.TabIndex = 4;
            this.btnViTri2.UseVisualStyleBackColor = false;
            // 
            // btnViTri1
            // 
            this.btnViTri1.BackColor = System.Drawing.Color.Lime;
            this.btnViTri1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViTri1.ForeColor = System.Drawing.Color.White;
            this.btnViTri1.Location = new System.Drawing.Point(3, 101);
            this.btnViTri1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViTri1.Name = "btnViTri1";
            this.btnViTri1.Size = new System.Drawing.Size(109, 94);
            this.btnViTri1.TabIndex = 3;
            this.btnViTri1.UseVisualStyleBackColor = false;
            // 
            // btnViTri5
            // 
            this.btnViTri5.BackColor = System.Drawing.Color.Lime;
            this.btnViTri5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViTri5.ForeColor = System.Drawing.Color.White;
            this.btnViTri5.Location = new System.Drawing.Point(119, 2);
            this.btnViTri5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViTri5.Name = "btnViTri5";
            this.btnViTri5.Size = new System.Drawing.Size(109, 94);
            this.btnViTri5.TabIndex = 1;
            this.btnViTri5.UseVisualStyleBackColor = false;
            // 
            // btnViTri4
            // 
            this.btnViTri4.BackColor = System.Drawing.Color.Lime;
            this.btnViTri4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViTri4.ForeColor = System.Drawing.Color.White;
            this.btnViTri4.Location = new System.Drawing.Point(3, 2);
            this.btnViTri4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViTri4.Name = "btnViTri4";
            this.btnViTri4.Size = new System.Drawing.Size(108, 94);
            this.btnViTri4.TabIndex = 2;
            this.btnViTri4.UseVisualStyleBackColor = false;
            // 
            // btnViTri6
            // 
            this.btnViTri6.BackColor = System.Drawing.Color.Lime;
            this.btnViTri6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViTri6.ForeColor = System.Drawing.Color.White;
            this.btnViTri6.Location = new System.Drawing.Point(235, 2);
            this.btnViTri6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViTri6.Name = "btnViTri6";
            this.btnViTri6.Size = new System.Drawing.Size(109, 94);
            this.btnViTri6.TabIndex = 0;
            this.btnViTri6.UseVisualStyleBackColor = false;
            this.btnViTri6.Click += new System.EventHandler(this.btnViTri6_Click);
            // 
            // comboBoxCameras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 705);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btnXoaThongBao);
            this.Controls.Add(this.btnLuuKhoTay);
            this.Controls.Add(this.dataGridViewHistory);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxThongTin);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.comboBoxCameraSource);
            this.Controls.Add(this.btnToggleCamera);
            this.Controls.Add(this.xuatkho);
            this.Controls.Add(this.luukho);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBoxQR);
            this.Controls.Add(this.pictureBoxCam);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.txtStation);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.disconnect);
            this.Controls.Add(this.connect);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "comboBoxCameras";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCam)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.standardControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.standardControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHistory)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button disconnect;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button m_vanxilanh;
        private System.Windows.Forms.Button m_bt2;
        private System.Windows.Forms.Button m_bt1;
        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.Button dirX;
        private System.Windows.Forms.Button dirZ;
        private System.Windows.Forms.Button Z;
        private System.Windows.Forms.Button X;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBoxCam;
        private System.Windows.Forms.TextBox textBoxQR;
        private System.Windows.Forms.GroupBox groupBox2;
        private SymbolFactoryDotNet.StandardControl standardControl1;
        private SymbolFactoryDotNet.StandardControl standardControl2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button mode;
        private System.Windows.Forms.Button xuatkho;
        private System.Windows.Forms.Button luukho;
        private System.Windows.Forms.Button btnToggleCamera;
        private System.Windows.Forms.ComboBox comboBoxCameraSource;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxThongTin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dataGridViewHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn Time;
        private System.Windows.Forms.DataGridViewTextBoxColumn QRCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Action;
        private System.Windows.Forms.Button btnLuuKhoTay;
        private System.Windows.Forms.Button btnXoaThongBao;
        private TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnViTri6;
        private System.Windows.Forms.Button btnViTri3;
        private System.Windows.Forms.Button btnViTri2;
        private System.Windows.Forms.Button btnViTri1;
        private System.Windows.Forms.Button btnViTri4;
        private System.Windows.Forms.Button btnViTri5;
    }
}

