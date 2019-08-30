namespace Acerto.MarvelHeros.Almanaque.GoogleTradutor.Abstractions
{
    public interface IGoogleTradutorAdapter
    {
        /// <summary>
        ///     Traduz um Termo do Portugues para o Ingles
        /// </summary>
        /// <param name="termo"></param>
        /// <returns></returns>
        string TraduzirPtBrToEnUs(string termo);
    }
}