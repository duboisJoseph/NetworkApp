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
    class TCPConnection
    {
        TcpClient server; //TCP Information for client to server.
        TcpClient client; //TCP Information for client to client.
        NetworkStream ns; //Data stream stores messages sent to/from client and server sockets
        NetworkStream p2p; //Data stream stores messages sent to/from client and server sockets
        byte[] bytes = new byte[1024]; //array of bytes
        int bytesRead; //number of bytes read
        int serverGivenID = -1;
        private Socket listener;
        public Socket Handler;

        //Constructor
        public TCPConnection()
        {

        }

        public Boolean connectToServer(string ip, string portNum)
        {
            Boolean connected = false;
            Int32 port; //Port Number
            Int32.TryParse(portNum, out port);

            server = new TcpClient(ip, port);

            return connected;
        }

        //Get Network Stream.
        public void getStream()
        {
            ns = server.GetStream();
        }

        //Returns boolean for if network stream can be read.
        public Boolean canRead()
        {
            return ns.CanRead;
        }

        //Returns boolean for if data is available on the network stream.
        public Boolean dataAvailable()
        {
            return ns.DataAvailable;
        }

        //Reads bytes from stream.
        public void readBytes()
        {
            bytesRead = ns.Read(bytes, 0, bytes.Length); //read bytes from data stream
        }

        //Gets the CID from the bytes read.
        public int getCID()
        {
            return int.Parse(Encoding.ASCII.GetString(bytes, 2, 1));
        }

        //Gets the response message from the bytes read.
        public string getResponse()
        {
            return Encoding.ASCII.GetString(bytes, 3, bytesRead); //convert bytes to string
        }

        //Writes string to server.
        public void writeToServer(string str)
        {
            BinaryWriter writer = new BinaryWriter(ns);
            writer.Write(str);
        }

        //Listening method.
        public void startListening(string hostIP, Int32 hostPort)
        {

        }
    }

}
