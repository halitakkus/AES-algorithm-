using Application.Packages.Hashing.Core.Service;

namespace Application.Packages.Encryption.Core.Service
{
    /// <summary>
    /// Çekirdek bir Encryption servisi oluşturuldu. İnterface Segregation
    /// </summary>
    public interface IEncryptionService : IHashService
    {
        /// <summary>
        ///  Deşifrelemek için:
        /// </summary>
        /// <param name="plainText">Plain text for hashing.</param>
        /// <returns></returns>
        string Decryption(string encryptedText, string key);

        /// <summary>
        /// String olarak verilen veriyi, bize şifreleyip byte dizisi olarak döner.
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV);


        /// <summary>
        /// Byte olarak verilen diziyi bize deşifreleme işlemi uygulayıp sonucu string olarak döner.
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="Key"></param>
        /// <param name="IV"></param>
        /// <returns></returns>
        string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV);
    }
}
