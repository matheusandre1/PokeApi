using Microsoft.AspNetCore.Mvc;
using PokeApi.Services.Interfaces;

namespace PokeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRegion([FromQuery]string idOrName)
        {
            var region = await _regionService.GetRegionByIdAsync(idOrName);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        [HttpGet("getPokemons")]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await _regionService.GetAllRegionsAsync();

            return Ok(regions);
        }

    }
}
