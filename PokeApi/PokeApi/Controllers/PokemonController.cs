using Microsoft.AspNetCore.Mvc;
using PokeApi.Services;
using PokeApi.Services.Interfaces;

namespace PokeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("getPokemons")]
        public async Task<IActionResult> GetAllPokemon()
        {
            var pokemons = await _pokemonService.GetAllPokemon();

            return Ok(pokemons);
        }

        [HttpGet("types")]

        public async Task<IActionResult> GetTypes()
        {
            var type = await _pokemonService.GetAllTypesAsync();

            return Ok(type);
        }
    }
}
