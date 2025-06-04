using apo_ia.net.Application.Dtos;
using apo_ia.net.Application.Interfaces;
using apo_ia.net.Domain.Entities;
using apo_ia.net.Domain.Interfaces;
using apo_ia.net.Infraestructure.Data.AppData;
using apo_ia.net.Infraestructure.Data.Repositories;
using System.Linq;

namespace apo_ia.net.Application.Services
{
    public class AbrigadoApplicationService : IAbrigadoApplicationService
    {
        private readonly IAbrigadoRepository _abrigadoRepository;
        private readonly ApplicationContext _context;

        public AbrigadoApplicationService(IAbrigadoRepository abrigadoRepository, ApplicationContext context)
        {
            _abrigadoRepository = abrigadoRepository;
            _context = context;
        }

        public AbrigadoEntity? DeletarDadosAbrigado(int id)
        {
            return _abrigadoRepository.DeletarDados(id);
        }

        public AbrigadoEntity? EditarDadosAbrigado(int id, AbrigadoDto entity)
        {
            var abrigado = new AbrigadoEntity
            {
                id = id,
                nome = entity.nome,
                idade = entity.idade,
                altura = entity.altura,
                peso = entity.peso,
                cpf = entity.cpf,
                voluntario = entity.voluntario,
                ferimento = entity.ferimento
            };

            return _abrigadoRepository.EditarDados(abrigado);
        }

        public AbrigadoEntity? ObterAbrigadoporId(int id)
        {
            return _abrigadoRepository.ObterporId(id);
        }

        public IEnumerable<AbrigadoEntity>? ObterTodosAbrigados()
        {
            return _abrigadoRepository.ObterTodos();
        }

        public AbrigadoEntity? SalvarDadosAbrigado(AbrigadoDto entity)
        {
            var doencas = new List<DoencaEntity>();

            if (entity.doencaIds.Any())
            {
                var doencaIds = entity.doencaIds
                    .Where(id => id.HasValue)
                    .Select(id => id.Value)
                    .ToList();

                doencas = _context.Doenca
                    .Where(d => d.id.HasValue && doencaIds.Contains(d.id.Value))
                    .ToList();

            }

            var local = _context.Local.FirstOrDefault(l => l.id == entity.localId);
            if (local == null)
            {
                throw new Exception("Local informado não foi encontrado.");
            }

            var abrigado = new AbrigadoEntity
            {
                nome = entity.nome,
                idade = entity.idade,
                altura = entity.altura,
                peso = entity.peso,
                cpf = entity.cpf,
                voluntario = entity.voluntario,
                ferimento = entity.ferimento,
                localId = local.id,
                doencas = doencas
            };

            return _abrigadoRepository.SalvarDados(abrigado);
        }

    }
}
