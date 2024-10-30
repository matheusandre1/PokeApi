using PokeApi.Models;
using PokeApi.Responses;
using PokeApi.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokeApi.Services
{
    public class RegionService : IRegionService
    {
        private readonly HttpClient _httpClient;        

        public RegionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RegionModel> GetRegionByIdAsync(string idOrName)
        {
            var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/region/{idOrName}");

            response.EnsureSuccessStatusCode();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true, // Ignorar diferença entre maiúsculas e minúsculas
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            };

            var jsonResponse = await response.Content.ReadAsStringAsync();
            var region = JsonSerializer.Deserialize<RegionModel>(jsonResponse, options);

            return region;
        }

        public async Task<List<Region>> GetAllRegionsAsync()
        {
            var response = await _httpClient.GetAsync("https://pokeapi.co/api/v2/region");

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var regionListResponse = JsonSerializer.Deserialize<RegionResponse>(jsonResponse, options);

            return regionListResponse?.Results ?? new List<Region>();
        }
    }
}
