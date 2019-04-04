/**
 * Creator: Joe Dubois
 * Creation Date: 03/26/2019
 * 
 * CIS 457 Project 2
 * HandleClient.cs
 * 
 * This class is used to handle each connected client. It is able to communicate with the main server thread using shared memory communication (IPC)
 * This class will first recive each message/command from the client. Each thread should handle requests by clients on their own using information 
 * that the server periodically will broadcast to all threads. Essentially we will probably have copies of the client table and file table in each 
 * HandleClient object. Or this class could pass on their requests to the main server thread. 
 * 
 *  
 * 
 * 
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SharedMemory; //downloaded library that facilitates shared memory IPC communication between threads

namespace NetworkApp
{
  //Class to handle each client request separatly
  public class HandleClient
  {
    TcpClient clientSocket;

    Thread ctThread;

    // Declare a delegate used to communicate with the parent thread
    private delegate void UpdateStatusDelegate();

    private UpdateStatusDelegate updateStatusDelegate = null;

    int clNo;

    bool closing { get; set; }

    private bool keepLiving = true;

    List<FileStruct> fileList = new List<FileStruct>(); //List of files in the client directory.

    List<FileStruct> serverFileList = new List<FileStruct>(); //List of files from server.

    List<ClientInfo> clientsList = new List<ClientInfo>();//List of connected clients from server.

    List<ClientInfo> serverClientsList = new List<ClientInfo>();//Server Master list of connected clients

    //Adds file to file list.
    private void AddFileToList(string name, string desc, int id, int oid)
    {
      FileStruct fs = new FileStruct(name, desc, id, oid);
      fileList.Add(fs);
    }

    //Removes file from file list.
    private void RemoveFileFromList(string name)
  {
      int index = 0;
      for (int i = 0; i < fileList.Count(); i++)
      {
        if (fileList[i].GetFileName() == name)
        {
          index = i;
        }
      }
      fileList.RemoveAt(index);
    }

    //Serializes client file list for sending to server.
    private void SerializeClientList()
    {
       Serializer.Save("FileList.bin", fileList);
    }

    //Deserializes server file list.
    private void DeserializeServerList(string listName)
    {
      serverFileList = Serializer.Load<List<FileStruct>>(listName);
    }

    public void StartClient(TcpClient inClientSocket, int clineNo)
    {
      closing = true;
      this.updateStatusDelegate = new UpdateStatusDelegate(this.UpdateStatus);
      this.clientSocket = inClientSocket;
      this.clNo = clineNo;
      ctThread = new Thread(DoChat);
      ctThread.Start();
    }

    private void UpdateStatus()
    {
      closing = true;
    }

    private void DoChat()
    {
      NetworkStream networkStream;

      byte[] bytesFrom = new byte[8192];
      Byte[] sendBytes = null;
      string serverResponse = null;

      networkStream = clientSocket.GetStream();

      bool msgToSend = true;  
                        
      while (keepLiving)
      {
        byte[] cmd = new byte[40];

        serverResponse = "Connection Established" + DateTime.Now.ToString(); //Set Value of first message to send to client
         
        if(networkStream.CanRead)
        {
          string fileString = "";
          while (networkStream.DataAvailable)
          {
            BinaryReader reader = new BinaryReader(networkStream);
            fileString = reader.ReadString();
            Console.WriteLine(fileString);

            if(fileString[0] == '#')
            {
              string[] encodedFiles = fileString.Split('#');
              int i = 0;
              foreach (string s in encodedFiles)
              {
                if(i > 0)
                {
                  FileStruct f = new FileStruct(s);
                  fileList.Add(f);
                }
                i++;
              }
              DeserializeServerList("server.bin");

              foreach (FileStruct f in fileList)
              {
                bool existsInServer = false;
                foreach (FileStruct onServ in serverFileList)
                {

                  if ((f.GetID() == onServ.GetID()) && (f.GetOwner() == onServ.GetOwner()))
                  {
                    existsInServer = true;
                  }
                }
                if (!existsInServer)
                {
                  serverFileList.Add(f);
                  Console.WriteLine("Adding: "+ f.ToString() + " to server fileList");
                }
              }
              Serializer.Save("server.bin", serverFileList);
            } else if(fileString[0] == '!')
            {
              Console.WriteLine("Client info recieved: " + fileString);
              string[] encodedClients = fileString.Split('!');
              int i = 0;
              foreach (string s in encodedClients)
              {
                if (i > 0)
                {
                  ClientInfo c = new ClientInfo(s);
                  clientsList.Add(c);
                }
                i++;
              }
              DeserializeClientsList("clients.bin");

              foreach (ClientInfo c in clientsList)
              {
                bool existsInServer = false;
                foreach (ClientInfo onServ in serverClientsList)
                {

                  if ((c.clientID == onServ.clientID))
                  {
                    existsInServer = true;
                  }
                }
                if (!existsInServer)
                {
                  serverClientsList.Add(c);
                  Console.WriteLine("Adding: " + c.ToString() + " to server serverClientsList");
                }
              }
              Serializer.Save("clients.bin", serverClientsList);
            }
            else
            {
              serverResponse = "To Client: Server Recived cmd: [" + fileString + "]";
              msgToSend = true;
            }
          }
          networkStream.Flush();
        }
        if (msgToSend)
        {
          try
          {
            /*Code handles sending messages to client*/
            serverResponse = "id"+clNo+"From server to client ( " + clNo + " ): " + serverResponse;
            sendBytes = Encoding.ASCII.GetBytes(serverResponse);
            if (networkStream.CanWrite)
            {
                networkStream.Write(sendBytes, 0, sendBytes.Length);
            }
            else
            {
                Console.WriteLine("Client Handler #" + clNo + " can't write");
            }
            if (!keepLiving)
            {
              clientSocket.Close(); //close socket
              networkStream.Close();//close data stream (allows for garbage collection)
            }
          }
          catch (Exception ex)
          {
            clientSocket.Close();
            networkStream.Close();
          }
          msgToSend = false; //set to false so message is only sent once.
        }
      }
      this.ctThread.Abort();
    }

    private void DeserializeClientsList(string listName)
    {
      serverClientsList = Serializer.Load<List<ClientInfo>>(listName);   
    }
  }//End of class
}//End of NameSpace
