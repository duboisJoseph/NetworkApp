namespace NetworkApp
{
  partial class ServerForm
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
      this.CmdLbl = new System.Windows.Forms.Label();
      this.CmdBox = new System.Windows.Forms.TextBox();
      this.CmdBtn = new System.Windows.Forms.Button();
      this.LogBox = new System.Windows.Forms.RichTextBox();
      this.LogLbl = new System.Windows.Forms.Label();
      this.IPLbl = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // TitleLbl
      // 
      this.TitleLbl.AutoSize = true;
      this.TitleLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.TitleLbl.Location = new System.Drawing.Point(13, 13);
      this.TitleLbl.Name = "TitleLbl";
      this.TitleLbl.Size = new System.Drawing.Size(205, 20);
      this.TitleLbl.TabIndex = 0;
      this.TitleLbl.Text = "Hello! This is a server portal!";
      // 
      // CmdLbl
      // 
      this.CmdLbl.AutoSize = true;
      this.CmdLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.CmdLbl.Location = new System.Drawing.Point(12, 43);
      this.CmdLbl.Name = "CmdLbl";
      this.CmdLbl.Size = new System.Drawing.Size(40, 17);
      this.CmdLbl.TabIndex = 1;
      this.CmdLbl.Text = "Cmd:";
      // 
      // CmdBox
      // 
      this.CmdBox.Location = new System.Drawing.Point(58, 42);
      this.CmdBox.Name = "CmdBox";
      this.CmdBox.Size = new System.Drawing.Size(160, 20);
      this.CmdBox.TabIndex = 2;
      this.CmdBox.TextChanged += new System.EventHandler(this.CmdBox_TextChanged);
      // 
      // CmdBtn
      // 
      this.CmdBtn.Location = new System.Drawing.Point(224, 42);
      this.CmdBtn.Name = "CmdBtn";
      this.CmdBtn.Size = new System.Drawing.Size(86, 21);
      this.CmdBtn.TabIndex = 3;
      this.CmdBtn.Text = "Send";
      this.CmdBtn.UseVisualStyleBackColor = true;
      this.CmdBtn.Click += new System.EventHandler(this.CmdBtn_Click);
      // 
      // LogBox
      // 
      this.LogBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
      this.LogBox.Location = new System.Drawing.Point(12, 118);
      this.LogBox.Name = "LogBox";
      this.LogBox.ReadOnly = true;
      this.LogBox.Size = new System.Drawing.Size(298, 310);
      this.LogBox.TabIndex = 4;
      this.LogBox.Text = "";
      this.LogBox.TextChanged += new System.EventHandler(this.LogBox_TextChanged);
      // 
      // LogLbl
      // 
      this.LogLbl.AutoSize = true;
      this.LogLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LogLbl.Location = new System.Drawing.Point(9, 98);
      this.LogLbl.Name = "LogLbl";
      this.LogLbl.Size = new System.Drawing.Size(82, 17);
      this.LogLbl.TabIndex = 5;
      this.LogLbl.Text = "Server Log:";
      // 
      // IPLbl
      // 
      this.IPLbl.AutoSize = true;
      this.IPLbl.ForeColor = System.Drawing.Color.Blue;
      this.IPLbl.Location = new System.Drawing.Point(17, 72);
      this.IPLbl.Name = "IPLbl";
      this.IPLbl.Size = new System.Drawing.Size(0, 13);
      this.IPLbl.TabIndex = 6;
      // 
      // ServerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(326, 450);
      this.Controls.Add(this.IPLbl);
      this.Controls.Add(this.LogLbl);
      this.Controls.Add(this.LogBox);
      this.Controls.Add(this.CmdBtn);
      this.Controls.Add(this.CmdBox);
      this.Controls.Add(this.CmdLbl);
      this.Controls.Add(this.TitleLbl);
      this.Name = "ServerForm";
      this.Text = "ServerForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label TitleLbl;
    private System.Windows.Forms.Label CmdLbl;
    private System.Windows.Forms.TextBox CmdBox;
    private System.Windows.Forms.Button CmdBtn;
    private System.Windows.Forms.RichTextBox LogBox;
    private System.Windows.Forms.Label LogLbl;
    private System.Windows.Forms.Label IPLbl;
  }
}