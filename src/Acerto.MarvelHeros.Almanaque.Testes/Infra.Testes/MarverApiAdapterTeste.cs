using Acerto.MarvelHeros.Almanaque.Dominio.Adapters;
using Acerto.MarvelHeros.Almanaque.MarvelApiAdapter;
using Acerto.MarvelHeros.Almanaque.MarvelApiAdapter.Clients;
using Acerto.MarvelHeros.Almanaque.Md5.Abstractions;
using Acerto.MarvelHeros.Almanaque.WebApi;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Acerto.MarvelHeros.Almanaque.Testes.Infra.Testes
{


    public class MarverApiAdapterTeste : TesteStartup
    {

        #region [+] Variáveis Corretas
        readonly string nomeHeroi = "Thor";
        readonly int timestamp = 1;
        readonly string privateKey = "asjdiausbd";
        readonly string publicKey = "zasjdhasdaaaa";
        readonly string hashCorreto = "6fbdde614c9de4d6a156ee6029687a97";
        readonly int comics_returned = 20;
        readonly int available = 1666;
        readonly int offset = 0;
        readonly int limit = 20;
        readonly int total = 8;
        readonly int count = 8;
        readonly int data_id = 1009664;
        readonly int code = 200;
        readonly string status = "Ok";
        readonly string copyright = "© 2019 MARVEL";
        readonly string attributionText = "Data provided by Marvel. © 2019 MARVEL";
        readonly string attributionHTML = "<a href=\"http://marvel.com\">Data provided by Marvel. © 2019 MARVEL</a>";
        readonly string etag = "d865b1e5f2f50e4710afa0ab0b850576d1cbe1b0";
        readonly string name = "Thor";
        readonly string description = "As the Norse God of thunder and lightning, Thor wields one of the greatest weapons ever made, the enchanted hammer Mjolnir. While others have described Thor as an over-muscled, oafish imbecile, he's quite smart and compassionate.  He's self-assured, and he would never, ever stop fighting for a worthwhile cause.";
        readonly string modified = "2019-02-06T18:10:24-0500";
        readonly string path = "http://i.annihil.us/u/prod/marvel/i/mg/d/d0/5269657a74350";
        readonly string extension = "jpg";
        readonly string resourceURI = "http://gateway.marvel.com/v1/public/characters/1009664";
        readonly string collectionURI = "http://gateway.marvel.com/v1/public/characters/1009664/comics";
        readonly int comics_available = 1666;
        readonly string comics_collectionURI = "http://gateway.marvel.com/v1/public/characters/1009664/comics";
        readonly string comics_item_resourceURI = "http://gateway.marvel.com/v1/public/comics/43506";
        readonly string comics_item_name = "A+X (2012) #7";
        readonly int stories_available = 2562;
        readonly string stories_collectionURI = "http://gateway.marvel.com/v1/public/characters/1009664/stories";
        readonly string stories_item_resourceURI = "http://gateway.marvel.com/v1/public/stories/876";
        readonly string stories_item_name = "THOR (1998) #76";
        readonly string stories_item_type = "cover";
        #endregion


        #region Variavis Zuadas
        readonly string nomeHeroi_zuado = "Thora";
        #endregion

        #region Testes com Mock

        private Mock<IMarvelApiClient> Mock_IMarvelApiClient_Teste()
        {
            var mockMarvelCliente = new Mock<IMarvelApiClient>();

            mockMarvelCliente
               .Setup(x => x.BuscarHeroiPeloNome(It.Is<string>(i => i != nomeHeroi), It.Is<string>(i => i == publicKey), It.Is<int>(i => i == timestamp), It.Is<string>(i => i == hashCorreto)))
               .ReturnsAsync(new MarvelHeroFull()
               {
                   AttributionHtml = "",
                   AttributionText = "",
                   Code = code.ToString(),
                   Copyright = copyright,
                   Etag = etag,
                   Status = status,
                   Data = new Data()
                   {
                       Count = 0,
                       Limit = 0,
                       Offset = 0,
                       Total = 0,
                       Results = new List<Result>().ToArray()
                   }
               });

            mockMarvelCliente
                 .Setup(x => x.BuscarHeroiPeloNome(It.Is<string>(i => i == nomeHeroi), It.Is<string>(i => i == publicKey), It.Is<int>(i => i == timestamp), It.Is<string>(i => i == hashCorreto)))
                 .ReturnsAsync(new MarvelHeroFull()
                 {
                     AttributionHtml = "",
                     AttributionText = "",
                     Code = code.ToString(),
                     Copyright = copyright,
                     Etag = etag,
                     Status = status,
                     Data = new Data()
                     {
                         Count = count,
                         Limit = limit,
                         Offset = offset,
                         Total = total,
                         Results = new List<Result>()
                         {
                            new Result(){
                                Id = data_id,
                                Description = description,
                                Modified = modified,
                                Name = name,
                                ResourceUri  = resourceURI,
                                Comics = new Comics()
                                {
                                    Available = comics_available,
                                    CollectionUri = comics_collectionURI,
                                    Items = new List<ComicsItem>()
                                    {
                                        new ComicsItem(){
                                            Name = comics_item_name,
                                            ResourceUri = comics_item_resourceURI
                                        }

                                    }.ToArray()
                                },
                                Events = new Events()
                                {

                                },
                                Series = new Series()
                                {

                                },
                                Stories= new Stories()
                                {
                                     Available = stories_available,
                                     CollectionUri = stories_collectionURI,
                                     Items = new List<StoriesItem>()
                                     {
                                         new StoriesItem()
                                         {
                                             Name =  stories_item_name,
                                             ResourceUri = stories_item_resourceURI,
                                             Type = stories_item_type
                                         }
                                     }.ToArray()
                                },
                                Thumbnail = new Thumbnail()
                                {
                                    Path = path,
                                    Extension = extension
                                }
                            }
                         }.ToArray()
                     }
                 });

            return mockMarvelCliente;
        }

        private Mock<IMd5Encode> Mock_IMd5Encode_Teste()
        {
            var mockIMd5Encode = new Mock<IMd5Encode>();

            mockIMd5Encode
                .Setup(x => x.EncodeHash(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(hashCorreto);

            return mockIMd5Encode;
        }

        [Fact]
        public async Task New_Busca_Heroi_SucessAsync()
        {
            var mockMarvelClient = Mock_IMarvelApiClient_Teste().Object;
            var mockIMd5Encode = Mock_IMd5Encode_Teste().Object;
            var mockMarvelConfiguratio = new MarvelApiAdapterConfiguration()
            {
                AppKey = publicKey,
                PrivateKey = privateKey,
                TimeStampDefault = timestamp,
                UrlBase = ""
            };

            var mockLog = new Mock<ILogger<MarvelApiHeroAdapter>>().Object;

            var marvelApiAdapter = new MarvelApiHeroAdapter(mockMarvelClient, mockMarvelConfiguratio, mockIMd5Encode, mockLog);

            var result = await marvelApiAdapter.BuscarHeroiAsync(nomeHeroi);

            Assert.Equal(nomeHeroi, result.First().Nome);
            Assert.Single(result.First().Historias.Items);
        }

        [Fact]
        public async Task New_Busca_Heroi_FailAsync()
        {
            var mockMarvelClient = Mock_IMarvelApiClient_Teste().Object;
            var mockIMd5Encode = Mock_IMd5Encode_Teste().Object;
            var mockMarvelConfiguratio = new MarvelApiAdapterConfiguration()
            {
                AppKey = publicKey,
                PrivateKey = privateKey,
                TimeStampDefault = timestamp,
                UrlBase = ""
            };

            var mockLog = new Mock<ILogger<MarvelApiHeroAdapter>>().Object;

            var marvelApiAdapter = new MarvelApiHeroAdapter(mockMarvelClient, mockMarvelConfiguratio, mockIMd5Encode, mockLog);

            var result = await marvelApiAdapter.BuscarHeroiAsync(nomeHeroi_zuado);

            Assert.Equal(0, result.Count);
        }
        #endregion
    }
}