using System;
using System.Text;


namespace NetworkApp
{
    public class fileStruct
    {
        string fileName;
        string fileDesc;
        int fileID;
        int ownerID;

        //Getter and setters
        public string getFileName()
        {
            return fileName;
        }

        private void setFileName(string name)
        {
            fileName = name;
        }

        public string getFileDesc()
        {
            return fileDesc;
        }

        private void setFileDesc(string desc)
        {
            fileDesc = desc;
        }

        public int getID()
        {
            return fileID;
        }

        private void setID(int id)
        {
            fileID = id;
        }

        public int getOwner()
        {
            return ownerID;
        }

        private void setOwner(int id)
        {
            ownerID = id;
        }

        //Constructor
        public fileStruct(string name, string desc, int id, int oid)
        {
            setFileName(name);
            setFileDesc(desc);
            setID(id);
            setOwner(oid);
        }
    }
}