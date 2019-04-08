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
    
    private Timer MyTimer; //timer object that triggers clock events

    private byte[] bytes = new byte[8192]; //array of bytes
    private int bytesRead; //number of bytes read
    private int serverGivenID = -1;

    //Folder Browser for files:
    private FolderBrowserDialog FBD = new FolderBrowserDialog();

    private List<FileStruct> localFileList = new List<FileStruct>();
    private ClientInfo localHostInfo;
    private Socket PeerSocket1;
    private TcpClient client; //TCP Client socket object
    private NetworkStream ns;
    string[] files;
 

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
        Interval = 100
      };
      MyTimer.Tick += new EventHandler(MyTimer_tick);

      // Enable timer.  
      MyTimer.Enabled = false;
    }

    private void MyTimer_tick(object Sender, EventArgs e) //Event handler for Timer ticks.
    {


      string response = "";
      if (ns.CanRead)
      {
        try
        {
          while (ns.DataAvailable)
          {
            bytesRead = ns.Read(bytes, 0, bytes.Length); //read bytes from data stream
            serverGivenID = int.Parse(Encoding.ASCII.GetString(bytes, 2, 1));
            response = Encoding.ASCII.GetString(bytes, 3, bytesRead); //convert bytes to string and output to log window
            if (response.Contains("Results:"))
            {
              SearchResultsBox.Text = response;
            } else {
              LogBox.Text += "\n " + serverGivenID + ">>" + response;
            }
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
      int portNum; //Port number

      if (int.TryParse(PortEntryField.Text, out portNum)) //if able to parse field entry into a portNum continue
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

    private void ChooseSharingDirectoryClick(object sender, EventArgs e)
    {

      if (FBD.ShowDialog() == DialogResult.OK)
      {
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
        if(fid == 0)
        {
          FileStruct f = new FileStruct("EmptyDirectory", "EmptyDir", -1, serverGivenID);
        }
      }
    }

    private void RefreshFileList(object sender, EventArgs e)
    {
      fileInformationGrid.Rows.Clear();
      files = null;
      //Show files in the listbox:
      if (files != null)
      {
        files = Directory.GetFiles(FBD.SelectedPath);
        fileInformationGrid.Rows.Clear();
        int fid = localFileList.Count;
        foreach (string file in files)
        {
          fileInformationGrid.Rows.Add(Path.GetFileName(file), Path.GetExtension(file), file);
          FileStruct f = new FileStruct(Path.GetFileName(file), Path.GetExtension(file), fid, serverGivenID);
          bool fileInList = false;
          foreach(FileStruct struc in localFileList)
          {
            if (f.GetFileName() == struc.GetFileName())
            {
              fileInList = true;
            }
          }
          
          if(!fileInList)
            localFileList.Add(f);
          fid++;
        }
      }
    }

    private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

      foreach (FileStruct f in localFileList)
      {
        fileString += f.ToString(); //uses overridden toString function
      }
      BinaryWriter writer = new BinaryWriter(ns);
      writer.Write(fileString);

      LogBox.Text += "\n Writing File List to Server";

      string clientInfoString = "";

      clientInfoString += localHostInfo.ToString();
      writer.Write(clientInfoString);

      //Paste Host Button Clicked Code      
      HostPeer();
    }

    //Invoked by hostpeer Button Clicked
    private void HostPeer()
    {
      string fileNameToSend = "";

      //Create Listener
      Socket ListenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      IPEndPoint HostIPEndPoint = new IPEndPoint(IPAddress.Parse(HostIpBox.Text), int.Parse(HostPortBox.Text));
      ListenerSocket.Bind(HostIPEndPoint);

      //Listen
      ListenerSocket.Listen(40);
      LogBox.Text += "\n Opening Connections to other P2P with local machine at : ";
      bool keepListening = true;

      //Accept Socket
      while (keepListening)
      {
        if (ListenerSocket.Poll(100, SelectMode.SelectRead))
        {
          PeerSocket1 = ListenerSocket.Accept();
          keepListening = false;
        }
        Application.DoEvents();
      }

      //Send Greeting
      int bytesSent = TransmitString(PeerSocket1, HostNameBox.Text);

      //Receive Response
      string connectedPeerName = ReceiveString(PeerSocket1);

      LogBox.Text += "\n" + connectedPeerName + " has connected.";

      keepListening = true;

      while (keepListening)
      {
        if (PeerSocket1.Poll(100, SelectMode.SelectRead))
        {
          fileNameToSend = ReceiveString(PeerSocket1);
          keepListening = false;
        }
        Application.DoEvents();
      }
      TransmitFile(PeerSocket1, FBD.SelectedPath, fileNameToSend);

      LogBox.Text += "\n Sent "+ fileNameToSend + " to " + connectedPeerName + ".";

    }

    //Invoked By CMD Button Clicked
    private void ConnectToPeer(string desiredFileName, string ipAddr, string portNum)
    {
      Socket SocketConnectedToPeer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
      IPEndPoint HostIPEndPoint = new IPEndPoint(IPAddress.Parse(ipAddr), int.Parse(portNum));

      //Connect To Lobby
      SocketConnectedToPeer.Connect(HostIPEndPoint);

      //Receive Greeting
      String fromHostPeer = ReceiveString(SocketConnectedToPeer);

      LogBox.Text += "\n Connected to " + fromHostPeer + ".";

      //Send host name
      int bytesSent = TransmitString(SocketConnectedToPeer, HostNameBox.Text);

      TransmitString(SocketConnectedToPeer, desiredFileName);
      LogBox.Text += "\n Transmitted FileRequest";

      //bool keepWaitingForFile = true;
      ReceiveFile(SocketConnectedToPeer, FBD.SelectedPath + @"\" + desiredFileName);


      LogBox.Text += "\n File recevied from " + fromHostPeer;
    }

    private int TransmitFile(Socket socket, string filePath, string fileName)
    {
      string combinedFilePath = filePath + @"\" + fileName;
      FileInfo toTransmitFileInfo = new FileInfo(combinedFilePath);
      TransmitString(socket, "!fi:" + toTransmitFileInfo.Length);

      bool clientNotReady = true;
      while (clientNotReady)
      {
        if (ReceiveString(socket) == "!go")
        {
          clientNotReady = false;
          socket.SendFile(combinedFilePath);
        }
      }
      return 1;
    }

    private int ReceiveFile(Socket socket, string completePath)
    {
      byte[] fileSizeBuffer = new byte[20];
      int numBytes = -1;

      string filesize = ReceiveString(socket);
      int sizeInBytes = int.Parse(filesize.Substring(4));


      byte[] fileBuffer = new byte[sizeInBytes];
      TransmitString(socket, "!go");

      bool keepWaiting = true;
      while (keepWaiting)
      {
        if (socket.Poll(100, SelectMode.SelectRead))
        {

          numBytes = socket.Receive(fileBuffer);
          keepWaiting = false;
        }
        Application.DoEvents();
      }

      File.WriteAllBytes(completePath, fileBuffer);

      return numBytes;
    }

    private int TransmitString(Socket socket, string msg)
    {
      byte[] sendBuffer = Encoding.UTF8.GetBytes(msg);
      int bytesSent = socket.Send(sendBuffer);
      return bytesSent;
    }

    private string ReceiveString(Socket socket)
    {
      byte[] receiveBuffer = new byte[1024];
      int bytesReceived = socket.Receive(receiveBuffer);
      return Encoding.UTF8.GetString(receiveBuffer, 0, bytesReceived);
    }

    private void CmdBtn_Click(object sender, EventArgs e)
    {

      if (CmdField.Text.Contains("import"))
      {
        string[] cmdParams = CmdField.Text.Split(' ');

        if(cmdParams.Length == 4)
        {
          ConnectToPeer(cmdParams[1], cmdParams[2], cmdParams[3]);
        } else
        {
          foreach(string s in cmdParams)
            Console.WriteLine(">>> " + s + " <<<");
        }
        
      }
      else
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

    private void BeginSearchBtn_Click(object sender, EventArgs e)
    {
      ns.Flush();
      string searchString = "";
      LogBox.Text += "\n Client Searching for:" + SearchBox.Text;
      BinaryWriter writer = new BinaryWriter(ns);

      searchString += "@" + SearchBox.Text;
      writer.Write(searchString);
    }

    private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      MyTimer.Stop();
      MyTimer.Dispose();

      //Post File Data to Server
      string closingString = "$$!" + serverGivenID;

      BinaryWriter writer = new BinaryWriter(ns);
      writer.Write(closingString);

      LogBox.Text += "Shutting Down.";

      writer.Write(closingString);

      FBD.Dispose();
      client.Close();
      ns.Close();
      //listener.Close();

    }


  }
}



