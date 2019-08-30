using Acerto.MarvelHeros.Almanaque.MarvelApiAdapter;
using AutoMapper;

namespace Acerto.MarvelHeros.Almanaque.Testes
{
    public class TesteStartup
    {
        public TesteStartup()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<MarvelApiAdapterConfigurationAutoMapperProfile>();
            });
        }
    }
}