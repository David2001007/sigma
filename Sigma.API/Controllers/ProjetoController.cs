using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Dtos;
using Sigma.Application.Interfaces;
using Sigma.Domain.Dtos;
using Sigma.Domain.Enums;

namespace Sigma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpPost]
        [Route("inserir")]
        public async Task<IActionResult> Inserir([FromBody] ProjetoNovoDto model)
        {
            return new JsonResult(await _projetoService.Inserir(model));
        }

        [HttpGet]
        [Route("listar")]
        public async Task<IActionResult> Listar()
        {
            var resultado = await _projetoService.Listar();
            return Ok(resultado);
        }

        [HttpDelete]
        [Route("excluir/{id}")]
        public async Task<IActionResult> Excluir(long id)
        {
            try
            {
                await _projetoService.Excluir(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { mensagem = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Alterar(long id, [FromBody] ProjetoEditarDto dto)
        {
            await _projetoService.Alterar(id, dto);
            return NoContent();
        }

        [HttpGet("filtro")]
        public async Task<IActionResult> ConsultarPorFiltro([FromQuery] string? nome, [FromQuery] StatusProjeto? status)
        {
            var projetos = await _projetoService.ConsultarPorFiltro(nome, status);
            return Ok(projetos);
        }


    }
}
