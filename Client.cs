/**
* This class is the general layout for a
* client connecting to another client and
* a client connecting to a server
* 
* @author Joe Dubois, Alec Allain, Christain Ye, Anthony Nguyen
* @version 3/31/19
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using SharedMemory;
using System.Timers;
//using System.Windows.Forms;

namespace NetworkApp {
    public class Client {
        FtpWebRequest ftpRequest;
        FtpWebResponse ftpResponse;
        string hostIP;
        string username;
        string portNumber;
        List<fileStruct> fileList = new List<fileStruct>();
        List<fileStruct> clientFileList = new List<fileStruct>();
        List<ClientInfo> clientList = new List<ClientInfo>();
        SharedArray<byte> producer;

        /* Constructor */
        public Client(string host, string user, string port) {
            hostIP = host;
            username = user;
            portNumber = port;
        }

        /*
        * Method allows client to check if a file is avaliable
        * in other clients directory and put it into their own directory
        *
        * @param fileName is name of the file requested
        * @param source is the other client's IP address
        * @param destination is current clients IP address
        */
        public void download(string fileName, string source, string destination) {
            
        }
    }
}