using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apo_ia.net.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoluntarioController : ControllerBase
    {
        private readonly IVoluntarioApplicationService _voluntarioApplicationService;
        public VoluntarioController(IVoluntarioApplicationService voluntarioApplicationService)
        {
            _voluntarioApplicationService = voluntarioApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os voluntarios", Description = "Este endpoint retorna uma lista completa de todos os voluntarios cadastrados.")]
        [Produces(typeof(IEnumerable<VoluntarioEntity>))]
        public IActionResult Get()
        {
            try
            {
                var voluntarios = _voluntarioApplicationService.ObterTodosVoluntarios();

                if (voluntarios is null)
                    return NoContent();

                return Ok(voluntarios);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um voluntario específico", Description = "Este endpoint retorna os detalhes de um voluntario específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Voluntario encontrado com sucesso", typeof(VoluntarioEntity))]
        [SwaggerResponse(204, "Voluntario não encontrado")]
        [SwaggerResponse(404, "Falha para obter o voluntario")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var voluntario = _voluntarioApplicationService.ObterVoluntarioporId(id);

                if (voluntario is null)
                    return NoContent();

                return Ok(voluntario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo voluntario", Description = "Este endpoint cria um novo voluntario com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Voluntario criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o voluntario")]
        [Produces(typeof(VoluntarioEntity))]
        public IActionResult Post([FromBody] VoluntarioDto entity)
        {
            try
            {
                var voluntario = _voluntarioApplicationService.SalvarDadosVoluntario(entity);

                return Ok(voluntario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um voluntario existente", Description = "Este endpoint atualiza as informações de um voluntario com base no ID fornecido.")]
        [SwaggerResponse(200, "Voluntario atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o voluntario")]
        [Produces(typeof(VoluntarioEntity))]
        public IActionResult Put(int id, [FromBody] VoluntarioDto entity)
        {
            try
            {
                var voluntario = _voluntarioApplicationService.EditarDadosVoluntario(id, entity);

                return Ok(voluntario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um voluntario existente", Description = "Este endpoint remove as informações de um voluntario com base no ID fornecido.")]
        [SwaggerResponse(200, "Voluntario removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o voluntario")]
        [Produces(typeof(VoluntarioEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var voluntario = _voluntarioApplicationService.DeletarDadosVoluntario(id);

                return Ok(voluntario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
