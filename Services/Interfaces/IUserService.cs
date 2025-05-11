using MotoMarketApi.Dtos;

namespace MotoMarketApi.Services.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetAll();
        UserDto? GetById(int id);
        void Create(UserDto user);
        void Update(int id, UserDto user);
        void Delete(int id);
    }
}
