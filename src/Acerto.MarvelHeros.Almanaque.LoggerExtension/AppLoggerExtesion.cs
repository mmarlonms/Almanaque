using Acerto.MarvelHeros.Almanaque.LoggerExtension;
using System;

namespace Microsoft.Extensions.Logging
{
    public static class AppLoggerExtesion
    {
        public static ILoggerFactory AddContext(this ILoggerFactory factory,
           Func<string, LogLevel, bool> filter = null, string connectionString = null)
        {
            factory.AddProvider(new AppLoggerProvider(filter, connectionString));
            return factory;
        }

        public static ILoggerFactory AddContext(this ILoggerFactory factory, LogLevel minLevel, string connectionString)
        {
            return AddContext(factory, (_, logLevel) => logLevel >= minLevel, connectionString);
        }
    }
}