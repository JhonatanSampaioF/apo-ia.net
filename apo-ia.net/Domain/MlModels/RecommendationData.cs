namespace apo_ia.net.Domain.MlModels
{
    public class RecommendationData
    {
        public string VoluntarioId { get; set; }
        public string Habilidade { get; set; }
        public string SetorDesejado { get; set; } // Exemplo: "cozinha", "enfermaria"
        public bool AlocadoComSucesso { get; set; } // rótulo: 1 para alocado, 0 para não
    }
}
