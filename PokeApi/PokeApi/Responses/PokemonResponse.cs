using PokeApi.Models;
using System.Text.Json.Serialization;

namespace PokeApi.Responses
{
    public class PokemonResponse
    {
        [JsonPropertyName("results")]
        public List<Pokemon> Results { get; set; }
    }
}
