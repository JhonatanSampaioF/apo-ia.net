using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apo_ia.net.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AbrigadoController : ControllerBase
    {
        private readonly IAbrigadoApplicationService _abrigadoApplicationService;
        public AbrigadoController(IAbrigadoApplicationService abrigadoApplicationService)
        {
            _abrigadoApplicationService = abrigadoApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os abrigados", Description = "Este endpoint retorna uma lista completa de todos os abrigados cadastrados.")]
        [Produces(typeof(IEnumerable<AbrigadoEntity>))]
        public IActionResult Get()
        {
            try
            {
                var abrigados = _abrigadoApplicationService.ObterTodosAbrigados();

                if (abrigados is null)
                    return NoContent();

                return Ok(abrigados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um abrigado específico", Description = "Este endpoint retorna os detalhes de um abrigado específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Abrigado encontrado com sucesso", typeof(AbrigadoEntity))]
        [SwaggerResponse(204, "Abrigado não encontrado")]
        [SwaggerResponse(404, "Falha para obter o abrigado")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var abrigado = _abrigadoApplicationService.ObterAbrigadoporId(id);

                if (abrigado is null)
                    return NoContent();

                return Ok(abrigado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo abrigado", Description = "Este endpoint cria um novo abrigado com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Abrigado criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o abrigado")]
        [Produces(typeof(AbrigadoEntity))]
        public IActionResult Post([FromBody] AbrigadoDto entity)
        {
            try
            {
                var abrigado = _abrigadoApplicationService.SalvarDadosAbrigado(entity);

                return Ok(abrigado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um abrigado existente", Description = "Este endpoint atualiza as informações de um abrigado com base no ID fornecido.")]
        [SwaggerResponse(200, "Abrigado atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o abrigado")]
        [Produces(typeof(AbrigadoEntity))]
        public IActionResult Put(int id, [FromBody] AbrigadoDto entity)
        {
            try
            {
                var abrigado = _abrigadoApplicationService.EditarDadosAbrigado(id, entity);

                return Ok(abrigado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um abrigado existente", Description = "Este endpoint remove as informações de um abrigado com base no ID fornecido.")]
        [SwaggerResponse(200, "Abrigado removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o abrigado")]
        [Produces(typeof(AbrigadoEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var abrigado = _abrigadoApplicationService.DeletarDadosAbrigado(id);

                return Ok(abrigado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
