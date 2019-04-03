using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkApp
{
  public class ClientInfo
  {
    string dnsName { get; set; }
    string ipAddr { get; set; }
    int clientID { get; set; }
    string connType { get; set; }
    int numOfFiles { get; set; }

    public  ClientInfo(int id)
    {
      clientID = id;
    }
  }
}
