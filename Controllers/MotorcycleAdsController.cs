using Microsoft.AspNetCore.Mvc;
using MotoMarketApi.Dtos;
using MotoMarketApi.Services.Interfaces;

namespace MotoMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorcycleAdsController : ControllerBase
    {
        private readonly IMotorcycleAdService _adService;

        public MotorcycleAdsController(IMotorcycleAdService adService)
        {
            _adService = adService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var ads = _adService.GetAll();
            return Ok(ads);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ad = _adService.GetById(id);
            if (ad == null) return NotFound();
            return Ok(ad);
        }

        [HttpPost]
        public IActionResult Create([FromBody] MotorcycleAdDto adDto)
        {
            _adService.Create(adDto);
            return CreatedAtAction(nameof(GetById), new { id = adDto.Id }, adDto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MotorcycleAdDto adDto)
        {
            var existing = _adService.GetById(id);
            if (existing == null) return NotFound();
            _adService.Update(id, adDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _adService.GetById(id);
            if (existing == null) return NotFound();
            _adService.Delete(id);
            return NoContent();
        }
    }
}
