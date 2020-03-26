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
    public class HabilidadesController : ControllerBase
    {
        public IHabilidadeRepository HabilidadeRepository { get; set; }

        public HabilidadesController()
        {
            HabilidadeRepository = new HabilidadeRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(HabilidadeRepository.Listar());
        }

        [HttpGet("id")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Habilidades habilidade = HabilidadeRepository.BuscarPorId(id);
                if (habilidade == null)
                    return NotFound();
                return Ok(habilidade);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Tem algo errado aqui... " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Habilidades habilidade)
        {
            try
            {
                HabilidadeRepository.Cadastrar(habilidade);
                return Ok(habilidade);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Tem algo errado aqui... " + ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Habilidades habilidade)
        {
            try
            {
                Habilidades habilidadeBuscada = HabilidadeRepository.BuscarPorId(id);
                if (habilidadeBuscada == null)
                    return NotFound();

                habilidade.IdHabilidade = habilidadeBuscada.IdHabilidade;
                HabilidadeRepository.Atualizar(habilidade);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Tem algo errado aqui... " + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                HabilidadeRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Oops! Tem algo errado aqui... " + ex.Message });
            }
        }
    }
}
