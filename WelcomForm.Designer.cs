namespace NetworkApp
{
  partial class WelcomForm
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
      this.Greetings_lbl = new System.Windows.Forms.Label();
      this.ClientModeBtn = new System.Windows.Forms.Button();
      this.ServerModeBtn = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // Greetings_lbl
      // 
      this.Greetings_lbl.AutoSize = true;
      this.Greetings_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Greetings_lbl.ForeColor = System.Drawing.SystemColors.ControlLight;
      this.Greetings_lbl.Location = new System.Drawing.Point(334, 87);
      this.Greetings_lbl.Name = "Greetings_lbl";
      this.Greetings_lbl.Size = new System.Drawing.Size(134, 31);
      this.Greetings_lbl.TabIndex = 0;
      this.Greetings_lbl.Text = "Welcome!";
      this.Greetings_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.Greetings_lbl.Click += new System.EventHandler(this.Greetings_lbl_Click);
      // 
      // ClientModeBtn
      // 
      this.ClientModeBtn.BackColor = System.Drawing.Color.Transparent;
      this.ClientModeBtn.ForeColor = System.Drawing.SystemColors.ControlText;
      this.ClientModeBtn.Location = new System.Drawing.Point(288, 207);
      this.ClientModeBtn.Name = "ClientModeBtn";
      this.ClientModeBtn.Size = new System.Drawing.Size(106, 23);
      this.ClientModeBtn.TabIndex = 1;
      this.ClientModeBtn.Text = "Create Client";
      this.ClientModeBtn.UseVisualStyleBackColor = false;
      this.ClientModeBtn.Click += new System.EventHandler(this.ClientModeBtn_Click);
      // 
      // ServerModeBtn
      // 
      this.ServerModeBtn.Location = new System.Drawing.Point(421, 207);
      this.ServerModeBtn.Name = "ServerModeBtn";
      this.ServerModeBtn.Size = new System.Drawing.Size(97, 23);
      this.ServerModeBtn.TabIndex = 2;
      this.ServerModeBtn.Text = "Create Server";
      this.ServerModeBtn.UseVisualStyleBackColor = true;
      this.ServerModeBtn.Click += new System.EventHandler(this.ServerModeBtn_Click);
      // 
      // WelcomForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(798, 367);
      this.Controls.Add(this.ServerModeBtn);
      this.Controls.Add(this.ClientModeBtn);
      this.Controls.Add(this.Greetings_lbl);
      this.Name = "WelcomForm";
      this.Text = "WelcomForm";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label Greetings_lbl;
    private System.Windows.Forms.Button ClientModeBtn;
    private System.Windows.Forms.Button ServerModeBtn;
  }
}