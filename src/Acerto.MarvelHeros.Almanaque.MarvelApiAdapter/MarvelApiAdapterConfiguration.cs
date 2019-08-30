using System.ComponentModel.DataAnnotations;

namespace Acerto.MarvelHeros.Almanaque.MarvelApiAdapter
{
    public class MarvelApiAdapterConfiguration
    {
        [Required]
        public string AppKey { get; set; }
        [Required]
        public string PrivateKey { get; set; }
        [Required]
        public string UrlBase { get; set; }
        [Required]
        public int TimeStampDefault { get; set; }
    }
}