﻿namespace NetworkApp
{
  partial class ClientForm
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
      this.TitleLbl = new System.Windows.Forms.Label();
      this.IPEntryField = new System.Windows.Forms.TextBox();
      this.IPEntryLbl = new System.Windows.Forms.Label();
      this.PortEntryField = new System.Windows.Forms.TextBox();
      this.PortEntryLbl = new System.Windows.Forms.Label();
      this.LogBox = new System.Windows.Forms.RichTextBox();
      this.LogWindowLabel = new System.Windows.Forms.Label();
      this.BeginConnectionBtn = new System.Windows.Forms.Button();
      this.CmdLbl = new System.Windows.Forms.Label();
      this.CmdField = new System.Windows.Forms.TextBox();
      this.CmdBtn = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.fileInformationGrid = new System.Windows.Forms.DataGridView();
      this.File = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FileType = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.FileLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.button2 = new System.Windows.Forms.Button();
      this.label2 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.localAddress = new System.Windows.Forms.TextBox();
      this.textBox4 = new System.Windows.Forms.TextBox();
      this.label5 = new System.Windows.Forms.Label();
      this.comboBox1 = new System.Windows.Forms.ComboBox();
      this.label3 = new System.Windows.Forms.Label();
      this.textBox1 = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.fileInformationGrid)).BeginInit();
      this.SuspendLayout();
      // 
      // TitleLbl
      // 
      this.TitleLbl.AutoSize = true;
      this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TitleLbl.Location = new System.Drawing.Point(12, 9);
      this.TitleLbl.Name = "TitleLbl";
      this.TitleLbl.Size = new System.Drawing.Size(199, 20);
      this.TitleLbl.TabIndex = 0;
      this.TitleLbl.Tag = "Client";
      this.TitleLbl.Text = "Hello! This is a client portal.";
      // 
      // IPEntryField
      // 
      this.IPEntryField.Location = new System.Drawing.Point(53, 44);
      this.IPEntryField.Name = "IPEntryField";
      this.IPEntryField.Size = new System.Drawing.Size(235, 20);
      this.IPEntryField.TabIndex = 1;
      this.IPEntryField.TextChanged += new System.EventHandler(this.IPEntryField_TextChanged);
      // 
      // IPEntryLbl
      // 
      this.IPEntryLbl.AutoSize = true;
      this.IPEntryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.IPEntryLbl.Location = new System.Drawing.Point(23, 45);
      this.IPEntryLbl.Name = "IPEntryLbl";
      this.IPEntryLbl.Size = new System.Drawing.Size(24, 17);
      this.IPEntryLbl.TabIndex = 2;
      this.IPEntryLbl.Text = "IP:";
      // 
      // PortEntryField
      // 
      this.PortEntryField.Location = new System.Drawing.Point(338, 44);
      this.PortEntryField.Name = "PortEntryField";
      this.PortEntryField.Size = new System.Drawing.Size(51, 20);
      this.PortEntryField.TabIndex = 3;
      this.PortEntryField.TextChanged += new System.EventHandler(this.PortEntryField_TextChanged);
      // 
      // PortEntryLbl
      // 
      this.PortEntryLbl.AutoSize = true;
      this.PortEntryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PortEntryLbl.Location = new System.Drawing.Point(294, 45);
      this.PortEntryLbl.Name = "PortEntryLbl";
      this.PortEntryLbl.Size = new System.Drawing.Size(38, 17);
      this.PortEntryLbl.TabIndex = 4;
      this.PortEntryLbl.Text = "Port:";
      // 
      // LogBox
      // 
      this.LogBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.LogBox.Location = new System.Drawing.Point(12, 166);
      this.LogBox.Name = "LogBox";
      this.LogBox.ReadOnly = true;
      this.LogBox.Size = new System.Drawing.Size(468, 101);
      this.LogBox.TabIndex = 5;
      this.LogBox.Text = "";
      // 
      // LogWindowLabel
      // 
      this.LogWindowLabel.AutoSize = true;
      this.LogWindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LogWindowLabel.Location = new System.Drawing.Point(12, 146);
      this.LogWindowLabel.Name = "LogWindowLabel";
      this.LogWindowLabel.Size = new System.Drawing.Size(71, 17);
      this.LogWindowLabel.TabIndex = 6;
      this.LogWindowLabel.Text = "Client Log";
      this.LogWindowLabel.Click += new System.EventHandler(this.LogWindowLabel_Click);
      // 
      // BeginConnectionBtn
      // 
      this.BeginConnectionBtn.Location = new System.Drawing.Point(395, 42);
      this.BeginConnectionBtn.Name = "BeginConnectionBtn";
      this.BeginConnectionBtn.Size = new System.Drawing.Size(85, 23);
      this.BeginConnectionBtn.TabIndex = 7;
      this.BeginConnectionBtn.Text = "Connect";
      this.BeginConnectionBtn.UseVisualStyleBackColor = true;
      this.BeginConnectionBtn.Click += new System.EventHandler(this.BeginConnectionBtn_Click);
      // 
      // CmdLbl
      // 
      this.CmdLbl.AutoSize = true;
      this.CmdLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CmdLbl.Location = new System.Drawing.Point(12, 115);
      this.CmdLbl.Name = "CmdLbl";
      this.CmdLbl.Size = new System.Drawing.Size(40, 17);
      this.CmdLbl.TabIndex = 8;
      this.CmdLbl.Text = "Cmd:";
      // 
      // CmdField
      // 
      this.CmdField.Location = new System.Drawing.Point(53, 114);
      this.CmdField.Name = "CmdField";
      this.CmdField.Size = new System.Drawing.Size(336, 20);
      this.CmdField.TabIndex = 9;
      this.CmdField.TextChanged += new System.EventHandler(this.CmdBox_TextChanged);
      // 
      // CmdBtn
      // 
      this.CmdBtn.Location = new System.Drawing.Point(395, 115);
      this.CmdBtn.Name = "CmdBtn";
      this.CmdBtn.Size = new System.Drawing.Size(85, 23);
      this.CmdBtn.TabIndex = 10;
      this.CmdBtn.Text = "Send";
      this.CmdBtn.UseVisualStyleBackColor = true;
      this.CmdBtn.Click += new System.EventHandler(this.CmdBtn_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(12, 414);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(156, 23);
      this.button1.TabIndex = 11;
      this.button1.Text = "Choose Sharing Directory";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.ChooseSharingDirectoryClick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.label1.Location = new System.Drawing.Point(12, 270);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(95, 17);
      this.label1.TabIndex = 13;
      this.label1.Text = "Client File List";
      // 
      // fileInformationGrid
      // 
      this.fileInformationGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.fileInformationGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.File,
            this.FileType,
            this.FileLocation});
      this.fileInformationGrid.Location = new System.Drawing.Point(16, 300);
      this.fileInformationGrid.Name = "fileInformationGrid";
      this.fileInformationGrid.Size = new System.Drawing.Size(458, 99);
      this.fileInformationGrid.TabIndex = 14;
      this.fileInformationGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.fileInformationGrid_CellContentClick);
      // 
      // File
      // 
      this.File.HeaderText = "File Name";
      this.File.Name = "File";
      this.File.Width = 150;
      // 
      // FileType
      // 
      this.FileType.HeaderText = "File Type";
      this.FileType.Name = "FileType";
      // 
      // FileLocation
      // 
      this.FileLocation.HeaderText = "File Location";
      this.FileLocation.Name = "FileLocation";
      this.FileLocation.Width = 200;
      // 
      // button2
      // 
      this.button2.Location = new System.Drawing.Point(373, 414);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(107, 23);
      this.button2.TabIndex = 15;
      this.button2.Text = "Refresh File List";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.refreshFileList);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.label2.Location = new System.Drawing.Point(13, 77);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(78, 17);
      this.label2.TabIndex = 17;
      this.label2.Text = "Host Name";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(289, 77);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(61, 13);
      this.label4.TabIndex = 19;
      this.label4.Text = "Connection";
      // 
      // localAddress
      // 
      this.localAddress.Location = new System.Drawing.Point(101, 74);
      this.localAddress.Name = "localAddress";
      this.localAddress.ReadOnly = true;
      this.localAddress.Size = new System.Drawing.Size(187, 20);
      this.localAddress.TabIndex = 20;
      // 
      // textBox4
      // 
      this.textBox4.Location = new System.Drawing.Point(337, 13);
      this.textBox4.Name = "textBox4";
      this.textBox4.Size = new System.Drawing.Size(133, 20);
      this.textBox4.TabIndex = 23;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.label5.Location = new System.Drawing.Point(289, 13);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(42, 17);
      this.label5.TabIndex = 24;
      this.label5.Text = "User:";
      // 
      // comboBox1
      // 
      this.comboBox1.FormattingEnabled = true;
      this.comboBox1.Items.AddRange(new object[] {
            "Ethernet",
            "Modem",
            "T1",
            "T3",
            "Carrier Pigeon"});
      this.comboBox1.Location = new System.Drawing.Point(359, 71);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(121, 21);
      this.comboBox1.TabIndex = 25;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
      this.label3.Location = new System.Drawing.Point(9, 451);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(166, 17);
      this.label3.TabIndex = 26;
      this.label3.Text = "Search for File on Server";
      this.label3.Click += new System.EventHandler(this.label3_Click);
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(188, 451);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(292, 20);
      this.textBox1.TabIndex = 27;
      // 
      // ClientForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(502, 675);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.comboBox1);
      this.Controls.Add(this.label5);
      this.Controls.Add(this.textBox4);
      this.Controls.Add(this.localAddress);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.fileInformationGrid);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.CmdBtn);
      this.Controls.Add(this.CmdField);
      this.Controls.Add(this.CmdLbl);
      this.Controls.Add(this.BeginConnectionBtn);
      this.Controls.Add(this.LogWindowLabel);
      this.Controls.Add(this.LogBox);
      this.Controls.Add(this.PortEntryLbl);
      this.Controls.Add(this.PortEntryField);
      this.Controls.Add(this.IPEntryLbl);
      this.Controls.Add(this.IPEntryField);
      this.Controls.Add(this.TitleLbl);
      this.Name = "ClientForm";
      this.Text = "ClientForm";
      this.Load += new System.EventHandler(this.ClientForm_Load);
      ((System.ComponentModel.ISupportInitialize)(this.fileInformationGrid)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label TitleLbl;
    private System.Windows.Forms.TextBox IPEntryField;
    private System.Windows.Forms.Label IPEntryLbl;
    private System.Windows.Forms.TextBox PortEntryField;
    private System.Windows.Forms.Label PortEntryLbl;
    private System.Windows.Forms.RichTextBox LogBox;
    private System.Windows.Forms.Label LogWindowLabel;
    private System.Windows.Forms.Button BeginConnectionBtn;
    private System.Windows.Forms.Label CmdLbl;
    private System.Windows.Forms.TextBox CmdField;
    private System.Windows.Forms.Button CmdBtn;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.DataGridView fileInformationGrid;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.DataGridViewTextBoxColumn File;
    private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
    private System.Windows.Forms.DataGridViewTextBoxColumn FileLocation;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox localAddress;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox textBox1;
  }
}