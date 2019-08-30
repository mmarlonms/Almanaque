using Acerto.MarvelHeros.Almanaque.Md5;
using Xunit;

namespace Acerto.MarvelHeros.Almanaque.Testes.Infra.Testes
{
    public class Md5EncodeTeste
    {
        private readonly Md5Encode md5Encode;

        public Md5EncodeTeste()
        {
            this.md5Encode = new Md5Encode();
        }

        [Fact]
        public void New_Md5Econde_Suscess()
        {
            int timestamp = 1;
            string privateKey = "asjdiausbd";
            string publicKey = "zasjdhasdaaaa";
            string hashCorreto = "6fbdde614c9de4d6a156ee6029687a97";

            var hash = md5Encode.EncodeHash(timestamp, privateKey, publicKey);

            Assert.Equal(hash, hashCorreto);
        }

        [Fact]
        public void New_Md5Econde_Fail()
        {
            int timestamp = 1;
            string privateKey = "asjdiausbd";
            string publicKey = "zasjdhasdaaaa";
            string hasinvalido = "6fbdde614c9de4d6a156ee6029687a7";

            var hash = md5Encode.EncodeHash(timestamp, privateKey, publicKey);

            Assert.NotEqual(hash, hasinvalido);
        }
    }
}