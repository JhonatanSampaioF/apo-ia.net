using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apo_ia.net.Domain.Entities
{
    [Table("tb_habilidade")]
    public class HabilidadeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? nome { get; set; }
        public int? prioridade { get; set; }

        [ForeignKey("grupoHabilidadeId")]
        public GrupoHabilidadeEntity GrupoHabilidade { get; private set; }
        public int? grupoHabilidadeId { get; set; }

        public List<VoluntarioEntity> voluntarios { get; set; } = new();
    }
}
