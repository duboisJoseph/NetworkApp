using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace NetworkApp
{
    class Client
    {
        TCPConnection tcpConnection = new TCPConnection();
        ClientInfo clientInfo;
        List<FileStruct> localFileList = new List<FileStruct>();

        //Constructor
        public Client()
        {

        }

        //Connect Client to server
        public Boolean connectToServer(string ip, string portNum)
        {
            Boolean connected = tcpConnection.connectToServer(ip, portNum);
            if (connected)
            {
                tcpConnection.getStream();
            }
            return connected;
        }

        //Returns client ID
        public int getCID()
        {
            return clientInfo.clientID; 
        }

        //sets connection type
        public void setConnectionType(string type)
        {
            clientInfo.connType = type;
        }

        //returns connection type
        public string getConnectionType()
        {
            return clientInfo.connType;
        }

        //sets host ID
        public void setHostIP(string ip)
        {
            clientInfo.ipAddr = ip;
        }

        //sets port number
        public void setPort(string port)
        {
            Int32 portNum; //Port number

            if (Int32.TryParse(port, out portNum)) //if able to parse field entry into a portNum continue
            {
                clientInfo.portNum = portNum;
            }
        }

        //returns boolean on if stream can be read
        public Boolean canRead()
        {
            return tcpConnection.canRead();
        }

        //returns booleon on if data is available on stream
        public Boolean dataAvailable()
        {
            return tcpConnection.dataAvailable();
        }

        //gets response message from connecting to server
        //also gets assigned client ID from server
        public string getResponse()
        {
            tcpConnection.readBytes();
            clientInfo = new ClientInfo(tcpConnection.getCID());
            return tcpConnection.getResponse();

        }

        //Adds files to list list.
        public void addFileToList(FileStruct file)
        {
            //Adds file to list if list is empty.
            if (localFileList.Count == 0)
            {
                localFileList.Add(file);
            }
            else
            {
                //Makes sure duplicate files are not added.
                Boolean dupe = false;
                for (int i = 0; i < localFileList.Count; i++)
                {
                    if (localFileList[i].Equals(file))
                    {
                        dupe = true;
                    }
                }

                if (!dupe)
                {
                    localFileList.Add(file);
                }
            }
        }

        //sends file list to server
        public void sendFileListToServer()
        {
            //Post File Data to Server
            string fileString = "";

            foreach (FileStruct f in localFileList)
            {
                fileString += f.ToString(); //uses overridden toString function
            }
            tcpConnection.writeToServer(fileString);
        }

        //sends client information to server
        public void sendClientInfoToServer()
        {
            string clientInfoString = "";
            clientInfoString += clientInfo.ToString();
            tcpConnection.writeToServer(clientInfoString);
        }

        //client listening to other client
        public void startListening()
        {
            tcpConnection.startListening(clientInfo.ipAddr, clientInfo.portNum);
        }
    }
}
