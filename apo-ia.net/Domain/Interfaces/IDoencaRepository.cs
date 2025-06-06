using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Domain.Interfaces
{
    public interface IDoencaRepository
    {
        IEnumerable<DoencaEntity>? ObterTodos();
        DoencaEntity? ObterporId(int id);
        DoencaEntity? SalvarDados(DoencaEntity entity);
        DoencaEntity? EditarDados(DoencaEntity entity);
        DoencaEntity? DeletarDados(int id);
    }
}
