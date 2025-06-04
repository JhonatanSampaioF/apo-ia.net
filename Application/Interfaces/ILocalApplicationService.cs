using apo_ia.net.Application.Dtos;
using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Application.Interfaces
{
    public interface ILocalApplicationService
    {
        IEnumerable<LocalEntity>? ObterTodosLocals();
        LocalEntity? ObterLocalporId(int id);
        LocalEntity? SalvarDadosLocal(LocalDto entity);
        LocalEntity? EditarDadosLocal(int id, LocalDto entity);
        LocalEntity? DeletarDadosLocal(int id);
    }
}
