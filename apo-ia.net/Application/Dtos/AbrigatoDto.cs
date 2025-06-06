using System.ComponentModel.DataAnnotations;

namespace apo_ia.net.Application.Dtos
{
    public class AbrigadoDto
    {
        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [MinLength(3, ErrorMessage = "Nome deve ter no mínimo 3 caracteres")]
        [MaxLength(150, ErrorMessage = "Nome deve ter no máximo 150 caracteres")]
        public string nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo idade é obrigatório")]
        public int idade { get; set; }

        [Required(ErrorMessage = "Campo altura é obrigatório")]
        public double altura { get; set; }

        [Required(ErrorMessage = "Campo peso é obrigatório")]
        public double peso { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter exatamente 11 dígitos numéricos")]
        public string cpf { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo voluntário é obrigatório")]
        public bool voluntario { get; set; }

        [Required(ErrorMessage = "Campo ferimento é obrigatório")]
        public string ferimento { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo localId é obrigatório")]
        public int? localId { get; set; }

        public List<int?> doencaIds { get; set; } = new();
    }
}
