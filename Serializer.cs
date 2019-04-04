using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
/** 
 * Found this serializer class in 
 * https://stackoverflow.com/questions/5005900/how-to-serialize-listt.
 * */
namespace NetworkApp
{
  public static class Serializer
  {
    //Serializes an object using binary serialization and saves it as a .bin file.
    public static void Save(string filePath, object objToSerialize)
    {
      try
      {
        using (Stream stream = File.Open(filePath, FileMode.Create))
        {
          BinaryFormatter bin = new BinaryFormatter();
          bin.Serialize(stream, objToSerialize);
        }
      }
      catch (IOException)
      {
      }
    }

    //Takes a .bin file and deserializes it into an object. 
    //Returns the deserialized object.
    public static T Load<T>(string filePath) where T : new()
    {
      T rez = new T();

      try
      {
        using (Stream stream = File.Open(filePath, FileMode.Open))
        {
          BinaryFormatter bin = new BinaryFormatter();
          rez = (T)bin.Deserialize(stream);
        }
      }
      catch (IOException)
      {
      }

      return rez;
    }
  }
}
