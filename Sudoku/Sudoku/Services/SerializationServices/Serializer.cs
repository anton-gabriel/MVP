using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sudoku.Services.SerializationServices
{
    internal static class Serializer
    {
        #region Public methods
        public static void SerializeObject(string fileName, ISerializable objectToSerialize)
        {
            using (Stream stream = File.Open(fileName, FileMode.Create))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                bFormatter.Serialize(stream, objectToSerialize);
            }
        }

        public static ISerializable DeserializeObject(string fileName)
        {
            ISerializable objectToSerialize;
            using (Stream stream = File.Open(fileName, FileMode.Open))
            {
                BinaryFormatter bFormatter = new BinaryFormatter();
                objectToSerialize = (ISerializable)bFormatter.Deserialize(stream);
            }
            return objectToSerialize;
        }
        #endregion
    }
}
