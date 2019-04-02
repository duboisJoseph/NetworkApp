using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using SharedMemory; //downloaded library that facilitates shared memory IPC communication between threads
using System.Timers;
using System.Windows.Forms;

namespace NetworkApp
{
  class Server
  {
    TcpListener server; //This object will listen for new clients.
    TcpClient[] clients; //array of client objects not currently used but 
    int[] connectedIDs; //int array of conectedIDS the index of an element is a possible client ID value, the value of the element at that index (1 or 0) notifys whether or not a client is using that ID
                        //TODO Since we have to maintain a list of connected clients and their connection info we will need to either modify the above data structure or

    const int max_connections = 256; //Arbitrary limit set by me (Joe)

    int cmdCt = 0; //an identifier that increments for each command/message sent to the clients

    SharedArray<byte> producer; //Shared memory array write to this to communicate with child threads.

    public Server()
    {
      //Currently Hard Coded IP Address could be user input driven
      IPAddress localAddr = IPAddress.Parse("127.0.0.1");

      //Currently Hard port number could be user input driven
      Int32 portNum = 3333;

      //array stores client socket connections
      clients = new TcpClient[max_connections];

      //array contains 1s or 0s
      //if array element at index i = 1 then that index is the integer ID of an active client socket.
      connectedIDs = new int[max_connections];

      //Initalize Array to 0s
      for (int i = 0; i < max_connections; i++) { connectedIDs[i] = 0; }

      //create new tcpServer listener
      server = new TcpListener(localAddr, portNum);

      ServerRunning(server);
    }

    public void ServerRunning(TcpListener listener)
    {
      bool running = true;
      using (producer = new SharedArray<byte>("ParentToChildCmdArray", 40))
      {
        //server begins listening for connections
        server.Start();
        while (running)
        {

          if (cmdCt > 1000000)
          {
            Console.WriteLine("\n" + "."); //output to server log.
            cmdCt = 0;
          }
          cmdCt++;
         
          try
          {
            //Console.WriteLine("Waiting for connections..."); //output to server log.

            if (server.Pending()) //if there is a client trying to connect to the server
            {
              TcpClient clientSocket; //create a TCP client object
              Console.WriteLine("Client Connecting");
              clientSocket = server.AcceptTcpClient(); //accept the client connection
              clientSocket.ReceiveBufferSize = 8192;   //Set buffer size 
              clientSocket.SendBufferSize = 8192;      //Set buffer size

              if (clientSocket != null) //if client connection was succssessful
              {
                Console.WriteLine("Client Connected");
                for (int i = 0; i < max_connections; i++) //find an open client ID int TODO: in this loop we could update the server's table of clients table with client information
                {
                  if (connectedIDs[i] < 1) //if id not taken 
                  {
                    byte[] cmd = System.Text.Encoding.ASCII.GetBytes("!" + "Connected to Server");

                    int j = 0;
                    foreach (byte b in cmd) { producer[i] = b; j++; }

                    connectedIDs[i] = 1;//mark that ID as taken

                    HandleClient client = new HandleClient(); //create new client handler

                    Console.WriteLine("Client #" + i + "Connected");
                    client.StartClient(clientSocket, Convert.ToString(i)); //start new client handler with the socket connection and the client ID i
                    break;
                  }
                }
              }
            }
          }
          catch (Exception z)
          {
            Console.WriteLine(z.ToString());
          }
          Application.DoEvents();
        }
      }
    }
  }
}
