using PokeApi.Models;

namespace PokeApi.Services.Interfaces
{
    public interface IRegionService
    {
        Task<RegionModel> GetRegionByIdAsync(string idOrName);
        Task<List<Region>> GetAllRegionsAsync();
    }

}
