using PokeApi.Models;
using System.Text.Json.Serialization;

namespace PokeApi.Responses
{
    public class RegionResponse
    {
        [JsonPropertyName("results")]
        public List<Region> Results { get; set; }
    }
}
