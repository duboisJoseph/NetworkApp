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
 * 
 * Things it can not currently do (and needs to do):
 * Send commands to the server
 * P2P connect with another client
 * Host a P2P relation ship with another client.
 * Access its host file system.
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
    TcpClient client; //TCP Client socket object
    NetworkStream ns; //Data stream stores messages sent to/from client and server sockets
    Timer MyTimer; //timer object that triggers clock events
    byte[] bytes = new byte[1024]; //array of bytes
    int bytesRead; //number of bytes read

    //Folder Browser for files:
    FolderBrowserDialog FBD = new FolderBrowserDialog();
    string[] files;             //Anthony/Alec, this is the string of files that stores all the files in the local user's computer.

        public ClientForm() //Constructor (called only once)
        {
            InitializeComponent(); //Loads UI
            InitializeTimer(); //Sets up timer
            GetLocalClientInformation();
        }

        private void GetLocalClientInformation()
        {
           //Get HostName
            localAddress.Clear();
            try
            {
                // Get the local computer host name.
                String hostName = Dns.GetHostName();
                localAddress.Text = hostName;
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
            }

           

        }

    private void InitializeTimer()
    {
      MyTimer = new Timer
      {
        // Call this procedure when the application starts.  
        // Set to 1 second.  
        Interval = 1000
      };
      MyTimer.Tick += new EventHandler(MyTimer_tick);

      // Enable timer.  
      MyTimer.Enabled = false;
    }

    private void MyTimer_tick(object Sender, EventArgs e) //Event handler for Timer ticks.
    {
      LogBox.Text += "\n" + "."; //output to log window
      try
      {
        ns = client.GetStream(); //connect data stream to client socket

        bytesRead = ns.Read(bytes, 0, bytes.Length); //read bytes from data stream

        LogBox.Text += "\n >>" + Encoding.ASCII.GetString(bytes, 0, bytesRead); //convert bytes to string and output to log window
       
      }
      catch (Exception z)
      {
        LogBox.Text += "\n >>" + z.ToString(); //Output error to log window
      }
    }

    private void ClientForm_Load(object sender, EventArgs e)
    {

    }//function is called when the window first appears, could be used for intializations

    private void IPEntryField_TextChanged(object sender, EventArgs e)
    {

    }//event could be used for input validation

    private void PortEntryField_TextChanged(object sender, EventArgs e)
    {

    }//event could be used for input validation

    private void BeginConnectionBtn_Click(object sender, EventArgs e) //Using information in fields connect to the server
    {
      Int32 portNum; //Port number
      
      if (Int32.TryParse(PortEntryField.Text, out portNum)) //if able to parse field entry into a portNum continue
      {
        LogBox.Text += "\n" + "Connecting to " + IPEntryField.Text + ":" + PortEntryField.Text + "...";//Output to log window

        client = new TcpClient(IPEntryField.Text, portNum); //Create client connection to server.

        if (client != null) //if not failed
        {
          LogBox.Text += "\n" + "Connection Complete!";//Output to log window
          MyTimer.Enabled = true; //Start timer                 //Get Local information
                }
        else
        {
          LogBox.Text += "\n" + "Connection Not Found";//Output to log window
        }
      } else
      {
        LogBox.Text += "\n" + "Invalid Port Number:" + PortEntryField.Text; //Output to log window
      }
    }

    private void CmdBtn_Click(object sender, EventArgs e) 
    {
      //TODO need to develop function so that when the send command button is pressed the client writes its command string to the server 
      ns = client.GetStream();
      byte[] outStream = System.Text.Encoding.ASCII.GetBytes(CmdField.Text);
      ns.Write(outStream, 0, outStream.Length);
      ns.Flush();
    }

    private void CmdBox_TextChanged(object sender, EventArgs e)
    {

    } //could be used for input validation

        private void LogWindowLabel_Click(object sender, EventArgs e)
        {

        }

        private void fileListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                foreach(string file in files)
                {
                    fileInformationGrid.Rows.Add(Path.GetFileName(file)," ",file);
                }
            }
        }

        //"Refresh File List" Button Handler:
        private void refreshFileList(object sender, EventArgs e)
        {
            //Get all files in directory:
            

            fileInformationGrid.Rows.Clear();
            //Show files in the listbox:
            if (files != null)
            {
                files = Directory.GetFiles(FBD.SelectedPath);
                fileInformationGrid.Rows.Clear();
                foreach (string file in files)
                {
                    fileInformationGrid.Rows.Add(Path.GetFileName(file), Path.GetExtension(file), file);
                }
            }
        }

        private void fileInformationGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
