namespace apo_ia.net.Application.Dtos
{
    public class RecommendationRequestDto
    {
        public string Pergunta { get; set; } = string.Empty;
    }

    public class RecommendationResponseDto
    {
        public string Resposta { get; set; } = string.Empty;
    }
}
