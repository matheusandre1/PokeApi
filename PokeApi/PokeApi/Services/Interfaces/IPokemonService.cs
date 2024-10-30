using PokeApi.Models;
using PokeApi.Responses;

namespace PokeApi.Services.Interfaces
{
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetAllPokemon();
        Task<List<string>> GetAllTypesAsync();        
    }
}
