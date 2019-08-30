using Acerto.MarvelHeros.Almanaque.Dominio.Models;
using Acerto.MarvelHeros.Almanaque.MarvelApiAdapter.Clients;
using AutoMapper;
using System.Collections.Generic;

namespace Acerto.MarvelHeros.Almanaque.MarvelApiAdapter
{
    public class MarvelApiAdapterConfigurationAutoMapperProfile : Profile
    {
        public MarvelApiAdapterConfigurationAutoMapperProfile()
        {
            CreateMap<Thumbnail, Foto>()
                .ForMember(source => source.Caminho, destination => destination.MapFrom(map => map.Path))
                .ForMember(source => source.Extensao, destination => destination.MapFrom(map => map.Extension));

            CreateMap<StoriesItem, Historia>()
                .ForMember(source => source.UrlHistoria, destination => destination.MapFrom(map => map.ResourceUri))
                .ForMember(source => source.Nome, destination => destination.MapFrom(map => map.Name))
                .ForMember(source => source.Tipo, destination => destination.MapFrom(map => map.Type));

            CreateMap<Stories, Historias>()
              .ForMember(source => source.QauntidadeDeHistoriasDisponiveis, destination => destination.MapFrom(map => map.Available))
              .ForMember(source => source.QauntidadeDeHistoriasRetornadas, destination => destination.MapFrom(map => map.Returned))
              .ForMember(source => source.UrlColecao, destination => destination.MapFrom(map => map.CollectionUri))
              .ForMember(source => source.Items, destination => destination.MapFrom(map => map.Items));

            CreateMap<MarvelHeroFull, IEnumerable<HeroiMarvel>>().ConvertUsing<HeroConverter>();
        }
    }

    class HeroConverter : ITypeConverter<MarvelHeroFull, IEnumerable<HeroiMarvel>>
    {
        public IEnumerable<HeroiMarvel> Convert(MarvelHeroFull source, IEnumerable<HeroiMarvel> destination, ResolutionContext context)
        {
            List<HeroiMarvel> herois = new List<HeroiMarvel>();

            foreach (var dto in source.Data.Results)
            {
                herois.Add(new HeroiMarvel() {
                    Id = dto.Id,
                    Nome = dto.Name,
                    Descricao = dto.Description,
                    Foto = Mapper.Map<Thumbnail, Foto>(dto.Thumbnail),
                    Historias = Mapper.Map<Stories,Historias>(dto.Stories)               
                });
            }

            return herois;
        }
    }
}