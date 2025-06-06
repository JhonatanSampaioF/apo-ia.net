using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apo_ia.net.Domain.Entities
{
    [Table("tb_abrigado")]
    public class AbrigadoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? nome { get; set; }
        public int? idade { get; set; }
        public double? altura{ get; set; }
        public double? peso{ get; set; }
        public string? cpf { get; set; }
        [Column(TypeName = "NUMBER(1)")]
        public bool? voluntario { get; set; }
        public string? ferimento { get; set; }

        [ForeignKey("localId")]
        public LocalEntity local { get; set; }
        public int? localId { get; set; }

        public List<DoencaEntity> doencas { get; set; } = new();
    }
}
