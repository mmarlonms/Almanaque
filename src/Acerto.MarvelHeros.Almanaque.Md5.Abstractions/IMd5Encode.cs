namespace Acerto.MarvelHeros.Almanaque.Md5.Abstractions
{
    public interface IMd5Encode
    {
        /// <summary>
        ///     Cria um Hash MD5 com base em um timestamp, uma privateKey e uma publicKey
        /// </summary>
        /// <param name="timestamp"></param>
        /// <param name="privateKey"></param>
        /// <param name="publicKey"></param>
        /// <returns></returns>
        string EncodeHash(int timestamp, string privateKey, string publicKey);
    }
}