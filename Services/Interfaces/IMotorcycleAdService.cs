using MotoMarketApi.Dtos;

namespace MotoMarketApi.Services.Interfaces
{
    public interface IMotorcycleAdService
    {
        List<MotorcycleAdDto> GetAll();
        MotorcycleAdDto? GetById(int id);
        void Create(MotorcycleAdDto motorcycleAd);
        void Update(int id, MotorcycleAdDto motorcycleAd);
        void Delete(int id);
    }
}
