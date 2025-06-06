using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Services;
using apo_ia.net.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace apo_ia.net.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly RecommendationService _recommendationService;
        private readonly IVoluntarioApplicationService _voluntarioApplicationService;

        public RecommendationController(RecommendationService recommendationService, IVoluntarioApplicationService voluntarioApplicationService)
        {
            _recommendationService = recommendationService;
            _voluntarioApplicationService = voluntarioApplicationService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Responde perguntas sobre alocação", Description = "Recebe uma pergunta em texto e responde com base nos dados dos voluntários e suas habilidades.")]
        [SwaggerResponse(200, "Resposta gerada com sucesso", typeof(RecommendationResponseDto))]
        public IActionResult Post([FromBody] RecommendationRequestDto request)
        {
            try
            {
                var voluntarios = _voluntarioApplicationService.ObterTodosVoluntarios()?.ToList();

                if (voluntarios == null || !voluntarios.Any())
                    return Ok(new RecommendationResponseDto { Resposta = "Não há voluntários cadastrados no sistema." });

                var resposta = _recommendationService.ResponderPergunta(request.Pergunta, voluntarios);

                return Ok(new RecommendationResponseDto { Resposta = resposta });
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao gerar recomendação: {ex.Message}");
            }
        }
    }
}
