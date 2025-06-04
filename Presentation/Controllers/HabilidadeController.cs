using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apo_ia.net.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadeController : ControllerBase
    {
        private readonly IHabilidadeApplicationService _habilidadeApplicationService;
        public HabilidadeController(IHabilidadeApplicationService habilidadeApplicationService)
        {
            _habilidadeApplicationService = habilidadeApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todas as habilidades", Description = "Este endpoint retorna uma lista completa de todas as habilidades cadastradas.")]
        [Produces(typeof(IEnumerable<HabilidadeEntity>))]
        public IActionResult Get()
        {
            try
            {
                var habilidades = _habilidadeApplicationService.ObterTodosHabilidades();

                if (habilidades is null)
                    return NoContent();

                return Ok(habilidades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém uma habilidade específica", Description = "Este endpoint retorna os detalhes de uma habilidade específica com base no ID fornecido.")]
        [SwaggerResponse(200, "Habilidade encontrada com sucesso", typeof(HabilidadeEntity))]
        [SwaggerResponse(204, "Habilidade não encontrada")]
        [SwaggerResponse(404, "Falha para obter a habilidade")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var habilidade = _habilidadeApplicationService.ObterHabilidadeporId(id);

                if (habilidade is null)
                    return NoContent();

                return Ok(habilidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra uma nova habilidade", Description = "Este endpoint cria uma nova habilidade com base nas informações fornecidas.")]
        [SwaggerResponse(200, "Habilidade criada com sucesso")]
        [SwaggerResponse(404, "Falha para inserir a habilidade")]
        [Produces(typeof(HabilidadeEntity))]
        public IActionResult Post([FromBody] HabilidadeDto entity)
        {
            try
            {
                var habilidade = _habilidadeApplicationService.SalvarDadosHabilidade(entity);

                return Ok(habilidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma habilidade existente", Description = "Este endpoint atualiza as informações de uma habilidade com base no ID fornecido.")]
        [SwaggerResponse(200, "Habilidade atualizada com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar a habilidade")]
        [Produces(typeof(HabilidadeEntity))]
        public IActionResult Put(int id, [FromBody] HabilidadeDto entity)
        {
            try
            {
                var habilidade = _habilidadeApplicationService.EditarDadosHabilidade(id, entity);

                return Ok(habilidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove uma habilidade existente", Description = "Este endpoint remove as informações de uma habilidade com base no ID fornecido.")]
        [SwaggerResponse(200, "Habilidade removida com sucesso")]
        [SwaggerResponse(404, "Falha para excluir a habilidade")]
        [Produces(typeof(HabilidadeEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var habilidade = _habilidadeApplicationService.DeletarDadosHabilidade(id);

                return Ok(habilidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
