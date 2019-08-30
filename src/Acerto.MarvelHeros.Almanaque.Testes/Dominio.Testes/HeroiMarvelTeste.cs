using Acerto.MarvelHeros.Almanaque.Dominio.Models;
using System;
using Xunit;

namespace Acerto.MarvelHeros.Almanaque.Testes.Dominio.Testes
{
    public class HeroiMarvelTeste 
    {
        [Fact]
        public void New_Heroi_Sucess()
        {
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

            var heroi = new HeroiMarvel()
            {
                Id = Teste_Id,
                Nome = Teste_Nome,
                Descricao = Teste_Descricao,
                Foto = new Foto() {
                    Caminho = Teste_Caminho,
                    Extensao = Teste_Extensao
                }

            };

            Historia[] Teste_itens = new Historia[Teste_QauntidadeDeHistoriasRetornadas];

            for (int i = 0; i < Teste_QauntidadeDeHistoriasRetornadas; i++)
            {
                Teste_itens[i] = new Historia()
                {
                    Nome = Teste_NomeHistoria,
                    Tipo = Teste_Tipo,
                    UrlHistoria = Teste_UrlHistoria
                };
            }

            heroi.Historias = new Historias() {
                QauntidadeDeHistoriasDisponiveis = Teste_QauntidadeDeHistoriasDisponiveis.ToString(),
                QauntidadeDeHistoriasRetornadas = Teste_QauntidadeDeHistoriasRetornadas.ToString(),
                UrlColecao = Teste_UrlColecao,
                Items = Teste_itens
            };

            Assert.Equal(heroi.Id, Teste_Id);
            Assert.Equal(heroi.Nome, Teste_Nome);
            Assert.Equal(heroi.Descricao, Teste_Descricao);
            Assert.Equal(heroi.Foto.Caminho, Teste_Caminho);
            Assert.Equal(heroi.Foto.Extensao, Teste_Extensao);

            Assert.Equal(heroi.Historias.Items.Length ,Teste_QauntidadeDeHistoriasRetornadas);
            Assert.True(Convert.ToInt32(heroi.Historias.QauntidadeDeHistoriasRetornadas) <= Convert.ToInt32(heroi.Historias.QauntidadeDeHistoriasDisponiveis));

        }

        [Fact]
        public void New_Heroi_Fail()
        {
            int Teste_Id = 1;
            string Teste_Nome = "Hero de Teste";
            string Teste_Descricao = "Hero criado para testar";
            int Teste_QauntidadeDeHistoriasDisponiveis = 100;
            int Teste_QauntidadeDeHistoriasRetornadas = 101;
            string Teste_UrlColecao = "https://Url.Teste.com.br";
            string Teste_NomeHistoria = "Historia de Teste";
            string Teste_Tipo = "Tipo de teste";
            string Teste_UrlHistoria = "https://Url.Teste.com.br/h";
            string Teste_Caminho = "https://Url.Teste.com.br/image";
            string Teste_Extensao = ".jpg";

            var heroi = new HeroiMarvel()
            {
                Id = Teste_Id,
                Nome = Teste_Nome,
                Descricao = Teste_Descricao,
                Foto = new Foto()
                {
                    Caminho = Teste_Caminho,
                    Extensao = Teste_Extensao
                }
            };

            Historia[] Teste_itens = new Historia[Teste_QauntidadeDeHistoriasRetornadas];

            for (int i = 0; i < Teste_QauntidadeDeHistoriasRetornadas; i++)
            {
                Teste_itens[i] = new Historia()
                {
                    Nome = Teste_NomeHistoria,
                    Tipo = Teste_Tipo,
                    UrlHistoria = Teste_UrlHistoria
                };
            }

            heroi.Historias = new Historias()
            {
                QauntidadeDeHistoriasDisponiveis = Teste_QauntidadeDeHistoriasDisponiveis.ToString(),
                QauntidadeDeHistoriasRetornadas = Teste_QauntidadeDeHistoriasRetornadas.ToString(),
                UrlColecao = Teste_UrlColecao,
                Items = Teste_itens
            };

            Assert.False(Convert.ToInt32(heroi.Historias.QauntidadeDeHistoriasRetornadas) <= Convert.ToInt32(heroi.Historias.QauntidadeDeHistoriasDisponiveis));
        }
    }
}