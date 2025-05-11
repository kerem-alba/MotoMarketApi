using AutoMapper;
using MotoMarketApi.Data;
using MotoMarketApi.Dtos;
using MotoMarketApi.Entities;
using MotoMarketApi.Entities.Enums;
using MotoMarketApi.Services.Interfaces;

namespace MotoMarketApi.Services
{
    public class MotorcycleAdService : IMotorcycleAdService
    {
        private readonly MotoMarketDbContext _context;
        private readonly IMapper _mapper;

        public MotorcycleAdService(MotoMarketDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MotorcycleAdDto> GetAll()
        {
            return _mapper.Map<List<MotorcycleAdDto>>(_context.MotorcycleAds.Where(a => !a.IsDeleted));
        }

        public MotorcycleAdDto? GetById(int id)
        {
            return _mapper.Map<MotorcycleAdDto>(_context.MotorcycleAds.FirstOrDefault(a => a.Id == id && !a.IsDeleted));
        }

        public void Create(MotorcycleAdDto motorcycleAdDto)
        {
            _context.MotorcycleAds.Add(_mapper.Map<MotorcycleAd>(motorcycleAdDto));
            _context.SaveChanges();
        }

        public void Update(int id, MotorcycleAdDto motorcycleAdDto)
        {
            var adToUpdate = _context.MotorcycleAds.FirstOrDefault(a => a.Id == id && !a.IsDeleted);
            if (adToUpdate == null) return;

            adToUpdate.Title = motorcycleAdDto.Title;
            adToUpdate.Description = motorcycleAdDto.Description;
            adToUpdate.Price = motorcycleAdDto.Price;
            adToUpdate.Year = motorcycleAdDto.Year;
            adToUpdate.Mileage = motorcycleAdDto.Mileage;
            adToUpdate.City = (City)motorcycleAdDto.City;
            adToUpdate.Status = (AdStatus)motorcycleAdDto.Status;
            adToUpdate.ModelId = motorcycleAdDto.ModelId;
            adToUpdate.CategoryId = motorcycleAdDto.CategoryId;
        }

        public void Delete(int id)
        {
            var ad = _context.MotorcycleAds.FirstOrDefault(a => a.Id == id);
            if (ad != null)
                ad.IsDeleted = true;
            _context.SaveChanges();
        }
    }
}
