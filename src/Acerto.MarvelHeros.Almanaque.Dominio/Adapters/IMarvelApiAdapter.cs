using Acerto.MarvelHeros.Almanaque.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acerto.MarvelHeros.Almanaque.Dominio.Adapters
{
    public interface IMarvelApiAdapter
    {
        /// <summary>
        ///     Busca um Heroi no Respositório da Marvel
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        /// <exception cref="HeroiNaoEncontradoException"></exception>
        Task<ICollection<HeroiMarvel>> BuscarHeroiAsync(string nome);
    }
}