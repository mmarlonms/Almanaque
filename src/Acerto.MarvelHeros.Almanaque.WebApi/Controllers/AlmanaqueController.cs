using Acerto.MarvelHeros.Almanaque.Dominio.Adapters;
using Acerto.MarvelHeros.Almanaque.Dominio.Aplication;
using Acerto.MarvelHeros.Almanaque.Dominio.Models;
using Acerto.MarvelHeros.Almanaque.GoogleTradutor.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Acerto.MarvelHeros.Almanaque.WebApi.Controllers
{
    public class AlmanaqueController : Controller
    {
        private readonly IAlmanaque almanaque;
        private readonly IGoogleTradutorAdapter googleTradutorAdapter;

        public AlmanaqueController(IAlmanaque almanaque, IGoogleTradutorAdapter googleTradutorAdapter)
        {
            this.almanaque = almanaque;
            this.googleTradutorAdapter = googleTradutorAdapter;
        }

        /// <summary>
        ///     Obtem as informações dos Herois da Marvel cujo nome tenha correspondencia com o nome informado. 
        ///     O nome deve estar de acordo com o nome do personagem nos EUA, Ex: de "Homen Aranha" para "Spider Man", de "Homem de Ferro" para "Iron Man", etc.
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<HeroiMarvel>), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(Exception), 500)]
        [HttpGet("/BuscarHeroi/{nome}")]
        public async Task<IActionResult> BuscarHeroiEnusAsync([FromRoute][Required] string nome)
        {
            var result = await almanaque.BuscarHeroiPeloNome(nome);
            if (result.Any())
                return Ok(result);
            else
                return NotFound("Não foram encontrados herois com o nome informado na base de dados da Marvel, favor verifique o nome e tente novamente.");
        }

        /// <summary>
        ///     Obtem as informações dos Herois da Marvel cujo nome tenha correspondencia com o nome informado. 
        ///     O nome deve estar de acordo com o nome do personagem no Brasil, Ex: Homen Aranha, Homem de Ferro
        /// </summary>
        /// <remarks> Obs.: O método foi colocado com obsoleto pois prara funcionar é necessário uma conta do google ativa com a funação translate habilitada, como descobri que     o método é pago após a impelmentação, optei por manter como exemplo. </remarks>
        /// <param name="nome"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ICollection<HeroiMarvel>), 200)]
        [ProducesResponseType(typeof(NotFoundResult), 404)]
        [ProducesResponseType(typeof(Exception), 500)]
        [HttpGet("/BuscarHeroi/{nome}/ptBr")]
        [Obsolete]
        public async Task<IActionResult> BuscarHeroiPtBrAsync([FromRoute][Required] string nome)
        {
            var nomeTraduzido = googleTradutorAdapter.TraduzirPtBrToEnUs(nome);

            var result = await almanaque.BuscarHeroiPeloNome(nomeTraduzido);
            if (result.Any())
                return Ok(result);
            else
                return NotFound("Não foram encontrados herois com o nome informado na base de dados da Marvel, favor verifique o nome e tente novamente.");
        }
    }
}