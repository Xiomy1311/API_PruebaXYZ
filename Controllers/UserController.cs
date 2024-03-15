using API_Usuarios_XYZ.Entities;
using API_Usuarios_XYZ.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Text;

namespace API_Usuarios_XYZ.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class UserController : ControllerBase
    {

        private readonly IRepUsers _repUsers;
        private readonly IConfiguration _config;

        public UserController(IRepUsers repUsers, IConfiguration config)
        {
            _repUsers = repUsers;
            _config = config;
        }

      

        [HttpPost]
        public IActionResult Login(ModUsers modUsers)
        {

            bool user = _repUsers.GetUserByUserName(modUsers.UserName, modUsers.Password);



            if (user)
            {

                Claim[] claims = new[]
                 {
                   new Claim(JwtRegisteredClaimNames.Sub,_config["Jwt:Subject"]),
                   new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                   new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                   new Claim("userName",modUsers.UserName)
                };

                SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                SigningCredentials signIn = new(key, SecurityAlgorithms.HmacSha256);
                JwtSecurityToken token = new(
                    _config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: signIn
                    );

                return Ok(new JwtSecurityTokenHandler().WriteToken(token));

            }

            else {
                return BadRequest("Usuario o contraseña incorrecta");
                    }

           

        }
    }
}
