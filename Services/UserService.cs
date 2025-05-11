using AutoMapper;
using MotoMarketApi.Data;
using MotoMarketApi.Dtos;
using MotoMarketApi.Entities;
using MotoMarketApi.Services.Interfaces;

namespace MotoMarketApi.Services
{
    public class UserService : IUserService
    {
        private readonly MotoMarketDbContext _context;
        private readonly IMapper _mapper;
        public UserService(MotoMarketDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public List<UserDto> GetAll()
        {
            return _mapper.Map<List<UserDto>>(_context.Users.Where(u => !u.IsDeleted));
        }

        public UserDto? GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id && !u.IsDeleted);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }
        public void Create(UserDto userDto)
        {
            var newUser = _mapper.Map<User>(userDto);

            newUser.PasswordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
            _context.Users.Add(newUser);
            _context.SaveChanges();

            userDto.Id = newUser.Id;

        }

        public void Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id && !u.IsDeleted);
            if (user != null)
                user.IsDeleted = true;
            _context.SaveChanges();
        }


        public void Update(int id, UserDto userDto)
        {
            var userToUpdate = _context.Users.FirstOrDefault(u => u.Id == id && !u.IsDeleted);
            if (userToUpdate != null)
            {
                userToUpdate.Name = userDto.Name;
                userToUpdate.Email = userDto.Email;
                userToUpdate.Role = userDto.Role;

                _context.SaveChanges();


            }
        }
    }
}