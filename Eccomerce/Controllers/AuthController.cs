using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Eccomerce.DTOs;
using Eccomerce.Models;
using Eccomerce.Repo;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Eccomerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitWork _UNIT;
        private IConfiguration _configration;
        private IMapper _mapepr;
        public AuthController(IUnitWork uNIT, IConfiguration configration,IMapper mapper)
        {
            _UNIT = uNIT;
            _configration = configration;
            _mapepr = mapper;
        }
        private string GenerateToken(User user)
        {
            var cliams = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Name,user.FullName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configration["Jwt:Key"]!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenObject = new JwtSecurityToken
                (
                issuer: _configration["Jwt:Issuer"],
                audience: _configration["Jwt:Audience"],
                claims: cliams,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(tokenObject);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var user = await _UNIT.Auth.GetByEmail(dto.Email);
            if (user == null || user.Password != dto.Password)
            {
                return Unauthorized("Invalid email or password");
            }
            var result = GenerateToken(user);
            return Ok(result);
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegistrationDTO dto)
        {
            var existEmail = await _UNIT.Auth.GetByEmail(dto.Email);
            if (existEmail != null)
            {
                return BadRequest("Email already exists");
            }
            if (dto.Role != "Customer" && dto.Role != "Admin")
            {
                return BadRequest("Role must be either 'Customer' or 'Admin'");
            }
            var user=_mapepr.Map<User>(dto);
           
            await _UNIT.Auth.Add(user);
            _UNIT.Save();
            return Ok("User registered successfully");
        }
    }
}
