namespace Homework_4.SaveLoad.Scripts.Encrypt
{
    public class Encryptor : IEncryptor
    {
        const byte Secret = 183;

        public byte[] Encrypt(byte[] data)
        {
            EncryptDecryptBytes(data);
            return data;
        }

        public byte[] Decrypt(byte[] data)
        {
            EncryptDecryptBytes(data);
            return data;
        }
        
        void EncryptDecryptBytes(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
                buffer[i] = (byte)(buffer[i] ^ Secret);
        }
    }
}