using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apo_ia.net.Domain.Entities
{
    [Table("tb_voluntario")]
    public class VoluntarioEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? alocacao { get; set; }
        public string? capacidadeMotora { get; set; }

        [Required]
        [ForeignKey("abrigadoId")]
        public AbrigadoEntity abrigado { get; set; }
        public int? abrigadoId { get; set; }


        public List<HabilidadeEntity> habilidades { get; set; } = new();
    }
}
