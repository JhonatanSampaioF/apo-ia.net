using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apo_ia.net.Domain.Entities
{
    [Table("tb_grupo_habilidade")]
    public class GrupoHabilidadeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? nome { get; set; }
    }
}
