using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;

namespace apo_ia.net.Application.Services
{
    public class GrupoHabilidadeApplicationService : IGrupoHabilidadeApplicationService
    {
        private readonly IGrupoHabilidadeRepository _grupoHabilidadeRepository;

        public GrupoHabilidadeApplicationService(IGrupoHabilidadeRepository grupoHabilidadeRepository)
        {
            _grupoHabilidadeRepository = grupoHabilidadeRepository;
        }

        public GrupoHabilidadeEntity? DeletarDadosGrupoHabilidade(int id)
        {
            return _grupoHabilidadeRepository.DeletarDados(id);
        }

        public GrupoHabilidadeEntity? EditarDadosGrupoHabilidade(int id, GrupoHabilidadeDto entity)
        {
            var grupoHabilidade = new GrupoHabilidadeEntity
            {
                id = id,
                nome = entity.nome
            };

            return _grupoHabilidadeRepository.EditarDados(grupoHabilidade);
        }

        public GrupoHabilidadeEntity? ObterGrupoHabilidadeporId(int id)
        {
            return _grupoHabilidadeRepository.ObterporId(id);
        }

        public IEnumerable<GrupoHabilidadeEntity>? ObterTodosGrupoHabilidades()
        {
            return _grupoHabilidadeRepository.ObterTodos();
        }

        public GrupoHabilidadeEntity? SalvarDadosGrupoHabilidade(GrupoHabilidadeDto entity)
        {
            var grupoHabilidade = new GrupoHabilidadeEntity
            {
                nome = entity.nome
            };

            return _grupoHabilidadeRepository.SalvarDados(grupoHabilidade);
        }
    }
}
