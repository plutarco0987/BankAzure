using APIAzure.Data;
using APIAzure.Data.BankModels;
using APIAzure.DTO;
using APIAzure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIAzure.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _service;
        private IConfiguration config;
        public LoginController(LoginService loginService,IConfiguration config)
        {
            this._service = loginService;
            this.config = config;
        }

        [HttpPost("auth")]
        public async Task<IActionResult> Login(AdminDto adminDto)
        {
            var admin = await _service.GetAdministrator(adminDto);

            if (admin is null)
                return BadRequest();

            //Generate token
            string jwtToken = GenerateToken(admin);
            return Ok(new { token = jwtToken });
        }

        private string GenerateToken(Administrator administrator)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,administrator.Name),
                new Claim(ClaimTypes.Email,administrator.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds
                                );
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
       
    }
}