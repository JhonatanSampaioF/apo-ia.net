using apo_ia.net.Application.Dtos;
using apo_ia.net.Domain.Entities;

namespace apo_ia.net.Application.Interfaces
{
    public interface IGrupoHabilidadeApplicationService
    {
        IEnumerable<GrupoHabilidadeEntity>? ObterTodosGrupoHabilidades();
        GrupoHabilidadeEntity? ObterGrupoHabilidadeporId(int id);
        GrupoHabilidadeEntity? SalvarDadosGrupoHabilidade(GrupoHabilidadeDto entity);
        GrupoHabilidadeEntity? EditarDadosGrupoHabilidade(int id, GrupoHabilidadeDto entity);
        GrupoHabilidadeEntity? DeletarDadosGrupoHabilidade(int id);
    }
}
