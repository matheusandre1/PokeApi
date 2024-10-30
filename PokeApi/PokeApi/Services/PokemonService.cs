using PokeApi.Models;
using PokeApi.Responses;
using PokeApi.Services.Interfaces;
using System.Text.Json;

namespace PokeApi.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;
        
        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        
        public async Task<List<Pokemon>> GetAllPokemon()
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon?limit=100000");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var pokemonResponse = JsonSerializer.Deserialize<PokemonResponse>(jsonResponse, options);

            return pokemonResponse?.Results ?? new List<Pokemon>();
        }

        public async Task<List<string>> GetAllTypesAsync()
        {
            var response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/type");
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var typeResponse = JsonSerializer.Deserialize<TypeResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            
            return typeResponse?.Results.Select(t => t.Name).ToList() ?? new List<string>();
        }
    }
}
