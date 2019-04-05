namespace NetworkApp
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
      this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
      this.SearchBox = new System.Windows.Forms.TextBox();
      this.HostIpBox = new System.Windows.Forms.TextBox();
      this.HostPortBox = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.HostHeaderLbl = new System.Windows.Forms.Label();
      this.BeginHostBtn = new System.Windows.Forms.Button();
      this.SearchResultsBox = new System.Windows.Forms.RichTextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.button3 = new System.Windows.Forms.Button();
      this.BeginSearchBtn = new System.Windows.Forms.Button();
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
      this.CmdLbl.Location = new System.Drawing.Point(12, 118);
      this.CmdLbl.Name = "CmdLbl";
      this.CmdLbl.Size = new System.Drawing.Size(40, 17);
      this.CmdLbl.TabIndex = 8;
      this.CmdLbl.Text = "Cmd:";
      // 
      // CmdField
      // 
      this.CmdField.Location = new System.Drawing.Point(53, 117);
      this.CmdField.Name = "CmdField";
      this.CmdField.Size = new System.Drawing.Size(336, 20);
      this.CmdField.TabIndex = 9;
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
      this.button1.Enabled = false;
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
            this.FileName,
            this.FileType,
            this.FileLocation});
      this.fileInformationGrid.Location = new System.Drawing.Point(16, 300);
      this.fileInformationGrid.Name = "fileInformationGrid";
      this.fileInformationGrid.Size = new System.Drawing.Size(458, 99);
      this.fileInformationGrid.TabIndex = 14;
      // 
      // FileName
      // 
      this.FileName.HeaderText = "File Name";
      this.FileName.Name = "FileName";
      this.FileName.Width = 150;
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
      this.button2.Enabled = false;
      this.button2.Location = new System.Drawing.Point(373, 414);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(107, 23);
      this.button2.TabIndex = 15;
      this.button2.Text = "Refresh File List";
      this.button2.UseVisualStyleBackColor = true;
      this.button2.Click += new System.EventHandler(this.RefreshFileList);
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
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.Location = new System.Drawing.Point(294, 74);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(79, 17);
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
      this.textBox4.Size = new System.Drawing.Size(143, 20);
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
      this.comboBox1.Location = new System.Drawing.Point(373, 73);
      this.comboBox1.Name = "comboBox1";
      this.comboBox1.Size = new System.Drawing.Size(107, 21);
      this.comboBox1.TabIndex = 25;
      this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
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
      // 
      // SearchBox
      // 
      this.SearchBox.Location = new System.Drawing.Point(188, 451);
      this.SearchBox.Name = "SearchBox";
      this.SearchBox.Size = new System.Drawing.Size(179, 20);
      this.SearchBox.TabIndex = 27;
      // 
      // HostIpBox
      // 
      this.HostIpBox.Location = new System.Drawing.Point(53, 633);
      this.HostIpBox.Name = "HostIpBox";
      this.HostIpBox.Size = new System.Drawing.Size(235, 20);
      this.HostIpBox.TabIndex = 28;
      this.HostIpBox.TextChanged += new System.EventHandler(this.HostIpBox_TextChanged);
      // 
      // HostPortBox
      // 
      this.HostPortBox.Location = new System.Drawing.Point(337, 632);
      this.HostPortBox.Name = "HostPortBox";
      this.HostPortBox.Size = new System.Drawing.Size(52, 20);
      this.HostPortBox.TabIndex = 29;
      this.HostPortBox.TextChanged += new System.EventHandler(this.HostPortBox_TextChanged);
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.Location = new System.Drawing.Point(13, 635);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(24, 17);
      this.label6.TabIndex = 30;
      this.label6.Text = "IP:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label7.Location = new System.Drawing.Point(294, 632);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(38, 17);
      this.label7.TabIndex = 31;
      this.label7.Text = "Port:";
      // 
      // HostHeaderLbl
      // 
      this.HostHeaderLbl.AutoSize = true;
      this.HostHeaderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.HostHeaderLbl.Location = new System.Drawing.Point(13, 613);
      this.HostHeaderLbl.Name = "HostHeaderLbl";
      this.HostHeaderLbl.Size = new System.Drawing.Size(119, 17);
      this.HostHeaderLbl.TabIndex = 32;
      this.HostHeaderLbl.Text = "Host Network Info";
      // 
      // BeginHostBtn
      // 
      this.BeginHostBtn.Location = new System.Drawing.Point(415, 629);
      this.BeginHostBtn.Name = "BeginHostBtn";
      this.BeginHostBtn.Size = new System.Drawing.Size(75, 23);
      this.BeginHostBtn.TabIndex = 33;
      this.BeginHostBtn.Text = "Allow Peers";
      this.BeginHostBtn.UseVisualStyleBackColor = true;
      this.BeginHostBtn.Click += new System.EventHandler(this.BeginHostBtn_Click);
      // 
      // SearchResultsBox
      // 
      this.SearchResultsBox.Location = new System.Drawing.Point(15, 496);
      this.SearchResultsBox.Name = "SearchResultsBox";
      this.SearchResultsBox.Size = new System.Drawing.Size(465, 87);
      this.SearchResultsBox.TabIndex = 34;
      this.SearchResultsBox.Text = "";
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(12, 480);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(77, 13);
      this.label8.TabIndex = 35;
      this.label8.Text = "Search Result:";
      // 
      // button3
      // 
      this.button3.Location = new System.Drawing.Point(395, 592);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(95, 23);
      this.button3.TabIndex = 36;
      this.button3.Text = "Download File";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new System.EventHandler(this.button3_Click_1);
      // 
      // BeginSearchBtn
      // 
      this.BeginSearchBtn.Location = new System.Drawing.Point(373, 449);
      this.BeginSearchBtn.Name = "BeginSearchBtn";
      this.BeginSearchBtn.Size = new System.Drawing.Size(107, 23);
      this.BeginSearchBtn.TabIndex = 37;
      this.BeginSearchBtn.Text = "Search";
      this.BeginSearchBtn.UseVisualStyleBackColor = true;
      this.BeginSearchBtn.Click += new System.EventHandler(this.BeginSearchBtn_Click);
      // 
      // ClientForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(502, 675);
      this.Controls.Add(this.BeginSearchBtn);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.label8);
      this.Controls.Add(this.SearchResultsBox);
      this.Controls.Add(this.BeginHostBtn);
      this.Controls.Add(this.HostHeaderLbl);
      this.Controls.Add(this.label7);
      this.Controls.Add(this.label6);
      this.Controls.Add(this.HostPortBox);
      this.Controls.Add(this.HostIpBox);
      this.Controls.Add(this.SearchBox);
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
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
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
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox localAddress;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.ComboBox comboBox1;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox SearchBox;
    private System.Windows.Forms.TextBox HostIpBox;
    private System.Windows.Forms.TextBox HostPortBox;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label HostHeaderLbl;
    private System.Windows.Forms.Button BeginHostBtn;
    private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
    private System.Windows.Forms.DataGridViewTextBoxColumn FileType;
    private System.Windows.Forms.DataGridViewTextBoxColumn FileLocation;
        private System.Windows.Forms.RichTextBox SearchResultsBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button BeginSearchBtn;
  }
}