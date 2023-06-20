namespace Homework_4.SaveLoad.Scripts.SaveLoadSystem.Serializer
{
    public interface ISerializer
    {
        byte[] Serialize(object obj);
        T Deserialize<T>(byte[] buffer);
    }
}