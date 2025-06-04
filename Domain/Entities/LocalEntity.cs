using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apo_ia.net.Domain.Entities
{
    [Table("tb_local")]
    public class LocalEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? id { get; set; }
        public string? nome { get; set; }
        public string? endereco { get; set; }
        public int? capacidade { get; set; }
        public int? qtdAbrigados { get; set; }
    }
}
