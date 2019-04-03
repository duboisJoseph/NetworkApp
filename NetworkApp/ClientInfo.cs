using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp
{
  [Serializable]
  public class ClientInfo
  {
    public string dnsName {  get; set; }
    public string ipAddr { get; set; }
    public int clientID { get; set; }
    public string connType { get; set; }
    public int numOfFiles { get; set; }
    public int portNum { get; set; }

    public  ClientInfo(int id)
    {
      clientID = id;
      dnsName = "null";
      ipAddr = "null";
      connType = "null";
      numOfFiles = -1;
      portNum = -1;
    }
  }
}
