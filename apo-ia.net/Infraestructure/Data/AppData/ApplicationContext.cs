using apo_ia.net.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace apo_ia.net.Infraestructure.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<AbrigadoEntity> Abrigado{ get; set; }
        public DbSet<DoencaEntity> Doenca { get; set; }
        public DbSet<GrupoHabilidadeEntity> GrupoHabilidade { get; set; }
        public DbSet<HabilidadeEntity> Habilidade { get; set; }
        public DbSet<LocalEntity> Local { get; set; }
        public DbSet<VoluntarioEntity> Voluntario { get; set; }
    }
}