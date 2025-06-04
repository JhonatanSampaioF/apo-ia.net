using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Domain.Interfaces
{
    public interface IVoluntarioRepository
    {
        IEnumerable<VoluntarioEntity>? ObterTodos();
        VoluntarioEntity? ObterporId(int id);
        VoluntarioEntity? SalvarDados(VoluntarioEntity entity);
        VoluntarioEntity? EditarDados(VoluntarioEntity entity);
        VoluntarioEntity? DeletarDados(int id);
    }
}
