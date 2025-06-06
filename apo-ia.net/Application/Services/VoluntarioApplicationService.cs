using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;
using apo_ia.net.Infraestructure.Data.AppData;

namespace apo_ia.net.Application.Services
{
    public class VoluntarioApplicationService : IVoluntarioApplicationService
    {
        private readonly IVoluntarioRepository _voluntarioRepository;
        private readonly ApplicationContext _context;

        public VoluntarioApplicationService(IVoluntarioRepository voluntarioRepository, ApplicationContext context)
        {
            _voluntarioRepository = voluntarioRepository;
            _context = context;
        }

        public VoluntarioEntity? DeletarDadosVoluntario(int id)
        {
            return _voluntarioRepository.DeletarDados(id);
        }

        public VoluntarioEntity? EditarDadosVoluntario(int id, VoluntarioDto entity)
        {
            var voluntario = new VoluntarioEntity
            {
                id = id,
                capacidadeMotora = entity.capacidadeMotora
            };

            return _voluntarioRepository.EditarDados(voluntario);
        }

        public VoluntarioEntity? ObterVoluntarioporId(int id)
        {
            return _voluntarioRepository.ObterporId(id);
        }

        public IEnumerable<VoluntarioEntity>? ObterTodosVoluntarios()
        {
            return _voluntarioRepository.ObterTodos();
        }

        public VoluntarioEntity? SalvarDadosVoluntario(VoluntarioDto entity)
        {
            var abrigado = _context.Abrigado.Find(entity.abrigadoId);
            if (abrigado == null)
                throw new Exception("Abrigado não encontrado.");

            var habilidades = new List<HabilidadeEntity>();
            if (entity.habilidadeIds.Any())
            {
                var ids = entity.habilidadeIds
                                .Where(id => id.HasValue)
                                .Select(id => id.Value)
                                .ToList();

                habilidades = _context.Habilidade
                    .Where(h => h.id.HasValue && ids.Contains(h.id.Value))
                    .ToList();
            }

            var voluntario = new VoluntarioEntity
            {
                capacidadeMotora = entity.capacidadeMotora,
                abrigado = abrigado,
                habilidades = habilidades
            };

            return _voluntarioRepository.SalvarDados(voluntario);
        }

    }
}
