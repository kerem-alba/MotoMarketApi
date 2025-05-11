using Microsoft.AspNetCore.Mvc;
using MotoMarketApi.Dtos;
using MotoMarketApi.Services.Interfaces;

namespace MotoMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteAdsController : ControllerBase
    {
        private readonly IFavoriteAdService _favoriteService;

        public FavoriteAdsController(IFavoriteAdService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetFavoritesByUser(int userId)
        {
            var favorites = _favoriteService.GetAllByUserId(userId);
            return Ok(favorites);
        }

        [HttpPost]
        public IActionResult AddFavorite([FromBody] FavoriteAdDto favoriteAd)
        {
            _favoriteService.Add(favoriteAd);
            return Ok();
        }

        [HttpDelete]
        public IActionResult RemoveFavorite([FromQuery] int userId, [FromQuery] int motorcycleAdId)
        {
            _favoriteService.Remove(userId, motorcycleAdId);
            return NoContent();
        }
    }
}
