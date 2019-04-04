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
    TcpClient client; //TCP Client socket object
    NetworkStream ns; //Data stream stores messages sent to/from client and server sockets
    Timer MyTimer; //timer object that triggers clock events
    byte[] bytes = new byte[1024]; //array of bytes
    int bytesRead; //number of bytes read
    int serverGivenID = -1;

    //Folder Browser for files:
    FolderBrowserDialog FBD = new FolderBrowserDialog();
    string[] files;             //Anthony/Alec, this is the string of files that stores all the files in the local user's computer.

    List<FileStruct> localFileList = new List<FileStruct>();
    ClientInfo localHostInfo;

    public ClientForm() 
    {
      InitializeComponent();
      InitializeTimer(); 
      GetLocalClientInformation();
    }

    private void GetLocalClientInformation()
    {
      //Get HostName
      localAddress.Clear();

      localHostInfo = new ClientInfo(serverGivenID);
      try
      {
        // Get the local computer host name.
        localHostInfo.dnsName = Dns.GetHostName();
        localAddress.Text = localHostInfo.dnsName;
        
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
      if (ns.CanRead)
      {
        try
        {
          while (ns.DataAvailable)
          { 
            bytesRead = ns.Read(bytes, 0, bytes.Length); //read bytes from data stream
            serverGivenID = int.Parse(Encoding.ASCII.GetString(bytes, 2, 1));
            LogBox.Text += "\n "+serverGivenID+">>" + Encoding.ASCII.GetString(bytes, 3, bytesRead); //convert bytes to string and output to log window
            localHostInfo.clientID = serverGivenID;
          }
        }
        catch (Exception z)
        {
          LogBox.Text += "\n >>" + z.ToString(); //Output error to log window
        }
      } else
      {
        LogBox.Text += "\n >>" + "Can not read network stream"; //convert bytes to string and output to log window
      }
    }

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
          ns = client.GetStream(); //connect data stream to client socket
          button1.Enabled = true;
          button2.Enabled = true;
          MyTimer.Enabled = true; //Start timer          
        }
        else
        {
          LogBox.Text += "\n" + "Connection Not Found";//Output to log window
        }
      }
      else
      {
        LogBox.Text += "\n" + "Invalid Port Number:" + PortEntryField.Text; //Output to log window
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
          FileStruct f = new FileStruct(Path.GetFileName(file), Path.GetExtension(file), fid, serverGivenID);
          localFileList.Add(f);
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
          FileStruct f = new FileStruct(Path.GetFileName(file), Path.GetExtension(file), fid, serverGivenID);
          localFileList.Add(f);
          fid++;
        }
      }
    }

    private void PushFileDataToServer(string file)
    {
      

    } 

    private void DeserializeClientFileList(string clientFileListName)
    {
      localFileList = Serializer.Load<List<FileStruct>>(clientFileListName);
      for (int i = 0; i < localFileList.Count(); i++)
      {
        localFileList.Add(localFileList[i]);
      }
    }

    //Seralizes the server's file list for sending to client.
    private void SerializeFileList()
    {
      Serializer.Save("ServerFileList.bin", localFileList);
    }


    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      localHostInfo.connType = comboBox1.Text;
    }

    private void HostIpBox_TextChanged(object sender, EventArgs e)
    {
      localHostInfo.ipAddr = HostIpBox.Text;
    }

    private void HostPortBox_TextChanged(object sender, EventArgs e)
    {
      Int32 portNum; //Port number

      if (Int32.TryParse(HostPortBox.Text, out portNum)) //if able to parse field entry into a portNum continue
      {
        localHostInfo.portNum = portNum;
      }
    }

    private void BeginHostBtn_Click(object sender, EventArgs e)
    {
      //Post File Data to Server
      string fileString = "";

      foreach(FileStruct f in localFileList)
      {
        fileString += f.ToString(); //uses overridden toString function
      }
      BinaryWriter writer = new BinaryWriter(ns);
      writer.Write(fileString);

      LogBox.Text += "\n Writing File List to Server";

      string clientInfoString = "";

      clientInfoString += localHostInfo.ToString();
      writer.Write(clientInfoString);

      LogBox.Text += "\n Write local connection info to Server";
    }

    private void CmdBtn_Click(object sender, EventArgs e)
    {
      switch (CmdField.Text)
      {
        case "encode":
          {
            foreach (FileStruct f in localFileList)
              LogBox.Text += "\n" + f.ToString();
            break;
          }
        case "decode": //command I use to test stuff to test decoding sent strings
          {
            break;
          }
        default:
          LogBox.Text += "\n Client:" + CmdField.Text;
          BinaryWriter writer = new BinaryWriter(ns);
          writer.Write(CmdField.Text);
          break;
      }  
    }
  }
}
