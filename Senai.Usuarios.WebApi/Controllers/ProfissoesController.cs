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
    public class ProfissoesController : ControllerBase
    {
        public IProfissaoRepository ProfissaoRepository { get; set; }

        public ProfissoesController()
        {
            ProfissaoRepository = new ProfissaoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ProfissaoRepository.Listar());
        }

        [Authorize]
        [HttpGet ("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Profissoes profissao = ProfissaoRepository.BuscarPorId(id);
                if (profissao == null)
                    return NotFound();
                return Ok(profissao);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Algo está errado aqui... " + ex.Message });
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Profissoes profissao)
        {
            try
            {
                ProfissaoRepository.Cadastrar(profissao);
                return Ok(profissao);

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Algo está errado aqui... " + ex.Message });
            }
        }

        [Authorize]
        [HttpPut]
        public IActionResult Atualizar(int id, Profissoes profissao)
        {
            try
            {
                Profissoes profissaoBuscada = ProfissaoRepository.BuscarPorId(id);
                if (profissaoBuscada == null)
                    return NotFound();

                profissao.IdProfissao = profissaoBuscada.IdProfissao;
                ProfissaoRepository.Atualizar(profissao);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Algo está errado aqui... " + ex.Message });
            }
        }

        [Authorize]
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                ProfissaoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Algo está errado aqui... " + ex.Message });
            }
        }
    }
}