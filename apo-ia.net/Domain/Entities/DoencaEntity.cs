using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apo_ia.net.Domain.Entities
{
    [Table("tb_doenca")]
    public class DoencaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? nome { get; set; }
        public string? gravidade { get; set; }

        public List<AbrigadoEntity> abrigados { get; set; } = new();
    }
}
