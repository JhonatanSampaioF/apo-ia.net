using System.ComponentModel.DataAnnotations;

namespace apo_ia.net.Application.Dtos
{
    public class LocalDto
    {
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [MinLength(2, ErrorMessage = "Nome deve ter no mínimo 2 caracteres")]
        [MaxLength(150, ErrorMessage = "Nome deve ter no máximo 150 caracteres")]
        public string nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo endereço é obrigatório")]
        [MinLength(5, ErrorMessage = "Endereço deve ter no mínimo 5 caracteres")]
        [MaxLength(255, ErrorMessage = "Endereço deve ter no máximo 255 caracteres")]
        public string endereco { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo capacidade é obrigatório")]
        public int capacidade { get; set; }

        [Required(ErrorMessage = "Campo qtd_abrigados é obrigatório")]
        public int qtdAbrigados { get; set; }
    }
}
