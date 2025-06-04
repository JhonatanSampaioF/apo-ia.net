using System.ComponentModel.DataAnnotations;

namespace apo_ia.net.Application.Dtos
{
    public class VoluntarioDto
    {
        [Required(ErrorMessage = "Campo capacidadeMotora é obrigatório")]
        [MinLength(2, ErrorMessage = "Capacidade motora deve ter no mínimo 2 caracteres")]
        [MaxLength(100, ErrorMessage = "Capacidade motora deve ter no máximo 100 caracteres")]
        public string capacidadeMotora { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo abrigadoId é obrigatório")]
        public int? abrigadoId { get; set; }

        public List<int?> habilidadeIds { get; set; } = new();
    }
}
