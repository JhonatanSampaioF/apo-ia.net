using apo_ia.net.Application.Dtos;
using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Application.Interfaces
{
    public interface IVoluntarioApplicationService
    {
        IEnumerable<VoluntarioEntity>? ObterTodosVoluntarios();
        VoluntarioEntity? ObterVoluntarioporId(int id);
        VoluntarioEntity? SalvarDadosVoluntario(VoluntarioDto entity);
        VoluntarioEntity? EditarDadosVoluntario(int id, VoluntarioDto entity);
        VoluntarioEntity? DeletarDadosVoluntario(int id);
    }
}
