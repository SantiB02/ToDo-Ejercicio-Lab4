using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo_Ejercicio_Lab4.Data.Entities;
using ToDo_Ejercicio_Lab4.Data.Models;
using ToDo_Ejercicio_Lab4.Services.Interfaces;

namespace ToDo_Ejercicio_Lab4.Controllers
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

        [HttpGet("{email}")]
        public IActionResult GetUserByEmail([FromRoute]string email)
        {
            User? user = _userService.GetUserByEmail(email);
            if (user != null)
            {
                return Ok(user);
            } else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateUser(UserCreateDto userCreateDto)
        {
            User user = new User()
            {
                Name = userCreateDto.Name,
                Email = userCreateDto.Email,
                Address = userCreateDto.Address,
            };
            int id = _userService.CreateUser(user);
            return Ok(user);
        }

        [HttpPut("{email}")]
        public IActionResult UpdateUser([FromRoute] string email, [FromBody] UserUpdateDto userUpdateDto)
        {
            User? user = _userService.GetUserByEmail(email);
            if ( user != null )
            {
                user.Name = userUpdateDto.Name;
                user.Address = userUpdateDto.Address;
                _userService.UpdateUser(user);
                return Ok();
            } else
            {
                return NotFound();
            }
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser([FromRoute] int userId)
        {
            _userService.DeleteUser(userId);
            return Ok();
            
        }
    }
}
