namespace Acerto.MarvelHeros.Almanaque.Dominio.Models
{
    public class HeroiMarvel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Historias Historias { get; set; }
        public Foto Foto { get; set; }
    }

    public class Historias {

        public string QauntidadeDeHistoriasDisponiveis { get; set; }
        public string QauntidadeDeHistoriasRetornadas { get; set; }
        public string UrlColecao { get; set; }
        public Historia[] Items { get; set; }
    }

    public class Historia
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string UrlHistoria { get; set; }
    }

    public class Foto
    {
        public string Caminho { get; set; }
        public string Extensao { get; set; }
    }
}