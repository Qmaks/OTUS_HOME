using Sirenix.Serialization;

namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem.Serializer
{
    public class Serializer : ISerializer
    {
        public byte[] Serialize(object obj)
        {
            return SerializationUtility.SerializeValue(obj, DataFormat.Binary);
        }

        public T Deserialize<T>(byte[] buffer)
        {
            return SerializationUtility.DeserializeValue<T>(buffer, DataFormat.Binary);
        }
    }
}