using System;

namespace Acerto.MarvelHeros.Almanaque.LoggerExtension.Model
{
    public class LogHeroi
    {
        public int Id { get; set; }
        public string LogLevel { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}