using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apo_ia.net.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoHabilidadeController : ControllerBase
    {
        private readonly IGrupoHabilidadeApplicationService _grupoHabilidadeApplicationService;
        public GrupoHabilidadeController(IGrupoHabilidadeApplicationService grupoHabilidadeApplicationService)
        {
            _grupoHabilidadeApplicationService = grupoHabilidadeApplicationService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Lista todos os grupoHabilidades", Description = "Este endpoint retorna uma lista completa de todos os grupoHabilidades cadastrados.")]
        [Produces(typeof(IEnumerable<GrupoHabilidadeEntity>))]
        public IActionResult Get()
        {
            try
            {
                var grupoHabilidades = _grupoHabilidadeApplicationService.ObterTodosGrupoHabilidades();

                if (grupoHabilidades is null)
                    return NoContent();

                return Ok(grupoHabilidades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtém um grupoHabilidade específico", Description = "Este endpoint retorna os detalhes de um grupoHabilidade específico com base no ID fornecido.")]
        [SwaggerResponse(200, "GrupoHabilidade encontrado com sucesso", typeof(GrupoHabilidadeEntity))]
        [SwaggerResponse(204, "GrupoHabilidade não encontrado")]
        [SwaggerResponse(404, "Falha para obter o grupoHabilidade")]
        public IActionResult ObterPorId(int id)
        {
            try
            {
                var grupoHabilidade = _grupoHabilidadeApplicationService.ObterGrupoHabilidadeporId(id);

                if (grupoHabilidade is null)
                    return NoContent();

                return Ok(grupoHabilidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo grupoHabilidade", Description = "Este endpoint cria um novo grupoHabilidade com base nas informações fornecidas.")]
        [SwaggerResponse(200, "GrupoHabilidade criado com sucesso")]
        [SwaggerResponse(404, "Falha para inserir o grupoHabilidade")]
        [Produces(typeof(GrupoHabilidadeEntity))]
        public IActionResult Post([FromBody] GrupoHabilidadeDto entity)
        {
            try
            {
                var grupoHabilidade = _grupoHabilidadeApplicationService.SalvarDadosGrupoHabilidade(entity);

                return Ok(grupoHabilidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um grupoHabilidade existente", Description = "Este endpoint atualiza as informações de um grupoHabilidade com base no ID fornecido.")]
        [SwaggerResponse(200, "GrupoHabilidade atualizado com sucesso")]
        [SwaggerResponse(404, "Falha para atualizar o grupoHabilidade")]
        [Produces(typeof(GrupoHabilidadeEntity))]
        public IActionResult Put(int id, [FromBody] GrupoHabilidadeDto entity)
        {
            try
            {
                var grupoHabilidade = _grupoHabilidadeApplicationService.EditarDadosGrupoHabilidade(id, entity);

                return Ok(grupoHabilidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove um grupoHabilidade existente", Description = "Este endpoint remove as informações de um grupoHabilidade com base no ID fornecido.")]
        [SwaggerResponse(200, "GrupoHabilidade removido com sucesso")]
        [SwaggerResponse(404, "Falha para excluir o grupoHabilidade")]
        [Produces(typeof(GrupoHabilidadeEntity))]
        public IActionResult Delete(int id)
        {
            try
            {
                var grupoHabilidade = _grupoHabilidadeApplicationService.DeletarDadosGrupoHabilidade(id);

                return Ok(grupoHabilidade);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
