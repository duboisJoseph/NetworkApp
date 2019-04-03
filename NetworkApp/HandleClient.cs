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
 * TODO: This class currently is able to recive data from the main server thread but can't send data to the main server thread. 
 * 
 * 
 */

using System;
using System.Collections.Generic;
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

      int requestCount = 0;
      byte[] bytesFrom = new byte[8192];
      string dataFromClient = null;
      Byte[] sendBytes = null;
      string serverResponse = null;
      requestCount = 0;
      networkStream = clientSocket.GetStream();

      
      bool msgToSend = true;  
      int cmdCt = -1; 
                      
      using (var consumer = new SharedMemory.SharedArray<byte>("ParentToChildCmdArray"))
      {
        while (keepLiving)
        {
          byte[] cmd = new byte[40];
          int i = 0;

          serverResponse = "Connection Established" + DateTime.Now.ToString(); //Set Value of first message to send to client

          foreach (byte b in consumer)
          {
            cmd[i] = b;
            i++;
          };

          if ((cmd[0] == '!') && (cmd[1] > cmdCt)) //if is a command and not the previous command
          {
            cmdCt = cmd[1]; //adjust cmdCt counter so that this child thread only executes the cmd once.
            msgToSend = true; //send a new message to the client

            string msg = System.Text.Encoding.ASCII.GetString(cmd, 2, (i - 2)); //extract cmd into a string

            if (msg == "stop") //if we have recieved a stop command
            {
              serverResponse = "Server shutting down...";
              keepLiving = false;
            }
            else
            {
              serverResponse = " .beat. ";//;
            }
          }

          if (msgToSend)
          {
            try
            {
              /*Code handles sending messages to client*/
              serverResponse = "From server to client ( " + clNo + " ): " + serverResponse;
              sendBytes = Encoding.ASCII.GetBytes(serverResponse);
              if (networkStream.CanWrite)
              {
                 networkStream.Write(sendBytes, 0, sendBytes.Length);
              }
              else
              {
                 Console.WriteLine("Client Handler #" + clNo + " can't write");
              }//networkStream.Flush();


              //networkStream.Close();
              if (!keepLiving)
              {
                clientSocket.Close(); //close socket
                networkStream.Close();//close data stream (allows for garbage collection)
              }
            }
            catch (Exception ex)
            {
              Console.WriteLine(" >> " + ex.ToString());
              clientSocket.Close();
              networkStream.Close();
            }
            msgToSend = false; //set to false so message is only sent once.
          }
        }
      }
      this.ctThread.Abort();
    }
  }//End of class
}//End of NameSpace
