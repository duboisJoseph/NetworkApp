using System;
using System.Text;


namespace NetworkApp
{

  [Serializable]
  public class FileStruct
  {
    string fileName;
    string fileDesc;
    int fileID;
    int ownerID;

    //Getter and setters
    public string GetFileName()
    {
      return fileName;
    }

    public void SetFileName(string name)
    {
      fileName = name;
    }

    public string GetFileDesc()
    {
       return fileDesc;
    }

    public void SetFileDesc(string desc)
    {
      fileDesc = desc;
    }

    public int GetID()
    {
      return fileID;
    }

    private void SetID(int id)
    {
      fileID = id;
    }

    public int GetOwner()
    {
      return ownerID;
    }

    private void SetOwner(int id)
    {
      ownerID = id;
    }

    public override string  ToString()
    {
      string craftedString = "#";

      craftedString += "|ID:" + GetID()+"";
      craftedString += "|Owner:" + GetOwner()+"";
      craftedString += "|FileName:" + GetFileName()+"";
      craftedString += "|FileDes:" + GetFileDesc()+"";

      craftedString += "";

      return craftedString;
    }

    public FileStruct(string encoded)
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
            case "ID":
              SetID(int.Parse(seed[1]));
              break;
            case "Owner":
              SetOwner(int.Parse(seed[1]));
              break;
            case "FileName":
              SetFileName(seed[1]);
              break;
            case "FileDes":
              SetFileDesc(seed[1]);
              break;
            default:
              SetFileName("null");
              SetFileDesc("null");
              SetID(-1);
              SetOwner(-1);
              break;
          }
        }
        i++;
      }
    }

    //Constructor
    public FileStruct(string name, string desc, int id, int oid)
    {
      SetFileName(name);
      SetFileDesc(desc);
      SetID(id);
      SetOwner(oid);
    }
  }
}