using apo_ia.net.Application.Dtos;
using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Application.Interfaces
{
    public interface IHabilidadeApplicationService
    {
        IEnumerable<HabilidadeEntity>? ObterTodosHabilidades();
        HabilidadeEntity? ObterHabilidadeporId(int id);
        HabilidadeEntity? SalvarDadosHabilidade(HabilidadeDto entity);
        HabilidadeEntity? EditarDadosHabilidade(int id, HabilidadeDto entity);
        HabilidadeEntity? DeletarDadosHabilidade(int id);
    }
}
