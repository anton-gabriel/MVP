using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sudoku.Services.SerializationServices
{
    internal static class Serializer
    {
        #region Public methods
        //public static void SerializeObject(string fileName, ISerializable objectToSerialize)
        //{
        //    using (Stream stream = File.Open(fileName, FileMode.Create))
        //    {
        //        BinaryFormatter bFormatter = new BinaryFormatter();
        //        bFormatter.Serialize(stream, objectToSerialize);
        //    }
        //}
        //public static ISerializable DeserializeObject(string fileName)
        //{
        //    ISerializable objectToDeserialize;
        //    using (Stream stream = File.Open(fileName, FileMode.Open))
        //    {
        //        BinaryFormatter bFormatter = new BinaryFormatter();
        //        objectToDeserialize = (ISerializable)bFormatter.Deserialize(stream);
        //    }
        //    return objectToDeserialize;
        //}

        public static void SerializeJsonObject(string fileName, object objectToSerialize)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, objectToSerialize);
            }
        }
        public static T DeserializeJsonObject<T>(string fileName)
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
        }
        #endregion
    }
}
