using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Users.WebApi.Domains;
using Senai.Users.WebApi.Interfaces;
using Senai.Users.WebApi.Repositories;
using Senai.Users.WebApi.ViewModels;

namespace Senai.Users.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUsuarioRepository UsuarioRepository { get; set; }

        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login (LoginViewModel login)
        {
            try
            {
                Usuarios UsuarioBuscado = UsuarioRepository.BuscarPorEmailESenha(login);
                if (UsuarioBuscado == null)
                    return NotFound(new { mensagem = "Oops! O e-mail ou a senha estão errados! Verifique novamente!" });

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, UsuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, UsuarioBuscado.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, UsuarioBuscado.IdPerfilNavigation.Nome.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("usuarios-chave-autenticacao"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer:"Usuarios.WebApi",
                    audience: "Usuarios.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(50),
                    signingCredentials: creds);
                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    isAdmin = UsuarioBuscado.IdPerfil == 1
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Tem algo errado aqui... " + ex.Message });
            }
        }
    }
}