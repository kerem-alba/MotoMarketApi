using Microsoft.AspNetCore.Mvc;
using MotoMarketApi.Entities.Enums;

namespace MotoMarketApi.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

}
