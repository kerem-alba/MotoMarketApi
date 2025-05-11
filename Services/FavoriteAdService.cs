using AutoMapper;
using MotoMarketApi.Data;
using MotoMarketApi.Dtos;
using MotoMarketApi.Entities;
using MotoMarketApi.Services.Interfaces;

namespace MotoMarketApi.Services
{
    public class FavoriteAdService : IFavoriteAdService
    {
        private readonly MotoMarketDbContext _context;
        private readonly IMapper _mapper;

        public FavoriteAdService(MotoMarketDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<FavoriteAdDto> GetAllByUserId(int userId)
        {
            return _mapper.Map<List<FavoriteAdDto>>(_context.FavoriteAds.Where(f => f.UserId == userId));
        }
        public void Add(FavoriteAdDto favoriteAdDto)
        {
            var favoriteAd = _mapper.Map<FavoriteAd>(favoriteAdDto);
            _context.FavoriteAds.Add(favoriteAd);
            _context.SaveChanges();

            favoriteAdDto.Id = favoriteAd.Id;

        }

        public void Remove(int userId, int motorcycleAdId)
        {
            var existing = _context.FavoriteAds
                .FirstOrDefault(f => f.UserId == userId && f.MotorcycleAdId == motorcycleAdId);
            if (existing != null)
            {
                _context.FavoriteAds.Remove(existing);
                _context.SaveChanges();
            }
        }
    }
}
