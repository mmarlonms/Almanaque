using Acerto.MarvelHeros.Almanaque.Dominio.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acerto.MarvelHeros.Almanaque.Dominio.Aplication
{
    public interface IAlmanaque
    {
        /// <summary>
        ///  Obtem as informações dos Herois da Marvel cujo nome tenha correspondencia com o nome informado. 
        ///   O nome deve estar de acordo com o nome do personagem no Brasil, Ex: Homen Aranha, Homem de Ferro
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        Task<ICollection<HeroiMarvel>> BuscarHeroiPeloNome(string nome);
    }
}