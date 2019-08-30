using Refit;
using System.Threading.Tasks;

namespace Acerto.MarvelHeros.Almanaque.MarvelApiAdapter.Clients
{
    public interface IMarvelApiClient
    {
        [Get("/v1/public/characters?nameStartsWith={nomeHeroi}&apikey={apiKey}&ts={ts}&hash={hash}")]
        Task<MarvelHeroFull> BuscarHeroiPeloNome(string nomeHeroi, string apiKey, int ts, string hash);
    }
}