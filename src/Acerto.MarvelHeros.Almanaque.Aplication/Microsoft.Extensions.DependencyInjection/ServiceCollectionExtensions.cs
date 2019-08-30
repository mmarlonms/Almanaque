using Acerto.MarvelHeros.Almanaque.Aplication;
using Acerto.MarvelHeros.Almanaque.Dominio.Aplication;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAlmanaque(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IAlmanaque, Almanaque>();

            return services;
        }
    }
}