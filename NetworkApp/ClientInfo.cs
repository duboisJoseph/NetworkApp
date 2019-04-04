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

    public ClientInfo(string encoded)
    {
      string[] duo = encoded.Split('|');
      int i = 0;
      foreach (string part in duo)
      {
        if (i > 0)
        {
          string[] seed = part.Split(':');
          switch (seed[0])
          {
            case "dnsName":
              dnsName = seed[1];
              break;
            case "ipAddr":
              ipAddr = seed[1];
              break;
            case "clientID":
              clientID = int.Parse(seed[1]);
              break;
            case "connType":
              connType = seed[1];
              break;
            case "numOfFiles":
              numOfFiles = int.Parse(seed[1]);
              break;
            case "portNum":
              portNum = int.Parse(seed[1]);
              break;
            default:
              clientID = -1;
              dnsName = "null";
              ipAddr = "null";
              connType = "null";
              numOfFiles = -1;
              portNum = -1;
              break;
          }
        }
        i++;
      }
    }

    public override string ToString()
    {
      string craftedString = "#";

      craftedString += "|dnsName:" + dnsName + "";
      craftedString += "|ipAddr:" + ipAddr + "";
      craftedString += "|clientID:" + clientID + "";
      craftedString += "|connType:" + connType + "";
      craftedString += "|numOfFiles:" + numOfFiles + "";
      craftedString += "|portNum:" + portNum + "";

      craftedString += "";

      return craftedString;
    }
  }
}
