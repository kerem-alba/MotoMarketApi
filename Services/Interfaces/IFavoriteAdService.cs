using MotoMarketApi.Dtos;

namespace MotoMarketApi.Services.Interfaces
{
    public interface IFavoriteAdService
    {
        List<FavoriteAdDto> GetAllByUserId(int userId);
        void Add(FavoriteAdDto favoriteAdDto);
        void Remove(int userId, int motorcycleAdId);
    }
}
