using Microsoft.AspNetCore.Mvc;
using MotoMarketApi.Dtos;
using MotoMarketApi.Services.Interfaces;

namespace MotoMarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        // GET: api/users
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        // GET: api/users/{id}
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST: api/users
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDto)
        {
            _userService.Create(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = userDto.Id }, userDto);
        }

        // PUT: api/users/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto userDto)
        {
            var existing = _userService.GetById(id);
            if (existing == null) return NotFound();
            _userService.Update(id, userDto);
            return NoContent();
        }

        // DELETE: api/users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var existing = _userService.GetById(id);
            if (existing == null) return NotFound();
            _userService.Delete(id);
            return NoContent();
        }

    }
}
