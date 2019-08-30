using Acerto.MarvelHeros.Almanaque.GoogleTradutor.Abstractions;
using Acerto.MarvelHeros.Almanaque.GoogleTradutorAdapter;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddGoogleTradutorAdapter(this IServiceCollection services, GoogleTradutorAdapterConfiguration googleTradutorAdapterConfiguration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton(googleTradutorAdapterConfiguration ?? throw new ArgumentNullException(nameof(googleTradutorAdapterConfiguration)));

            services.AddSingleton<IGoogleTradutorAdapter, GoogleTradutorAdapter>();

            return services;
        }
    }
}