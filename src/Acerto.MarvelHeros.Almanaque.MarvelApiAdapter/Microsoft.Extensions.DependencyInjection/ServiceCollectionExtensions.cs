using Acerto.MarvelHeros.Almanaque.Dominio.Adapters;
using Acerto.MarvelHeros.Almanaque.MarvelApiAdapter;
using Acerto.MarvelHeros.Almanaque.MarvelApiAdapter.Clients;
using Refit;
using System;
using System.Net.Http;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMarvelApiAdapter(this IServiceCollection services, MarvelApiAdapterConfiguration marvelApiAdapterConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(marvelApiAdapterConfiguration ?? throw new ArgumentNullException(nameof(marvelApiAdapterConfiguration)));

            services.AddTransient(serviceProvider =>
            {
                var httpClient = new HttpClient()
                {
                    BaseAddress = new Uri(marvelApiAdapterConfiguration.UrlBase)
                };

                return RestService.For<IMarvelApiClient>(httpClient);
            });

            services.AddSingleton<IMarvelApiAdapter, MarvelApiHeroAdapter>();

            return services;
        }
    }
}