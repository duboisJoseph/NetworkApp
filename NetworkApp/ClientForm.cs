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
    public Socket Handler;
    private Socket listener; // added by corsiKa
    public static System.Threading.ManualResetEvent allDone = new System.Threading.ManualResetEvent(false);

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

      LogBox.Text += "\n Opening Connections to other P2P with local machine at : ";
      StartListening();
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

    public void StartListening()
    {
        //Establish the local end point for the socket. DNS name of the computer, running the listener is our IP
        IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ipAddress;
        IPAddress.TryParse("127.0.0.1", out ipAddress);
        //IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, Int32.Parse(HostPortBox.Text));
        
        //Create our client server:
        LogBox.Text += IPAddress.Parse(((IPEndPoint)localEndPoint).Address.ToString());
        LogBox.Text += ":" + HostPortBox.Text;
            
        // Create a TCP/IP socket.  
        listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // Bind the socket to the local endpoint and listen for incoming connections.  
            try
            {
                listener.Blocking = false;
                listener.Bind(localEndPoint);
                listener.Listen(100);
                LogBox.Text += "\n Listening...";
                performListen(listener);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void performListen(Socket listener)
        {
            listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            // Get the socket that handles the client request
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);
            Handler = handler;

            // Create the state object
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            LogBox.Text += "\n Successful connection between Client P2P";
        }

        public void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket  
            // from the asynchronous state object.  
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            // Read data from the client socket.   
            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.  
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read   
                // more data.  
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the   
                    // client. Display it on the console.  
                    Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);
                    // Echo the data back to the client.  
                    Send(handler, content);
                }
                else
                {
                    // Not all data received. Get more.  
                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReadCallback), state);
                }
            }
        }

        public void CloseNode(bool acceptMoreConnections)
        {
            try
            {
                if (Handler != null)
                {
                    Handler.Shutdown(SocketShutdown.Both);
                    Handler.Close();
                    Handler.Dispose();
                    Handler = null;
                }
                // changed by corsiKa
                if (acceptMoreConnections)
                    performListen(listener);
            }
            catch (Exception e)
            {
               
            }
        }

        public void Send(Socket client, String data)
        {
            // Convert the string data to byte data using ASCII encoding.  
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.  
            client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client);
        }

        public void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.  
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.  
                int bytesSent = handler.EndSend(ar);

                LogBox.Text += "\nSent " + bytesSent + " bytes to client.";

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Start TCP connection between P2P 
            TcpClient localClient = new TcpClient("127.0.0.1", 3332); //Create client connection to server.

            if (client != null) //if not failed
            {
                LogBox.Text += "\n" + "Connection Complete!";//Output to log window
                ns = client.GetStream(); //connect data stream to client socket
                MyTimer.Enabled = true; //Start timer          
            }
            else
            {
                LogBox.Text += "\n" + "Connection Not Found";//Output to log window
            }

            //Send(Handler, "lol");
        }
    }
}

// State object for reading client data asynchronously  
public class StateObject
{
    // Client  socket.  
    public Socket workSocket = null;
    // Size of receive buffer.  
    public const int BufferSize = 1024;
    // Receive buffer.  
    public byte[] buffer = new byte[BufferSize];
    // Received data string.  
    public StringBuilder sb = new StringBuilder();
}
