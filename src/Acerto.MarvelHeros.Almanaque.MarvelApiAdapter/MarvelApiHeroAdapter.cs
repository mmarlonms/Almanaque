using Acerto.MarvelHeros.Almanaque.Dominio.Adapters;
using Acerto.MarvelHeros.Almanaque.Dominio.Models;
using Acerto.MarvelHeros.Almanaque.MarvelApiAdapter.Clients;
using Acerto.MarvelHeros.Almanaque.Md5.Abstractions;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acerto.MarvelHeros.Almanaque.MarvelApiAdapter
{
    public class MarvelApiHeroAdapter : IMarvelApiAdapter
    {
        private readonly IMarvelApiClient marvelApiClient;
        private readonly MarvelApiAdapterConfiguration marvelApiAdapterConfiguration;
        private readonly IMd5Encode md5Encode;
        private readonly ILogger<MarvelApiHeroAdapter> log;

        public MarvelApiHeroAdapter(IMarvelApiClient marvelApiClient, MarvelApiAdapterConfiguration marvelApiAdapterConfiguration, IMd5Encode md5Encode, ILogger<MarvelApiHeroAdapter> log)
        {
            this.marvelApiClient = marvelApiClient;
            this.marvelApiAdapterConfiguration = marvelApiAdapterConfiguration;
            this.md5Encode = md5Encode;
            this.log = log;
        }

        public async Task<ICollection<HeroiMarvel>> BuscarHeroiAsync(string nome)
        {
            log.LogInformation("Busca Iniciada em {0} pelo heroi de nome {1}", DateTime.UtcNow, nome);

            try
            {
                var hero = await marvelApiClient.BuscarHeroiPeloNome(nome,marvelApiAdapterConfiguration.AppKey, marvelApiAdapterConfiguration.TimeStampDefault, md5Encode.EncodeHash(marvelApiAdapterConfiguration.TimeStampDefault, marvelApiAdapterConfiguration.PrivateKey, marvelApiAdapterConfiguration.AppKey));
                var heroConverted = Mapper.Map<MarvelHeroFull, List<HeroiMarvel>>(hero);

                log.LogInformation("Busca Realizada com suscesso em {0} pelo heroi de nome {1}", DateTime.UtcNow, nome);
                return heroConverted;
            }
            catch ( Exception  ex )
            {
                log.LogError("Erro \"[{0}]\" ao realizar a buca pelo heroi de nome {1}", ex.Message, nome);
                throw ex; 
            }
        }
    }
}