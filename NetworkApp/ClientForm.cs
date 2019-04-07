/**
 * Creator: Joe Dubois
 * Creation Date: 03/26/2019
 * 
 * CIS 457 Project 2
 * ClientForm.cs
 * 
 * Note to team: This File contains the primary code for our P2P clients.
 * The logic in this file is that which interacts with the user interface ClientForm which inherits the Form class.
 * Things you will notice is that there is no main() function or primary while loop. Since we have to always be 
 * able to accept user input.
 * 
 * 
 * LIST OF FUNCTIONALITY (PLEASE UPDATE AS YOU COMPLETE)
 * Things it can currently do: 
 * Connect to the server
 * Read messages sent from the server
 * Display an output log of what is happening
 * Accept user defined IP address and Port number
 * Accept user defined commands.
 * Create a list of file descriptions (for example a file called "filelist.xml")
 * Access its host file system.
 * Send commands to the server
 * 
 * Things it can not currently do (and needs to do):
 * 
 * P2P connect with another client
 * Host a P2P relation ship with another client.
 * 
 * Keyword search from the set of all other clients files.
 * Get a file from another peer client (P2P ftp transfer)
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace NetworkApp
{
    public partial class ClientForm : Form
    {
        Client client;
        Timer MyTimer = new Timer(); //timer object that triggers clock events
        Timer MyTimerTwo = new Timer();
        FolderBrowserDialog FBD = new FolderBrowserDialog();
        string[] files;             //Anthony/Alec, this is the string of files that stores all the files in the local user's computer.

        public ClientForm()
        {
            InitializeComponent();
            client = new Client();
        }

        //Timer
        private void MyTimer_tick(object Sender, EventArgs e) //Event handler for Timer ticks.
        {
            string response = "";
            if (client.canRead())
            {
                try
                {
                    while (client.dataAvailable())
                    {
                        response = client.getResponse(); //convert bytes to string and output to log window
                        if (response.Contains("Results:"))
                        {
                            SearchResultsBox.Text = response;
                        }
                        else
                        {
                            LogBox.Text += "\n " + client.getCID() + ">>" + response;
                        }
                    }
                }
                catch (Exception z)
                {
                    LogBox.Text += "\n >>" + z.ToString(); //Output error to log window
                }
            }
            else
            {
                LogBox.Text += "\n >>" + "Can not read network stream";
            }
        }

        //Connect Button click event
        private void BeginConnectionBtn_Click(object sender, EventArgs e) //Using information in fields connect to the server
        {
            LogBox.Text += "Attempting to connect to " + IPEntryField.Text + " " + PortEntryField.Text+"\n";
            if (client.connectToServer(IPEntryField.Text, PortEntryField.Text))
            {
                LogBox.Text += "Connection successful!\n";
                shareDirectoryBtn.Enabled = true;
                refreshFileListBtn.Enabled = true;
                MyTimer.Enabled = true; //Start timer 
            }
            else
            {
                LogBox.Text += "Connection failed!\n";
            }
        }

        //"Choose Sharing Directory" Button Handler:
        private void ChooseSharingDirectoryClick(object sender, EventArgs e)
        {

            if (FBD.ShowDialog() == DialogResult.OK)
            {
                //Get all files in directory:
                files = Directory.GetFiles(FBD.SelectedPath);

                fileInformationGrid.Rows.Clear();
                //Show files in the listbox:
                int fid = 0;
                foreach (string file in files)
                {
                    fileInformationGrid.Rows.Add(Path.GetFileName(file), Path.GetExtension(file), file);
                    FileStruct f = new FileStruct(Path.GetFileName(file), Path.GetExtension(file), fid, client.getCID());
                    client.addFileToList(f);
                    fid++;
                }
            }
        }

        //"Refresh File List" Button Handler:
        private void RefreshFileList(object sender, EventArgs e)
        {
            fileInformationGrid.Rows.Clear();
            //Show files in the listbox:
            if (files != null)
            {
                files = Directory.GetFiles(FBD.SelectedPath);
                fileInformationGrid.Rows.Clear();
                int fid = 0;
                foreach (string file in files)
                {
                    fileInformationGrid.Rows.Add(Path.GetFileName(file), Path.GetExtension(file), file);
                    FileStruct f = new FileStruct(Path.GetFileName(file), Path.GetExtension(file), fid, client.getCID());
                    client.addFileToList(f);
                    fid++;
                }
            }
        }

        private void BeginHostBtn_Click(object sender, EventArgs e)
        {
            client.sendFileListToServer();
            LogBox.Text += "\n Writing File List to Server";

            client.sendClientInfoToServer();
            LogBox.Text += "\n Opening Connections to other P2P with local machine at : ";

            client.startListening();
        }

        private void CmdBtn_Click(object sender, EventArgs e)
        {

        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {

        }

        private void BeginSearchBtn_Click(object sender, EventArgs e)
        {

        }

        private void HostPortBox_TextChanged(object sender, EventArgs e)
        {
            client.setPort(HostPortBox.Text);
        }

        private void HostIpBox_TextChanged(object sender, EventArgs e)
        {
            client.setHostIP(HostIpBox.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            client.setConnectionType(comboBox1.Text);
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }

}
