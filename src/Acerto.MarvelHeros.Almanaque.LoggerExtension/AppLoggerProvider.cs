using Microsoft.Extensions.Logging;
using System;

namespace Acerto.MarvelHeros.Almanaque.LoggerExtension
{
    public class AppLoggerProvider : ILoggerProvider
    {
        private readonly Func<string, LogLevel, bool> filtro;
        private readonly string connectionString;

        public AppLoggerProvider(Func<string, LogLevel, bool> filtro, string connectionString)
        {
            this.filtro = filtro;
            this.connectionString = connectionString;
        }

        public ILogger CreateLogger(string nomeCategoria)
        {
            return new AppLogger(nomeCategoria, filtro, connectionString);
        }

        public void Dispose()
        {

        }
    }
}