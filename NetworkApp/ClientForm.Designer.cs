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
      this.IPEntryField.Location = new System.Drawing.Point(43, 41);
      this.IPEntryField.Name = "IPEntryField";
      this.IPEntryField.Size = new System.Drawing.Size(184, 20);
      this.IPEntryField.TabIndex = 1;
      this.IPEntryField.TextChanged += new System.EventHandler(this.IPEntryField_TextChanged);
      // 
      // IPEntryLbl
      // 
      this.IPEntryLbl.AutoSize = true;
      this.IPEntryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.IPEntryLbl.Location = new System.Drawing.Point(13, 42);
      this.IPEntryLbl.Name = "IPEntryLbl";
      this.IPEntryLbl.Size = new System.Drawing.Size(24, 17);
      this.IPEntryLbl.TabIndex = 2;
      this.IPEntryLbl.Text = "IP:";
      // 
      // PortEntryField
      // 
      this.PortEntryField.Location = new System.Drawing.Point(43, 67);
      this.PortEntryField.Name = "PortEntryField";
      this.PortEntryField.Size = new System.Drawing.Size(51, 20);
      this.PortEntryField.TabIndex = 3;
      this.PortEntryField.TextChanged += new System.EventHandler(this.PortEntryField_TextChanged);
      // 
      // PortEntryLbl
      // 
      this.PortEntryLbl.AutoSize = true;
      this.PortEntryLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.PortEntryLbl.Location = new System.Drawing.Point(3, 68);
      this.PortEntryLbl.Name = "PortEntryLbl";
      this.PortEntryLbl.Size = new System.Drawing.Size(38, 17);
      this.PortEntryLbl.TabIndex = 4;
      this.PortEntryLbl.Text = "Port:";
      // 
      // LogBox
      // 
      this.LogBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.LogBox.Location = new System.Drawing.Point(12, 154);
      this.LogBox.Name = "LogBox";
      this.LogBox.ReadOnly = true;
      this.LogBox.Size = new System.Drawing.Size(225, 270);
      this.LogBox.TabIndex = 5;
      this.LogBox.Text = "";
      // 
      // LogWindowLabel
      // 
      this.LogWindowLabel.AutoSize = true;
      this.LogWindowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LogWindowLabel.Location = new System.Drawing.Point(13, 134);
      this.LogWindowLabel.Name = "LogWindowLabel";
      this.LogWindowLabel.Size = new System.Drawing.Size(75, 17);
      this.LogWindowLabel.TabIndex = 6;
      this.LogWindowLabel.Text = "Client Log:";
      // 
      // BeginConnectionBtn
      // 
      this.BeginConnectionBtn.Location = new System.Drawing.Point(152, 67);
      this.BeginConnectionBtn.Name = "BeginConnectionBtn";
      this.BeginConnectionBtn.Size = new System.Drawing.Size(75, 23);
      this.BeginConnectionBtn.TabIndex = 7;
      this.BeginConnectionBtn.Text = "Connect";
      this.BeginConnectionBtn.UseVisualStyleBackColor = true;
      this.BeginConnectionBtn.Click += new System.EventHandler(this.BeginConnectionBtn_Click);
      // 
      // CmdLbl
      // 
      this.CmdLbl.AutoSize = true;
      this.CmdLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CmdLbl.Location = new System.Drawing.Point(1, 96);
      this.CmdLbl.Name = "CmdLbl";
      this.CmdLbl.Size = new System.Drawing.Size(40, 17);
      this.CmdLbl.TabIndex = 8;
      this.CmdLbl.Text = "Cmd:";
      // 
      // CmdField
      // 
      this.CmdField.Location = new System.Drawing.Point(43, 96);
      this.CmdField.Name = "CmdField";
      this.CmdField.Size = new System.Drawing.Size(103, 20);
      this.CmdField.TabIndex = 9;
      this.CmdField.TextChanged += new System.EventHandler(this.CmdBox_TextChanged);
      // 
      // CmdBtn
      // 
      this.CmdBtn.Location = new System.Drawing.Point(152, 93);
      this.CmdBtn.Name = "CmdBtn";
      this.CmdBtn.Size = new System.Drawing.Size(75, 23);
      this.CmdBtn.TabIndex = 10;
      this.CmdBtn.Text = "Send";
      this.CmdBtn.UseVisualStyleBackColor = true;
      this.CmdBtn.Click += new System.EventHandler(this.CmdBtn_Click);
      // 
      // ClientForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(256, 450);
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
  }
}