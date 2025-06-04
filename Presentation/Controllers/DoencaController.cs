using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apo_ia.net.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoencaController : ControllerBase
    {
        private readonly IDoencaApplicationService _doencaApplicationService;
        public DoencaController(IDoencaApplicationService doencaApplicationService)
        {
            _doencaApplicationService = doencaApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as doencas", Description = "Este endpoint retorna uma lista completa de todas as doencas cadastradas.")]
        [Produces(typeof(IEnumerable<DoencaEntity>))]
        public IActionResult Get()
        {
            try
            {
                var doencas = _doencaApplicationService.ObterTodosDoencas();

                if (doencas is null)
                    return NoContent();

                return Ok(doencas);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma doenca específico", Description = "Este endpoint retorna os detalhes de uma doenca específica com base no ID fornecido.")]
        [SwaggerResponse(200, "Doenca encontrada com sucesso", typeof(DoencaEntity))]
        [SwaggerResponse(204, "Doenca não encontrada")]
        [SwaggerResponse(404, "Falha para obter a doenca")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var doenca = _doencaApplicationService.ObterDoencaporId(id);

                if (doenca is null)
                    return NoContent();

                return Ok(doenca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova doenca", Description = "Este endpoint cria uma nova doenca com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Doenca criada com sucesso")]
        [SwaggerResponse(404, "Falha para inserir a doenca")]
        [Produces(typeof(DoencaEntity))]
        public IActionResult Post([FromBody] DoencaDto entity)
        {
            try
            {
                var doenca = _doencaApplicationService.SalvarDadosDoenca(entity);

                return Ok(doenca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma doenca existente", Description = "Este endpoint atualiza as informações de uma doenca com base no ID fornecido.")]
        [SwaggerResponse(200, "Doenca atualizada com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar a doenca")]
        [Produces(typeof(DoencaEntity))]
        public IActionResult Put(int id, [FromBody] DoencaDto entity)
        {
            try
            {
                var doenca = _doencaApplicationService.EditarDadosDoenca(id, entity);

                return Ok(doenca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove uma doenca existente", Description = "Este endpoint remove as informações de uma doenca com base no ID fornecido.")]
        [SwaggerResponse(200, "Doenca removida com sucesso")]
        [SwaggerResponse(404, "Falha para excluir a doenca")]
        [Produces(typeof(DoencaEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var doenca = _doencaApplicationService.DeletarDadosDoenca(id);

                return Ok(doenca);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
