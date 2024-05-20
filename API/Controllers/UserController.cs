using Microsoft.AspNetCore.Mvc;
using BLL.DTO;
using BLL.Services;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    // Called made on api/endpoint
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IUserMessageService _userMessageQueue;

        public UserController(IUserService userService, IUserMessageService userMessageQueue)
        {
            _userService = userService;
            _userMessageQueue = userMessageQueue;
        }

        [HttpPost("addUser")]
        public IActionResult AddUser([FromBody] UserDTO newUser)
        {
            _userMessageQueue.PutAddUser(newUser);
            return NoContent();

        }

        [HttpPut("editUser")]
        public IActionResult EditUser([FromBody] UserDTO updatedUser)
        {
            _userMessageQueue.PutUpdateUser(updatedUser);
            return NoContent();

        }

        [HttpPost("deleteUser")]
        public IActionResult DeleteUser([FromBody] UserDTO removedUser)
        {
            _userMessageQueue.PutDeleteUser(removedUser);
            return NoContent();

        }

        [HttpGet("getUsers")]
        public IActionResult GetUsers(int pageNumber, int pageSize)
        {
            var users = _userService.GetUsers(pageNumber, pageSize);
            return Ok(users);
            
        }

        [HttpGet("getUserById")]
        public IActionResult GetUsers([FromBody] int userId)
        {
            var user = _userService.GetUsers(userId);
            return Ok(user);
            
        }

    }

}
