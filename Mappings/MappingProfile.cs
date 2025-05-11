using AutoMapper;
using MotoMarketApi.Dtos;
using MotoMarketApi.Entities;

namespace MotoMarketApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<MotorcycleAd, MotorcycleAdDto>().ReverseMap();
            CreateMap<FavoriteAd, FavoriteAdDto>().ReverseMap();
        }
    }
}
