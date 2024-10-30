namespace PokeApi.Models
{
    public class RegionName 
    {
        public string Name { get; set; }
        public Language Language { get; set; } = new Language();
    }
}
