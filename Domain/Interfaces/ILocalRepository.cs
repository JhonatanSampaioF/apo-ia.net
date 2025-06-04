using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Domain.Interfaces
{
    public interface ILocalRepository
    {
        IEnumerable<LocalEntity>? ObterTodos();
        LocalEntity? ObterporId(int id);
        LocalEntity? SalvarDados(LocalEntity entity);
        LocalEntity? EditarDados(LocalEntity entity);
        LocalEntity? DeletarDados(int id);
    }
}
