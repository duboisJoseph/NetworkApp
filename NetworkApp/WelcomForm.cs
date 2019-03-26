using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkApp
{
  public partial class WelcomForm : Form
  {
    public WelcomForm()
    {
      InitializeComponent();
    }

    private void Greetings_lbl_Click(object sender, EventArgs e)
    {
      Greetings_lbl.Text = "Secret Message!";
    }

    private void ServerModeBtn_Click(object sender, EventArgs e)
    {
      ServerForm server = new ServerForm();
      server.ShowDialog(this);
      server.Dispose();
    }

    private void ClientModeBtn_Click(object sender, EventArgs e)
    {
      ClientForm client = new ClientForm();
      client.ShowDialog(this);
      client.Dispose();
    }
  }
}
