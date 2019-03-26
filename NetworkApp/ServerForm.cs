/**
 * Creator: Joe Dubois
 * Creation Date: 03/26/2019
 * 
 * CIS 457 Project 2
 * ServerForm.cs
 * 
 * Note to team: This File contains the primary code for our centralized server.
 * The logic in this file is that which interacts with the user interface ServerForm which inherits the Form class.
 * Things you will notice is that there is no main() function or primary while loop. Since we have to always be 
 * able to accept user input.
 * 
 * Each new client handling thread is launched using the HandleClient class
 * Much of the functionality as listed below is partially handled in the HandleClient class.
 * 
 * LIST OF FUNCTIONALITY (PLEASE UPDATE AS YOU COMPLETE)
 * Things it can currently do
 * Implements TCP Protocol
 * Listens for client connections
 * Gives an ID for each connected client.
 * Accepts client connections
 * Fully Multithreaded (new thread for each client)
 * Can broadcast data to all clients
 * 
 * Things it can not currently do (and needs to do):
 * Recieve data from clients (other than connection request)
 * Maintain a table of clients and client connection info (IPAddress, PortNum, ID/Name, connection speed)
 * Track if a client has disconnected. 
 * Recieve file descriptions file
 * Maintain a table of files stored in the directory of each client
 * When prompted by client keyword search file table.
 * Return results of keyword search (ip of remote host that has file, port number, file name, connection speed)
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
using SharedMemory; //downloaded library that facilitates shared memory IPC communication between threads

namespace NetworkApp
{
  public partial class ServerForm : Form
  {
    TcpListener server; //This object will listen for new clients.
    Timer MyTimer; //Timer object will trigger events
    TcpClient[] clients; //array of client objects not currently used but 
    int[] connectedIDs; //int array of conectedIDS the index of an element is a possible client ID value, the value of the element at that index (1 or 0) notifys whether or not a client is using that ID
                        //TODO Since we have to maintain a list of connected clients and their connection info we will need to either modify the above data structure or create a new one.

    const int max_connections = 256; //Arbitrary limit set by me (Joe)

    //Below two variables are used to facilitate a server initiated shutdown of all clients
    bool shouldCountDown = false; //begin countdown
    int countDown = 10; //number of clock events to wait before shutting of the server so that we can be sure the clients have disconnected. 

    int cmdCt = 0; //an identifier that increments for each command/message sent to the clients

    SharedArray<byte> producer; //Shared memory array write to this to communicate with child threads.


    public ServerForm()  //constructor for the ServerForm class. Runs only once.
    {
      //Currently Hard Coded IP Address could be user input driven
      IPAddress localAddr = IPAddress.Parse("127.0.0.1");

      //Currently Hard port number could be user input driven
      Int32 portNum = 3333;

      producer = new SharedArray<byte>("ParentToChildCmdArray", 40);

      //array stores client socket connections
      clients = new TcpClient[max_connections];

      //array contains 1s or 0s
      //if array element at index i = 1 then that index is the integer ID of an active client socket.
      connectedIDs = new int[max_connections];

      Console.WriteLine("Here1");

      //Initalize Array to 0s
      for(int i = 0; i < max_connections; i++) { connectedIDs[i] = 0;}

      InitializeComponent(); //Native WinForms function creates the UI

      InitializeTimer(); //sets up timer

      //create new tcpServer listener
      server = new TcpListener(localAddr, portNum);

      //server begins listening for connections
      server.Start();
    }

    private void InitializeTimer() //set up timer
    {

      MyTimer = new Timer
      {
        Interval = 1000 // Set to 1 second.  
      };

      MyTimer.Tick += new EventHandler(MyTimer_tick); //add an event handler (timer interrupt)

      MyTimer.Enabled = true; // Begin ticking (counting).  
    }

    private void MyTimer_tick(object Sender, EventArgs e) //called every timer tick (interval set in InitializeTimer)
    { 
      LogBox.Text += "\n" + "."; //output to server log.

      TcpClient clientSocket; //create a TCP client object

      if (shouldCountDown) //is server shutting down?
      {
        countDown--; //Decrement Countdown if server begins to shut down.
      }
      try
      {
        LogBox.Text += "\n" + "Waiting for connections..."; //output to server log.

        if (server.Pending()) //if there is a client trying to connect to the server
        {
          clientSocket = server.AcceptTcpClient(); //accept the client connection
          clientSocket.ReceiveBufferSize = 8192; //Set buffer size 
          clientSocket.SendBufferSize = 8192;    //Set buffer size

          if (clientSocket != null) //if client connection was succssessful
          {
            for (int i = 0; i < max_connections; i++) //find an open client ID int TODO: in this loop we could update the server's table of clients table with client information
            {
              if (connectedIDs[i] < 1) //if id not taken 
              {
                byte[]cmd = System.Text.Encoding.ASCII.GetBytes("!"+"Connected to Server");

                int j = 0;
                foreach (byte b in cmd) { producer[i] = b; j++; }

                connectedIDs[i] = 1;//mark that ID as taken

                HandleClient client = new HandleClient(); //create new client handler
            
                client.StartClient(clientSocket, Convert.ToString(i)); //start new client handler with the socket connection and the client ID i
                break;
              }
            }
          }
        }
      }
      catch (Exception z)
      {
        LogBox.Text += "\n" + z.ToString();
      }   
    }

    private void LogBox_TextChanged(object sender, EventArgs e)
    {
      //function could be used for input verification
    }

    private void CmdBox_TextChanged(object sender, EventArgs e)
    {
      //function could be used for input verification
    }

    private void CmdBtn_Click(object sender, EventArgs e)
    {
      if (CmdBox.Text == "stop")
      { 
        //Add and ! point to the beginning of the message so that it is known to be a command
        //Add the cmdCt (command counter) to notify the child thread that this is a new command.
        byte[] cmd = System.Text.Encoding.ASCII.GetBytes("!"+ cmdCt + CmdBox.Text); //String into byte array
        int i = 0;
        foreach(byte b in cmd)
        {
          producer[i] = b; //pack byte array into shared memory array
          i++;
        }                
        server.Stop(); //stop the server socket
      } else //not a stop command but a message to send to all clients
      {
        byte[] cmd = System.Text.Encoding.ASCII.GetBytes("!" + cmdCt + CmdBox.Text); //cmd String to byte array
        int i = 0;
        foreach (byte b in cmd) //byte array into shared memory
        {
          producer[i] = b;
          i++;
        }
        /*TODO For Project two we will be required to post to the clients a list of the other connected clients' IDs, IPAddresses, PortNumbers, connection speed
         *We will need to craft a string that has this information and pass it to the client threads through shared memory */
      }   
      cmdCt++;
    }
  }
}
