using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Users.WebApi.Domains;
using Senai.Users.WebApi.Interfaces;
using Senai.Users.WebApi.Repositories;

namespace Senai.Users.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        public IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult BuscarPorId (int id)
        {
            try
            {
                Usuarios usuario = UsuarioRepository.BuscarPorId(id);
                if (usuario == null)
                    return NotFound();
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Algo está errado ..." + ex.Message});
            }
        }

        [HttpPost("CadastrarFuncionario")]
        [Authorize]
        public IActionResult CadastrarFuncionario(Usuarios usuario)
        {
            try
            {
                usuario.IdPerfil = 2;
                UsuarioRepository.Cadastrar(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Algo está errado ..." + ex.Message});
            }
        }

        [HttpPost]
        [Authorize (Roles = "Administrador")]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem =  "Oops! Algo está errado ..." + ex.Message});
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult Atualizar(int id, Usuarios usuario)
        {
            try
            {
                Usuarios UsuarioBuscado = UsuarioRepository.BuscarPorId(id);
                if (UsuarioBuscado == null)
                    return NotFound();

                usuario.IdUsuario = UsuarioBuscado.IdUsuario;
                UsuarioRepository.Atualizar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Algo está errado ..." + ex.Message});
            }
        }

        [HttpDelete]
        [Authorize (Roles = "Administrador")]
        public IActionResult Deletar(int id)
        {
            try
            {
                UsuarioRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Algo está errado ..." + ex.Message});
            }
        }




    }
}