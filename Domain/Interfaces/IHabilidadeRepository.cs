using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Domain.Interfaces
{
    public interface IHabilidadeRepository
    {
        IEnumerable<HabilidadeEntity>? ObterTodos();
        HabilidadeEntity? ObterporId(int id);
        HabilidadeEntity? SalvarDados(HabilidadeEntity entity);
        HabilidadeEntity? EditarDados(HabilidadeEntity entity);
        HabilidadeEntity? DeletarDados(int id);
    }
}
