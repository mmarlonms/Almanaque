using Acerto.MarvelHeros.Almanaque.Dominio.Aplication;
using Acerto.MarvelHeros.Almanaque.Dominio.Adapters;
using Acerto.MarvelHeros.Almanaque.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acerto.MarvelHeros.Almanaque.Aplication
{
    public class Almanaque : IAlmanaque
    {
        private readonly IMarvelApiAdapter marvelApiAdapter;

        public Almanaque(IMarvelApiAdapter marvelApiAdapter)
        {
            this.marvelApiAdapter = marvelApiAdapter;
        }

        public async Task<ICollection<HeroiMarvel>> BuscarHeroiPeloNome(string nome)
        {
            return await marvelApiAdapter.BuscarHeroiAsync(nome.Replace(' ', '-'));
        }
    }
}
