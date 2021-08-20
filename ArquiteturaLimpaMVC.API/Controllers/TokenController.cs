using ArquiteturaLimpaMVC.API.Models;
using ArquiteturaLimpaMVC.Dominio.Conta;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            _authenticate = authenticate;
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var resultado = await _authenticate.Authenticate(loginModel.Email, loginModel.Senha);

            if (resultado)
            {
                return Ok(GerarToken(loginModel));
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Inválido!");
                return BadRequest(ModelState);
            }
        }

        private UsuarioToken GerarToken(LoginModel loginModel)
        {
            var claims = new[]
            {
                new Claim("email",loginModel.Email),
                new Claim("valor","teste"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var credenciais = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiracao = DateTime.UtcNow.AddMinutes(10);
            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"],
                                             audience: _configuration["Jwt:Audience"],
                                             claims: claims,
                                             expires: expiracao,
                                             signingCredentials: credenciais);
            return new UsuarioToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracao = expiracao
            };
        }
    }
}