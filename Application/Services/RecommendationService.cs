using apo_ia.net.Domain.Entities;
using Microsoft.ML.Data;
using Microsoft.ML;
using apo_ia.net.Domain.MlModels;

namespace apo_ia.net.Application.Services
{
    public class RecommendationService
    {
        public string ResponderPergunta(string pergunta, List<VoluntarioEntity> voluntarios)
        {
            pergunta = pergunta.ToLower();

            if (pergunta.Contains("cozinha"))
                return ListarVoluntariosComHabilidade(voluntarios, "cozinha");

            if (pergunta.Contains("enfermagem") || pergunta.Contains("primeiros socorros"))
                return ListarVoluntariosComHabilidade(voluntarios, "primeiros socorros");

            if (pergunta.Contains("limpeza"))
                return ListarVoluntariosComHabilidade(voluntarios, "limpeza");

            return "Desculpe, não consegui entender sua pergunta. Tente ser mais específico.";
        }

        private string ListarVoluntariosComHabilidade(List<VoluntarioEntity> voluntarios, string habilidadeBuscada)
        {
            var nomes = voluntarios
                .Where(v => v.habilidades.Any(h => h.nome?.ToLower().Contains(habilidadeBuscada.ToLower()) == true))
                .Select(v => v.abrigado?.nome ?? $"Voluntário {v.id}")
                .ToList();

            if (!nomes.Any())
                return $"Nenhum voluntário com habilidades em {habilidadeBuscada} foi encontrado.";

            return $"{string.Join(", ", nomes)} possuem habilidades relevantes para {habilidadeBuscada}.";
        }
    }
}
