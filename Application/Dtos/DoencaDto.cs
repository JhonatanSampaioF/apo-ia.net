using System.ComponentModel.DataAnnotations;

namespace apo_ia.net.Application.Dtos
{
    public class DoencaDto
    {
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [MinLength(2, ErrorMessage = "Nome deve ter no mínimo 2 caracteres")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo gravidade é obrigatório")]
        [MinLength(2, ErrorMessage = "Gravidade deve ter no mínimo 2 caracteres")]
        [MaxLength(50, ErrorMessage = "Gravidade deve ter no máximo 50 caracteres")]
        public string gravidade { get; set; } = string.Empty;
    }
}
