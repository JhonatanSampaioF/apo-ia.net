using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apo_ia.net.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly ILocalApplicationService _localApplicationService;
        public LocalController(ILocalApplicationService localApplicationService)
        {
            _localApplicationService = localApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os locals", Description = "Este endpoint retorna uma lista completa de todos os locals cadastrados.")]
        [Produces(typeof(IEnumerable<LocalEntity>))]
        public IActionResult Get()
        {
            try
            {
                var locals = _localApplicationService.ObterTodosLocals();

                if (locals is null)
                    return NoContent();

                return Ok(locals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um local específico", Description = "Este endpoint retorna os detalhes de um local específico com base no ID fornecido.")]
        [SwaggerResponse(200, "Local encontrado com sucesso", typeof(LocalEntity))]
        [SwaggerResponse(204, "Local não encontrado")]
        [SwaggerResponse(404, "Falha para obter o local")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var local = _localApplicationService.ObterLocalporId(id);

                if (local is null)
                    return NoContent();

                return Ok(local);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo local", Description = "Este endpoint cria um novo local com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Local criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o local")]
        [Produces(typeof(LocalEntity))]
        public IActionResult Post([FromBody] LocalDto entity)
        {
            try
            {
                var local = _localApplicationService.SalvarDadosLocal(entity);

                return Ok(local);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um local existente", Description = "Este endpoint atualiza as informações de um local com base no ID fornecido.")]
        [SwaggerResponse(200, "Local atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o local")]
        [Produces(typeof(LocalEntity))]
        public IActionResult Put(int id, [FromBody] LocalDto entity)
        {
            try
            {
                var local = _localApplicationService.EditarDadosLocal(id, entity);

                return Ok(local);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um local existente", Description = "Este endpoint remove as informações de um local com base no ID fornecido.")]
        [SwaggerResponse(200, "Local removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o local")]
        [Produces(typeof(LocalEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var local = _localApplicationService.DeletarDadosLocal(id);

                return Ok(local);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
