using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Domain.Interfaces
{
    public interface IAbrigadoRepository
    {
        IEnumerable<AbrigadoEntity>? ObterTodos();
        AbrigadoEntity? ObterporId(int id);
        AbrigadoEntity? SalvarDados(AbrigadoEntity entity);
        AbrigadoEntity? EditarDados(AbrigadoEntity entity);
        AbrigadoEntity? DeletarDados(int id);
    }
}
