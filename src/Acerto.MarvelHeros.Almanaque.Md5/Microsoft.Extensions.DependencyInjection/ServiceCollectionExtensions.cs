using Acerto.MarvelHeros.Almanaque.Md5;
using Acerto.MarvelHeros.Almanaque.Md5.Abstractions;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMd5Encode(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddSingleton<IMd5Encode, Md5Encode>();

            return services;
        }
    }
}