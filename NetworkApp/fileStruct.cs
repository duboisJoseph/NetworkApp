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

    private void SetFileDesc(string desc)
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