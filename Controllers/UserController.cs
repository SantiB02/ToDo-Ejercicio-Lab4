using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo_Ejercicio_Lab4.Data.Entities;
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

        [HttpGet]
        public IActionResult GetUserByEmail(string email)
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
    }
}
