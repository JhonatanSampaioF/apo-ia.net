using apo_ia.net.Application.Dtos;
using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Application.Interfaces
{
    public interface IDoencaApplicationService
    {
        IEnumerable<DoencaEntity>? ObterTodosDoencas();
        DoencaEntity? ObterDoencaporId(int id);
        DoencaEntity? SalvarDadosDoenca(DoencaDto entity);
        DoencaEntity? EditarDadosDoenca(int id, DoencaDto entity);
        DoencaEntity? DeletarDadosDoenca(int id);
    }
}
