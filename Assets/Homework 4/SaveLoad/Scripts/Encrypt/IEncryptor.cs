namespace Homework_4.SaveLoad.Scripts.Encrypt
{
    public interface IEncryptor
    {
        public byte[] Encrypt(byte[] data);
        public byte[] Decrypt(byte[] data);
    }
}