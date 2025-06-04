using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;
using apo_ia.net.Infraestructure.Data.AppData;

namespace apo_ia.net.Application.Services
{
    public class HabilidadeApplicationService : IHabilidadeApplicationService
    {
        private readonly IHabilidadeRepository _habilidadeRepository;
        private readonly ApplicationContext _context;

        public HabilidadeApplicationService(IHabilidadeRepository habilidadeRepository, ApplicationContext context)
        {
            _habilidadeRepository = habilidadeRepository;
            _context = context;
        }

        public HabilidadeEntity? DeletarDadosHabilidade(int id)
        {
            return _habilidadeRepository.DeletarDados(id);
        }

        public HabilidadeEntity? EditarDadosHabilidade(int id, HabilidadeDto entity)
        {
            var habilidade = new HabilidadeEntity
            {
                id = id,
                nome = entity.nome,
                prioridade = entity.prioridade
            };

            return _habilidadeRepository.EditarDados(habilidade);
        }

        public HabilidadeEntity? ObterHabilidadeporId(int id)
        {
            return _habilidadeRepository.ObterporId(id);
        }

        public IEnumerable<HabilidadeEntity>? ObterTodosHabilidades()
        {
            return _habilidadeRepository.ObterTodos();
        }

        public HabilidadeEntity? SalvarDadosHabilidade(HabilidadeDto entity)
        {
            var grupoHabilidade = _context.GrupoHabilidade.Find(entity.grupoHabilidadeId);

            if (grupoHabilidade == null)
                throw new Exception("Grupo de habilidade não encontrado.");

            var habilidade = new HabilidadeEntity
            {
                nome = entity.nome,
                prioridade = entity.prioridade,
                grupoHabilidadeId = grupoHabilidade.id
            };

            return _habilidadeRepository.SalvarDados(habilidade);
        }

    }
}
