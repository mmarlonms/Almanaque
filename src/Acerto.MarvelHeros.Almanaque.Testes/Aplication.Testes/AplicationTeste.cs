using Acerto.MarvelHeros.Almanaque.Dominio.Adapters;
using Acerto.MarvelHeros.Almanaque.Dominio.Models;
using Acerto.MarvelHeros.Almanaque.GoogleTradutor.Abstractions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Acerto.MarvelHeros.Almanaque.Testes.Infra.Testes
{
    public class AplicationTeste
    {
        #region [+] Variáveis Corretas
        public string id = "1009664";
        public string nome = "Thor";
        public string descricao = "As the Norse God of thunder and lightning, Thor wields one of the greatest weapons ever made, the enchanted hammer Mjolnir. While others have described Thor as an over-muscled, oafish imbecile, he's quite smart and compassionate.  He's self-assured, and he would never, ever stop fighting for a worthwhile cause.";
        public string qauntidadeDeHistoriasDisponiveis = "2562";
        public string qauntidadeDeHistoriasRetornadas = "20";
        public string urlColecao = "http://gateway.marvel.com/v1/public/characters/1009664/stories";
        public string nome_historia = "THOR (1998) #76";
        public string tipo = "cover";
        public string urlHistoria = "http://gateway.marvel.com/v1/public/stories/876";
        public string caminho = "http://i.annihil.us/u/prod/marvel/i/mg/d/d0/5269657a74350";
        public string extensao = "jpg";
        #endregion

        #region Variaveis Zuadas
        public string zuado_id = "100164";
        public string zuado_nome = "Thora";
        public string zuado_descricao = "Qualquer coisa";
        public string zuado_qauntidadeDeHistoriasDisponiveis = "22";
        public string zuado_qauntidadeDeHistoriasRetornadas = "254";
        public string zuado_urlColecao = "http://gateway.marvel.com/v1/public/characters/1009664/stories";
        public string zuado_nome_historia = "THOR (1998) #76";
        public string zuado_tipo = "cover";
        public string zuado_urlHistoria = "http://gateway.marvel.com/v1/public/stories/876";
        public string zuado_caminho = "http://i.annihil.us/u/prod/marvel/i/mg/d/d0/5269657a74350";
        public string zuado_extensao = "mpg";
        #endregion

        #region Variaveis Zuadas
        int Teste_Id = 1;
        string Teste_Nome = "Hero de Teste";
        string Teste_Descricao = "Hero criado para testar";
        int Teste_QauntidadeDeHistoriasDisponiveis = 100;
        int Teste_QauntidadeDeHistoriasRetornadas = 10;
        string Teste_UrlColecao = "https://Url.Teste.com.br";
        string Teste_NomeHistoria = "Historia de Teste";
        string Teste_Tipo = "Tipo de teste";
        string Teste_UrlHistoria = "https://Url.Teste.com.br/h";
        string Teste_Caminho = "https://Url.Teste.com.br/image";
        string Teste_Extensao = ".jpg";
        #endregion

        #region Testes com Mock
        private Mock<IMarvelApiAdapter> Test_BuscarHeroitAsync_Success_Mocks()
        {
            var mockMarvelApiAdapter = new Mock<IMarvelApiAdapter>();
            mockMarvelApiAdapter.Setup(x => x.BuscarHeroiAsync(It.IsAny<string>()))
                .ReturnsAsync(new List<HeroiMarvel>()
                {
                    new HeroiMarvel()
                    {
                        Id = Teste_Id,
                        Nome = Teste_Nome,
                        Descricao = Teste_Descricao,
                        Foto = new Foto()
                        {
                            Caminho = Teste_Caminho,
                            Extensao = Teste_Extensao
                        },
                        Historias = new Historias(){
                            QauntidadeDeHistoriasDisponiveis =  Teste_QauntidadeDeHistoriasDisponiveis.ToString(),
                            QauntidadeDeHistoriasRetornadas = Teste_QauntidadeDeHistoriasRetornadas.ToString(),
                            UrlColecao = Teste_UrlColecao,
                            Items = new List<Historia>()
                            {
                                new Historia(){
                                     Nome = Teste_NomeHistoria,
                                     Tipo = Teste_Tipo,
                                     UrlHistoria= Teste_UrlHistoria
                                }
                            }.ToArray()
                        }
                    }
                });

            return mockMarvelApiAdapter;
        }

  
        [Fact]
        private async Task Test_BuscarHeroitAsync_Success_PtBr()
        {
            var adapterMarvel = Test_BuscarHeroitAsync_Success_Mocks().Object;
            var aplication = new Aplication.Almanaque(adapterMarvel);

            var result = await aplication.BuscarHeroiPeloNome(Teste_Nome);

            Assert.Equal(Teste_Nome, result.First().Nome);
        }

        [Fact]
        private async Task Test_BuscarHeroitAsync_Success_EnUs()
        {
            var adapterMarvel = Test_BuscarHeroitAsync_Success_Mocks().Object;
            
            var aplication = new Aplication.Almanaque(adapterMarvel);

            var result = await aplication.BuscarHeroiPeloNome(Teste_Nome);

            Assert.Equal(Teste_Nome, result.First().Nome);
        }
        #endregion
    }
}