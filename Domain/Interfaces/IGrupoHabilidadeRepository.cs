using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Domain.Interfaces
{
    public interface IGrupoHabilidadeRepository
    {
        IEnumerable<GrupoHabilidadeEntity>? ObterTodos();
        GrupoHabilidadeEntity? ObterporId(int id);
        GrupoHabilidadeEntity? SalvarDados(GrupoHabilidadeEntity entity);
        GrupoHabilidadeEntity? EditarDados(GrupoHabilidadeEntity entity);
        GrupoHabilidadeEntity? DeletarDados(int id);
    }
}
