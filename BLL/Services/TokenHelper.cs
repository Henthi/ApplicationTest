using BLL.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BLL.Services
{
    public class TokenHelper: ITokenHelper
    {
        private readonly IConfiguration _configuration;

        public TokenHelper(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string GenerateToken(string userName)
        {
            var section = _configuration.GetSection("JWT:Secret");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(section.Value!));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity("Token");
            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userName));

            var tokenOptions = new JwtSecurityToken(
                claims: claimsIdentity.Claims,
                issuer: "*",
                audience: "*",
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return tokenString;
        }
    }
}