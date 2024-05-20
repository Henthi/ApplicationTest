using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ITokenHelper _tokenHelper;

        public AuthController(ITokenHelper tokenHelper)
        {
            this._tokenHelper = tokenHelper;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]LoginDTO loginDTO)
        {

            if (loginDTO.Username == "Admin" && loginDTO.Password == "Admin") {
                string generatedToken = _tokenHelper.GenerateToken(loginDTO.Username);
                return Ok(generatedToken);
            } else
            {
                return BadRequest();
            }


        }

    }
}
