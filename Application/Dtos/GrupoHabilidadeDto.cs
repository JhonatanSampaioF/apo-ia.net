using System.ComponentModel.DataAnnotations;

namespace apo_ia.net.Application.Dtos
{
    public class GrupoHabilidadeDto
    {
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [MinLength(2, ErrorMessage = "Nome deve ter no mínimo 2 caracteres")]
        [MaxLength(100, ErrorMessage = "Nome deve ter no máximo 100 caracteres")]
        public string nome { get; set; } = string.Empty;
    }
}
