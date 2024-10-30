using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokeApi.Models
{
    public class RegionModel : BaseEntity
    {
        
        public int Id { get; set; }

        public string Name { get; set; }        
        public List<Location> Locations { get; set; } = new List<Location>();


        [JsonPropertyName("main_generation")]
        public Generation MainGeneration { get; set; } = new Generation();
        public List<RegionName> Names { get; set; } = new List<RegionName>();
        public List<Pokedex> Pokedexes { get; set; } = new List<Pokedex>();


        [JsonPropertyName("version_groups")]
        public List<VersionGroup> VersionGroups { get; set; } = new List<VersionGroup>();
    }
}
